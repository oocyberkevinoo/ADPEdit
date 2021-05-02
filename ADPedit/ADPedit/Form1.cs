using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace ADPedit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

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
                AddButton.Enabled = true;
                DeleteButton.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                label2.Text = "Please drag and drop a .adp file.";
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { 
                Filter = "add_param files (*.adp)|*.adp",
            };
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string file = ofd.FileName;
                    Code.readADP(file);
                    refreshList();
                    AddButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                label2.Text = "Please just select a file.";
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
            else
            {
                AddButton.Enabled = false;
                DeleteButton.Enabled = false;
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
                    curADP.ADPfuncVal = float.Parse(adpval, CultureInfo.InvariantCulture.NumberFormat);
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
                return null; //make sure to check if this is a null adp before adding to list so the program doesnt die
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Code.saveADP();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newnewadp = createFunc();
            int index = listBox1.SelectedIndex;
            Code.adps.Insert((index + 1), newnewadp);
            refreshList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Code.adps.Count > 0)
            {
                int index = listBox1.SelectedIndex;
                Code.adps.RemoveAt(index);
                refreshList();
            }
        }
        public void refreshList()
        {
            var dummy = new List<string>(); // Init a new list<string> since thats what listboxes take
            for (int i = 0; i < Code.adps.Count; i++) // get each adp and do something with them
            {
                dummy.Add(Code.adps[i].ADPfuncName);  // get all the names of the adps into the list<string>
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

    }
}

