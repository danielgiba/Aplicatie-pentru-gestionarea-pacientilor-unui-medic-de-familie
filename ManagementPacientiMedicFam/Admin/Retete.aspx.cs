using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ManagementPacientiMedicFam.Models.CommonFn;

namespace ManagementPacientiMedicFam.Admin
{
    public partial class Retete : Page
    {
        private Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCautarePacientiSpecialitate_Click(object sender, EventArgs e)
        {
            try
            {
                string specialitateCautata = txtCautareSpecialitate.Text.Trim();

                //cautarea pacientilor care au luat reteta si sunt programati la cabinetul de unde au medicam puse pe reteta
                string query = $@"
                    SELECT (P.Nume+' '+P.Prenume) AS NumePacient
                    FROM Pacienti P
                    WHERE P.PacientID IN (
                        SELECT PR.PacientID
                        FROM Programari PR
                        JOIN Retete R ON PR.ProgramareID = R.ProgramareID
                        JOIN Tratamente T ON R.TratamentID = T.TratamentID
                        JOIN Trimiteri TR ON PR.ProgramareID = TR.ProgramareID
                        JOIN Specialitati S ON TR.SpecialitateID = S.SpecialitateID
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

        protected void btnCautareReteteCompensate_Click(object sender, EventArgs e)
        {
            try
            {
                string statusPret = ddlCompensareRetete.SelectedValue;

                //aflarea pacientilor cu anumite retete:gratuite,reduse,pret intreg
                string query = $@"
                    SELECT (P.Nume+' '+P.Prenume) AS NumePacient
                    FROM Pacienti P
                    WHERE P.PacientID IN (
                        SELECT PR.PacientID
                        FROM Programari PR
                        JOIN Retete R ON R.ProgramareID = PR.ProgramareID
                        JOIN Tratamente T ON R.TratamentID = T.TratamentID
                        JOIN Medicamente M ON T.MedicamentID = M.MedicamentID
                        WHERE R.StatusPret = '{statusPret}'
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
