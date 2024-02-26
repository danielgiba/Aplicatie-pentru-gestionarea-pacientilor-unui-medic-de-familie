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
    public partial class Specialitati : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSpec();
            }
        }

        private void GetSpec()
        {
            DataTable dt = fn.Fetch("SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [Nr Specialitati],SpecialitateID,Nume,Strada,Numar,NumarTelefon FROM Specialitati");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //cu functia urmatoare se poate adauga o specilatitate/cabinet specializat in baza de date
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("SELECT * FROM Specialitati WHERE Nume = '" + txtNumeSpec.Text.Trim() + "' ");
                if (dt.Rows.Count == 0)
                {
                    string query = "INSERT INTO Specialitati VALUES('" + txtNumeSpec.Text.Trim() + "','" + txtStradaSpec.Text.Trim() + "','" + txtNumarSpec.Text.Trim() + "','" + txtNrTelSpec.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Specialitatea introdusa cu succes!";
                    lblMsg.CssClass = "alert alert-success";
                    txtNumeSpec.Text = string.Empty;
                    txtStradaSpec.Text = string.Empty;
                    txtNumarSpec.Text = string.Empty;
                    txtNrTelSpec.Text = string.Empty;
                    
                    GetSpec();
                }
                else
                {
                    lblMsg.Text = "Specialitatea deja exista!";
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
            GetSpec();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetSpec();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
        }

        //mai jos se poate face modificarea sau actualizarea informatiilor legate de o anumita specialitate
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int specID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string Nume = (row.FindControl("txtNumeSpecEdit") as TextBox).Text;
                string Strada = (row.FindControl("txtStradaSpecEdit") as TextBox).Text;
                string Numar = (row.FindControl("txtNumarSpecEdit") as TextBox).Text;
                string NumarTelefon = (row.FindControl("txtNrTelSpecEdit") as TextBox).Text;
                fn.Query("UPDATE Specialitati SET Nume = '" + Nume + "',Strada = '" + Strada + "',Numar = '" + Numar + "',NumarTelefon = '" + NumarTelefon + "' WHERE SpecialitateID = '" + specID + "' ");
                lblMsg.Text = "Specialitatea este updatata!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetSpec();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //mai jos este implementata stergerea unei specializari
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int specID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("DELETE FROM Specialitati WHERE SpecialitateID = '" + specID + "' ");
                lblMsg.Text = "Specialitatea este stearsa!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetSpec();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}