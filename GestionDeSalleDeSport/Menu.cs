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

namespace GestionDeSalleDeSport
{
    public partial class Menu : Form
    {
        ADO d = new ADO();
        public Menu()
        {
            InitializeComponent();
        }

        public void RemplirGrid()
        {
            d.Connecter();
            d.dap = new SqlDataAdapter("select distinct nomM as Nom,prenomM as Prénom, [Type] as Paymment from Paiement p,Membre m where [Type]='Non' or [Type]='non' ", d.cnx);
            d.dap.Fill(d.ds, "tbles");
            dataGridView1.DataSource = d.ds.Tables["tbles"];
            d.Deconnecter();
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ListeM l = new ListeM();
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ajouter a = new Ajouter();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModifierSupprimer ms = new ModifierSupprimer();
            ms.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifierSupprimer ms = new ModifierSupprimer();
            ms.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Paiement p = new Paiement();
            p.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public void getDate()
        {
            d.Connecter();
            d.cmd.CommandText = "update Paiement set [Type]='Non' where day([Date Paiement]) *30< ( datediff(day,[Date Paiement],getdate()));";
            d.cmd.Connection = d.cnx;
            d.cmd.ExecuteNonQuery();
        }

        public void UpdateTypePaiement()
        {
            d.Connecter();
            d.cmd.CommandText = "update Paiement set [Type]='Oui' where day([Date Paiement]) *30> ( datediff(day,[Date Paiement],getdate()));";
            d.cmd.Connection = d.cnx;
            d.cmd.ExecuteNonQuery();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            UpdateTypePaiement();
            getDate();
            RemplirGrid();
        }
    }
}
