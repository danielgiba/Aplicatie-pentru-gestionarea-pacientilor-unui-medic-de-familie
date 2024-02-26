using System;
using System.Data;
using static ManagementPacientiMedicFam.Models.CommonFn;

namespace ManagementPacientiMedicFam.Admin
{
    public partial class Medicamente : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnMedicamente1_Click(object sender, EventArgs e)
        {
            try
            {
                //medicamentele ce au fost prescrise pacientilor cu tratamente ce dureaza mai mult de 3 luni
                string query = @"
                    SELECT M.Nume
                    FROM Medicamente M
                    JOIN Tratamente T ON M.MedicamentID = T.MedicamentID
                    JOIN Retete R ON T.TratamentID = R.TratamentID
                    WHERE R.Valabilitate > 3;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Nume Medicament</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["Nume"] + "</td>";
                    tableHtml += "</tr>";
                }

                tableHtml += "</table>";

                lblMedicamente.Text = tableHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnSearchMedicament_Click(object sender, EventArgs e)
        {
            try
            {
                //pacientii ce iau un anumit medicament
                string medicamentName = txtSearchMedicament.Text.Trim();
                string query = $@"
                    SELECT (P.Nume+' '+P.Prenume) AS NumePacient
                    FROM Pacienti P
                    JOIN Programari PR ON P.PacientID = PR.PacientID
                    JOIN Retete R ON PR.ProgramareID = R.ProgramareID
                    JOIN Tratamente T ON R.TratamentID = T.TratamentID
                    JOIN Medicamente M ON T.MedicamentID = M.MedicamentID
                    WHERE M.Nume = '{medicamentName}';
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

                lblMedicamente.Text = tableHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
