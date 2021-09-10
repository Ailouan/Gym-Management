using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeSalleDeSport
{
    public partial class ListeM : Form
    {
        ADO d = new ADO();
        public ListeM()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        public void chargeGrid()
        {
            d.Connecter();
            d.ds.Clear();
            d.dap = new SqlDataAdapter("select idM as Id,nomM as Nom,prenomM as Prénom,cin as Cin,age as Age, tele as Téléphone,email as Email,dateInscrire DateInscrire,sexe as Sexe,seance as Seance from Membre", d.cnx);
            d.dap.Fill(d.ds, "Membre");
            dataGridView1.DataSource = d.ds.Tables["Membre"];
            d.Deconnecter();
        }

        private void ListeM_Load(object sender, EventArgs e)
        {
            chargeGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            chargeGrid();
        }

        public void Rechercher()
        {
            if (radioButton1.Checked)
            {
                try
                {
                    d.Connecter();
                    d.ds.Clear();
                    int id = int.Parse(txtid.Text);
                    d.dap = new SqlDataAdapter("select idM as Id,nomM as Nom,prenomM as Prénom,cin as Cin,age as Age, tele as Téléphone,email as Email,dateInscrire DateInscrire,sexe as Sexe,seance as Seance from Membre where idM='" + id + "'", d.cnx);
                    d.dap.Fill(d.ds, "Membre");
                    dataGridView1.DataSource = d.ds.Tables["Membre"];
                    d.Deconnecter();
                }
                catch
                {
                    MessageBox.Show("Pas trouve");
                }
            }else if (radioButton2.Checked)
            {
                try
                {
                    d.Connecter();
                    d.ds.Clear();
                    d.dap = new SqlDataAdapter("select idM as Id,nomM as Nom,prenomM as Prénom,cin as Cin,age as Age, tele as Téléphone,email as Email,dateInscrire DateInscrire,sexe as Sexe,seance as Seance from Membre where nomM='" + txtid.Text + "'", d.cnx);
                    d.dap.Fill(d.ds, "Membre");
                    dataGridView1.DataSource = d.ds.Tables["Membre"];
                    d.Deconnecter();
                }
                catch
                {
                    MessageBox.Show("Pas trouve");
                }
            }
            else
            {
                try
                {
                    d.Connecter();
                    d.ds.Clear();
                    d.dap = new SqlDataAdapter("select idM as Id,nomM as Nom,prenomM as Prénom,cin as Cin,age as Age, tele as Téléphone,email as Email,dateInscrire DateInscrire,sexe as Sexe,seance as Seance from Membre where cin='" + txtid.Text + "'", d.cnx);
                    d.dap.Fill(d.ds, "Membre");
                    dataGridView1.DataSource = d.ds.Tables["Membre"];
                    d.Deconnecter();
                }
                catch
                {
                    MessageBox.Show("Pas trouve");
                }
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Entre id d'un membre pour lui recherche");
            }
            else 
            {
                Rechercher();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Remplire le champ pour rechercher !!");
            }
            else
            {
                Rechercher();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtid.Text = "";
            chargeGrid();
        }
    }
}
