using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Windows.Forms.Layout;

namespace GestionDeSalleDeSport
{
    public partial class ModifierSupprimer : Form
    {
        ADO d = new ADO();
        public ModifierSupprimer()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        public void chargeGrid()
        {
            d.Connecter();
            d.ds.Clear();
            d.dap = new SqlDataAdapter("select idM as Id,nomM as Nom,prenomM as Prénom,cin as CIN,age as Age, tele as Téléphone,email as Email,dateInscrire DateInscrire,sexe as Sexe,seance as Seance from Membre", d.cnx);
            d.dap.Fill(d.ds, "Membre");
            dataGridView1.DataSource = d.ds.Tables["Membre"];
            d.Deconnecter();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtage.Text = "";
            txtseace.Text = "";
            txttele.Text = "";
            txtemail.Text = "";
        }

        private void ModifierSupprimer_Load(object sender, EventArgs e)
        {
            chargeGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public void Rechercher()
        {
            try
            {
                d.Connecter();
                d.ds.Clear();
                d.dap = new SqlDataAdapter("select idM as Id,nomM as Nom,prenomM as Prénom,cin as CIN,age as Age, tele as Téléphone,email as Email,dateInscrire DateInscrire,sexe as Sexe,seance as Seance from Membre where idM='" +int.Parse(txtid.Text)+ "'", d.cnx);
                d.dap.Fill(d.ds, "Membre");
                dataGridView1.DataSource = d.ds.Tables["Membre"];
                d.Deconnecter();
            }
            catch
            {
                MessageBox.Show("Pas trouve");
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Entre id");
            }
            else
            {
                Rechercher();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            chargeGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                d.Connecter();
                int id = Convert.ToInt32(txtid.Text);
                d.cmd.CommandText = "update Membre set age = '" + txtage.Text + "',tele='" + txttele.Text + "',seance='" + txtseace.Text + "',email='" + txtemail.Text + "' where idM='" + id + "'";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                chargeGrid();
                d.Deconnecter();
                txtid.Text = "";
                txtage.Text = "";
                txtseace.Text = "";
                txttele.Text = "";
                txtemail.Text = "";
                MessageBox.Show("Bien Modifier");
            }
            catch
            {
                MessageBox.Show("Pas Modifier !!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                d.Connecter();
                int id = Convert.ToInt32(txtid.Text);
                d.cmd.CommandText = "delete Membre where idM='" + txtid.Text + "'";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                chargeGrid();
                d.Deconnecter();
                txtid.Text = "";
                txtage.Text = "";
                txtseace.Text = "";
                txttele.Text = "";
                txtemail.Text = "";
                MessageBox.Show("Bien Supprimer");
            }
            catch
            {
                MessageBox.Show("Pas Supprimer !!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtage.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txttele.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtseace.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
    }

}