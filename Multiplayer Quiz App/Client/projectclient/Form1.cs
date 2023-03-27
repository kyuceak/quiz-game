using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectclient
{
    public partial class Form1 : Form
    {
        string uniqueName = "";
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

           
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = IPBox.Text;

            int portNumber;

            if (Int32.TryParse(PortBox.Text, out portNumber))
            {

                try
                {
                    clientSocket.Connect(IP, portNumber);
                    connected = true;
                    SendButton.Enabled = true;
                    DisconnectButton.Enabled = true;

                    ConnectButton.Enabled = false;

                    AppendText("Connected!" + uniqueName,Color.RoyalBlue);
                    uniqueName = NameBox.Text;
                    string ClientName = "Connect:" + uniqueName;

                    Byte[] SendingName = Encoding.Default.GetBytes(ClientName);

                    string sent = Encoding.Default.GetString(SendingName);

                    clientSocket.Send(SendingName);

                    AppendText("Your client name is: " + uniqueName,Color.Green);
                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                }
                catch
                {
                    AppendText("Can not connect!",Color.Red);
                }
            }
            else
            {
                AppendText("Check your port!",Color.Red);
            }
        }

        private void Receive()
        {

            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[256];

                    clientSocket.Receive(buffer);
                    string receivedText = Encoding.Default.GetString(buffer);
                    receivedText = receivedText.Substring(0, receivedText.IndexOf("\0"));
                    if (receivedText.Contains("#"))
                    {
                        List<string> messageDataList = receivedText.Split('#').ToList();
                        string topic = messageDataList[0];
                        if (topic == "Score")
                        {
                            AppendText(Environment.NewLine + messageDataList[1],Color.DarkGreen);
                        }
                        else if (topic == "ScoreTable")
                        {
                            AppendText(Environment.NewLine + messageDataList[1], Color.DarkBlue);
                        }
                        else if (topic == "Question")
                        {
                            AppendText(Environment.NewLine +"Question "+ messageDataList[1], Color.Purple);
                        }
                    }
                   
                }
                catch
                {
                    if (!terminating)
                    {
                        AppendText("Disconnected!!"+Environment.NewLine,Color.Red);
                    }

                    clientSocket.Close();
                    connected = false;
                    terminating = true;
                }

            }

            clientSocket.Close();
            connected = false;
            terminating = true;
        }


        private void AppendText(string text, Color color)
        {
            try
            {
                RichTextBox.SelectionStart = RichTextBox.TextLength;
                RichTextBox.SelectionLength = 0;

                RichTextBox.SelectionColor = color;
                RichTextBox.AppendText(text + Environment.NewLine);
                RichTextBox.SelectionColor = RichTextBox.ForeColor;
            }
            catch (Exception ex)
            {
                
               
            }
          
        }

        private void SendButton_Click(object sender, EventArgs e)
        {


            string AnswertoQuestion = "Answer:" + uniqueName +":"+ AnswerBox.Text;

            Byte[] sendingbuffer = Encoding.Default.GetBytes(AnswertoQuestion);

            string result = Encoding.Default.GetString(sendingbuffer);

            clientSocket.Send(sendingbuffer);

            AppendText( Environment.NewLine+"You sent answer as : " + AnswerBox.Text, Color.Purple);
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (clientSocket!=null && clientSocket.IsBound && connected)
            {
                clientSocket.Send(Encoding.ASCII.GetBytes("Disconnect:" + uniqueName));
                clientSocket.Disconnect(false);
                clientSocket.Close();
            }
           
            connected = false;
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
            terminating = true;
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IPBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PortBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {

            if (clientSocket != null && clientSocket.IsBound && connected)
            {
                clientSocket.Send(Encoding.ASCII.GetBytes("Disconnect:" + uniqueName));
                clientSocket.Disconnect(false);
                clientSocket.Close();
            }
           
            connected = false;
            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnswerBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AnswerText_Click(object sender, EventArgs e)
        {

        }

        private void PortText_Click(object sender, EventArgs e)
        {

        }

        private void NameText_Click(object sender, EventArgs e)
        {

        }
    }
}
