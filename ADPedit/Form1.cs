using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using ADPedit.Properties;

namespace ADPedit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.showFrame.Checked = Settings.Default.showFrame;
            this.showUnk.Checked = Settings.Default.showUnk;
            this.showValue.Checked = Settings.Default.showVal;
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop)).Last();
            if (file.EndsWith(".adp")) {
                Code.readADP(file);
                refreshList();
                createToolStripMenuItem.Enabled = true;
                comboBox1.SelectedIndex = 0;
                label2.Text = file;
            }
            else
            {
                label2.Text = "Please drag and drop a .adp file.";
            }
        }

        // These do a lot of code but they affect Form elements
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //get the values from the selected function in the listbox and change the labels to match
        {
            if (Code.adps.Count > 0)
            {
                adpFunc curADP = Code.adps[listBox1.SelectedIndex];
                try
                {
                    string adptime = curADP.frameTime.ToString();
                    TimeValue.Text = adptime;
                    float calcTime = float.Parse(TimeValue.Text) / 60;
                    Realtime1.Text = calcTime.ToString("0.00");
                    string adpval = curADP.ADPfuncVal.ToString();
                    AdpValue.Text = adpval;
                    AdpValue.Enabled = true;
                    if (curADP.ADPfuncName != "Unknown Function")
                    {
                        comboBox2.Enabled = true;
                        checkBox1.Enabled = false;
                        comboBox2.SelectedItem = curADP.ADPfuncName;
                        if (curADP.ADPfuncName == "Handheld 30FPS Limit" || curADP.ADPfuncName == "Docked 30FPS Limit")
                        {
                            checkBox1.Enabled = true;
                            AdpValue.Enabled = false;
                            if (curADP.ADPfuncVal == 0.8750001f || curADP.ADPfuncVal == 0.6750001f)
                            {
                                checkBox1.Checked = true;
                                curADP.is30fps = true;
                            }
                            else 
                            { 
                                checkBox1.Checked = false;
                                curADP.is30fps = false;
                            }
                        }
                        else { checkBox1.Enabled = false; }
                    }
                    else
                    {
                        checkBox1.Enabled = false;
                        comboBox2.Enabled = false;
                    }

                }
                catch (Exception) { }
            }
        }

        private void TimeValue_TextChanged(object sender, EventArgs e)
        {
            if (Code.adps.Count > 0)
            {
                adpFunc curADP = Code.adps[listBox1.SelectedIndex];
                try
                {
                    string adptime = TimeValue.Text;
                    curADP.frameTime = int.Parse(adptime, CultureInfo.InvariantCulture.NumberFormat);
                }
                catch (Exception) { }
            }
            try
            {
                float calcTime = float.Parse(TimeValue.Text) / 60;
                Realtime1.Text = calcTime.ToString("0.00");
            }
            catch (Exception) {
                Realtime1.Text = "0.00";
            }
        }

        private void AdpValue_TextChanged(object sender, EventArgs e)
        {
            if (Code.adps.Count > 0)
            {
                adpFunc curADP = Code.adps[listBox1.SelectedIndex];
                string adpval = AdpValue.Text;
                try
                {
                    var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    culture.NumberFormat.NumberDecimalSeparator = ".";
                    curADP.ADPfuncVal = float.Parse(adpval, culture);
                    //curADP.ADPfuncVal = float.Parse(adpval, CultureInfo.InvariantCulture.NumberFormat);
                }
                catch (Exception)
                {
                    adpval = "0";
                }
            }
        }

        private adpFunc createFunc()
        {
            float funcValRead;
            int frameTimeRead;
            try
            {
                if (textBox1.Text != null && textBox2.Text != null)
                {
                    frameTimeRead = int.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                    funcValRead = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                }
                else
                {
                    frameTimeRead = 0;
                    funcValRead = 0f;
                }
                var newFunc = new adpFunc() //make a new adp function and store it in the FinalFunc var so it can be used in funcDetect
                {
                    TimeID = 0,
                    unk = 0,
                    frameTime = frameTimeRead,
                    timeSecondsMarker = 0,
                    padding = 0,
                    ADPfuncID = 0,
                    ADPfuncVal = funcValRead,
                    ADPfuncName = null,
                };
                newFunc = Code.funcDetectNoList(newFunc, comboBox1.Text, checkBox2.Checked);
                Console.WriteLine(newFunc.ADPfuncName);
                return newFunc;


            }
            catch (Exception)
            {
                return null; 
            }
        }
        private void updateSettings()
        {
            Settings.Default.Upgrade();
            Settings.Default.showUnk = showUnk.Checked;
            Settings.Default.showFrame = showFrame.Checked;
            Settings.Default.showVal = showValue.Checked;
            Settings.Default.Save();
        }
        public void refreshList()
        {
            var dummy = new List<string>(); // Init a new list<string> since thats what listboxes take
            for (int i = 0; i < Code.adps.Count; i++) // get each adp and do something with them
            {
                string frameTime = null;
                string unkFuncID = null;
                string adpVal = null;
                string adpFunc = Code.adps[i].ADPfuncName;
                if (Settings.Default.showFrame == true)
                {
                    frameTime = "[" + Code.adps[i].frameTime.ToString() + "]  ";
                }
                if (Settings.Default.showVal == true)
                {
                    adpVal = ":  " + Code.adps[i].ADPfuncVal.ToString();
                }
                if (adpFunc == "Unknown Function")
                {
                    if(Settings.Default.showUnk == false)
                    {
                        string x = "";
                        dummy.Add(x);
                        continue;
                    }
                    unkFuncID = "                               (ID: " + Code.adps[i].ADPfuncID.ToString() + ")";
                }
                if (adpFunc == "Docked 30FPS Limit" & Settings.Default.showVal == true || adpFunc == "Handheld 30FPS Limit" & Settings.Default.showVal == true)
                {
                    if (adpVal == ":  0.8750001" || adpVal == ":  0.6750001")
                    {
                        string x = frameTime + adpFunc + ": ON";
                        dummy.Add(x);
                        continue;
                    }
                    else
                    {
                        string x = frameTime + adpFunc + ": OFF";
                        dummy.Add(x);
                        continue;
                    }
                }
                string listName = frameTime + adpFunc + adpVal + unkFuncID;
                if(adpFunc == "Unknown Function" & Settings.Default.showUnk == false)
                {
                    continue;
                }
                else
                {
                    dummy.Add(listName);  // get all the names of the adps into the list<string> if conditions are met
                }
            }
            listBox1.DataSource = dummy; // Make the listbox display the list of all adp names
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Code.adps.Count > 0)
            {
                adpFunc curADP = Code.adps[listBox1.SelectedIndex];
                if (curADP.ADPfuncName != "Unknown Function" && curADP.ADPfuncName != comboBox2.Text)
                {
                    try
                    {
                        bool chek = false;
                        if(comboBox2.Text == "Handheld 30FPS Limit" || comboBox2.Text == "Docked 30FPS Limit")
                        {
                            chek = checkBox1.Checked;
                        }
                        Code.funcDetectNoList(curADP, comboBox2.Text, chek);
                        curADP.ADPfuncName = comboBox2.Text;
                        int selIndex = listBox1.SelectedIndex;
                        refreshList();
                        listBox1.SelectedIndex = selIndex;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float calcTime = float.Parse(textBox1.Text) / 60;
                Realtime2.Text = calcTime.ToString("0.00");
            }
            catch (Exception) {
                Realtime2.Text = "0.00";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Code.adps.Count > 0)
            {
                adpFunc curADP = Code.adps[listBox1.SelectedIndex];
                try
                {
                    if (checkBox1.Checked)
                    {
                        curADP.is30fps = true;
                        curADP.ADPfuncVal = 0.8750001f;
                    }
                    else 
                    { 
                        curADP.ADPfuncVal = 0.875f;
                        curADP.is30fps = false;
                    }
                }
                catch (Exception) { }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Handheld 30FPS Limit" || comboBox1.Text == "Docked 30FPS Limit")
            {
                checkBox2.Enabled = true;
                textBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = false;
                textBox2.Enabled = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "add_param files (*.adp)|*.adp",
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                macrosToolStripMenuItem.Enabled = true;
                string file = ofd.FileName;
                Code.readADP(file);
                refreshList();
                createToolStripMenuItem.Enabled = true;
                comboBox1.SelectedIndex = 0;
                label2.Text = ofd.FileName;
            }
            else { label2.Text = "Select an ADP format file."; }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Code.saveADP();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addFunctionAtPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newnewadp = createFunc();
            int index = listBox1.SelectedIndex;
            Code.adps.Insert((index + 1), newnewadp);
            refreshList();
        }

        private void removeSelectedFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Code.adps.Count > 0)
            {
                int index = listBox1.SelectedIndex;
                Code.adps.RemoveAt(index);
                refreshList();
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = index - 1;
                }
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Code.updateADP();
        }

        private void showUnk_Click(object sender, EventArgs e)
        {
            updateSettings();
            refreshList();
        }

        private void showFrame_Click(object sender, EventArgs e)
        {
            updateSettings();
            refreshList();
        }

        private void showValue_Click(object sender, EventArgs e)
        {
            updateSettings();
            refreshList();
        }

        private void rGBTo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(adpFunc x in Code.adps)
            {
                if (x.frameTime == int.Parse(frameToolStripMenuItem.Text))
                {
                    if (x.ADPfuncID > 5 & x.ADPfuncID < 9)
                    {
                        x.ADPfuncVal = 1;
                    }
                }
            }
            refreshList();
        }

        private void simpleResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool foundH = false;
            bool foundD = false;
            foreach (adpFunc x in Code.adps)
            {
                if (x.frameTime == int.Parse(frameToolStripMenuItem.Text))
                {
                    if (x.ADPfuncID == 77)
                    {
                        x.ADPfuncVal = 0.75f;
                        foundH = true;
                    }
                    if (x.ADPfuncID == 78)
                    {
                        x.ADPfuncVal = 0.875f;
                        foundD = true;
                    }
                }
            }
            if (!foundH)
            {
                adpFunc x = new adpFunc();
                x.ADPfuncID = 77;
                x.ADPfuncName = "Handheld Resolution";
                x.ADPfuncVal = 0.75f;
                x.frameTime = int.Parse(frameToolStripMenuItem.Text);
                Code.adps.Insert(Code.adps.Count, x);
            }
            if (!foundD)
            {
                adpFunc x = new adpFunc();
                x.ADPfuncID = 78;
                x.ADPfuncName = "Docked Resolution";
                x.ADPfuncVal = 0.875f;
                x.frameTime = int.Parse(frameToolStripMenuItem.Text);
                Code.adps.Insert(Code.adps.Count, x);
            }
            refreshList();
        }

        private void darkToonFixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (adpFunc x in Code.adps)
            {
                if (x.frameTime == int.Parse(frameToolStripMenuItem.Text))
                {
                    if (x.ADPfuncID == 15)
                    {
                        x.ADPfuncVal = 2;
                    }
                    if (x.ADPfuncID == 17)
                    {
                        x.ADPfuncVal = 1;
                    }
                    if (x.ADPfuncID == 40)
                    {
                        x.ADPfuncVal = 0.8f;
                    }
                    if (x.ADPfuncID == 46)
                    {
                        x.ADPfuncVal = 1.75f;
                    }
                    if (x.ADPfuncID == 57)
                    {
                        x.ADPfuncVal = 4;
                    }
                    if (x.ADPfuncID == 59)
                    {
                        x.ADPfuncVal = 0.55f;
                    }
                    if (x.ADPfuncID == 72)
                    {
                        x.ADPfuncVal = 0.35f;
                    }
                }
            }
            refreshList();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void disableRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (adpFunc x in Code.adps)
            {
                if (x.frameTime == int.Parse(frameToolStripMenuItem.Text))
                {
                    if (x.ADPfuncID > 5 & x.ADPfuncID < 9)
                    {
                        x.ADPfuncVal = -0.1f;
                    }
                }
            }
            refreshList();
        }
    }
}

