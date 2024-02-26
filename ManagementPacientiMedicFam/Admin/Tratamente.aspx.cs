using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ManagementPacientiMedicFam.Models.CommonFn;

namespace ManagementPacientiMedicFam.Admin
{
    public partial class Tratamente : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAfiseazaTratamente_Click(object sender, EventArgs e)
        {
            try
            {
                //query-ul urmator va afisa numarul de tratamente pentru fiecare pacient
                string query = @"
                    SELECT (P.Nume+' '+P.Prenume) AS NumePacient, COUNT(T.TratamentID) AS NumarTratamente
                    FROM Pacienti P
                    JOIN Programari PR ON P.PacientID = PR.PacientID
                    JOIN Retete R ON PR.ProgramareID = R.ProgramareID
                    JOIN Tratamente T ON R.TratamentID = T.TratamentID
                    GROUP BY P.Nume, P.Prenume
                    ORDER BY NumarTratamente DESC;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Nume</th><th>Numar Tratamente</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["NumePacient"] + "</td>";
                    tableHtml += "<td>" + row["NumarTratamente"] + "</td>";
                    tableHtml += "</tr>";
                }

                tableHtml += "</table>";

                lblTratamente.Text = tableHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
