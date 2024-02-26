using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using static ManagementPacientiMedicFam.Models.CommonFn;

namespace ManagementPacientiMedicFam.Admin
{
    public partial class DetaliiCabinete : Page
    {
        private Commonfnx fn = new Commonfnx();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSpecialitatiFaraTrimiteri_Click(object sender, EventArgs e)
        {
            try
            {
                //query pentru afisarea cabinetelor unde s-au facut trimiteri
                string query = @"
                    SELECT S.Nume AS Specialitate
                    FROM Specialitati S
                    LEFT JOIN Trimiteri T ON S.SpecialitateID = T.SpecialitateID
                    WHERE S.SpecialitateID IS NULL;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Specialitate</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["Specialitate"] + "</td>";
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

        protected void btnStatisticiPacienti_Click(object sender, EventArgs e)
        {
            try
            {
                //se afiseaza numarul total de pacienti,dar si media varstei a acestora la fiecare specialitate
                string query = @"
                    SELECT S.Nume AS Specialitate, COUNT(PA.PacientID) AS NumarPacienti, AVG(DATEDIFF(YEAR, PA.DataNasterii, GETDATE())) AS MedieVarsta
                    FROM Specialitati S
                    LEFT JOIN Trimiteri TR ON S.SpecialitateID = TR.SpecialitateID
                    LEFT JOIN Programari PR ON TR.ProgramareID = PR.ProgramareID
                    LEFT JOIN Pacienti PA ON PR.PacientID = PA.PacientID
                    GROUP BY S.Nume;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Specialitate</th><th>Numar Pacienti</th><th>Medie Varsta</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["Specialitate"] + "</td>";
                    tableHtml += "<td>" + row["NumarPacienti"] + "</td>";
                    tableHtml += "<td>" + row["MedieVarsta"] + "</td>";
                    tableHtml += "</tr>";
                }

                tableHtml += "</table>";

                // Afișează tabelul în containerul divRezultate
                divRezultate.InnerHtml = tableHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btnProgramariSpecialitate_Click(object sender, EventArgs e)
        {
            try
            {
                //mai jos se afiseaza numarul total de programari de la fiecare cabinet
                string query = @"
                    SELECT S.Nume AS Specialitate, COUNT(P.ProgramareID) AS NumarProgramari
                    FROM Specialitati S
                    JOIN Trimiteri TR ON S.SpecialitateID = TR.SpecialitateID
                    JOIN Programari P ON TR.ProgramareID = P.ProgramareID
                    WHERE (
                        SELECT COUNT(P2.ProgramareID)
                        FROM Programari P2
                        JOIN Trimiteri TR2 ON P2.ProgramareID = TR2.ProgramareID
                        WHERE TR2.SpecialitateID = S.SpecialitateID
                    ) > 0
                    GROUP BY S.Nume;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Specialitate</th><th>Numar Programari</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["Specialitate"] + "</td>";
                    tableHtml += "<td>" + row["NumarProgramari"] + "</td>";
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

        protected void btnCautareSpecialitate_Click(object sender, EventArgs e)
        {
            try
            {
                string specialitateCautata = txtCautareSpecialitate.Text.Trim();

                //in query-ul de mai jos se va afisa numele pacientilor ce si-au luat trimitere la o anumita specialitate
                string query = @"
                    SELECT (P.Nume+' '+P.Prenume) AS NumePacient, MAX(PR.DataProg) AS UltimaProgramare
                    FROM Pacienti P
                    JOIN Programari PR ON P.PacientID = PR.PacientID
                    JOIN Trimiteri TR ON PR.ProgramareID = TR.ProgramareID
                    JOIN Specialitati S ON TR.SpecialitateID = S.SpecialitateID
                    WHERE S.Nume LIKE @SpecialitateCautata
                    GROUP BY P.PacientID, P.Nume, P.Prenume;
                ";

                var parameters = new Dictionary<string, object>
                {
                    { "@SpecialitateCautata", "%" + specialitateCautata + "%" }
                };

                DataTable dt = fn.Fetch(query, parameters);

                string tableHtml = "<table border='1'><tr><th>Nume</th><th>Ultima Programare</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["NumePacient"] + "</td>";
                    tableHtml += "<td>" + row["UltimaProgramare"] + "</td>";
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

        protected void btnAfiseazaDetalii_Click(object sender, EventArgs e)
        {
            try
            {
                //afisarea pacientilor programati la un anumit cabinet
                string query = @"
                     SELECT (P.Nume + ' ' + P.Prenume) AS NumePacient, S.Nume AS Specialitate
                     FROM Pacienti P
                        JOIN Programari PR ON P.PacientID = PR.PacientID
                        JOIN Trimiteri T ON PR.ProgramareID = T.ProgramareID
                        JOIN Specialitati S ON T.SpecialitateID = S.SpecialitateID
                        ORDER BY P.Nume, P.Prenume;
                ";

                DataTable dt = fn.Fetch(query);

                string tableHtml = "<table border='1'><tr><th>Nume Pacient</th><th>Specialitate</th></tr>";

                foreach (DataRow row in dt.Rows)
                {
                    tableHtml += "<tr>";
                    tableHtml += "<td>" + row["NumePacient"] + "</td>";
                    tableHtml += "<td>" + row["Specialitate"] + "</td>";
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
