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
    public partial class Login : Form
    {
        ADO d = new ADO();
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                MessageBox.Show("Entre votre nom");
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Entre votre mot de passe");
            }
            else if (txtNom.Text == "" && txtPass.Text == "")
            {
                 MessageBox.Show("Entre votre nom et mot de passe");
            }
            else
            {
                d.Connecter();
                bool tr = false;
                d.cmd.CommandText = "select nomAdmin,pass from Administrateur";
                d.cmd.Connection = d.cnx;
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    if(txtNom.Text.Equals(d.dr[0].ToString()) && txtPass.Text.Equals(d.dr[1].ToString()))
                    {
                        tr = true;
                        break;
                    }
                    
                }
                if (tr == true)
                {
                    Menu m = new Menu();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nom ou mot de passe incorrect !!");
                    txtNom.Text = "";
                    txtPass.Text = "";
                }
                d.dr.Close();
                d.Deconnecter();
            }

        }
    }
}
