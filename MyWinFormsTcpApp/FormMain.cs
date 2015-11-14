using ChangeLogUtilityDllF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsTcpApp
{
    public partial class FormMyWinFormsTcpApp : Form
    {
        const string SETINGS_FILE_NAME = "SocketConfiguration.xml";

        enum ClientServer { CLIENT, SERVER };
        ClientServer _clientServer = ClientServer.CLIENT;

        const String _revision = "0";

        const int ProgressBarMinimum = 0;
        const int ProgressBarMaximum = 30;
        const int TrackBarPacketSizeMinimum = 1;
        const int TrackBarPacketSizeMaximum = 1024*10;
        const int TrackBarSendDelayMinimum = 1;
        const int TrackBarSendDelayMaximum = 1000;

        int _counterMessage = 0;

        MinaTCPServer TheMinaTCPServer;
        MinaTCPClient TheMinaTCPClient;

        public bool IsStart { get; set; }

        private SocketConfiguration SelectedSocketConfiguration = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMyWinFormsTcpApp()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);

            InitializeComponent();

            progressBarPerformance.Minimum = ProgressBarMinimum;
            progressBarPerformance.Maximum = ProgressBarMaximum;
            trackBarPackageSize.Minimum = TrackBarPacketSizeMinimum;
            trackBarPackageSize.Maximum = TrackBarPacketSizeMaximum;
            trackBarSendDelay.Minimum = TrackBarSendDelayMinimum;
            trackBarSendDelay.Maximum = TrackBarSendDelayMaximum;

#if DEBUG
            Text += "    Debug Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " Revision " + _revision;
#else
            Text += "    Release Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version + " Revision " + _revision;
#endif

            LoadSettings(SETINGS_FILE_NAME);

            IsStart = false;
            SetSettingsToUI();
            EnableDisableControls();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// button_Start_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Start_Click(object sender, EventArgs e)
        {
            TimeMeasure Life = new TimeMeasure();
            IsStart = true;

            switch (_clientServer)
            {
                case ClientServer.CLIENT:
                    try
                    {
                        TheMinaTCPClient = new MinaTCPClient(IPAddress.Parse(textBoxTCPIPAddress.Text), Convert.ToInt32(maskedTextBoxPort.Text.ToString()), UpdateText, UpdateProgressBar);
                        TheMinaTCPClient.StressMinaSocket(Convert.ToInt32(labelPackageSizeValue.Text),Convert.ToInt32(labelSendDelayValue.Text));
                    }
                    catch (Exception ex)
                    {
                        UpdateText(String.Format("Exeption in Start TCP Client {0}", ex.Message));
                    }
                    break;
                case ClientServer.SERVER:
                    try
                    {
                        TheMinaTCPServer = new MinaTCPServer(Convert.ToInt32(maskedTextBoxPort.Text.ToString()), UpdateText,UpdateProgressBar);
                        UpdateText(String.Format("Start Mina-Server {0} ms",Life.StrRunTime));
                    }
                    catch (Exception ex)
                    {
                        UpdateText(String.Format("Exeption in Start TCP Server {0}", ex.Message));
                    }
                    break;
            }
            EnableDisableControls();
        }

        /// <summary>
        /// button_Stop_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Stop_Click(object sender, EventArgs e)
        {
            TimeMeasure Life = new TimeMeasure();
            IsStart = false;

            switch (_clientServer)
            {
                case ClientServer.CLIENT:
                    try
                    {
                        TheMinaTCPClient.CloseMinaSocket();
                        TheMinaTCPClient = null;
                        UpdateText(String.Format("Close Mina-Socket {0} ms", Life.StrRunTime));
                    }
                    catch (Exception ex)
                    {
                        UpdateText(String.Format("ERROR in TCP Client Close {0}", ex.Message));
                    }
                    break;
                case ClientServer.SERVER:
                    try
                    {
                        TheMinaTCPServer.StopMinaListener();
                        TheMinaTCPServer = null;
                        UpdateText(String.Format("Stop Mina-Server {0} ms", Life.StrRunTime));
                    }
                    catch (Exception ex)
                    {
                        UpdateText(String.Format("ERROR in TCP Server Close {0}", ex.Message));
                    }
                    break;
            }
            EnableDisableControls();
        }

        /// <summary>
        /// button_Clear_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBoxInfo.Text = "";
        }

        /// <summary>
        /// button_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*  Menu and Toolbar Events   */
        /******************************/
        #region Menu and Toolbar Events

        /// <summary>
        /// toolStripButton_Exit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// toolStripButton_Load_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Load_Click(object sender, EventArgs e)
        {
            // Create OpenFileDialog 
            OpenFileDialog Dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension 
            Dlg.DefaultExt = ".xml";
            Dlg.Filter = "ConfigFile (.xml)|*.xml";

            // Get the selected file name and display in a TextBox 
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                // Open Document 
                string Filename = Dlg.FileName;
                LoadSettings(Filename);
                SetSettingsToUI();
            }
        }

        /// <summary>
        /// toolStripButton_Save_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            // Create OpenFileDialog 
            SaveFileDialog Dlg = new SaveFileDialog();

            // Set filter for file extension and default file extension 
            Dlg.DefaultExt = ".xml";
            Dlg.Filter = "ConfigFile (.xml)|*.xml";

            // Get the selected file name and display in a TextBox 
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                // Open Document 
                string Filename = Dlg.FileName;
                GetSettingsFormUI();
                SaveSettings(Filename);
            }
        }

        /// <summary>
        /// toolStripButton_ChangeLog_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_ChangeLog_Click(object sender, EventArgs e)
        {
            ChangeLogTxtToolWindowF ChangeLogTxtToolWindow = new ChangeLogTxtToolWindowF(this);
            ChangeLogTxtToolWindow.ShowChangeLogWindow("ChangeLog.txt");
        }

        /// <summary>
        /// toolStripButton_About_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_About_Click(object sender, EventArgs e)
        {
            FormAbout AboutBox = new FormAbout();
            AboutBox.StartPosition = FormStartPosition.CenterScreen;
            AboutBox.ShowDialog();
        }

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        /// <summary>
        /// MyCommonExceptionHandlingMethod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="t"></param>
        private static void MyCommonExceptionHandlingMethod(object sender, System.Threading.ThreadExceptionEventArgs t)
        {
            System.Diagnostics.Debug.WriteLine(t);
        }

        /// <summary>
        /// FormMyWinFormsTcpApp_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMyWinFormsTcpApp_Load(object sender, EventArgs e)
        {
            UpdateText("Start MyWinFormsTcpApp");
        }

        /// <summary>
        /// radioButtonServer_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonServer_CheckedChanged(object sender, EventArgs e)
        {
            _clientServer = ClientServer.SERVER;
            EnableDisableControls();
        }

        /// <summary>
        /// radioButtonClient_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonClient_CheckedChanged(object sender, EventArgs e)
        {
            _clientServer = ClientServer.CLIENT;
            EnableDisableControls();
        }

        /// <summary>
        /// trackBarPackageSize_Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarPackageSize_Scroll(object sender, EventArgs e)
        {
            int v = trackBarPackageSize.Value;
            labelPackageSizeValue.Text = v.ToString();
        }

        /// <summary>
        /// trackBarSendDelay_Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSendDelay_Scroll(object sender, EventArgs e)
        {
            int v = trackBarSendDelay.Value;
            labelSendDelayValue.Text = v.ToString();
        }

        /// <summary>
        /// FormMyWinFormsTcpApp_FormClosed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMyWinFormsTcpApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(IsStart)
                button_Stop_Click(this,null);
            GetSettingsFormUI();
            SaveSettings(SETINGS_FILE_NAME);
        }

        /// <summary>
        /// checkBoxAutoRecover_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAutoRecover_CheckedChanged(object sender, EventArgs e)
        {
            switch (_clientServer)
            {
                case ClientServer.CLIENT:
                    try
                    {
                        if (TheMinaTCPClient == null)
                        {
                            UpdateText(String.Format("You must start the Client first"));
                            return;
                        }
                        TheMinaTCPClient.IsAutoRecover = checkBoxAutoRecover.Checked;
                        if(checkBoxAutoRecover.Checked)
                            UpdateText(String.Format("Auto Recovery ON"));
                        else
                            UpdateText(String.Format("Auto Recovery OFF"));
                    }
                    catch (Exception ex)
                    {
                        UpdateText(String.Format("ERROR in TCP Client Set AutoRecover {0}", ex.Message));
                    }
                    break;
                case ClientServer.SERVER:
                    UpdateText(String.Format("Auto Recovery has only effect in Client-Mode"));
                    break;
            }
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// DefaultSettings
        /// </summary>
        void DefaultSettings()
        {
            SelectedSocketConfiguration = new SocketConfiguration();

            SelectedSocketConfiguration.IPAdress = "127.0.0.1";
            SelectedSocketConfiguration.Port = 4712;
            SelectedSocketConfiguration.ServerClient = 2;
            SelectedSocketConfiguration.SendDelay = 1000;
            SelectedSocketConfiguration.MaxInfoTextLen = 1024;
            SelectedSocketConfiguration.PacketSize = 128;
        }

        /// <summary>
        /// LoadSettings
        /// </summary>
        void LoadSettings(string fileName)
        {
            XMLSerialize XMLS = new XMLSerialize(fileName);
            XMLS.Load(ref SelectedSocketConfiguration);
            if (SelectedSocketConfiguration == null)
                DefaultSettings();
        }

        /// <summary>
        /// SaveSettings
        /// </summary>
        void SaveSettings(string fileName)
        {
            XMLSerialize XMLS = new XMLSerialize(SelectedSocketConfiguration, fileName);
            XMLS.Save();
        }

        /// <summary>
        /// SetSettingsToUI
        /// </summary>
        void SetSettingsToUI()
        {
            textBoxTCPIPAddress.Text = SelectedSocketConfiguration.IPAdress;
            maskedTextBoxPort.Text = SelectedSocketConfiguration.Port.ToString();
            labelPackageSizeValue.Text = SelectedSocketConfiguration. PacketSize.ToString();
            labelSendDelayValue.Text = SelectedSocketConfiguration.SendDelay.ToString();
            _clientServer = (ClientServer)SelectedSocketConfiguration.ServerClient;

            trackBarPackageSize.Value = Convert.ToInt32(labelPackageSizeValue.Text);
            trackBarSendDelay.Value = Convert.ToInt32(labelSendDelayValue.Text);

            if (_clientServer == ClientServer.SERVER)
                radioButtonServer.Checked = true;
            else
                radioButtonClient.Checked = true;
        }

        /// <summary>
        /// GetSettingsFormUI
        /// </summary>
        void GetSettingsFormUI()
        {
            SelectedSocketConfiguration.IPAdress = textBoxTCPIPAddress.Text;
            SelectedSocketConfiguration.Port = Convert.ToInt32(maskedTextBoxPort.Text);
            SelectedSocketConfiguration.PacketSize = Convert.ToInt32(labelPackageSizeValue.Text);
            SelectedSocketConfiguration.SendDelay = Convert.ToInt32(labelSendDelayValue.Text);
            SelectedSocketConfiguration.ServerClient = (int)_clientServer;
        }

        /// <summary>
        /// EnableDisableControls
        /// </summary>
        public void EnableDisableControls()
        {
            switch (_clientServer)
            {
                case ClientServer.CLIENT:
                    textBoxTCPIPAddress.Enabled = true;
                    labelServerClient.Text = "Client";
                    trackBarPackageSize.Enabled = true;
                    trackBarSendDelay.Enabled = true;
                    labelPackageSize.Enabled = true;
                    labelPackageSizeValue.Enabled = true;
                    labelSendDelay.Enabled = true;
                    labelSendDelayValue.Enabled = true;
                    checkBoxAutoRecover.Enabled = true;
                    break;
                case ClientServer.SERVER:
                    textBoxTCPIPAddress.Enabled = false;
                    labelServerClient.Text = "Server";
                    trackBarPackageSize.Enabled = false;
                    trackBarSendDelay.Enabled = false;
                    labelPackageSize.Enabled = false;
                    labelPackageSizeValue.Enabled = false;
                    labelSendDelay.Enabled = false;
                    labelSendDelayValue.Enabled = false;
                    checkBoxAutoRecover.Enabled = false;
                    break;
            }
            if (IsStart)
            {
                toolStripButton_SaveConfig.Enabled = false;
                toolStripButton_LoadConfig.Enabled = false;

                textBoxTCPIPAddress.Enabled = false;
                trackBarPackageSize.Enabled = false;
                trackBarSendDelay.Enabled = false;
                labelPackageSize.Enabled = false;
                labelPackageSizeValue.Enabled = false;
                labelSendDelay.Enabled = false;
                labelSendDelayValue.Enabled = false;

                maskedTextBoxPort.Enabled = false;
                button_Start.Enabled = false;
                button_Stop.Enabled = !false;
                radioButtonServer.Enabled = false;
                radioButtonClient.Enabled = false;
            }
            else
            {
                if (_clientServer == ClientServer.CLIENT)
                {
                    textBoxTCPIPAddress.Enabled = true;
                    trackBarPackageSize.Enabled = true;
                    trackBarSendDelay.Enabled = true;
                    labelPackageSize.Enabled = true;
                    labelPackageSizeValue.Enabled = true;
                    labelSendDelay.Enabled = true;
                    labelSendDelayValue.Enabled = true;
                }
                toolStripButton_SaveConfig.Enabled = true;
                toolStripButton_LoadConfig.Enabled = true;
                maskedTextBoxPort.Enabled = true;
                button_Start.Enabled = true;
                button_Stop.Enabled = !true;
                radioButtonServer.Enabled = true;
                radioButtonClient.Enabled = true;
            }
        }

        /// <summary>
        /// UpdateProgressBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DUpdateProgressBar(object sender, EventArgs e);
        public void UpdateProgressBar(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                // syncron
                //Invoke(new DUpdateProgressBar(UpdateProgressBar), sender, e);
                // asyncron
                IAsyncResult res = BeginInvoke(new EventHandler(UpdateProgressBar), sender, e);
            }
            else
            {
                if (progressBarPerformance.Value >= ProgressBarMaximum)
                    progressBarPerformance.Value = ProgressBarMinimum;
                else
                    progressBarPerformance.Value++;

                labelPerformanceValue.Text = progressBarPerformance.Value.ToString();
            }
        }

        /// <summary>
        /// UpdateText
        /// </summary>
        /// <param name="strText"></param>
        public delegate void DUpdateText(String strText);
        public void UpdateText(String strText)
        {
            if (InvokeRequired)
            {
                // syncron
                //Invoke(new DUpdateText(UpdateText), new Object[] {strText});
                // asyncron
                IAsyncResult res = BeginInvoke(new DUpdateText(UpdateText), strText);
            }
            else
            {
                if (textBoxInfo.Text.Length > SelectedSocketConfiguration.MaxInfoTextLen)
                    textBoxInfo.Text = "";
                if (TheMinaTCPClient != null && strText == "Recover StressMinaSocket")
                {
                    TheMinaTCPClient.CloseMinaSocket();
                    TheMinaTCPClient = null;
                    TheMinaTCPClient = new MinaTCPClient(IPAddress.Parse(textBoxTCPIPAddress.Text), Convert.ToInt32(maskedTextBoxPort.Text.ToString()), UpdateText, UpdateProgressBar);
                    TheMinaTCPClient.StressMinaSocket(Convert.ToInt32(labelPackageSizeValue.Text), Convert.ToInt32(labelSendDelayValue.Text));
                }
                textBoxInfo.AppendText((++_counterMessage).ToString() + " " + strText + "\r\n");
            }
        }

        #endregion
    }

    #region Help Classes

    /// <summary>
    /// Class ProgressBarEvent
    /// </summary>
    public class ProgressBarEvent : EventArgs
    {

        public int Value { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProgressBarEvent()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"></param>
        public ProgressBarEvent(int value)
        {
            Value = value;
        }
    }

    #endregion
}
