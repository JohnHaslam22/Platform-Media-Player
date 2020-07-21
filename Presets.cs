using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
using System;

namespace John_s_Media_Player
{
    class Presets : Form1
    {
        
        // Sets Preset path if it exists
        public static void IsDirectoryEmpty(string path)
        {
            Form form1 = (Form1)Application.OpenForms["Form1"];
            Label l2 = (Label)form1.Controls["label2"];
            Label l4 = (Label)form1.Controls["label4"];
            Label l5 = (Label)form1.Controls["label5"];
            Label l6 = (Label)form1.Controls["label6"];
            Label l7 = (Label)form1.Controls["label7"];
            Button b3 = (Button)form1.Controls["button3"];
            Button b4 = (Button)form1.Controls["button4"];
            Button b5 = (Button)form1.Controls["button5"];
            Button b6 = (Button)form1.Controls["button6"];
            Button b7 = (Button)form1.Controls["button7"];
            Button b8 = (Button)form1.Controls["button8"];
            Button b9 = (Button)form1.Controls["button9"];
            Button b10 = (Button)form1.Controls["button10"];
            Button b17 = (Button)form1.Controls["button17"];
            Button b18 = (Button)form1.Controls["button18"];
            Button b25 = (Button)form1.Controls["button25"];
            Button b26 = (Button)form1.Controls["button26"];
            Button b27 = (Button)form1.Controls["button27"];
            Button b28 = (Button)form1.Controls["button28"];
            Button b29 = (Button)form1.Controls["button29"];
            if (Directory.Exists(path))
            {
                if (Directory.GetFiles(path).Length >= 1)
                {
                    if (path == PresetPath[0] + @"\Preset 1")
                    {
                        l2.Visible = true;
                        b3.Visible = true;
                        b4.Visible = true;
                        b29.Visible = true;
                    }
                    if (path == PresetPath[0] + @"\Preset 2")
                    {
                        l4.Visible = true;
                        b5.Visible = true;
                        b6.Visible = true;
                        b28.Visible = true;
                    }
                    if (path == PresetPath[0] + @"\Preset 3")
                    {
                        l5.Visible = true;
                        b7.Visible = true;
                        b8.Visible = true;
                        b27.Visible = true;
                    }
                    if (path == PresetPath[0] + @"\Preset 4")
                    {
                        l6.Visible = true;
                        b9.Visible = true;
                        b10.Visible = true;
                        b26.Visible = true;
                    }
                    if (path == PresetPath[0] + @"\Preset 5")
                    {
                        l7.Visible = true;
                        b17.Visible = true;
                        b18.Visible = true;
                        b25.Visible = true;
                    }
                }
            }
            else
            {

            }
        }

