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
    public partial class Purchase_Invoice : Sample2
    {
        public Purchase_Invoice()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=OM\SQLEXPRESS;Initial Catalog=InvManagement;Integrated Security=True");

        int ProductID;
        float gt, tot;
        string[] prodarr = new string[3];
        private void productidtxt_TextChanged(object sender, EventArgs e)
        {
            if (productidtxt.Text != "")
            {
                prodarr = getProductsWRTID(productidtxt.Text);
                ProductID = Convert.ToInt32(prodarr[1]);
                productnametxt.Text = prodarr[0];
                pricetxt.Text = prodarr[2];
                productnametxt.Enabled = false;
                pricetxt.Enabled = false;

            }
            else
            {
                ProductID = 0;
                productnametxt.Text = "";
                pricetxt.Text = "";
                Array.Clear(prodarr, 0, prodarr.Length);
            }
            
        }

        private string[] productsData = new string[3];
        public string[] getProductsWRTID(string ID)
        {
            SqlCommand cmd = new SqlCommand("st_ProductByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    productsData[0] = dr[0].ToString();
                    productsData[1] = dr[1].ToString();
                    productsData[2] = dr[2].ToString();
                }
            }
            con.Close();
            return productsData;
        }

        private void Purchase_Invoice_Load(object sender, EventArgs e)
        {
            MainClass.disable(leftpanel);
        }
        public override void addBtn_Click(object sender, EventArgs e)
        {
            MainClass.enable_reset(leftpanel);
        }

        //public override void saveBtn_Click(object sender, EventArgs e)
        //{
        //    con.Open();
        //    String query = "INSERT INTO tbl_Invoice (ID,Name,Quantity,Price) VALUES('" + productidtxt.Text + "','" + productnametxt.Text + "','" + quantitytxt.Text + "',,'" + pricetxt.Text + "')";
        //    SqlDataAdapter sda = new SqlDataAdapter(query, con);
        //    sda.SelectCommand.ExecuteNonQuery();
        //    con.Close();
        //    MessageBox.Show("INSERTED SUCCESSFULLY !!!!");
        //    MainClass.disable_reset(leftpanel);
        //}

        //public override void deleteBtn_Click(object sender, EventArgs e)
        //{

        //    con.Open();
        //    String query = "DELETE FROM tbl_Invoice WHERE Name = '" + productnametxt.Text + "'";
        //    SqlDataAdapter sda = new SqlDataAdapter(query, con);
        //    sda.SelectCommand.ExecuteNonQuery();
        //    con.Close();
        //    MessageBox.Show("RECORD DELETED !!!!");
        //    MainClass.disable_reset(leftpanel);
        //}

        //public override void viewBtn_Click(object sender, EventArgs e)
        //{


        //}

        //private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    productnametxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        //    productidtxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        //    pricetxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        //    MainClass.enable(leftpanel);
        //}

        private void quantitytxt_TextChanged(object sender, EventArgs e)
        {
            if (quantitytxt.Text != "")
            {
                float quan, price, tot;
                quan = Convert.ToSingle(quantitytxt.Text);
                price = Convert.ToSingle(pricetxt.Text);
                tot = quan * price;
                totlabel.Text = tot.ToString("####.##");
            }
            else
            {
                totlabel.Text = "0.00";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == 5)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    gt -= Convert.ToSingle(row.Cells["TotGV"].Value.ToString());
                    grosslabel.Text = gt.ToString();
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void cartBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(ProductID, productnametxt.Text, quantitytxt.Text, pricetxt.Text, totlabel.Text);
            
            gt += Convert.ToSingle(totlabel.Text);
            grosslabel.Text = gt.ToString();
            MainClass.enable_reset(leftpanel);
        }
    }
}
