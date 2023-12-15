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
    public partial class Products : Sample2
    {
        public Products()
        {
            InitializeComponent();
            Fillcombo();
        }

        SqlConnection con = new SqlConnection(@"Data Source=OM\SQLEXPRESS;Initial Catalog=InvManagement;Integrated Security=True");

        private void Products_Load(object sender, EventArgs e)
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
            String query = "INSERT INTO tbl_pd (Name,ID,Price,Category) VALUES('" + pdnametxt.Text + "','" + pdidtxt.Text + "','" + pricetxt.Text + "','" + categorybox.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTED SUCCESSFULLY !!!!");
            MainClass.disable_reset(leftpanel);
        }

        public override void deleteBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "DELETE FROM tbl_pd WHERE Name = '" + pdnametxt.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("RECORD DELETED !!!!");
            MainClass.disable_reset(leftpanel);
        }

        public override void viewBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM tbl_pd";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pdnametxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pdidtxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            pricetxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            categorybox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            MainClass.enable(leftpanel);
        }

        public void categorybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void Fillcombo()
        {
            String query = "Select * from tbl_Category";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myreader;
            con.Open();
            myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                if (myreader.GetString(1) == "Available")
                {
                    string cname = myreader.GetString(0);
                    categorybox.Items.Add(cname);
                }
                
            }
            con.Close();
        }
    }
}
