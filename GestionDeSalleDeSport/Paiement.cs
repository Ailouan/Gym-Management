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
    public partial class Paiement : Form
    {
        ADO d = new ADO();
        public Paiement()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        public void rempircombo()
        {
            d.Connecter();
            d.dap= new SqlDataAdapter( "select * from Paiement",d.cnx);
            d.dap.Fill(d.ds, "membr");
            txtidM.DataSource = d.ds.Tables["membr"];
            txtidM.DisplayMember = "[Id Membre]";
            txtidM.ValueMember = "Id Membre";
            d.Deconnecter();
        }

        public void rempirdgd()
        {
            d.ds.Clear();
            d.Connecter();
            d.dap = new SqlDataAdapter("select * from Paiement", d.cnx);
            d.dap.Fill(d.ds, "payment");
            dataGridView1.DataSource = d.ds.Tables["payment"];
            d.Deconnecter();
        }

        public void Rechercher()
        {
            try
            {
                d.ds.Clear();
                d.Connecter();
                d.dap = new SqlDataAdapter("select * from Paiement where [Id Membre] ='" + int.Parse(txtid.Text) + "'", d.cnx);
                d.dap.Fill(d.ds, "Payement");
                dataGridView1.DataSource = d.ds.Tables["Payement"];
                d.Deconnecter();
            }
            catch
            {
                MessageBox.Show("Pas trouve");
            }
        }
        public void ajoute()
        {
            try
            {
                d.Connecter();
                d.cmd.CommandText = "insert into Paiement values(@date,@type,@prix,@idm)";
                d.cmd.Parameters.AddWithValue("@date", txtdate.Value);
                d.cmd.Parameters.AddWithValue("@type", txttype.Text);
                d.cmd.Parameters.AddWithValue("@prix", double.Parse(txtprix.Text));
                d.cmd.Parameters.AddWithValue("@idm", txtidM.Text);
                d.cmd.Connection = d.cnx;
                d.cmd.ExecuteNonQuery();
                d.Deconnecter();
                rempirdgd();
                MessageBox.Show("Paiement bien ajoute");
            }
            catch
            {
                MessageBox.Show("Paiement pas ajoute");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ajoute();
            rempirdgd();
            txtid.Text = "";
            txtdate.Text = "";
            txttype.Text = "";
            txtprix.Text = "";
            txtidM.Text = "";
        }

        private void Paiement_Load(object sender, EventArgs e)
        {
            rempircombo();
            rempirdgd();
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
            rempirdgd();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txttype.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtprix.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtidM.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
