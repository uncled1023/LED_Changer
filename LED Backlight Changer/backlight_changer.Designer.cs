namespace WindowsFormsApplication1
{
    partial class Backlight_Changer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backlight_Changer));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.start_stop = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.com_port = new System.Windows.Forms.ComboBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pattern_select = new System.Windows.Forms.ComboBox();
            this.color_mode = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.custom_color = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.custom_color_2 = new System.Windows.Forms.TextBox();
            this.screen_select = new System.Windows.Forms.ComboBox();
            this.speed_track = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.color_delay_track = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_track)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_delay_track)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // start_stop
            // 
            this.start_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.start_stop.Location = new System.Drawing.Point(100, 41);
            this.start_stop.Name = "start_stop";
            this.start_stop.Size = new System.Drawing.Size(75, 23);
            this.start_stop.TabIndex = 0;
            this.start_stop.UseVisualStyleBackColor = true;
            this.start_stop.Click += new System.EventHandler(this.start_stop_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Background LED Changer ";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 411);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 60);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port";
            // 
            // com_port
            // 
            this.com_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_port.FormattingEnabled = true;
            this.com_port.Location = new System.Drawing.Point(12, 25);
            this.com_port.Name = "com_port";
            this.com_port.Size = new System.Drawing.Size(64, 21);
            this.com_port.Sorted = true;
            this.com_port.TabIndex = 3;
            // 
            // connect_button
            // 
            this.connect_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connect_button.Location = new System.Drawing.Point(100, 12);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(75, 23);
            this.connect_button.TabIndex = 4;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Color Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pattern";
            // 
            // pattern_select
            // 
            this.pattern_select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pattern_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pattern_select.FormattingEnabled = true;
            this.pattern_select.Items.AddRange(new object[] {
            "Solid",
            "Blink"});
            this.pattern_select.Location = new System.Drawing.Point(12, 224);
            this.pattern_select.Name = "pattern_select";
            this.pattern_select.Size = new System.Drawing.Size(163, 21);
            this.pattern_select.TabIndex = 7;
            // 
            // color_mode
            // 
            this.color_mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.color_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.color_mode.FormattingEnabled = true;
            this.color_mode.Items.AddRange(new object[] {
            "Average",
            "Custom"});
            this.color_mode.Location = new System.Drawing.Point(12, 119);
            this.color_mode.Name = "color_mode";
            this.color_mode.Size = new System.Drawing.Size(163, 21);
            this.color_mode.TabIndex = 8;
            // 
            // custom_color
            // 
            this.custom_color.Enabled = false;
            this.custom_color.Location = new System.Drawing.Point(12, 149);
            this.custom_color.Name = "custom_color";
            this.custom_color.Size = new System.Drawing.Size(61, 20);
            this.custom_color.TabIndex = 9;
            this.custom_color.Text = "#000000";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(79, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Select Color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current LED Color";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(79, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Select Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // custom_color_2
            // 
            this.custom_color_2.Enabled = false;
            this.custom_color_2.Location = new System.Drawing.Point(12, 175);
            this.custom_color_2.Name = "custom_color_2";
            this.custom_color_2.Size = new System.Drawing.Size(61, 20);
            this.custom_color_2.TabIndex = 12;
            this.custom_color_2.Text = "#000000";
            this.custom_color_2.TextChanged += new System.EventHandler(this.custom_color_2_TextChanged);
            // 
            // screen_select
            // 
            this.screen_select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screen_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screen_select.FormattingEnabled = true;
            this.screen_select.Location = new System.Drawing.Point(12, 70);
            this.screen_select.Name = "screen_select";
            this.screen_select.Size = new System.Drawing.Size(163, 21);
            this.screen_select.TabIndex = 14;
            // 
            // speed_track
            // 
            this.speed_track.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speed_track.Location = new System.Drawing.Point(12, 274);
            this.speed_track.Maximum = 100;
            this.speed_track.Minimum = 1;
            this.speed_track.Name = "speed_track";
            this.speed_track.Size = new System.Drawing.Size(163, 45);
            this.speed_track.TabIndex = 15;
            this.speed_track.TickFrequency = 5;
            this.speed_track.Value = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Gradiant Speed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Color Delay";
            // 
            // color_delay_track
            // 
            this.color_delay_track.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.color_delay_track.Location = new System.Drawing.Point(12, 338);
            this.color_delay_track.Maximum = 100;
            this.color_delay_track.Minimum = 1;
            this.color_delay_track.Name = "color_delay_track";
            this.color_delay_track.Size = new System.Drawing.Size(163, 45);
            this.color_delay_track.TabIndex = 17;
            this.color_delay_track.TickFrequency = 5;
            this.color_delay_track.Value = 50;
            this.color_delay_track.Scroll += new System.EventHandler(this.color_delay_track_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 483);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.color_delay_track);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.speed_track);
            this.Controls.Add(this.screen_select);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.custom_color_2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.custom_color);
            this.Controls.Add(this.color_mode);
            this.Controls.Add(this.pattern_select);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.com_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.start_stop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(203, 521);
            this.Name = "Form1";
            this.Text = "Backlight Control Panel";
            this.Load += new System.EventHandler(this.Backlight_Changer_Load);
            this.Shown += new System.EventHandler(this.Backlight_Changer_Shown);
            this.ResizeEnd += new System.EventHandler(this.Backlight_Changer_ResizeEnd);
            this.Resize += new System.EventHandler(this.Backlight_Changer_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_track)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_delay_track)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button start_stop;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com_port;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox pattern_select;
        private System.Windows.Forms.ComboBox color_mode;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox custom_color;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox custom_color_2;
        private System.Windows.Forms.ComboBox screen_select;
        private System.Windows.Forms.TrackBar speed_track;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar color_delay_track;
    }
}

