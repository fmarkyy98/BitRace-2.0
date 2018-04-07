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
using static BitRacePlayer.Enums;
using static BitRacePlayer.Enums.ConnectionState;
using static BitRacePlayer.Enums.ConnectionType;

namespace BitRacePlayer
{
    public partial class ViewForm : Form
    {
        Socket connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        IPEndPoint ipEndPoint;
        string name;
        public ViewForm()
        {
            InitializeComponent();
            changeConnectionState(MSSQL, disconnected);
            changeConnectionState(TCPIP, disconnected);
            submitName_button.Enabled = false;
            send_button.Enabled = false;
        }

        private void changeConnectionState(ConnectionType connectionType, Enums.ConnectionState connectionState)
        {
            ToolStripStatusLabel selectedLabel = null;
            Color selectedColor = Color.Gray;

            switch (connectionType)
            {
                case MSSQL:
                    selectedLabel = sql_statusLabel;
                    break;
                case TCPIP:
                    selectedLabel = TCP_StatusLabel;
                    break;
            }
            switch (connectionState)
            {
                case disconnected:
                    selectedColor = Color.Red;
                    if (connectionType == TCPIP)
                    {
                        connect_button.Enabled = true;
                        viewForm_timer.Stop();
                    }
                    break;
                case building:
                    selectedColor = Color.Orange;
                    if (connectionType == TCPIP) { connect_button.Enabled = false; }
                    break;
                case connected:
                    selectedColor = Color.Green;
                    if (connectionType == TCPIP)
                    {
                        connect_button.Enabled = false;
                        viewForm_timer.Start();
                    }
                    break;
            }
            selectedLabel.Text = connectionState.ToString();
            selectedLabel.ForeColor = selectedColor;
            Application.DoEvents();
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            IPAddress hostIP = null;
            int requiredPort;
            IPAddress.TryParse(ipAdress_textBox.Text, out hostIP);
            int.TryParse(portNumber_textBox.Text, out requiredPort);
            ipEndPoint = new IPEndPoint(hostIP, requiredPort);
            try
            {
                if (connection.IsBound && !connection.Connected)
                {
                    connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
                changeConnectionState(TCPIP, building);
                connection.Connect(ipEndPoint);
            }
            catch (SocketException)
            {
                changeConnectionState(TCPIP, disconnected);
                return;
            }
            changeConnectionState(TCPIP, connected);
            connection.Send(Encoding.ASCII.GetBytes("mssql"));
            submitName_button.Enabled = true;
            if (name != null)
            {
                string message = $"register;{name}";
                byte[] data = Encoding.ASCII.GetBytes(message);
                try
                {
                    connection.Send(data);
                }
                catch (SocketException)
                {
                    changeConnectionState(TCPIP, disconnected);
                }
            }
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"If you choose this name:{name_textBox.Text} you won't be able to change. Are you sure about your choice?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            name = name_textBox.Text;            
            submitName_button.Enabled = false;
            name_textBox.ReadOnly = true;

            string message = $"register;{name}";
            byte[] data = Encoding.ASCII.GetBytes(message);
            try
            {
                connection.Send(data);
            }
            catch (SocketException)
            {
                changeConnectionState(TCPIP, disconnected);
            }
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            error_statusLabel.Text = "";
            DialogResult dr = MessageBox.Show("Are you sure about your choice?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            string message = $"answer;{name};";
            if (a_radioButton.Checked)
            {
                message += "a";
            }
            else if (b_radioButton.Checked)
            {
                message += "b";
            }
            else if (c_radioButton.Checked)
            {
                message += "c";
            }
            else if (d_radioButton.Checked)
            {
                message += "d";
            }
            else
            {
                error_statusLabel.Text = "No answer choosen.";
                return;
            }

            byte[] data = Encoding.ASCII.GetBytes(message);
            try
            {
                connection.Send(data);
            }
            catch (SocketException)
            {
                changeConnectionState(TCPIP, disconnected);
            }
        }

        private void viewForm_timer_Tick(object sender, EventArgs e)
        {
            if (!connection.Poll(0, SelectMode.SelectRead))
            {
                return;
            }
            try
            {
                byte[] buffer = new byte[1024];
                int recieveSize = connection.Receive(buffer);
                string input = Encoding.ASCII.GetString(buffer, 0, recieveSize);
                string[] splitedInput = input.Split(';');

                if (splitedInput[0] == "mssql")
                {
                    ConnectionType currentConnectionType = MSSQL;
                    Enums.ConnectionState currentConnectionState = ToConnectionState(splitedInput[1]);
                    changeConnectionState(currentConnectionType, currentConnectionState);
                }
                else if (splitedInput[0] == "question")
                {
                    if (!send_button.Enabled) { send_button.Enabled = true; }
                    question_textBox.Text = splitedInput[1];
                    a_radioButton.Text = splitedInput[2];
                    b_radioButton.Text = splitedInput[3];
                    c_radioButton.Text = splitedInput[4];
                    d_radioButton.Text = splitedInput[5];
                }
            }
            catch (SocketException)
            {
                connection.Shutdown(SocketShutdown.Both);
                connection.Close();
                changeConnectionState(TCPIP, disconnected);
                changeConnectionState(MSSQL, disconnected);
            }
        }
    }
}
