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
    public partial class Users : Sample2
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=OM\SQLEXPRESS;Initial Catalog=InvManagement;Integrated Security=True");

        private void Users_Load(object sender, EventArgs e)
        {
            MainClass.disable_reset(leftpanel);
        }
        public override void addBtn_Click(object sender, EventArgs e)
        {
            MainClass.enable_reset(leftpanel);
        }

        public override void saveBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO Login (Name,Username,Password,Phone,Email) VALUES('" + nametxt.Text + "','" + usernametxt.Text + "','" + passtxt.Text + "','" + phonetxt.Text + "','" + emailtxt.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTED SUCCESSFULLY !!!!");
            MainClass.disable_reset(leftpanel);
        }

        public override void deleteBtn_Click(object sender, EventArgs e)
        {
            
            con.Open();
            String query = "DELETE FROM Login WHERE Name = '" + nametxt.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("RECORD DELETED !!!!");
            MainClass.disable_reset(leftpanel);
        }

        public override void viewBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT Name,Username,Phone,Email FROM Login";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            MainClass.disable_reset(leftpanel);

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            nametxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            usernametxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            phonetxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            emailtxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            MainClass.enable(leftpanel);
        }

        private void Users_Load_1(object sender, EventArgs e)
        {
            MainClass.disable_reset(leftpanel);
        }
    }
}
