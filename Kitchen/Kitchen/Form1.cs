using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitchen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TcpListener listner = new TcpListener(new IPEndPoint(IPAddress.Loopback, 11000));
            listner.Start();
            listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);

        }
        TcpClient client;
        Dictionary<String, TcpClient> Clients = new Dictionary<string, TcpClient>();
        static byte[] msg = new byte[1024];
        List<string> orders = new List<string>();
        List<string> waiting = new List<string>();

        private void ConnectListner(IAsyncResult ar)
        {
            TcpListener listner = (TcpListener)ar.AsyncState;
            TcpClient Client = listner.EndAcceptTcpClient(ar);
            NetworkStream ns = Client.GetStream();
            int count = ns.Read(msg, 0, msg.Length);
            string name = (ASCIIEncoding.ASCII.GetString(msg, 0, count));
            Clients.Add(name, Client);
            ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);
            listner.BeginAcceptTcpClient(new AsyncCallback(ConnectListner), listner);

        }




        private void StartRead(IAsyncResult ar)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                int count = ns.EndRead(ar);
                string msg1 = ASCIIEncoding.ASCII.GetString(msg, 0, count);
                string[] orderarray = msg1.Split(',');
                //InboxTxt.Text += msg1;
                //InboxTxt.Text += Environment.NewLine;
                if (orders.Count < 5)
                {
                    orders.Add(msg1);
                    for (int i = 0; i < orders.Count; i++)
                    {
                        txt_orders.Text += orders[i];
                        txt_orders.Text += Environment.NewLine;
                    }
                }
                else
                {
                    waiting.Add(msg1);
                    TcpClient waitingclient = new TcpClient();
                    Clients.TryGetValue("waiting", out waitingclient);
                    NetworkStream nswaiting = waitingclient.GetStream();
                    nswaiting.Write(ASCIIEncoding.ASCII.GetBytes(orderarray[0]), 0, orderarray[0].Length);
                }
                ns.BeginRead(msg, 0, msg.Length, new AsyncCallback(StartRead), ns);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btn_completed_Click(object sender, EventArgs e)
        {
            TcpClient completedclient = new TcpClient();
            Clients.TryGetValue("completed", out completedclient);
            NetworkStream completedstream = completedclient.GetStream();
            completedstream.Write(ASCIIEncoding.ASCII.GetBytes(txt_completed.Text), 0, txt_completed.Text.Length);
            for (int i = 0; i < orders.Count; i++)
            {
                string[] temp = orders[i].Split(',');
                if (txt_completed.Text.ToString() == temp[0])
                {
                    orders.RemoveAt(i);
                    orders.Add(waiting[0]);
                }
            }
            string[] arr = waiting[0].Split(',');
            TcpClient waitingclient = new TcpClient();
            Clients.TryGetValue("waiting", out waitingclient);
            NetworkStream waitingstream = waitingclient.GetStream();
            waitingstream.Write(ASCIIEncoding.ASCII.GetBytes(arr[0]), 0, arr[0].Length);
        }
    }
}
