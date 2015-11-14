using Mina.Core.Service;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Mina.Filter.Codec.TextLine;
using Mina.Filter.Logging;
using Mina.Transport.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyWinFormsTcpApp
{
    class MinaTCPServer
    {
        FormMyWinFormsTcpApp.DUpdateText CallDUpdateText;
        FormMyWinFormsTcpApp.DUpdateProgressBar CallDUpdateProgressBar;

        Int32 _port;
        byte[] _buffer;

        IoAcceptor Acceptor { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port"></param>
        public MinaTCPServer(Int32 port, FormMyWinFormsTcpApp.DUpdateText callDUpdateText, FormMyWinFormsTcpApp.DUpdateProgressBar callDUpdateProgressBar)
        {
            _port = port;
            CallDUpdateText = callDUpdateText;
            CallDUpdateProgressBar = callDUpdateProgressBar;
            StartMinaListener();
        }

        /// <summary>
        /// MinaListener
        /// </summary>
        void StartMinaListener()
        {
            if (Acceptor != null)
                throw new Exception("This should not happen!");

            Acceptor = new AsyncSocketAcceptor();
            Acceptor.FilterChain.AddLast("logger", new LoggingFilter());
            Acceptor.FilterChain.AddLast("codec", new ProtocolCodecFilter(new TextLineCodecFactory(Encoding.UTF8)));

            Acceptor.ExceptionCaught += HandleException;
            Acceptor.SessionOpened += HandeleSessionOpened;
            Acceptor.SessionClosed += HandeleSessionClosed;
            Acceptor.SessionIdle += HandleIdle;
            Acceptor.MessageReceived += HandleReceived;

            Acceptor.SessionConfig.ReadBufferSize = 10*1024;
            Acceptor.SessionConfig.SetIdleTime(IdleStatus.BothIdle, 10);

            Acceptor.Bind(new IPEndPoint(IPAddress.Any, _port));
        }

        /// <summary>
        /// StopMinaListener
        /// </summary>
        public void StopMinaListener()
        {
            if (Acceptor == null)
                throw new Exception("This should also not happen!");
            Acceptor.Unbind();
        }

        /******************************/
        /*          Events            */
        /******************************/
        #region Events

        /// <summary>
        /// HandleException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleException(Object sender, IoSessionExceptionEventArgs e)
        {
            CallDUpdateText(String.Format("HandleException {0}",e.Exception.Message));
        }

        /// <summary>
        /// HandeleSessionOpened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandeleSessionOpened(Object sender,IoSessionEventArgs e)
        {
            CallDUpdateText(String.Format("SessionOpened {0}",e.Session.RemoteEndPoint.ToString()));
        }

        /// <summary>
        /// HandeleSessionClosed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandeleSessionClosed(Object sender, IoSessionEventArgs e)
        {
            CallDUpdateText(String.Format("SessionClosed {0}",e.Session.RemoteEndPoint.ToString()));
        }

        /// <summary>
        /// HandleIdle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleIdle(Object sender, IoSessionIdleEventArgs e)
        {
            CallDUpdateText(String.Format("Idle {0}",e.Session.GetIdleCount(e.IdleStatus)));
        }

        /// <summary>
        /// HandleReceived
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleReceived(Object sender,IoSessionMessageEventArgs e)
        {
            String IncomingStringBuffer = e.Message.ToString();
            int IncommingMessageSize = IncomingStringBuffer.Length;
            _buffer = GetBytes(IncomingStringBuffer);

            // Send the same date back to the client
            e.Session.Write(IncomingStringBuffer);
            CallDUpdateText(String.Format("Geting {0} Bytes Sending {0} back", IncommingMessageSize));
            CallDUpdateProgressBar(this, null);
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// GetBytes
        /// </summary>
        /// <param name="IncomingStringBuffer"></param>
        /// <returns></returns>
        byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// GetString
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        #endregion
    }
}
