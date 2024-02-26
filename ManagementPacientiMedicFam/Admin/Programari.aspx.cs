using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using static ManagementPacientiMedicFam.Models.CommonFn;

namespace ManagementPacientiMedicFam.Admin
{
    public partial class Programari : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNumePacient();
                GetProg();
            }
        }

        private void GetNumePacient()
        {
            DataTable dt = fn.Fetch("SELECT PacientID, Nume, Prenume FROM Pacienti");

            foreach (DataRow row in dt.Rows)
            {
                string numePrenume = $"{row["Nume"]} {row["Prenume"]}";
                ListItem listItem = new ListItem(numePrenume, row["PacientID"].ToString());
                ddlNumePacient.Items.Add(listItem);
            }

            ddlNumePacient.Items.Insert(0, "Selecteaza Pacientul");
        }

        private void GetProg()
        {
            DataTable dt = fn.Fetch(@"SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Nr Programari], r.ProgramareID, p.Nume, p.Prenume, r.DataProg
                                       FROM Pacienti p INNER JOIN Programari r ON p.PacientID = r.PacientID");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //urmatoarea functie se implementeaza adaugarea unei programari
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string pacientID = ddlNumePacient.SelectedValue;
                DateTime dataProg;

                if (DateTime.TryParseExact(txtDataProg.Text.Trim(), "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataProg))
                {
                    DataTable dt = fn.Fetch($"SELECT * FROM Programari WHERE PacientID = '{pacientID}' AND DataProg = '{dataProg}'");
                    if (dt.Rows.Count == 0)
                    {
                        string query = "INSERT INTO Programari (PacientID, DataProg) VALUES (@PacientID, @DataProg)";
                        Dictionary<string, object> parameters = new Dictionary<string, object>();
                        parameters.Add("@PacientID", pacientID);
                        parameters.Add("@DataProg", dataProg);

                        fn.Query(query, parameters);
                        lblMsg.Text = "Programarea a fost adăugată cu succes!";
                        lblMsg.CssClass = "alert alert-success";
                        ddlNumePacient.SelectedIndex = 0;
                        txtDataProg.Text = string.Empty;

                        GetProg();
                    }
                    else
                    {
                        lblMsg.Text = "Pacientul are deja o programare pe data respectivă!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblMsg.Text = "Introduceți o dată validă!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //functia urmatoare prezinta modificarea programarii acesteia
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int programareID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["ProgramareID"]);
                string pacientID = (row.FindControl("ddlNumePacientEdit") as DropDownList).SelectedValue;
                DateTime dataProg;

                if (DateTime.TryParseExact((row.FindControl("txtDataProgEdit") as TextBox).Text.Trim(), "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataProg))
                {
                    fn.Query("UPDATE Programari SET PacientID = @PacientID, DataProg = @DataProg WHERE ProgramareID = @ProgramareID",
                        new Dictionary<string, object>
                        {
                            { "@PacientID", pacientID },
                            { "@DataProg", dataProg },
                            { "@ProgramareID", programareID }
                        });

                    lblMsg.Text = "Programarea a fost actualizată cu succes!";
                    lblMsg.CssClass = "alert alert-success";
                    GridView1.EditIndex = -1;
                    GetProg();
                }
                else
                {
                    lblMsg.Text = "Introduceți o dată validă!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetProg();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetProg();
        }

        //mai jos se implementeaza stergerea unei programari nedorite
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int programareID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["ProgramareID"]);

                fn.Query($"DELETE FROM Programari WHERE ProgramareID = '{programareID}' ");

                lblMsg.Text = "Programarea a fost ștearsă cu succes!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetProg();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetProg();
        }

        protected void ddlNumePacient_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
