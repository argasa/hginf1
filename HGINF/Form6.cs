using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HGINF
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                
            File.Delete("pcnum.conf");
            string Pc = WorkBD.GetPCnum(maskedTextBox1.Text);
                File.WriteAllText("pcnum.conf",Pc );
                this.Close();
        }
    }
}
