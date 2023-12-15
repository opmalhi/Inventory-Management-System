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
    public partial class Categories : Sample2
    {
        public Categories()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=OM\SQLEXPRESS;Initial Catalog=InvManagement;Integrated Security=True");

        private void Categories_Load(object sender, EventArgs e)
        {
            MainClass.disable(leftpanel);
        }
        public override void addBtn_Click(object sender, EventArgs e)
        {
            MainClass.enable_reset(leftpanel);
        }

        public override void saveBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO tbl_Category(Category,Status) VALUES('" +categorytxt.Text + "','" + statusbox.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTED SUCCESSFULLY !!!!");
            MainClass.disable_reset(leftpanel);
            
        }

        public override void deleteBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "DELETE FROM tbl_Category WHERE Category = '" + categorytxt.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("RECORD DELETED !!!!");
            MainClass.disable_reset(leftpanel);
        }

        public override void viewBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM tbl_Category";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            categorytxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            statusbox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            MainClass.enable(leftpanel);
        }
    }
}
