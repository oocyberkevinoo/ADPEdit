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

        public float currentLayout = 0f;

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
                            count = br.ReadInt64(),
                            dataLength = br.ReadInt64(),
                            offset = br.ReadInt64(),

                        };
                        headerlist.Add(headerStorage);
                    }
                    //br.BaseStream.Position = 0x34; //skip past the adp header
                    var count = br.BaseStream.Length / sizeof(int);
                    for (var i = 0; i < count; i++)
                    {
                        var FinalFunc = new adpFunc() //make a new adp function and store it in the FinalFunc var so it can be used in funcDetect
                        {
                            
                            TimeSeconds = br.ReadSingle(),
                            timeSecondsMarker = br.ReadBytes(4),
                            frameTime = br.ReadInt32(),
                            unk2 = br.ReadInt32(),
                            altFlag = br.ReadInt32(),
                            ADPfuncID = br.ReadUInt32(),
                            ADPfuncVal = br.ReadSingle(),
                            ADPfuncName = null,
                            Padding = br.ReadUInt32(),
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
                    Code.headerlist[0].count = (Code.adps.Count /*+ 1*/);
                    Code.headerlist[0].dataLength = (Code.adps.Count * 2 * 16) /*+ 32*/;
                    foreach (adpHeader headerStorage in Code.headerlist)
                    {
                        bw.Write(headerStorage.count);
                        bw.Write(headerStorage.dataLength);
                        bw.Write(headerStorage.offset);

                    }
                    foreach (adpFunc adp in Code.adps)
                    {
                        
                        bw.Write(adp.TimeSeconds);
                        bw.Write(adp.timeSecondsMarker);
                        bw.Write(adp.frameTime);
                        bw.Write(adp.unk2);
                        bw.Write(adp.altFlag);
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

                        bw.Write(adp.Padding);
                    }
                    
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
                case 0:
                    adp.ADPfuncName = "Alternative PV flag";
                    break;
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
                case 5:
                    adp.ADPfuncName = "Character Light (ALPHA) [UNUSED]";
                    break;
                case 6:
                    adp.ADPfuncName = "Character Color (RED)";
                    break;
                case 7:
                    adp.ADPfuncName = "Character Color (GREEN)";
                    break;
                case 8:
                    adp.ADPfuncName = "Character Color (BLUE)";
                    break;
                case 9:
                    adp.ADPfuncName = "Character Color (ALPHA) [UNUSED]";
                    break;
                case 10:
                    adp.ADPfuncName = "Reflection (RED)";
                    break;
                case 11:
                    adp.ADPfuncName = "Reflection (GREEN)";
                    break;
                case 12:
                    adp.ADPfuncName = "Reflection (BLUE)";
                    break;
                case 13:
                    adp.ADPfuncName = "Reflection (ALPHA) [UNUSED]";
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
                    adp.ADPfuncName = "Celshading Thickness";
                    break;
                case 22:
                    adp.ADPfuncName = "Celshading Eyelid";
                    break;
                case 37:
                    adp.ADPfuncName = "Celshading Body";
                    break;
                case 38:
                    adp.ADPfuncName = "Celshading Clothes/Hair";
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
                    adp.ADPfuncName = "Item/Facial Lighting";
                    break;
                case 44:
                    adp.ADPfuncName = "Hair Lighting";
                    break;
                case 46:
                    adp.ADPfuncName = "Stage Lighting";
                    break;
                case 48:
                    adp.ADPfuncName = "Shadow Quality";
                    break;
                case 49:
                    adp.ADPfuncName = "DoF Quality";
                    break;
                case 52:
                    adp.ADPfuncName = "DoF Tile Size";
                    break;
                case 53:
                    adp.ADPfuncName = "DoF Prefilter Tap Num";
                    break;
                case 54:
                    adp.ADPfuncName = "DoF Main Filter Sample Division";
                    break;
                case 55:
                    adp.ADPfuncName = "DoF Upsample Tap Num";
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
                case 61:
                    adp.ADPfuncName = "Inner Skin Shine";
                    break;
                case 62:
                    adp.ADPfuncName = "Shadow Intensity";
                    break;
                case 63:
                    adp.ADPfuncName = "Shadow Opacity";
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
                case 79:
                    adp.ADPfuncName = "AET Opacity";
                    break;
                default:
                    adp.ADPfuncName = "Unk.";
                    break;
            }
            adps.Add(adp);
        }


        public static adpFunc funcDetectNoList(adpFunc newadp, string curText, bool enable)
        {
            newadp.ADPfuncName = curText;

            //Give the newadp variable ADPfuncName and ADPfuncID based on what the current selection is in either comboBox
            switch (curText)
            {
                case "Alternative PV flag":
                    newadp.ADPfuncID = 0;
                    break;
                case "Brightness":
                    newadp.ADPfuncID = 1;
                    break;
                case "Character Light (RED)":
                    newadp.ADPfuncID = 2;
                    break;
                case "Character Light (GREEN)":
                    newadp.ADPfuncID = 3;
                    break;
                case "Character Light (BLUE)":
                    newadp.ADPfuncID = 4;
                    break;
                case "Character Light (ALPHA) [UNUSED]":
                    newadp.ADPfuncID = 5;
                    break;
                case "Character Color (RED)":
                    newadp.ADPfuncID = 6;
                    break;
                case "Character Color (GREEN)":
                    newadp.ADPfuncID = 7;
                    break;
                case "Character Color (BLUE)":
                    newadp.ADPfuncID = 8;
                    break;
                case "Character Color (ALPHA) [UNUSED]":
                    newadp.ADPfuncID = 9;
                    break;
                case "Reflection (RED)":
                    newadp.ADPfuncID = 10;
                    break;
                case "Reflection (GREEN)":
                    newadp.ADPfuncID = 11;
                    break;
                case "Reflection (BLUE)":
                    newadp.ADPfuncID = 12;
                    break;
                case "Reflection (ALPHA) [UNUSED]":
                    newadp.ADPfuncID = 13;
                    break;
                case "Spec. Map Transparency":
                    newadp.ADPfuncID = 14;
                    break;
                case "Character Lighting":
                    newadp.ADPfuncID = 15;
                    break;
                case "Generic Lighting":
                    newadp.ADPfuncID = 17;
                    break;
                case "Celshading Thickness":
                    newadp.ADPfuncID = 21;
                    break;
                case "Skin Shine":
                    newadp.ADPfuncID = 18;
                    break;
                case "Celshading Eyelid":
                    newadp.ADPfuncID = 22;
                    break;
                case "Celshading Body":
                    newadp.ADPfuncID = 37;
                    break;
                case "Celshading Hair/Clothes":
                    newadp.ADPfuncID = 38;
                    break;
                case "Eye Lighting":
                    newadp.ADPfuncID = 39;
                    break;
                case "Skin Toon Intensity":
                    newadp.ADPfuncID = 40;
                    break;
                case "BLINN Lighting":
                    newadp.ADPfuncID = 41;
                    break;
                case "Cloth Lighting":
                    newadp.ADPfuncID = 42;
                    break;
                case "Item/Facial Lighting":
                    newadp.ADPfuncID = 43;
                    break;
                case "Hair Lighting":
                    newadp.ADPfuncID = 44;
                    break;
                case "Stage Lighting":
                    newadp.ADPfuncID = 46;
                    break;
                case "Shadow Quality":
                    newadp.ADPfuncID = 48;
                    break;
                case "DoF Quality":
                    newadp.ADPfuncID = 49;
                    break;
                case "DoF Tile Size":
                    newadp.ADPfuncID = 52;
                    break;
                case "DoF Prefilter Tap Num":
                    newadp.ADPfuncID = 53;
                    break;
                case "DoF Main Filter Sample Division":
                    newadp.ADPfuncID = 54;
                    break;
                case "DoF Upsample Tap Num":
                    newadp.ADPfuncID = 55;
                    break;
                case "Hair Shine":
                    newadp.ADPfuncID = 57;
                    break;
                case "Dimness":
                    newadp.ADPfuncID = 59;
                    break;
                case "Character Lightness":
                    newadp.ADPfuncID = 60;
                    break;
                case "Inner Skin Shine":
                    newadp.ADPfuncID = 61;
                    break;
                case "Shadow Intensity":
                    newadp.ADPfuncID = 62;
                    break;
                case "Shadow Opacity":
                    newadp.ADPfuncID = 63;
                    break;
                case "Eye Colour Saturation":
                    newadp.ADPfuncID = 72;
                    break;
                case "Handheld 30FPS Limit":
                    newadp.ADPfuncID = 75;
                    if (enable)
                    {
                        newadp.ADPfuncVal = 0.8750001f;
                    }
                    break;
                case "Docked 30FPS Limit":
                    newadp.ADPfuncID = 76;
                    if (enable)
                    {
                        newadp.ADPfuncVal = 0.8750001f;
                    }
                    break;
                case "Handheld Resolution":
                    newadp.ADPfuncID = 77;
                    break;
                case "Docked Resolution":
                    newadp.ADPfuncID = 78;
                    break;
                case "AET Opacity":
                    newadp.ADPfuncID = 79;
                    break;
                default:
                    newadp.ADPfuncName = "Unk.";
                    newadp.ADPfuncID = 49;
                    break;
            }
            return newadp;
        }
    }
}
