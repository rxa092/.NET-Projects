using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //Thread t1 = new Thread(new Product().RunPendingTask);
            //t1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.CheckForInternetConnection())
            {
                Form1 fm = new Form1();
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Internet Connection");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.CheckForInternetConnection())
            {
                Form2 fm = new Form2();
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Internet Connection");
            }

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
