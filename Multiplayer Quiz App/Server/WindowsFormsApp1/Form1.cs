using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using  System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Dictionary<string, SocketData> clientDic = new Dictionary<string, SocketData>();
        List<Dictionary<string, string>> questionList = new List<Dictionary<string, string>>();
        int currentQuestionIndex = 0;
        int currentQuestionCount = 0;
        int maximumQuestions = 4;
        bool isGameStarted = false;
        Dictionary<string, string> currentQuestionDic = new Dictionary<string, string>();
        public Form1()
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            GetQuestionList();
            EnableDisableStartButton();
        }


        private void GetQuestionList()
        {
            if (File.Exists("questions.txt"))
            {
                List<string> rowQuestionList = File.ReadAllLines("questions.txt").ToList();
                for (int i = 0; i < rowQuestionList.Count; i=i+2)
                {
                    Dictionary<string, string> questionDic = new Dictionary<string, string>();
                    questionDic.Add(rowQuestionList[i],rowQuestionList[i+1]);
                    questionList.Add(questionDic);
                }
            }
        }



        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort)) //taking server port
            {
                AppendText("About to accept incoming connection.", Color.Orange);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(100);
                AppendText("Started listening on port: " + serverPort, Color.DarkGreen);
                Thread acceptThread = new Thread(AcceptClient);
                acceptThread.Start();
            }
            else
            {
                logs.AppendText("Please check port number \n");
            }


        }
        private void AcceptClient()
        {
            while (true)
            {
                Socket socket = serverSocket.Accept();
                StartClient(socket);
            }
        }


        private void StartClient(Socket socket)
        {
            Thread ctThread = new Thread(() => StartChat(socket));
            ctThread.Start();
        }


        private void StartChat(Socket socket)
        {

            try
            {
                while (true)
                {
                    Byte[] byteArray = new Byte[128];
                    socket.Receive(byteArray);
                    string receivedMessage = Encoding.UTF8.GetString(byteArray);
                    receivedMessage = receivedMessage.Substring(0, receivedMessage.IndexOf("\0"));
                    if (receivedMessage.Contains(":"))
                    {
                        List<string> messageDataList = receivedMessage.Split(':').ToList();
                        string topic = messageDataList[0];
                        string uniqueName = messageDataList[1];
                        if (topic == "Connect")
                        {
                            if (!clientDic.Keys.Contains(uniqueName))
                            {
                                SocketData socketData = new SocketData();
                                socketData.uniqueName = uniqueName;
                                socketData.score = 0;
                                socketData.totalScore = 0;
                                socketData.socket = socket;
                                socketData.deviation = 0;
                                clientDic.Add(uniqueName, socketData);
                                AppendText("Client connected : " + uniqueName,Color.RoyalBlue);
                                EnableDisableStartButton();
                                UpdateConnectionCount();
                            }
                        }
                        else if (topic == "Disconnect")
                        {
                            if (clientDic.Keys.Contains(uniqueName))
                            {
                                clientDic.Remove(uniqueName);
                                AppendText("Client disconnected : " + uniqueName, Color.Red);
                                EnableDisableStartButton();
                                UpdateConnectionCount();
                                if (CheckTerminationAvailable())
                                {
                                    ManupulateGameTerminated();
                                    isGameStarted = false;
                                }
                                EnableDisableStartButton();
                            }
                        }
                        else if (topic == "Answer")
                        {
                            if (clientDic.Keys.Contains(uniqueName))
                            {
                                clientDic[uniqueName].answer = messageDataList[2];
                                clientDic[uniqueName].isAnswered = true;
                                AppendText("Answer received by : " + uniqueName + " is " + messageDataList[2], Color.Purple);
                                if (CheckAllAnswered())
                                {
                                    ManupulateAnswers();
                                    if (maximumQuestions > currentQuestionCount)
                                    {
                                        ManupulateNextQuestion();
                                    }
                                    else
                                    {
                                        ManupulateGameComplete();
                                    }
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Text");
                    }
                }
                
            }
            catch (Exception ex)
            {
             
            }
           
           
        }


        private bool CheckAllAnswered()
        {
            bool isAnswered = true;
            try
            {
                foreach (string name in clientDic.Keys)
                {
                    if (clientDic[name].isInGame)
                    {
                        if (!clientDic[name].isAnswered)
                        {
                            isAnswered = false;
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                
              
            }
           
           
            return isAnswered;
        }

        private bool CheckTerminationAvailable()
        {
            int count = 0;
            bool isTerminateAvailable = false;
            try
            {
                foreach (string name in clientDic.Keys)
                {
                    if (clientDic[name].isInGame)
                    {
                        count = count + 1;
                    }
                }
            }
            catch (Exception ex)
            {


            }
            if (count > 1)
            {
                isTerminateAvailable = false;
            }
            else
            {
                isTerminateAvailable = true;
            }

            return isTerminateAvailable;
        }

        private void ManupulateAnswers()
        {
            try
            {
                int answer = int.Parse(currentQuestionDic.Values.ToList()[0]);
                foreach (string name in clientDic.Keys)
                {
                    if (clientDic[name].isInGame)
                    {
                        if (clientDic[name].isAnswered)
                        {
                            int clientAnswer = 0;
                            if (int.TryParse(clientDic[name].answer, out clientAnswer))
                            {
                                clientDic[name].deviation= Math.Abs(answer - clientAnswer);
                            }
                        }
                    }
                }

                List<SocketData> clientList = clientDic.Values.ToList();
                List<SocketData> answeredClientList = clientList.Where(obj => obj.isInGame && obj.isAnswered).ToList();
               
                double minDeviation = answeredClientList.Min(obj => obj.deviation);
                List<SocketData> minDeviationList = answeredClientList.Where(obj => obj.deviation == minDeviation).ToList();
                double winningScore = 1;
                if (minDeviationList.Count > 1)
                {
                    double mainValue=1;
                    winningScore = Math.Round(mainValue/ minDeviationList.Count, 1);
                }
                foreach (SocketData socketData in answeredClientList)
                {
                    double score = 0;
                    if (socketData.deviation == minDeviation)
                    {
                        score = winningScore;
                    }
                  
                    clientDic[socketData.uniqueName].score = score;
                    clientDic[socketData.uniqueName].totalScore = clientDic[socketData.uniqueName].totalScore + score;
                    string responseText="Score#Your score for question is : "+score+Environment.NewLine+"Correct answer is : "+answer;
                    SendResponse(clientDic[socketData.uniqueName].socket, responseText);
                }
                clientList = clientDic.Values.ToList();
                answeredClientList = clientList.Where(obj => obj.isInGame && obj.isAnswered).ToList().OrderBy(obj => obj.totalScore).ToList();
                string scoreTableText = "";
                foreach (SocketData socketData in answeredClientList)
                {
                    scoreTableText = scoreTableText + socketData.uniqueName + " : " + socketData.totalScore+Environment.NewLine;
                }
                foreach (SocketData socketData in answeredClientList)
                {
                    SendResponse(clientDic[socketData.uniqueName].socket, "ScoreTable#"+scoreTableText);
                    Thread.Sleep(50);
                }

            }
            catch (Exception ex)
            {
                
               
            }
        
        }

        private void ManupulateNextQuestion()
        {
            try
            {
                string question = GetNextQuestion();
                foreach (string uniqueName in clientDic.Keys)
                {
                    if (clientDic[uniqueName].isInGame)
                    {
                        clientDic[uniqueName].isInGame = true;
                        clientDic[uniqueName].question = question;
                        clientDic[uniqueName].isAnswered = false;
                        clientDic[uniqueName].score = 0;
                        clientDic[uniqueName].deviation = 0;
                        Thread.Sleep(100);
                        SendResponse(clientDic[uniqueName].socket, "Question#" + question);
                        Thread.Sleep(50);
                        AppendText("Sent question to " + uniqueName + ". Question : " + question,Color.DarkOrange);
                    }
                    
                }
                UpdateConnectionCount();

            }
            catch (Exception ex)
            {


            }

        }

        private void ManupulateGameComplete()
        {
            try
            {
                currentQuestionCount = 0;
                currentQuestionIndex = 0;
                isGameStarted = false;
                foreach (string uniqueName in clientDic.Keys)
                {
                    clientDic[uniqueName].isInGame = false;
                    clientDic[uniqueName].question = "";
                    clientDic[uniqueName].isAnswered = false;
                    clientDic[uniqueName].score = 0;
                    clientDic[uniqueName].deviation = 0;
                    clientDic[uniqueName].totalScore = 0;
                }
                UpdateConnectionCount();
                EnableDisableStartButton();
                AppendText("Game is completed. !!!." + Environment.NewLine + "Press start game for new game.", Color.Green);

            }
            catch (Exception ex)
            {


            }

        }


        private void ManupulateGameTerminated()
        {
            try
            {
                currentQuestionCount = 0;
                currentQuestionIndex = 0;
                isGameStarted = false;
                foreach (string uniqueName in clientDic.Keys)
                {
                    clientDic[uniqueName].isInGame = false;
                    clientDic[uniqueName].question = "";
                    clientDic[uniqueName].isAnswered = false;
                    clientDic[uniqueName].score = 0;
                    clientDic[uniqueName].deviation = 0;
                    clientDic[uniqueName].totalScore = 0;
                }
                UpdateConnectionCount();
                EnableDisableStartButton();
                AppendText("Game is terminiated. !!!." + Environment.NewLine + "Press start game for new game.", Color.Orange);

            }
            catch (Exception ex)
            {


            }

        }
        

        private void SendResponse(Socket socket, string message)
        {
            try
            {
                  socket.Send(Encoding.ASCII.GetBytes(message));
            }
            catch (Exception ex)
            {
              
            }
        }


        private void AppendText(string text, Color color)
        {
            logs.SelectionStart = logs.TextLength;
            logs.SelectionLength = 0;

            logs.SelectionColor = color;
            logs.AppendText(text+Environment.NewLine);
            logs.SelectionColor = logs.ForeColor;
        }

        private string GetNextQuestion()
        {
            currentQuestionDic = questionList[currentQuestionIndex];
            string question = currentQuestionDic.Keys.ToList()[0];

            currentQuestionIndex = currentQuestionIndex + 1;
            if (currentQuestionIndex >= questionList.Count)
            {
                currentQuestionIndex = 0;
            }
            currentQuestionCount = currentQuestionCount + 1;
            return question;
        }

        private string GetAnswer()
        {
           string answerString= currentQuestionDic.Values.ToList()[0];
           return answerString;
        }

        private void EnableDisableStartButton()
        {
            if (serverSocket != null && serverSocket.IsBound && !isGameStarted)
            {
                if (clientDic.Count >= 2)
                {
                    buttonStart.Enabled = true;
                }
                else
                {
                    buttonStart.Enabled = false;
                }
            }
            else
            {
                buttonStart.Enabled = false;
            }
        }

        private void UpdateConnectionCount()
        {
            int connectedCount = clientDic.Count;
            int inGameCount = 0;
            foreach (string uniqueName in clientDic.Keys)
            {
                if (clientDic[uniqueName].isInGame)
                {
                    inGameCount = inGameCount + 1;
                }
            }
            labelInGameCount.Text = inGameCount.ToString();
            labelConnectedCount.Text = connectedCount.ToString();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string question = GetNextQuestion();
            foreach (string uniqueName in clientDic.Keys)
            {
                clientDic[uniqueName].isInGame = true;
                clientDic[uniqueName].question = question;
                clientDic[uniqueName].isAnswered = false;
                clientDic[uniqueName].score = 0;
                clientDic[uniqueName].totalScore = 0;
                clientDic[uniqueName].deviation = 0;
                SendResponse(clientDic[uniqueName].socket, "Question#" + question);
                Thread.Sleep(50);
                AppendText("Sent question to " + uniqueName + ". Question : " + question, Color.DarkOrange);
            }
            isGameStarted = true;
            UpdateConnectionCount();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (int.TryParse(QuestionNumberBox.Text, out maximumQuestions))
            {
                AppendText("Number of Questions : "+maximumQuestions, Color.Green);
            }
            else
            {
                
            }
        }

        private void QuestionNumberBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(QuestionNumberBox.Text, out maximumQuestions))
            {
                AppendText("Number of Questions : " + maximumQuestions, Color.Green);
            }
            else
            {
                AppendText("Invalid Number of Questions.", Color.Red);
            }
        }

     
    }



}
