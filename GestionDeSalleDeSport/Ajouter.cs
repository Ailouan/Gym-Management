using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeSalleDeSport
{
    public partial class Ajouter : Form
    {
        ADO d = new ADO();
        public Ajouter()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtnom.Text=="" || txtprenom.Text=="" || txtcin.Text=="" || txtage.Text=="" || txtsex.Text=="" ||
                txttele.Text=="" || txtemail.Text=="" || txtdate.Text=="" || txtseance.Text=="")
            {
                MessageBox.Show("Merci de eemplire tout les champes");
            }
            else
            {
                try
                {
                    d.Connecter();
                //d.cmd.CommandText = "insert into Membre values('" + txtnom.Text + "', '" + txtprenom.Text + "','" + txtcin.Text +"', '" + int.Parse(txtage.Text) + "', '" + txtsex.Text + "', '" + txttele.Text + "', '" + txtemail.Text + "', '" + txtdate.Text + "', '" + txtseance.Text + "')";
                d.cmd.CommandText = "insert into Membre values('" + txtnom.Text + "', '" + txtprenom.Text + "','"+txtcin.Text+"', '" + int.Parse(txtage.Text) + "', '" + txtsex.Text + "', '" + txttele.Text + "', '" + txtemail.Text + "',getdate(), '" + txtseance.Text + "')";
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                d.Deconnecter();
                MessageBox.Show("Membre bien ajouter");
                }
                catch
                {
                MessageBox.Show("Membre pas ajouter");
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtnom.Text = "";
            txtprenom.Text = "";
            txtcin.Text = "";
            txtage.Text = "";
            txttele.Text = "";
            txtemail.Text = "";
            txtsex.Text = "";
            txtseance.Text = "";
        }

        private void Ajouter_Load(object sender, EventArgs e)
        {

        }
    }
}
