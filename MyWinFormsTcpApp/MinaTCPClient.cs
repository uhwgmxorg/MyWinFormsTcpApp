using Mina.Core.Future;
using Mina.Core.Service;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Mina.Filter.Codec.TextLine;
using Mina.Filter.Logging;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyWinFormsTcpApp
{
    class MinaTCPClient
    {
        static public object _threadLock = new object();

        private bool cancelConnetionRetry;
        private int waitTimeOutToWrite;

        private bool isRunning;
        public bool IsRunning 
        { 
            get 
            {
                lock (_threadLock)
                {
                    return isRunning;
                }
            }
            set 
            {
                lock (_threadLock)
                {
                    isRunning = value;
                }
            }
        }
        private bool isAutoRecover;
        public bool IsAutoRecover
        {
            get
            {
                lock (_threadLock)
                {
                    return isAutoRecover;
                }
            }
            set
            {
                lock (_threadLock)
                {
                    isAutoRecover = value;
                }
            }
        }

        private int _bufferSize = 512;
        private int _delay = 1000;

        FormMyWinFormsTcpApp.DUpdateText CallDUpdateText;
        FormMyWinFormsTcpApp.DUpdateProgressBar CallDUpdateProgressBar;

        IPAddress _serverIPAddress;
        Int32 _port;

        IoConnector Connector { get; set; }
        IoSession Session { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MinaTCPClient(IPAddress serverIPAddress, Int32 port, FormMyWinFormsTcpApp.DUpdateText callDUpdateText, FormMyWinFormsTcpApp.DUpdateProgressBar callDUpdateProgressBar)
        {
            IsRunning = true;
            cancelConnetionRetry = false;
            waitTimeOutToWrite = 500;
            _serverIPAddress = serverIPAddress;
            _port = port;
            CallDUpdateText = callDUpdateText;
            CallDUpdateProgressBar = callDUpdateProgressBar;
            OpenMinaSocket();
        }

        /// <summary>
        /// OpenMinaSocket
        /// Open a socket with the parameter
        /// specified in the constructor
        /// </summary>
        private void OpenMinaSocket()
        {
            Connector = new AsyncSocketConnector();
            Connector.FilterChain.AddLast("logger", new LoggingFilter());
            Connector.FilterChain.AddLast("codec", new ProtocolCodecFilter(new TextLineCodecFactory(Encoding.UTF8)));

            Connector.SessionOpened += (s, e) =>
            {
                e.Session.Write("open");
                CallDUpdateText(String.Format("SessionOpened"));
            };

            Connector.MessageReceived += (s, e) =>
            {
                String IncomingStringBuffer = e.Message.ToString();
                CallDUpdateText(String.Format("MessageReceived {0}", IncomingStringBuffer));
            };

            while (!cancelConnetionRetry)
            {
                try
                {
                    IConnectFuture Future = Connector.Connect(new IPEndPoint(_serverIPAddress, _port));
                    Future.Await();
                    Session = Future.Session;
                    CallDUpdateText(String.Format("Connection to {0}:{1} established", _serverIPAddress.ToString(), _port));
                    break;
                }
                catch (Exception ex)
                {
                    CallDUpdateText(String.Format("Exception in OpenMinaSocket {0}", ex.Message));
                    Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// WriteToMinaSocket
        /// Use this method to send data via
        /// the open socket from outside of the class
        /// </summary>
        /// <param name="buffer"></param>
        public void WriteToMinaSocket(string buffer)
        {
            Session.Write(buffer);
        }

        /// <summary>
        /// CloseMinaSocket
        /// Use this method to close the socket
        /// and stop the automatic (test) sending
        /// in StressMinaSocket
        /// </summary>
        public void CloseMinaSocket()
        {
            try
            {
                IsRunning = false;
                Session.Close(true);
            }
            catch (Exception ex)
            {
                CallDUpdateText(String.Format("Exception in CloseMinaSocket {0}", ex.Message));
            }
        }

        /// <summary>
        /// StressMinaSocket
        /// Use this method to test the
        /// class and send some random data
        /// </summary>
        /// <param name="bufferSize"></param>
        public void StressMinaSocket(int bufferSize,int delay)
        {
            _bufferSize = bufferSize;
            _delay = delay;

            Thread thread = new Thread(
            () =>
            {
                try
                {
                    string WriteBuffer;
                    Thread.CurrentThread.Name = "Mina Socket Client";
                    while (IsRunning)
                    {
                        WriteBuffer = RandomString(bufferSize);
                        IWriteFuture res = Session.Write(WriteBuffer);
                        if (IsAutoRecover)
                        {
                            // The next call ensures that the main thread close the socket and then 
                            // open it again and then start again sending the random string
                            res.Await(waitTimeOutToWrite);
                            if (!res.Written)
                            {
                                CallDUpdateText(String.Format("Error Writing Data To Socket"));
                                CallDUpdateText(String.Format("Closing Socket"));
                                CallDUpdateText("Recover StressMinaSocket");
                            }
                            else
                                CallDUpdateText(String.Format("Session.Write {0}", WriteBuffer));
                        }
                        CallDUpdateProgressBar(this, null);
                        Thread.Sleep(delay);
                    }
                }
                catch (Exception ex)
                {
                    CallDUpdateText(String.Format("Exception in StressMinaSocket {0}", ex.Message));
                }
            });
            thread.Start();
        }

        /// <summary>
        /// RandomString
        /// Create a random string
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Random _random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            double d;
            for (int i = 0; i < size; i++)
            {
                d = _random.NextDouble();
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * d) + 65));
                builder.Append(ch);
            }

            return builder.ToString();
        }

    }
}
