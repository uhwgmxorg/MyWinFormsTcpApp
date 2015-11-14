using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsTcpApp
{
    public partial class FormAbout : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormAbout()
        {
            InitializeComponent();
            richTextBox1.Text = "MyWinFormsTcpApp Program to demonstate the use of Mina.Net and TCP/IP sockets";
        }
    }
}
