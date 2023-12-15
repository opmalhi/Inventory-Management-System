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
namespace Inventory_Management_System
{
    public partial class Login : Sample
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=om-pc\sqlexpress;Initial Catalog=InvManagement;Integrated Security=True");

        private void loginBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Login where Username= '"+userTxt.Text+"'and Password='"+passTxt.Text+"'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                HomeScreen obj = new HomeScreen();
                MainClass.ShowWindow(obj, this, MDI.ActiveForm);
            }
            else
            {
                MessageBox.Show("Please Check Your Username and Password");
            }

        }
    }
}
