using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using static ManagementPacientiMedicFam.Models.CommonFn;

namespace ManagementPacientiMedicFam.Admin
{
    public partial class Trimiteri : Page
    {
        private Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSpecialitatiCuValabilitateMaxima_Click(object sender, EventArgs e)
        {
            try
            {
                //va afisa toate cabinetele cu fiecare cat dureaza cel mai mult trimiterea
                string query = @"
                    SELECT S.Nume AS Specialitate, MAX(CAST(Valabilitate AS INTEGER)) AS ValabilitateMaxima
                    FROM Specialitati S
                    JOIN Trimiteri TR ON S.SpecialitateID = TR.SpecialitateID
                    WHERE TR.Valabilitate = (
                        SELECT MAX(CAST(Valabilitate AS INTEGER))
                        FROM Trimiteri T
                        WHERE T.SpecialitateID = S.SpecialitateID
                    )
                    GROUP BY S.Nume;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Specialitate</th><th>Valabilitate Maximă</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["Specialitate"] + "</td>";
                    tableHtml += "<td>" + row["ValabilitateMaxima"] + "</td>";
                    tableHtml += "</tr>";
                }

                tableHtml += "</table>";

                divRezultate.InnerHtml = tableHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnCautarePacientiSpecialitate_Click(object sender, EventArgs e)
        {
            try
            {
                string specialitateCautata = txtCautareSpecialitate.Text.Trim();

                //cauta pacientii care si-au luat trimiteri la o anumita specialitate
                string query = $@"
                    SELECT (P.Nume+' '+P.Prenume) AS NumePacient
                    FROM Pacienti P
                    WHERE P.PacientID IN (
                        SELECT PR.PacientID
                        FROM Programari PR
                        JOIN Trimiteri T ON PR.ProgramareID = T.ProgramareID
                        JOIN Specialitati S ON T.SpecialitateID = S.SpecialitateID
                        WHERE S.Nume = '{specialitateCautata}'
                    );
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Nume</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["NumePacient"] + "</td>";
                    tableHtml += "</tr>";
                }

                tableHtml += "</table>";

                divRezultate.InnerHtml = tableHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
