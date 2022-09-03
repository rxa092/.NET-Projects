using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
using System.Drawing.Imaging;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Dictionary<string, int> products;
        public static int count;
        public static int productid = 0;
        public static string text = "";
        public static DateTime date = DateTime.Now;
        public static string shift = "";
        public static int quantity = 0;
        public Form1()
        {
            //new Product().ConnectToServer();
            InitializeComponent();
            products = new Product().getProducts();
            for (int i = 0; i < products.Count; i++)
            {
                comboBox1.Items.Add(products.ElementAt(i).Key);
            }
            count = 0;
            //button2.Hide();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
           // dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            numericUpDown1.Maximum = 2000;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;

            if (comboBox2.Text.ToString().ToLower() == "morning")
            {
                shift = "1";
            }
            else if (comboBox2.Text.ToString().ToLower() == "evening")
            {
                shift = "2";
            }
            if (count == 0)
            {
                count = new Product().LastID(DateTime.ParseExact(dateTimePicker1.Text,"M/d/yyyy",null));
            }
            count = count + 1;

            //text = dateTimePicker1.Text[0].ToString() + dateTimePicker1.Text[2].ToString() + dateTimePicker1.Text[3].ToString() + dateTimePicker1.Text[5].ToString() + dateTimePicker1.Text[6].ToString() + dateTimePicker1.Text[7].ToString() + dateTimePicker1.Text[8].ToString() ;
            text = dateTimePicker1.Text.Replace(@"/", string.Empty);
            text += products[comboBox1.Text].ToString() + shift + numericUpDown1.Value.ToString() + (count).ToString();
            productid = products[comboBox1.Text];
            date = Convert.ToDateTime(dateTimePicker1.Text);
            quantity = (int)numericUpDown1.Value;
            pictureBox1.Image = barcode.Draw(text, 60);
            new Product().NewStock(Form1.text, Form1.date, Form1.productid, int.Parse(Form1.shift), Form1.quantity, Form1.count);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            //new Product().NewStock(text, date, productid, int.Parse(shift), quantity, count);


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, new Point(20,10));
            //e.Graphics.DrawImage(pictureBox1.Image, new Point(5, 10));
            e.Graphics.DrawString(text, new Font("Times New Roman", 13, FontStyle.Regular), Brushes.Black, new Point(20,70));
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom2",200,20);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

    }
}
