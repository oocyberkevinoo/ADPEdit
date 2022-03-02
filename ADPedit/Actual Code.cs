using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;

namespace ADPedit
{
    class Code
    {
        public static List<adpFunc> adps = new List<adpFunc>();
        public static List<adpHeader> headerlist = new List<adpHeader>();
        public static string filePathString { get; set; }
        public static short fps1 = 1;
        public static short fps2 = 16224;

        public static void readADP(string x)
        {
            adps.Clear(); //clear list of adp functions when opening a new file
            headerlist.Clear(); //dipshit forgot to also clear header list too
            filePathString = x;
            BinaryReader br = new BinaryReader(File.OpenRead(x));
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
                            timeSecondsMarker = (float) br.ReadSingle()*1.0f,
                            unk = br.ReadInt32(),
                            frameTime = br.ReadInt32(),
                            padding = br.ReadDouble(),
                            ADPfuncID = br.ReadUInt32(),
                            ADPfuncVal = (float) br.ReadSingle()*1.0f,
                            ADPfuncName = null,
                        };
                        FuncDetect(FinalFunc); //push FinalFunc into funcDetect
                    }
                }
                br.Close(); //close the binary reader to avoid dumbshit
            }
            catch (Exception) //catch errors and change the little notice box :)
            {
            }
        }

        public static void saveADP()
        {
            try
            {
                var sfd = new SaveFileDialog() { Filter = "add_param files (*.adp)|*.adp" };
                if (sfd.ShowDialog() != DialogResult.OK) { }
                saveFile(sfd.FileName);
            }
            catch (Exception) { }
        }

        public static void updateADP()
        {
            saveFile(filePathString);
        }

        public static void saveFile(string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                bool didWrite = false;
                if (!didWrite)
                {
                    Code.headerlist[0].count = (Code.adps.Count + 1);
                    Code.headerlist[0].dataLength = (Code.adps.Count * 2 * 16) + 32;
                    foreach (adpHeader headerStorage in Code.headerlist)
                    {
                        bw.Write(headerStorage.count);
                        bw.Write(headerStorage.unk0);
                        bw.Write(headerStorage.dataLength);
                        bw.Write(headerStorage.unk1);
                        bw.Write(headerStorage.offset);
                        for (int i = 0; i < 7; i++)
                        {
                            bw.Write(0x00);
                        }
                        bw.Write(1);
                    }
                    foreach (adpFunc adp in Code.adps)
                    {
                        bw.Write(adp.TimeID);
                        bw.Write(0x00);
                        bw.Write(0x00);
                        bw.Write(adp.frameTime);
                        bw.Write(0x00);
                        bw.Write(0x00);
                        bw.Write(adp.ADPfuncID);
                        if (adp.is30fps)
                        {
                            bw.Write(fps1);
                            bw.Write(fps2);
                        }
                        else
                        {
                            bw.Write(adp.ADPfuncVal);
                        }
                    }
                    bw.Write(0x00);
                    didWrite = true;
                }
                bw.Close();
            }
        }

        public static void FuncDetect(adpFunc x)
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
                case 21:
                    adp.ADPfuncName = "Outline Transparency";
                    break;
                case 39:
                    adp.ADPfuncName = "Eye Lighting";
                    break;
                case 40:
                    adp.ADPfuncName = "Skin Toon Intensity";
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
                case 60:
                    adp.ADPfuncName = "Character Lightness";
                    break;
                case 72:
                    adp.ADPfuncName = "Eye Colour Saturation";
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
        }

        public static adpFunc funcDetectNoList(adpFunc newadp, string curText, bool enable)
        {
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
                case "Outline Transparency":
                    newadp.ADPfuncName = "Outline Transparency";
                    newadp.ADPfuncID = 21;
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
                    newadp.ADPfuncName = "Skin Toon Intensity";
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
                case "Character Lightness":
                    newadp.ADPfuncName = "Character Lightness";
                    newadp.ADPfuncID = 60;
                    break;
                case "Eye Colour Saturation":
                    newadp.ADPfuncName = "Eye Colour Saturation";
                    newadp.ADPfuncID = 72;
                    break;
                case "Handheld 30FPS Limit":
                    newadp.ADPfuncName = "Handheld 30FPS Limit";
                    newadp.ADPfuncID = 75;
                    if (enable)
                    {
                        newadp.ADPfuncVal = 0.8750001f;
                    }
                    break;
                case "Docked 30FPS Limit":
                    newadp.ADPfuncName = "Docked 30FPS Limit";
                    newadp.ADPfuncID = 76;
                    if (enable)
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
    }
}
