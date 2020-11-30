using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void lblHome_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
           // pnlform.Controls.Add(frm);
            frm.Show();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            AboutUs frm = new AboutUs();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
             pnlAboutUs.Controls.Add(frm);
            frm.Show();
        }
    }
}
