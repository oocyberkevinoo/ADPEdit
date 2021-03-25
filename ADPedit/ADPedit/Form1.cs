using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        //make an open file dialog to allow the program to open files
        //make a list called adps that uses our adpFunc struct as the data type
        OpenFileDialog ofd = new OpenFileDialog();
        private List<adpFunc> adps = new List<adpFunc>();
        private List<adpHeader> headerlist = new List<adpHeader>();
        public string filePathString { get; set; }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;

        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                filePathString = file;
            }
            if (filePathString.EndsWith(".adp")) {
                readADP(filePathString);
            }
            else
            {
                label2.Text = "Please drag and drop a .adp file.";
            }
        }

        public class adpFunc //make a struct with all the values from an adp function
        {
            public uint TimeID;
            public float timeSecondsMarker;
            public int unk;
            public int frameTime;
            public double padding;
            public uint ADPfuncID;
            public float ADPfuncVal;
            public string ADPfuncName;
        }
        public class adpHeader
        {
            public int count;
            public int unk0;
            public int dataLength;
            public int unk1;
            public int offset;
            public int trash1;
            public int trash2;
            public int trash3;
            public int trash4;
            public int trash5;
            public int trash6;
            public int trash7;
            public int trash8;
        }

        private void readADP(string filePathString)
        {
            adps.Clear(); //clear list of adp functions when opening a new file
            headerlist.Clear(); //dipshit forgot to also clear header list too
            BinaryReader br = new BinaryReader(File.OpenRead(filePathString));
            try
            {
                using (br) //read for a var with the adpfunc values to use for funcDetect
                {
                    {
                        var headerStorage = new adpHeader()
                        {
                            count = br.ReadInt32(),
                            unk0 = br.ReadInt32(),
                            dataLength = br.ReadInt32(),
                            unk1 = br.ReadInt32(),
                            offset = br.ReadInt32(),
                            trash1 = br.ReadInt32(),
                            trash2 = br.ReadInt32(),
                            trash3 = br.ReadInt32(),
                            trash4 = br.ReadInt32(),
                            trash5 = br.ReadInt32(),
                            trash6 = br.ReadInt32(),
                            trash7 = br.ReadInt32(),
                            trash8 = br.ReadInt32(),
                        };
                        headerlist.Add(headerStorage);
                    }
                    br.BaseStream.Position = 0x34; //skip past the adp header
                    var count = br.BaseStream.Length / sizeof(int);
                    for (var i = 0; i < count; i++)
                    {
                        var FinalFunc = new adpFunc() //make a new adp function and store it in the FinalFunc var so it can be used in funcDetect
                        {
                            TimeID = br.ReadUInt32(),
                            timeSecondsMarker = br.ReadSingle(),
                            unk = br.ReadInt32(),
                            frameTime = br.ReadInt32(),
                            padding = br.ReadDouble(),
                            ADPfuncID = br.ReadUInt32(),
                            ADPfuncVal = br.ReadSingle(),
                            ADPfuncName = null,
                        };
                        funcDetect(FinalFunc); //push FinalFunc into funcDetect
                    }
                }
                br.Close(); //close the binary reader to avoid dumbshit
                AddButton.Enabled = true;
                DeleteButton.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception) //catch errors and change the little notice box :)
            {
                label2.Text = "File loaded, with errors.";
                AddButton.Enabled = true;
                DeleteButton.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "add_param files (*.adp)|*.adp";
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePathString = ofd.FileName;
                    readADP(filePathString);
                }
                else { }
            }
            catch (Exception)
            {
                label2.Text = "Please just select a file.";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //get the values from the selected function in the listbox and change the labels to match
        {
            if (adps.Count > 0)
            {
                adpFunc curADP = adps[listBox1.SelectedIndex];
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
                            if (curADP.ADPfuncVal == 0.8750001f)
                            {
                                checkBox1.Checked = true;
                            }
                            else { checkBox1.Checked = false; }
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
            if (adps.Count > 0)
            {
                adpFunc curADP = adps[listBox1.SelectedIndex];
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
            if (adps.Count > 0)
            {
                adpFunc curADP = adps[listBox1.SelectedIndex];
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

        public void addtoList(adpFunc x)
        {
            var dummy = new List<string>(); // Init a new list<string> since thats what listboxes take
            for (int i = 0; i < adps.Count; i++) // get each adp and do something with them
            {
                x = adps[i];
                dummy.Add(x.ADPfuncName);  // get all the names of the adps into the list<string>
            }
            listBox1.DataSource = dummy; // Make the listbox display the list of all adp names
        }

        public void funcDetect(adpFunc x)
        {
            var adp = x;
            //Detect ADP Function using the ID it gives us
            switch (adp.ADPfuncID)
            {
                case 1:
                    adp.ADPfuncName = "Brightness";
                    break;
                case 2:
                    adp.ADPfuncName = "Character Light (RED)";
                    break;
                case 3:
                    adp.ADPfuncName = "Character Light (GREEN)";
                    break;
                case 4:
                    adp.ADPfuncName = "Character Light (BLUE)";
                    break;
                case 6:
                    adp.ADPfuncName = "Red Light";
                    break;
                case 7:
                    adp.ADPfuncName = "Green Light";
                    break;
                case 8:
                    adp.ADPfuncName = "Blue Light";
                    break;
                case 14:
                    adp.ADPfuncName = "Spec. Map Transparency";
                    break;
                case 15:
                    adp.ADPfuncName = "Character Lighting";
                    break;
                case 17:
                    adp.ADPfuncName = "Generic Lighting";
                    break;
                case 18:
                    adp.ADPfuncName = "Skin Shine";
                    break;
                case 39:
                    adp.ADPfuncName = "Eye Lighting";
                    break;
                case 40:
                    adp.ADPfuncName = "Skin Lighting";
                    break;
                case 41:
                    adp.ADPfuncName = "BLINN Lighting";
                    break;
                case 42:
                    adp.ADPfuncName = "Cloth Lighting";
                    break;
                case 43:
                    adp.ADPfuncName = "Item Lighting";
                    break;
                case 44:
                    adp.ADPfuncName = "Hair Lighting";
                    break;
                case 46:
                    adp.ADPfuncName = "Stage Lighting";
                    break;
                case 57:
                    adp.ADPfuncName = "Hair Shine";
                    break;
                case 59:
                    adp.ADPfuncName = "Dimness";
                    break;
                case 72:
                    adp.ADPfuncName = "Eye Colour";
                    break;
                case 75:
                    adp.ADPfuncName = "Handheld 30FPS Limit";
                    break;
                case 76:
                    adp.ADPfuncName = "Docked 30FPS Limit";
                    break;
                case 77:
                    adp.ADPfuncName = "Handheld Resolution";
                    break;
                case 78:
                    adp.ADPfuncName = "Docked Resolution";
                    break;
                default:
                    adp.ADPfuncName = "Unknown Function";
                    break;
            }
            adps.Add(adp);
            addtoList(adp);
        }

        public adpFunc funcDetectNoList(adpFunc x, string y)
        {
            var newadp = x;
            string curText = y;
            //Give the newadp variable ADPfuncName and ADPfuncID based on what the current selection is in either comboBox
            switch (curText)
            {
                case "Brightness":
                    newadp.ADPfuncName = "Brightness";
                    newadp.ADPfuncID = 1;
                    break;
                case "Character Light (RED)":
                    newadp.ADPfuncName = "Character Light (RED)";
                    newadp.ADPfuncID = 2;
                    break;
                case "Character Light (GREEN)":
                    newadp.ADPfuncName = "Character Light (GREEN)";
                    newadp.ADPfuncID = 3;
                    break;
                case "Character Light (BLUE)":
                    newadp.ADPfuncName = "Character Light (BLUE)";
                    newadp.ADPfuncID = 4;
                    break;
                case "Red Light":
                    newadp.ADPfuncName = "Red Light";
                    newadp.ADPfuncID = 6;
                    break;
                case "Green Light":
                    newadp.ADPfuncName = "Green Light";
                    newadp.ADPfuncID = 7;
                    break;
                case "Blue Light":
                    newadp.ADPfuncName = "Blue Light";
                    newadp.ADPfuncID = 8;
                    break;
                case "Spec. Map Transparency":
                    newadp.ADPfuncName = "Spec. Map Transparency";
                    newadp.ADPfuncID = 14;
                    break;
                case "Character Lighting":
                    newadp.ADPfuncName = "Character Lighting";
                    newadp.ADPfuncID = 15;
                    break;
                case "Generic Lighting":
                    newadp.ADPfuncName = "Generic Lighting";
                    newadp.ADPfuncID = 17;
                    break;
                case "Skin Shine":
                    newadp.ADPfuncName = "Skin Shine";
                    newadp.ADPfuncID = 18;
                    break;
                case "Eye Lighting":
                    newadp.ADPfuncName = "Eye Lighting";
                    newadp.ADPfuncID = 39;
                    break;
                case "Skin Lighting":
                    newadp.ADPfuncName = "Skin Lighting";
                    newadp.ADPfuncID = 40;
                    break;
                case "BLINN Lighting":
                    newadp.ADPfuncName = "BLINN Lighting";
                    newadp.ADPfuncID = 41;
                    break;
                case "Cloth Lighting":
                    newadp.ADPfuncName = "Cloth Lighting";
                    newadp.ADPfuncID = 42;
                    break;
                case "Item Lighting":
                    newadp.ADPfuncName = "Item Lighting";
                    newadp.ADPfuncID = 43;
                    break;
                case "Hair Lighting":
                    newadp.ADPfuncName = "Hair Lighting";
                    newadp.ADPfuncID = 44;
                    break;
                case "Stage Lighting":
                    newadp.ADPfuncName = "Stage Lighting";
                    newadp.ADPfuncID = 46;
                    break;
                case "Hair Shine":
                    newadp.ADPfuncName = "Hair Shine";
                    newadp.ADPfuncID = 57;
                    break;
                case "Dimness":
                    newadp.ADPfuncName = "Dimness";
                    newadp.ADPfuncID = 59;
                    break;
                case "Eye Colour":
                    newadp.ADPfuncName = "Eye Colour";
                    newadp.ADPfuncID = 72;
                    break;
                case "Handheld 30FPS Limit":
                    newadp.ADPfuncName = "Handheld 30FPS Limit";
                    newadp.ADPfuncID = 75;
                    if (checkBox2.Checked)
                    {
                        newadp.ADPfuncVal = 0.8750001f;
                    }
                    break;
                case "Docked 30FPS Limit":
                    newadp.ADPfuncName = "Docked 30FPS Limit";
                    newadp.ADPfuncID = 76;
                    if (checkBox2.Checked)
                    {
                        newadp.ADPfuncVal = 0.8750001f;
                    }
                    break;
                case "Handheld Resolution":
                    newadp.ADPfuncName = "Handheld Resolution";
                    newadp.ADPfuncID = 77;
                    break;
                case "Docked Resolution":
                    newadp.ADPfuncName = "Docked Resolution";
                    newadp.ADPfuncID = 78;
                    break;
                default:
                    newadp.ADPfuncName = "Unknown Function";
                    newadp.ADPfuncID = 49;
                    break;
            }
            return newadp;
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
                newFunc = funcDetectNoList(newFunc, comboBox1.Text);
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
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(filePathString, FileMode.Create)))
                {
                    bool didWrite = false;
                    if (!didWrite)
                    {
                        foreach (adpHeader headerStorage in headerlist)
                        {
                            bw.Write(headerStorage.count);
                            bw.Write(headerStorage.unk0);
                            bw.Write(headerStorage.dataLength);
                            bw.Write(headerStorage.unk1);
                            bw.Write(headerStorage.offset);
                            bw.Write(headerStorage.trash1);
                            bw.Write(headerStorage.trash2);
                            bw.Write(headerStorage.trash3);
                            bw.Write(headerStorage.trash4);
                            bw.Write(headerStorage.trash5);
                            bw.Write(headerStorage.trash6);
                            bw.Write(headerStorage.trash7);
                            bw.Write(headerStorage.trash8);
                            Console.WriteLine("Wrote header once.");
                        }
                        foreach (adpFunc adp in adps)
                        {
                            bw.Write(adp.TimeID);
                            bw.Write(adp.timeSecondsMarker);
                            bw.Write(adp.unk);
                            bw.Write(adp.frameTime);
                            bw.Write(adp.padding);
                            bw.Write(adp.ADPfuncID);
                            bw.Write(adp.ADPfuncVal);
                        }
                        Console.WriteLine("Wrote ADPs once.");
                        didWrite = true;
                    }
                    bw.Close();
                }
            }
            catch (Exception) { }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var newnewadp = createFunc();
            int index = listBox1.SelectedIndex;
            adps.Insert((index + 1), newnewadp);
            addtoList(newnewadp);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (adps.Count > 0)
            {
                int index = listBox1.SelectedIndex;
                adps.RemoveAt(index);
                refreshList();
            }
        }
        public void refreshList()
        {
            var dummy = new List<string>(); // Init a new list<string> since thats what listboxes take
            for (int i = 0; i < adps.Count; i++) // get each adp and do something with them
            {
                dummy.Add(adps[i].ADPfuncName);  // get all the names of the adps into the list<string>
            }
            listBox1.DataSource = dummy; // Make the listbox display the list of all adp names
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adps.Count > 0)
            {
                adpFunc curADP = adps[listBox1.SelectedIndex];
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
            if (adps.Count > 0)
            {
                adpFunc curADP = adps[listBox1.SelectedIndex];
                try
                {
                    if (checkBox1.Checked)
                    {
                        curADP.ADPfuncVal = 0.8750001f;
                    }
                    else { curADP.ADPfuncVal = 0.875f; }
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

