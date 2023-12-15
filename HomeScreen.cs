using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace Inventory_Management_System
{
    public partial class HomeScreen : Sample
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            MainClass.ShowWindow(u, this, MDI.ActiveForm);
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();
            MainClass.ShowWindow(c, this, MDI.ActiveForm);
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            MainClass.ShowWindow(p, this, MDI.ActiveForm);
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void userlabel_Click(object sender, EventArgs e)
        {

        }

        private void invoiceBtn_Click(object sender, EventArgs e)
        {
            Purchase_Invoice pi = new Purchase_Invoice();
            MainClass.ShowWindow(pi, this, MDI.ActiveForm);
        }
    }
}