        //Preset Path Methods
        public static void CreatePath()
        {
            string toplevel = @"D:\";
            string path = System.IO.Path.Combine(toplevel, @"Preset Path");
            if (!System.IO.File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        public static void EnterPath()
        {
            if (PresetPath.Count == 0)
            {
                string defaultValue = "";
                string path = Interaction.InputBox("Path: ", "Please enter a path for presets", defaultValue, -1, -1);
                PresetPath.Add(path);
                SavePath();
            }
        }

        public static void ChangePath()
        {
            Form form1 = (Form1)Application.OpenForms["Form1"];
            Label l1 = (Label)form1.Controls["label1"];
            PresetPath.Clear();
            if (PresetPath.Count == 0)
            {
                string defaultValue = "";
                string path = Interaction.InputBox("Path: ", "Please enter a path for presets", defaultValue, -1, -1);
                PresetPath.Add(path);
                SavePath();
                l1.Text = "Current Preset Path: " + PresetPath[0];
            }
        }

        public static void LoadPath()
        {
            string dir = @"D:\Preset Path";
            string serializationFile1 = Path.Combine(dir, "presetpath.bin");
            if (!System.IO.File.Exists(serializationFile1))
            {

            }
            else
            {
                using (Stream stream = File.Open(serializationFile1, FileMode.Open))
                {
                    var bformatter = new BinaryFormatter();
                    PresetPath = (List<string>)bformatter.Deserialize(stream);
                }
            }
        }

        public static void SavePath()
        {
            string dir = @"D:\Preset Path";
            string serializationFile1 = Path.Combine(dir, "presetpath.bin");
            using (Stream stream = File.Open(serializationFile1, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, PresetPath);
            }
        }

        
         public static void DeletePreset()
        {
            if(PresetNo == "1")
            {
                string Path = PresetPath[0] + @"\Preset 1";
                Directory.Delete(Path, true);
            }
            if (PresetNo == "2")
            {
                string Path = PresetPath[0] + @"\Preset 2";
                Directory.Delete(Path, true);
            }
            if (PresetNo == "3")
            {
                string Path = PresetPath[0] + @"\Preset 3";
                Directory.Delete(Path, true);
            }
            if (PresetNo == "4")
            {
                string Path = PresetPath[0] + @"\Preset 4";
                Directory.Delete(Path, true);
            }
            if (PresetNo == "5")
            {
                string Path = PresetPath[0] + @"\Preset 5";
                Directory.Delete(Path, true);
            }
        }

        // Shows Preset during runtime if it exists
        public static void CreatePreset()
        {
            Form form1 = (Form1)Application.OpenForms["Form1"];
            Label l2 = (Label)form1.Controls["label2"];
            Label l4 = (Label)form1.Controls["label4"];
            Label l5 = (Label)form1.Controls["label5"];
            Label l6 = (Label)form1.Controls["label6"];
            Label l7 = (Label)form1.Controls["label7"];
            Button b3 = (Button)form1.Controls["button3"];
            Button b4 = (Button)form1.Controls["button4"];
            Button b5 = (Button)form1.Controls["button5"];
            Button b6 = (Button)form1.Controls["button6"];
            Button b7 = (Button)form1.Controls["button7"];
            Button b8 = (Button)form1.Controls["button8"];
            Button b9 = (Button)form1.Controls["button9"];
            Button b10 = (Button)form1.Controls["button10"];
            Button b17 = (Button)form1.Controls["button17"];
            Button b18 = (Button)form1.Controls["button18"];
            Button b25 = (Button)form1.Controls["button25"];
            Button b26 = (Button)form1.Controls["button26"];
            Button b27 = (Button)form1.Controls["button27"];
            Button b28 = (Button)form1.Controls["button28"];
            Button b29 = (Button)form1.Controls["button29"];
            string toplevel = PresetPath[0];
            string path = System.IO.Path.Combine(toplevel, "");
            if (!System.IO.File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            if (b9.Visible == true)
            {
                l7.Visible = true;
                b17.Visible = true;
                b18.Visible = true;
                b25.Visible = true;
            }
            if (b8.Visible == true)
            {
                l6.Visible = true;
                b9.Visible = true;
                b10.Visible = true;
                b26.Visible = true;
            }
            if (b5.Visible == true)
            {
                l5.Visible = true;
                b7.Visible = true;
                b8.Visible = true;
                b27.Visible = true;
            }
            if (b3.Visible == true)
            {
                l4.Visible = true;
                b5.Visible = true;
                b6.Visible = true;
                b28.Visible = true;
            }
            l2.Visible = true;
            b3.Visible = true;
            b4.Visible = true;
            b29.Visible = true;

        }

        // Saves preset data, serializes the list data into .bin files
        public static void SaveData()
        {
            string toplevel = PresetPath[0];
            string path = System.IO.Path.Combine(toplevel, "Preset " + PresetNo);
            if (!System.IO.File.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string dir = PresetPath[0] + @"\Preset " + PresetNo;
            string serializationFile1 = Path.Combine(dir, "starttimelist.bin");
            string serializationFile2 = Path.Combine(dir, "middletimelist.bin");
            string serializationFile3 = Path.Combine(dir, "endtimelist.bin");
            string serializationFile4 = Path.Combine(dir, "Intervallist.bin");
            string serializationFile5 = Path.Combine(dir, "MotorABeginList.bin");
            string serializationFile6 = Path.Combine(dir, "MotorBBeginList.bin");
            string serializationFile7 = Path.Combine(dir, "MotorAMiddleList.bin");
            string serializationFile8 = Path.Combine(dir, "MotorBMiddleList.bin");
            string serializationFile9 = Path.Combine(dir, "MotorAEndList.bin");
            string serializationFile10 = Path.Combine(dir, "MotorBEndList.bin");
            string serializationFile11 = Path.Combine(dir, "CMBeforeIntervalAList.bin");
            string serializationFile12 = Path.Combine(dir, "CMBeforeIntervalBList.bin");
            string serializationFile13 = Path.Combine(dir, "CMAfterIntervalAList.bin");
            string serializationFile14 = Path.Combine(dir, "CMAfterIntervalBList.bin");

            using (Stream stream = File.Open(serializationFile1, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, StartTimeList);
            }
            using (Stream stream = File.Open(serializationFile2, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MiddleTimeList);
            }
            using (Stream stream = File.Open(serializationFile3, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, EndTimeList);
            }
            using (Stream stream = File.Open(serializationFile4, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, IntervalList);
            }
            using (Stream stream = File.Open(serializationFile5, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MotorABeginList);
            }
            using (Stream stream = File.Open(serializationFile6, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MotorBBeginList);
            }
            using (Stream stream = File.Open(serializationFile7, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MotorAMiddleList);
            }
            using (Stream stream = File.Open(serializationFile8, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MotorBMiddleList);
            }
            using (Stream stream = File.Open(serializationFile9, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MotorAEndList);
            }
            using (Stream stream = File.Open(serializationFile10, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, MotorBEndList);
            }
            using (Stream stream = File.Open(serializationFile11, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, CMBeforeIntervalAList);
            }
            using (Stream stream = File.Open(serializationFile12, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, CMBeforeIntervalBList);
            }
            using (Stream stream = File.Open(serializationFile13, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, CMAfterIntervalAList);
            }
            using (Stream stream = File.Open(serializationFile14, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, CMAfterIntervalBList);
            }
        }

        // Loads preset data, deserializes the list data from .bin files
        public static void LoadData()
        {
            string dir = PresetPath[0] + @"\Preset " + PresetNo;
            string serializationFile1 = Path.Combine(dir, "starttimelist.bin");
            string serializationFile2 = Path.Combine(dir, "middletimelist.bin");
            string serializationFile3 = Path.Combine(dir, "endtimelist.bin");
            string serializationFile4 = Path.Combine(dir, "Intervallist.bin");
            string serializationFile5 = Path.Combine(dir, "MotorABeginList.bin");
            string serializationFile6 = Path.Combine(dir, "MotorBBeginList.bin");
            string serializationFile7 = Path.Combine(dir, "MotorAMiddleList.bin");
            string serializationFile8 = Path.Combine(dir, "MotorBMiddleList.bin");
            string serializationFile9 = Path.Combine(dir, "MotorAEndList.bin");
            string serializationFile10 = Path.Combine(dir, "MotorBEndList.bin");
            string serializationFile11 = Path.Combine(dir, "CMBeforeIntervalAList.bin");
            string serializationFile12 = Path.Combine(dir, "CMBeforeIntervalBList.bin");
            string serializationFile13 = Path.Combine(dir, "CMAfterIntervalAList.bin");
            string serializationFile14 = Path.Combine(dir, "CMAfterIntervalBList.bin");

            using (Stream stream = File.Open(serializationFile1, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                StartTimeList = (List<string>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile2, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MiddleTimeList = (List<string>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile3, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                EndTimeList = (List<string>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile4, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                IntervalList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile5, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MotorABeginList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile6, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MotorBBeginList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile7, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MotorAMiddleList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile8, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MotorBMiddleList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile9, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MotorAEndList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile10, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                MotorBEndList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile11, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                CMBeforeIntervalAList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile12, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                CMBeforeIntervalBList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile13, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                CMAfterIntervalAList = (List<int>)bformatter.Deserialize(stream);
            }
            using (Stream stream = File.Open(serializationFile14, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                CMAfterIntervalBList = (List<int>)bformatter.Deserialize(stream);
            }
        }

    }
}
