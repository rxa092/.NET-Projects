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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = Product.barcode.ProductName;
            textBox2.Text = Product.barcode.ShiftName;
            textBox3.Text = Convert.ToString(Product.barcode.date);
            textBox4.Text = Product.barcode.Quantity.ToString();
            
        }
    }
}
