using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new Product().StockIn(textBox1.Text);
                MessageBox.Show("Stock Updated");
                textBox1.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Some error occured stock not updated ");
            }

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                new Product().StockOut(textBox1.Text);
                MessageBox.Show("Stock Updated");
                textBox1.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Some error occured stock not updated");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Product().GetBarcode(textBox1.Text);
        }
    }
}
