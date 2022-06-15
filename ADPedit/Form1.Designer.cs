
namespace ADPedit
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TimeValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AdpValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.adpTrig = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Realtime1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Realtime2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFunctionAtPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showUnk = new System.Windows.Forms.ToolStripMenuItem();
            this.showFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.showTriggerUnknownValToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showValue = new System.Windows.Forms.ToolStripMenuItem();
            this.macrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBTo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToonFixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_ALT_edit = new System.Windows.Forms.CheckBox();
            this.checkBox_ALT = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeValue
            // 
            this.TimeValue.Location = new System.Drawing.Point(56, 67);
            this.TimeValue.Margin = new System.Windows.Forms.Padding(2);
            this.TimeValue.Name = "TimeValue";
            this.TimeValue.Size = new System.Drawing.Size(102, 20);
            this.TimeValue.TabIndex = 3;
            this.TimeValue.Text = "0";
            this.toolTip1.SetToolTip(this.TimeValue, "The frame on which this command will run.\r\nFrames for this setting are always cou" +
        "nted in 60fps, \r\neven when the framerate is limited.");
            this.TimeValue.TextChanged += new System.EventHandler(this.TimeValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Value:";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 232);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.MaximumSize = new System.Drawing.Size(698, 790);
            this.listBox1.MinimumSize = new System.Drawing.Size(350, 355);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(350, 368);
            this.listBox1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.listBox1, "This is the collection of ADP Functions found\r\nin the currently selected ADP file" +
        ".");
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 628);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.MaximumSize = new System.Drawing.Size(648, 28);
            this.label2.MinimumSize = new System.Drawing.Size(324, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Program by Jay39w. Special thanks to BroGamer and korenkonder!\r\nUpdated by CyberK" +
    "evin";
            this.toolTip1.SetToolTip(this.label2, "Huge thanks to BroGamer for helping me\r\nwith the code used in this project!\r\nAlso" +
        " many thanks to korenkonder for figuring\r\nout the header format for ADP files!");
            // 
            // AdpValue
            // 
            this.AdpValue.Location = new System.Drawing.Point(56, 106);
            this.AdpValue.Margin = new System.Windows.Forms.Padding(2);
            this.AdpValue.Name = "AdpValue";
            this.AdpValue.Size = new System.Drawing.Size(102, 20);
            this.AdpValue.TabIndex = 7;
            this.AdpValue.Text = "0";
            this.toolTip1.SetToolTip(this.AdpValue, "The value you would like to use for the function.\r\nDecimal values are acceptable." +
        "");
            this.AdpValue.TextChanged += new System.EventHandler(this.AdpValue_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Frame:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Brightness",
            "Generic Lighting",
            "Stage Lighting",
            "---",
            "Character Lighting",
            "Character Lightness",
            "Character Light (RED)",
            "Character Light (GREEN)",
            "Character Light (BLUE)",
            "Character Color (RED)",
            "Character Color (GREEN)",
            "Character Color (BLUE)",
            "Skin Shine",
            "Inner Skin Shine",
            "Shadow Intensity",
            "Shadow Opacity",
            "Skin Toon Intensity",
            "BLINN Lighting",
            "Cloth Lighting",
            "Item/Facial Lighting",
            "Hair Lighting",
            "Hair Shine",
            "Eye Lighting",
            "Eye Colour Saturation",
            "Reflection (RED)",
            "Reflection (GREEN)",
            "Reflection (BLUE)",
            "---",
            "Celshading Thickness",
            "Celshading Body",
            "Celshading Clothes/Hair",
            "Celshading Eyelid",
            "Spec. Map Transparency",
            "Bloom",
            "Dimness",
            "---",
            "Handheld 30FPS Limit",
            "Docked 30FPS Limit",
            "Handheld Resolution",
            "Docked Resolution",
            "Alternative PV flag"});
            this.comboBox1.Location = new System.Drawing.Point(19, 34);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.comboBox1, "The function you would like to add to the ADP.");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_ALT_edit);
            this.groupBox1.Controls.Add(this.adpTrig);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.Realtime1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TimeValue);
            this.groupBox1.Controls.Add(this.AdpValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(169, 203);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // adpTrig
            // 
            this.adpTrig.Location = new System.Drawing.Point(56, 155);
            this.adpTrig.Margin = new System.Windows.Forms.Padding(2);
            this.adpTrig.Name = "adpTrig";
            this.adpTrig.Size = new System.Drawing.Size(102, 20);
            this.adpTrig.TabIndex = 20;
            this.adpTrig.Text = "0";
            this.toolTip1.SetToolTip(this.adpTrig, "The value you would like to use for the function.\r\nDecimal values are acceptable." +
        "");
            this.adpTrig.TextChanged += new System.EventHandler(this.adpTrig_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Trig:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(60, 126);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Enable/Disable";
            this.toolTip1.SetToolTip(this.checkBox1, "Check this box to enable the function.\r\nUncheck this box to disable it.");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Realtime1
            // 
            this.Realtime1.AutoSize = true;
            this.Realtime1.Location = new System.Drawing.Point(120, 88);
            this.Realtime1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Realtime1.Name = "Realtime1";
            this.Realtime1.Size = new System.Drawing.Size(13, 13);
            this.Realtime1.TabIndex = 16;
            this.Realtime1.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 88);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Secs:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Brightness",
            "Generic Lighting",
            "Stage Lighting",
            "---",
            "Character Lighting",
            "Character Lightness",
            "Character Light (RED)",
            "Character Light (GREEN)",
            "Character Light (BLUE)",
            "Character Color (RED)",
            "Character Color (GREEN)",
            "Character Color (BLUE)",
            "Skin Shine",
            "Inner Skin Shine",
            "Shadow Intensity",
            "Shadow Opacity",
            "Skin Toon Intensity",
            "BLINN Lighting",
            "Cloth Lighting",
            "Item/Facial Lighting",
            "Hair Lighting",
            "Hair Shine",
            "Eye Lighting",
            "Eye Colour Saturation",
            "Reflection (RED)",
            "Reflection (GREEN)",
            "Reflection (BLUE)",
            "---",
            "Celshading Thickness",
            "Celshading Body",
            "Celshading Clothes/Hair",
            "Celshading Eyelid",
            "Spec. Map Transparency",
            "Bloom",
            "Dimness",
            "---",
            "Handheld 30FPS Limit",
            "Docked 30FPS Limit",
            "Handheld Resolution",
            "Docked Resolution",
            "Alternative PV flag"});
            this.comboBox2.Location = new System.Drawing.Point(15, 34);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 13;
            this.toolTip1.SetToolTip(this.comboBox2, "The function you would like to add to the ADP.");
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Function Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBox_ALT);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Realtime2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(184, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(173, 203);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(56, 155);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(102, 20);
            this.textBox3.TabIndex = 22;
            this.textBox3.Text = "0";
            this.toolTip1.SetToolTip(this.textBox3, "The value you would like to use for the function.\r\nDecimal values are acceptable." +
        "");
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(64, 126);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(99, 17);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Enable/Disable";
            this.toolTip1.SetToolTip(this.checkBox2, "Check this box to enable the function.\r\nUncheck this box to disable it.\r\n");
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 158);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Trig:";
            // 
            // Realtime2
            // 
            this.Realtime2.AutoSize = true;
            this.Realtime2.Location = new System.Drawing.Point(122, 88);
            this.Realtime2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Realtime2.Name = "Realtime2";
            this.Realtime2.Size = new System.Drawing.Size(13, 13);
            this.Realtime2.TabIndex = 18;
            this.Realtime2.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 88);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Secs:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Function Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Frame:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 106);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(99, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "0";
            this.toolTip1.SetToolTip(this.textBox2, "The value you would like to use for the function.\r\nDecimal values are acceptable." +
        "");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 67);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0";
            this.toolTip1.SetToolTip(this.textBox1, "The frame on which this command will run.\r\nFrames for this setting are always cou" +
        "nted in 60fps, \r\neven when the framerate is limited.\r\n");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.macrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(368, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.toolTip1.SetToolTip(this.menuStrip1, "File - Open or Save files and Exit the application.\r\nCreate - Options relating to" +
        " the \'Create\' function area.");
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.saveToolStripMenuItem.Text = "Save As...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Visible = false;
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFunctionAtPosToolStripMenuItem,
            this.removeSelectedFunctionToolStripMenuItem});
            this.createToolStripMenuItem.Enabled = false;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // addFunctionAtPosToolStripMenuItem
            // 
            this.addFunctionAtPosToolStripMenuItem.Name = "addFunctionAtPosToolStripMenuItem";
            this.addFunctionAtPosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addFunctionAtPosToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.addFunctionAtPosToolStripMenuItem.Text = "Add Function at Pos.";
            this.addFunctionAtPosToolStripMenuItem.Click += new System.EventHandler(this.addFunctionAtPosToolStripMenuItem_Click);
            // 
            // removeSelectedFunctionToolStripMenuItem
            // 
            this.removeSelectedFunctionToolStripMenuItem.Name = "removeSelectedFunctionToolStripMenuItem";
            this.removeSelectedFunctionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.removeSelectedFunctionToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.removeSelectedFunctionToolStripMenuItem.Text = "Remove Selected Function";
            this.removeSelectedFunctionToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedFunctionToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUnk,
            this.showFrame,
            this.showTriggerUnknownValToolStripMenuItem,
            this.showValue});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // showUnk
            // 
            this.showUnk.Checked = true;
            this.showUnk.CheckOnClick = true;
            this.showUnk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showUnk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showUnk.Name = "showUnk";
            this.showUnk.Size = new System.Drawing.Size(214, 22);
            this.showUnk.Text = "Show Unknown Functions";
            this.showUnk.Click += new System.EventHandler(this.showUnk_Click);
            // 
            // showFrame
            // 
            this.showFrame.Checked = true;
            this.showFrame.CheckOnClick = true;
            this.showFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showFrame.Name = "showFrame";
            this.showFrame.Size = new System.Drawing.Size(214, 22);
            this.showFrame.Text = "Show Frame on List";
            this.showFrame.Click += new System.EventHandler(this.showFrame_Click);
            // 
            // showTriggerUnknownValToolStripMenuItem
            // 
            this.showTriggerUnknownValToolStripMenuItem.Checked = true;
            this.showTriggerUnknownValToolStripMenuItem.CheckOnClick = true;
            this.showTriggerUnknownValToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTriggerUnknownValToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showTriggerUnknownValToolStripMenuItem.Name = "showTriggerUnknownValToolStripMenuItem";
            this.showTriggerUnknownValToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showTriggerUnknownValToolStripMenuItem.Text = "Show Trigger Unknown Val";
            this.showTriggerUnknownValToolStripMenuItem.Click += new System.EventHandler(this.showTriggerUnknownValToolStripMenuItem_Click);
            // 
            // showValue
            // 
            this.showValue.Checked = true;
            this.showValue.CheckOnClick = true;
            this.showValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showValue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showValue.Name = "showValue";
            this.showValue.Size = new System.Drawing.Size(214, 22);
            this.showValue.Text = "Show Value on List";
            this.showValue.Click += new System.EventHandler(this.showValue_Click);
            // 
            // macrosToolStripMenuItem
            // 
            this.macrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBTo1ToolStripMenuItem,
            this.disableRGBToolStripMenuItem,
            this.simpleResolutionToolStripMenuItem,
            this.darkToonFixToolStripMenuItem,
            this.frameToolStripMenuItem1,
            this.frameToolStripMenuItem});
            this.macrosToolStripMenuItem.Enabled = false;
            this.macrosToolStripMenuItem.Name = "macrosToolStripMenuItem";
            this.macrosToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.macrosToolStripMenuItem.Text = "Macros";
            // 
            // rGBTo1ToolStripMenuItem
            // 
            this.rGBTo1ToolStripMenuItem.Name = "rGBTo1ToolStripMenuItem";
            this.rGBTo1ToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.rGBTo1ToolStripMenuItem.Text = "Set RGB To 1";
            this.rGBTo1ToolStripMenuItem.Click += new System.EventHandler(this.rGBTo1ToolStripMenuItem_Click);
            // 
            // disableRGBToolStripMenuItem
            // 
            this.disableRGBToolStripMenuItem.Name = "disableRGBToolStripMenuItem";
            this.disableRGBToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.disableRGBToolStripMenuItem.Text = "Disable RGB";
            this.disableRGBToolStripMenuItem.Click += new System.EventHandler(this.disableRGBToolStripMenuItem_Click);
            // 
            // simpleResolutionToolStripMenuItem
            // 
            this.simpleResolutionToolStripMenuItem.Name = "simpleResolutionToolStripMenuItem";
            this.simpleResolutionToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.simpleResolutionToolStripMenuItem.Text = "Apply Standard Resolutions";
            this.simpleResolutionToolStripMenuItem.Click += new System.EventHandler(this.simpleResolutionToolStripMenuItem_Click);
            // 
            // darkToonFixToolStripMenuItem
            // 
            this.darkToonFixToolStripMenuItem.Name = "darkToonFixToolStripMenuItem";
            this.darkToonFixToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.darkToonFixToolStripMenuItem.Text = "Dark Stage Preset";
            this.darkToonFixToolStripMenuItem.Click += new System.EventHandler(this.darkToonFixToolStripMenuItem_Click);
            // 
            // frameToolStripMenuItem1
            // 
            this.frameToolStripMenuItem1.Name = "frameToolStripMenuItem1";
            this.frameToolStripMenuItem1.Size = new System.Drawing.Size(284, 22);
            this.frameToolStripMenuItem1.Text = "Frame to apply to:";
            // 
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.frameToolStripMenuItem.Text = "0";
            this.frameToolStripMenuItem.ToolTipText = "The frame on which you\'d like the macro to run";
            // 
            // checkBox_ALT_edit
            // 
            this.checkBox_ALT_edit.AutoSize = true;
            this.checkBox_ALT_edit.Location = new System.Drawing.Point(60, 179);
            this.checkBox_ALT_edit.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ALT_edit.Name = "checkBox_ALT_edit";
            this.checkBox_ALT_edit.Size = new System.Drawing.Size(55, 17);
            this.checkBox_ALT_edit.TabIndex = 21;
            this.checkBox_ALT_edit.Text = "Alt PV";
            this.toolTip1.SetToolTip(this.checkBox_ALT_edit, "Check this box to enable the function.\r\nUncheck this box to disable it.");
            this.checkBox_ALT_edit.UseVisualStyleBackColor = true;
            this.checkBox_ALT_edit.CheckedChanged += new System.EventHandler(this.checkBox_ALT_edit_CheckedChanged);
            // 
            // checkBox_ALT
            // 
            this.checkBox_ALT.AutoSize = true;
            this.checkBox_ALT.Location = new System.Drawing.Point(64, 179);
            this.checkBox_ALT.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ALT.Name = "checkBox_ALT";
            this.checkBox_ALT.Size = new System.Drawing.Size(55, 17);
            this.checkBox_ALT.TabIndex = 22;
            this.checkBox_ALT.Text = "Alt PV";
            this.toolTip1.SetToolTip(this.checkBox_ALT, "Check this box to enable the function.\r\nUncheck this box to disable it.");
            this.checkBox_ALT.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(368, 657);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 816);
            this.MinimumSize = new System.Drawing.Size(384, 656);
            this.Name = "Form1";
            this.Text = "ADPEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TimeValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AdpValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Realtime1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Realtime2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFunctionAtPosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showUnk;
        private System.Windows.Forms.ToolStripMenuItem showFrame;
        private System.Windows.Forms.ToolStripMenuItem showValue;
        private System.Windows.Forms.ToolStripMenuItem macrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBTo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleResolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToonFixToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox frameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTriggerUnknownValToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox adpTrig;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_ALT_edit;
        private System.Windows.Forms.CheckBox checkBox_ALT;
    }
}

