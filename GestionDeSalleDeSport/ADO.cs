using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GestionDeSalleDeSport
{
    class ADO
    {
        public SqlConnection cnx = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter dap;
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        public void Connecter()
        {
            if(cnx.State==ConnectionState.Closed || cnx.State == ConnectionState.Broken)
            {
                cnx.ConnectionString = "Data Source=DESKTOP-45GHVO0\\SQLEXPRESS;Initial Catalog=GestionSalleSport;Integrated Security=True";
                cnx.Open();
            }
        }
        public void Deconnecter()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}
