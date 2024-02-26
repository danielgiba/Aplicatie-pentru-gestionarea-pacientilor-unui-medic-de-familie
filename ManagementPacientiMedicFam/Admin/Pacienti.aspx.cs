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
    public partial class Pacienti : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPacient();
            }
        }

        //cu aceasta functie se preia informatii din baza de date creata
        private void GetPacient()
        {
            DataTable dt = fn.Fetch("SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Nr Pacienti],PacientID,Nume,Prenume,CNP FROM Pacienti");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //functia de mai jos este implementata adaugarea unui pacient in baza de date
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("SELECT * FROM Pacienti WHERE Nume = '" + txtNumePacient.Text.Trim() + "' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "INSERT INTO Pacienti VALUES('" + txtNumePacient.Text.Trim() + "','" + txtPrenumePacient.Text.Trim() + "','" + txtCNPPacient.Text.Trim() + "','" + txtStradaPacient.Text.Trim() + "','" + txtNrAdresaPacient.Text.Trim() + "','" + ddlSexPacient.SelectedValue + "','" + txtDataNasterePacient.Text.Trim() + "','" + txtNrTelPacient.Text.Trim() + "','" + txtEmailPacient.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Pacient introdus cu succes!";
                    lblMsg.CssClass = "alert alert-success";
                    txtNumePacient.Text = string.Empty;
                    txtPrenumePacient.Text = string.Empty;
                    txtCNPPacient.Text = string.Empty;
                    txtStradaPacient.Text = string.Empty;
                    txtNrAdresaPacient.Text = string.Empty;
                    ddlSexPacient.SelectedIndex = 0;
                    txtDataNasterePacient.Text = string.Empty;
                    txtNrTelPacient.Text = string.Empty;
                    txtEmailPacient.Text = string.Empty;
                    GetPacient();
                }
                else
                {
                    lblMsg.Text = "Pacientul deja este adaugat!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetPacient();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetPacient();
        }

        //in urmatoarea functie se poate adauga functia de EDIT ce poate face UPDATE sau DELETE la un pacient dorit la informatiile relevante
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.Columns[1].ControlStyle.Width = Unit.Pixel(200); 
            GridView1.Columns[2].ControlStyle.Width = Unit.Pixel(200);
            GridView1.Columns[3].ControlStyle.Width = Unit.Pixel(200);

            
            GetPacient();
        }

        //mai jos este prezentata updatarea bazei de date cu pacienti
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int pID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string Nume = (row.FindControl("txtNumeEdit") as TextBox).Text;
                string Prenume = (row.FindControl("txtPrenumeEdit") as TextBox).Text;
                string CNP = (row.FindControl("txtCNPEdit") as TextBox).Text;
                fn.Query("UPDATE Pacienti SET Nume = '" + Nume + "',Prenume = '" + Prenume + "',CNP = '" + CNP + "' WHERE PacientID = '" + pID + "' ");
                lblMsg.Text = "Pacientul este updatat!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetPacient();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //functia urmatoare se implementeaza eliminarea unui pacient din baza de date
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
               
                int pID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("DELETE FROM Pacienti WHERE PacientID = '" + pID + "' ");
                lblMsg.Text = "Pacientul este sters!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetPacient();
            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



    }
}