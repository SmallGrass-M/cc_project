using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5
{
    public partial class MD5 : Form
    {
        public MD5()
        {
            InitializeComponent();

            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.textBox1.Text.ToUpper(), "MD5");

            this.textBox2.Focus();
        }
    }
}
