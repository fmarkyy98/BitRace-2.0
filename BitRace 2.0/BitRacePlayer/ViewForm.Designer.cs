namespace BitRacePlayer
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.viewForm_statusStrip = new System.Windows.Forms.StatusStrip();
            this.sqlText_statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sql_statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacing_StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcpText_statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TCP_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacing_dtatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.error_statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.viewForm_tabControl = new System.Windows.Forms.TabControl();
            this.connectionName_tabPage = new System.Windows.Forms.TabPage();
            this.submitName_button = new System.Windows.Forms.Button();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.ipAdress_textBox = new System.Windows.Forms.TextBox();
            this.portNumberText_label = new System.Windows.Forms.Label();
            this.portNumber_textBox = new System.Windows.Forms.TextBox();
            this.ipAdressText_label = new System.Windows.Forms.Label();
            this.questionnaire_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.question_textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dText_label = new System.Windows.Forms.Label();
            this.cText_label = new System.Windows.Forms.Label();
            this.bText_label = new System.Windows.Forms.Label();
            this.aText_label = new System.Windows.Forms.Label();
            this.a_radioButton = new System.Windows.Forms.RadioButton();
            this.b_radioButton = new System.Windows.Forms.RadioButton();
            this.c_radioButton = new System.Windows.Forms.RadioButton();
            this.d_radioButton = new System.Windows.Forms.RadioButton();
            this.send_button = new System.Windows.Forms.Button();
            this.viewForm_timer = new System.Windows.Forms.Timer(this.components);
            this.viewForm_statusStrip.SuspendLayout();
            this.viewForm_tabControl.SuspendLayout();
            this.connectionName_tabPage.SuspendLayout();
            this.questionnaire_tabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewForm_statusStrip
            // 
            this.viewForm_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sqlText_statusLabel,
            this.sql_statusLabel,
            this.spacing_StatusLabel1,
            this.tcpText_statusLabel,
            this.TCP_StatusLabel,
            this.spacing_dtatusLabel2,
            this.error_statusLabel});
            this.viewForm_statusStrip.Location = new System.Drawing.Point(0, 340);
            this.viewForm_statusStrip.Name = "viewForm_statusStrip";
            this.viewForm_statusStrip.Size = new System.Drawing.Size(584, 22);
            this.viewForm_statusStrip.TabIndex = 1;
            this.viewForm_statusStrip.Text = "statusStrip1";
            // 
            // sqlText_statusLabel
            // 
            this.sqlText_statusLabel.Name = "sqlText_statusLabel";
            this.sqlText_statusLabel.Size = new System.Drawing.Size(60, 17);
            this.sqlText_statusLabel.Text = "SQL State:";
            // 
            // sql_statusLabel
            // 
            this.sql_statusLabel.AutoSize = false;
            this.sql_statusLabel.Name = "sql_statusLabel";
            this.sql_statusLabel.Size = new System.Drawing.Size(79, 17);
            this.sql_statusLabel.Text = "Disconnected";
            this.sql_statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spacing_StatusLabel1
            // 
            this.spacing_StatusLabel1.Name = "spacing_StatusLabel1";
            this.spacing_StatusLabel1.Size = new System.Drawing.Size(49, 17);
            this.spacing_StatusLabel1.Text = "              ";
            // 
            // tcpText_statusLabel
            // 
            this.tcpText_statusLabel.Name = "tcpText_statusLabel";
            this.tcpText_statusLabel.Size = new System.Drawing.Size(76, 17);
            this.tcpText_statusLabel.Text = "TCP/IP State:";
            // 
            // TCP_StatusLabel
            // 
            this.TCP_StatusLabel.Name = "TCP_StatusLabel";
            this.TCP_StatusLabel.Size = new System.Drawing.Size(79, 17);
            this.TCP_StatusLabel.Text = "Disconnected";
            // 
            // spacing_dtatusLabel2
            // 
            this.spacing_dtatusLabel2.Name = "spacing_dtatusLabel2";
            this.spacing_dtatusLabel2.Size = new System.Drawing.Size(49, 17);
            this.spacing_dtatusLabel2.Text = "              ";
            // 
            // error_statusLabel
            // 
            this.error_statusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.error_statusLabel.ForeColor = System.Drawing.Color.Red;
            this.error_statusLabel.Name = "error_statusLabel";
            this.error_statusLabel.Size = new System.Drawing.Size(94, 17);
            this.error_statusLabel.Text = "                             ";
            // 
            // viewForm_tabControl
            // 
            this.viewForm_tabControl.Controls.Add(this.connectionName_tabPage);
            this.viewForm_tabControl.Controls.Add(this.questionnaire_tabPage);
            this.viewForm_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewForm_tabControl.Location = new System.Drawing.Point(0, 0);
            this.viewForm_tabControl.Name = "viewForm_tabControl";
            this.viewForm_tabControl.SelectedIndex = 0;
            this.viewForm_tabControl.Size = new System.Drawing.Size(584, 340);
            this.viewForm_tabControl.TabIndex = 2;
            // 
            // connectionName_tabPage
            // 
            this.connectionName_tabPage.Controls.Add(this.submitName_button);
            this.connectionName_tabPage.Controls.Add(this.name_textBox);
            this.connectionName_tabPage.Controls.Add(this.connect_button);
            this.connectionName_tabPage.Controls.Add(this.ipAdress_textBox);
            this.connectionName_tabPage.Controls.Add(this.portNumberText_label);
            this.connectionName_tabPage.Controls.Add(this.portNumber_textBox);
            this.connectionName_tabPage.Controls.Add(this.ipAdressText_label);
            this.connectionName_tabPage.Location = new System.Drawing.Point(4, 22);
            this.connectionName_tabPage.Name = "connectionName_tabPage";
            this.connectionName_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectionName_tabPage.Size = new System.Drawing.Size(576, 314);
            this.connectionName_tabPage.TabIndex = 0;
            this.connectionName_tabPage.Text = "Connection & Name";
            this.connectionName_tabPage.UseVisualStyleBackColor = true;
            // 
            // submitName_button
            // 
            this.submitName_button.Location = new System.Drawing.Point(365, 38);
            this.submitName_button.Name = "submitName_button";
            this.submitName_button.Size = new System.Drawing.Size(82, 23);
            this.submitName_button.TabIndex = 12;
            this.submitName_button.Text = "Submit Name";
            this.submitName_button.UseVisualStyleBackColor = true;
            this.submitName_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // name_textBox
            // 
            this.name_textBox.Location = new System.Drawing.Point(112, 40);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(247, 20);
            this.name_textBox.TabIndex = 11;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(333, 186);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(75, 36);
            this.connect_button.TabIndex = 10;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // ipAdress_textBox
            // 
            this.ipAdress_textBox.Location = new System.Drawing.Point(85, 202);
            this.ipAdress_textBox.Name = "ipAdress_textBox";
            this.ipAdress_textBox.Size = new System.Drawing.Size(100, 20);
            this.ipAdress_textBox.TabIndex = 6;
            this.ipAdress_textBox.Text = "127.0.0.1";
            // 
            // portNumberText_label
            // 
            this.portNumberText_label.AutoSize = true;
            this.portNumberText_label.Location = new System.Drawing.Point(206, 186);
            this.portNumberText_label.Name = "portNumberText_label";
            this.portNumberText_label.Size = new System.Drawing.Size(69, 13);
            this.portNumberText_label.TabIndex = 9;
            this.portNumberText_label.Text = "Port Number:";
            // 
            // portNumber_textBox
            // 
            this.portNumber_textBox.Location = new System.Drawing.Point(209, 202);
            this.portNumber_textBox.Name = "portNumber_textBox";
            this.portNumber_textBox.Size = new System.Drawing.Size(100, 20);
            this.portNumber_textBox.TabIndex = 7;
            this.portNumber_textBox.Text = "8912";
            // 
            // ipAdressText_label
            // 
            this.ipAdressText_label.AutoSize = true;
            this.ipAdressText_label.Location = new System.Drawing.Point(82, 186);
            this.ipAdressText_label.Name = "ipAdressText_label";
            this.ipAdressText_label.Size = new System.Drawing.Size(55, 13);
            this.ipAdressText_label.TabIndex = 8;
            this.ipAdressText_label.Text = "IP Adress:";
            // 
            // questionnaire_tabPage
            // 
            this.questionnaire_tabPage.Controls.Add(this.tableLayoutPanel1);
            this.questionnaire_tabPage.Location = new System.Drawing.Point(4, 22);
            this.questionnaire_tabPage.Name = "questionnaire_tabPage";
            this.questionnaire_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.questionnaire_tabPage.Size = new System.Drawing.Size(576, 314);
            this.questionnaire_tabPage.TabIndex = 1;
            this.questionnaire_tabPage.Text = "Questionnaire";
            this.questionnaire_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.question_textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 308);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // question_textBox
            // 
            this.question_textBox.BackColor = System.Drawing.Color.White;
            this.question_textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.question_textBox.Location = new System.Drawing.Point(3, 3);
            this.question_textBox.Multiline = true;
            this.question_textBox.Name = "question_textBox";
            this.question_textBox.ReadOnly = true;
            this.question_textBox.Size = new System.Drawing.Size(564, 178);
            this.question_textBox.TabIndex = 4;
            this.question_textBox.Text = "Questin 1.";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.send_button, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 187);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(564, 118);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.90909F));
            this.tableLayoutPanel3.Controls.Add(this.dText_label, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.cText_label, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.bText_label, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.aText_label, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.a_radioButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.b_radioButton, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.c_radioButton, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.d_radioButton, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(473, 112);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // dText_label
            // 
            this.dText_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dText_label.Location = new System.Drawing.Point(3, 89);
            this.dText_label.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dText_label.Name = "dText_label";
            this.dText_label.Size = new System.Drawing.Size(36, 20);
            this.dText_label.TabIndex = 6;
            this.dText_label.Text = "d:";
            this.dText_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cText_label
            // 
            this.cText_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cText_label.Location = new System.Drawing.Point(3, 61);
            this.cText_label.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cText_label.Name = "cText_label";
            this.cText_label.Size = new System.Drawing.Size(36, 20);
            this.cText_label.TabIndex = 4;
            this.cText_label.Text = "c:";
            this.cText_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bText_label
            // 
            this.bText_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bText_label.Location = new System.Drawing.Point(3, 33);
            this.bText_label.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.bText_label.Name = "bText_label";
            this.bText_label.Size = new System.Drawing.Size(36, 20);
            this.bText_label.TabIndex = 2;
            this.bText_label.Text = "b:";
            this.bText_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // aText_label
            // 
            this.aText_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aText_label.Location = new System.Drawing.Point(3, 5);
            this.aText_label.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.aText_label.Name = "aText_label";
            this.aText_label.Size = new System.Drawing.Size(36, 20);
            this.aText_label.TabIndex = 0;
            this.aText_label.Text = "a:";
            this.aText_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // a_radioButton
            // 
            this.a_radioButton.AutoSize = true;
            this.a_radioButton.Location = new System.Drawing.Point(45, 3);
            this.a_radioButton.Name = "a_radioButton";
            this.a_radioButton.Size = new System.Drawing.Size(37, 17);
            this.a_radioButton.TabIndex = 7;
            this.a_radioButton.TabStop = true;
            this.a_radioButton.Text = "a1";
            this.a_radioButton.UseVisualStyleBackColor = true;
            // 
            // b_radioButton
            // 
            this.b_radioButton.AutoSize = true;
            this.b_radioButton.Location = new System.Drawing.Point(45, 31);
            this.b_radioButton.Name = "b_radioButton";
            this.b_radioButton.Size = new System.Drawing.Size(37, 17);
            this.b_radioButton.TabIndex = 8;
            this.b_radioButton.TabStop = true;
            this.b_radioButton.Text = "a2";
            this.b_radioButton.UseVisualStyleBackColor = true;
            // 
            // c_radioButton
            // 
            this.c_radioButton.AutoSize = true;
            this.c_radioButton.Location = new System.Drawing.Point(45, 59);
            this.c_radioButton.Name = "c_radioButton";
            this.c_radioButton.Size = new System.Drawing.Size(37, 17);
            this.c_radioButton.TabIndex = 9;
            this.c_radioButton.TabStop = true;
            this.c_radioButton.Text = "a3";
            this.c_radioButton.UseVisualStyleBackColor = true;
            // 
            // d_radioButton
            // 
            this.d_radioButton.AutoSize = true;
            this.d_radioButton.Location = new System.Drawing.Point(45, 87);
            this.d_radioButton.Name = "d_radioButton";
            this.d_radioButton.Size = new System.Drawing.Size(37, 17);
            this.d_radioButton.TabIndex = 10;
            this.d_radioButton.TabStop = true;
            this.d_radioButton.Text = "a4";
            this.d_radioButton.UseVisualStyleBackColor = true;
            // 
            // send_button
            // 
            this.send_button.AutoSize = true;
            this.send_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.send_button.Location = new System.Drawing.Point(482, 3);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(79, 112);
            this.send_button.TabIndex = 7;
            this.send_button.Text = "Send Answer";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // viewForm_timer
            // 
            this.viewForm_timer.Tick += new System.EventHandler(this.viewForm_timer_Tick);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.viewForm_tabControl);
            this.Controls.Add(this.viewForm_statusStrip);
            this.Name = "ViewForm";
            this.Text = "Form1";
            this.viewForm_statusStrip.ResumeLayout(false);
            this.viewForm_statusStrip.PerformLayout();
            this.viewForm_tabControl.ResumeLayout(false);
            this.connectionName_tabPage.ResumeLayout(false);
            this.connectionName_tabPage.PerformLayout();
            this.questionnaire_tabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip viewForm_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sqlText_statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel sql_statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel spacing_StatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tcpText_statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel TCP_StatusLabel;
        private System.Windows.Forms.TabControl viewForm_tabControl;
        private System.Windows.Forms.TabPage connectionName_tabPage;
        private System.Windows.Forms.TabPage questionnaire_tabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox question_textBox;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.TextBox ipAdress_textBox;
        private System.Windows.Forms.Label portNumberText_label;
        private System.Windows.Forms.TextBox portNumber_textBox;
        private System.Windows.Forms.Label ipAdressText_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label dText_label;
        private System.Windows.Forms.Label cText_label;
        private System.Windows.Forms.Label bText_label;
        private System.Windows.Forms.Label aText_label;
        private System.Windows.Forms.RadioButton a_radioButton;
        private System.Windows.Forms.RadioButton b_radioButton;
        private System.Windows.Forms.RadioButton c_radioButton;
        private System.Windows.Forms.RadioButton d_radioButton;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Timer viewForm_timer;
        private System.Windows.Forms.Button submitName_button;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.ToolStripStatusLabel spacing_dtatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel error_statusLabel;
    }
}

