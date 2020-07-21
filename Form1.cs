using System;
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

namespace John_s_Media_Player
{
    

    public partial class Form1 : Form
    {
        public static byte[] motorA = new byte[5];
        public static byte[] motorB = new byte[5];
        public static string StartTimeStamp { get; set; }
        public static string EndTimeStamp { get; set; }
        public static string MiddleTimeStamp { get; set; }
        public static string mediaPlayerTimeStamp { get; set; }
        public static int totaltime { get; set; }
        public static int interval { get; set; }
        public static int MotorABeginValueI { get; set; }
        public static int MotorBBeginValueI { get; set; }
        public static int MotorAMiddleValueI { get; set; }
        public static int MotorBMiddleValueI { get; set; }
        public static int MotorAEndValueI { get; set; }
        public static int MotorBEndValueI { get; set; }
        public static string intervalstring { get; set; }
        public static int uniqueinterval { get; set; }
        public static string M1 { get; set; }
        public static string M2 { get; set; }
        public static string M3 { get; set; }
        public static string M4 { get; set; }
        public static string M5 { get; set; }
        public static List<string> StartTimeList { get; set; }
        public static List<string> MiddleTimeList { get; set; }
        public static List<string> EndTimeList { get; set; }
        public static List<int> IntervalList { get; set; }
        public static System.Timers.Timer timer { get; set; }
        public static List<int> MotorABeginList { get; set; }
        public static List<int> MotorBBeginList { get; set; }
        public static List<int> MotorAEndList { get; set; }
        public static List<int> MotorBEndList { get; set; }
        public static List<int> MotorAMiddleList { get; set; }
        public static List<int> MotorBMiddleList { get; set; }
        public static string PresetNo { get; set; }
        public static string PIDTermA { get; set; }
        public static string PIDTermB { get; set; }
        public static SerialPort serialPort1 { get; set; }
        public static List<string> PresetPath { get; set; }
        public static int totalstarttimestampsecs { get; set; }
        public static int totalendtimestampsecs { get; set; }
        public static int CMBeforeIntervalA { get; set; }
        public static int CMBeforeIntervalB { get; set; }
        public static int CMAfterIntervalA { get; set; }
        public static int CMAfterIntervalB { get; set; }
        public static List<int> CMBeforeIntervalAList { get; set; }
        public static List<int> CMBeforeIntervalBList { get; set; }
        public static List<int> CMAfterIntervalAList { get; set; }
        public static List<int> CMAfterIntervalBList { get; set; }
        public static string exceptionname { get; set; }


        public Form1()
        {
            motorA[0] = 0x5B;
            motorA[1] = 0x41;
            motorA[4] = 0x5D;
            motorB[0] = 0x5B;
            motorB[1] = 0x42;
            motorB[4] = 0x5D;
            StartTimeList = new List<string>();
            MiddleTimeList = new List<string>();
            EndTimeList = new List<string>();
            PresetPath = new List<string>();
            IntervalList = new List<int>();
            timer = new System.Timers.Timer();
            MotorABeginList = new List<int>();
            MotorBBeginList = new List<int>();
            MotorAEndList = new List<int>();
            MotorBEndList = new List<int>();
            MotorAMiddleList = new List<int>();
            MotorBMiddleList = new List<int>();
            CMBeforeIntervalAList = new List<int>();
            CMBeforeIntervalBList = new List<int>();
            CMAfterIntervalAList = new List<int>();
            CMAfterIntervalBList = new List<int>();

            serialPort1 = new SerialPort();


            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listFile.ValueMember = "Path";
            listFile.DisplayMember = "FileName";
            // Open Conntection Dropdown
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                portList.Items.Add(port);
            }

            List<string> my_list1 = new List<string>();
            List<string> my_list2 = new List<string>();
            List<string> my_list3 = new List<string>();
            List<string> my_list4 = new List<string>();
            List<string> my_list5 = new List<string>();
            List<string> PIDListA = new List<string>();
            List<string> PIDListB = new List<string>();
            my_list1.Add("Pitch Forwards");
            my_list1.Add("Pitch Backwards");
            my_list1.Add("Roll Left");
            my_list1.Add("Roll Right");
            my_list1.Add("Custom Movement");
            my_list2.Add("Pitch Forwards");
            my_list2.Add("Pitch Backwards");
            my_list2.Add("Roll Left");
            my_list2.Add("Roll Right");
            my_list2.Add("Custom Movement");
            my_list3.Add("Pitch Forwards");
            my_list3.Add("Pitch Backwards");
            my_list3.Add("Roll Left");
            my_list3.Add("Roll Right");
            my_list3.Add("Custom Movement");
            my_list4.Add("Pitch Forwards");
            my_list4.Add("Pitch Backwards");
            my_list4.Add("Roll Left");
            my_list4.Add("Roll Right");
            my_list4.Add("Custom Movement");
            my_list5.Add("Pitch Forwards");
            my_list5.Add("Pitch Backwards");
            my_list5.Add("Roll Left");
            my_list5.Add("Roll Right");
            my_list5.Add("Custom Movement");
            PIDListA.Add("");
            PIDListA.Add("Potential Term");
            PIDListA.Add("Integral Term");
            PIDListA.Add("Derivative Term");
            PIDListA.Add("Smoothing Term");
            PIDListB.Add("");
            PIDListB.Add("Potential Term");
            PIDListB.Add("Integral Term");
            PIDListB.Add("Derivative Term");
            PIDListB.Add("Smoothing Term");
            Movement1.DataSource = my_list1;
            Movement2.DataSource = my_list2;
            Movement3.DataSource = my_list3;
            Movement4.DataSource = my_list4;
            Movement5.DataSource = my_list5;
            comboBox2.DataSource = PIDListA;
            comboBox3.DataSource = PIDListB;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            serialPort1.DtrEnable = true;
            serialPort1.BaudRate = 500000;          
            MovementOne.Visible = false;
            MovementTwo.Visible = false;
            MovementThree.Visible = false;
            MovementFour.Visible = false;
            MovementFive.Visible = false;
            Movement1.Visible = false;
            Movement2.Visible = false;
            Movement3.Visible = false;
            Movement4.Visible = false;
            Movement5.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button29.Visible = false;
            button28.Visible = false;
            button27.Visible = false;
            button26.Visible = false;
            button25.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            button30.Enabled = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            Fullscreen.Enabled = false;
            MotorBSettings.Enabled = false;
            button21.Enabled = false;
            ClosePort.Enabled = false;
            MotorSettings.ActiveA = false;
            MotorSettings.ActiveB = false;
            label1.Text = "Current Preset Path: ";
            Presets.CreatePath();
            Presets.LoadPath();
            // Loads Presets, if they exist
           
                if (Directory.GetFiles(@"D:\Preset Path").Length >= 1)
                {
                    label1.Text = "Current Preset Path: " + PresetPath[0];
                    Presets.IsDirectoryEmpty(PresetPath[0] + @"\Preset 1");
                    Presets.IsDirectoryEmpty(PresetPath[0] + @"\Preset 2");
                    Presets.IsDirectoryEmpty(PresetPath[0] + @"\Preset 3");
                    Presets.IsDirectoryEmpty(PresetPath[0] + @"\Preset 4");
                    Presets.IsDirectoryEmpty(PresetPath[0] + @"\Preset 5");
                }
            
            else
            {

            }
        }

        // Select Video and Starts Timestamp Print out
        private void ListFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listFile.SelectedItem as MediaFile;
            if (file != null)
            {
                axWindowsMediaPlayer.URL = file.Path;
                axWindowsMediaPlayer.Ctlcontrols.play();
                timer.Interval = 1000;
                timer.AutoReset = true;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerEventProcessor);
                timer.Start();
            }
        }

        //Checks if Timestamps match User created Start Timestamp, if it does movement is initiated
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            mediaPlayerTimeStamp = axWindowsMediaPlayer.Ctlcontrols.currentPositionString;
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
            Console.WriteLine("Timestamp : " + axWindowsMediaPlayer.Ctlcontrols.currentPositionString);
            }
            else
            {

            }

            string[] myArray = StartTimeList.ToArray();

                int caseSwitch = myArray.Length;  

                switch (caseSwitch)
                {

                    case 1:
                        if (mediaPlayerTimeStamp == myArray[0])
                        {
                            if (M1 == "Pitch Forwards")
                            {                         
                               PFMovement();
                            }
                            if (M1 == "Pitch Backwards")
                            {
                                PBMovement();
                            }
                            if (M1 == "Roll Left")
                            {
                                RLMovement();
                            }
                            if (M1 == "Roll Right")
                            {
                                RRMovement();
                            }
                            if (M1 == "Custom Movement")
                            {
                                CustomMovement();
                            }
                        }
                        else
                        {

                        }
                        break;
                    case 2:
                    if (mediaPlayerTimeStamp == myArray[0])
                    {
                        if (M1 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M1 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M1 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M1 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M1 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[1])
                        {
                            if (M2 == "Pitch Forwards")
                            {
                                PFMovement();
                            }
                            if (M2 == "Pitch Backwards")
                            {
                                PBMovement();
                            }
                            if (M2 == "Roll Left")
                            {
                                RLMovement();
                            }
                            if (M2 == "Roll Right")
                            {
                                RRMovement();
                            }
                            if (M2 == "Custom Movement")
                            {
                                CustomMovement();
                            }
                        }
                        else
                        {

                        }
                        break;
                    case 3:
                    if (mediaPlayerTimeStamp == myArray[0])
                    {
                        if (M1 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M1 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M1 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M1 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M1 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[1])
                    {
                        if (M2 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M2 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M2 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M2 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M2 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[2])
                        {
                            if (M3 == "Pitch Forwards")
                            {
                                PFMovement();
                            }
                            if (M3 == "Pitch Backwards")
                            {
                                PBMovement();
                            }
                            if (M3 == "Roll Left")
                            {
                                RLMovement();
                            }
                            if (M3 == "Roll Right")
                            {
                                RRMovement();
                            }
                            if (M3 == "Custom Movement")
                            {
                                CustomMovement();
                            }
                        }
                        else
                        {

                        }
                        break;
                    case 4:
                    if (mediaPlayerTimeStamp == myArray[0])
                    {
                        if (M1 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M1 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M1 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M1 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M1 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[1])
                    {
                        if (M2 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M2 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M2 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M2 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M2 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[2])
                    {
                        if (M3 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M3 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M3 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M3 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M3 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[3])
                        {
                            if (M4 == "Pitch Forwards")
                            {
                                PFMovement();
                            }
                            if (M4 == "Pitch Backwards")
                            {
                                PBMovement();
                            }
                            if (M4 == "Roll Left")
                            {
                                RLMovement();
                            }
                            if (M4 == "Roll Right")
                            {
                                RRMovement();
                            }
                            if (M4 == "Custom Movement")
                            {
                                CustomMovement();
                            }
                        }
                        else
                        {

                        }
                        break;
                    case 5:
                    if (mediaPlayerTimeStamp == myArray[0])
                    {
                        if (M1 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M1 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M1 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M1 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M1 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[1])
                    {
                        if (M2 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M2 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M2 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M2 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M2 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[2])
                    {
                        if (M3 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M3 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M3 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M3 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M3 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[3])
                    {
                        if (M4 == "Pitch Forwards")
                        {
                            PFMovement();
                        }
                        if (M4 == "Pitch Backwards")
                        {
                            PBMovement();
                        }
                        if (M4 == "Roll Left")
                        {
                            RLMovement();
                        }
                        if (M4 == "Roll Right")
                        {
                            RRMovement();
                        }
                        if (M4 == "Custom Movement")
                        {
                            CustomMovement();
                        }
                    }
                    if (mediaPlayerTimeStamp == myArray[4])
                        {
                            if (M5 == "Pitch Forwards")
                            {
                                PFMovement();
                            }
                            if (M5 == "Pitch Backwards")
                            {
                                PBMovement();
                            }
                            if (M5 == "Roll Left")
                            {
                                RLMovement();
                            }
                            if (M5 == "Roll Right")
                            {
                                RRMovement();
                            }
                            if (M5 == "Custom Movement")
                            {
                                CustomMovement();
                            }
                        }
                        else
                        {

                        }
                        break;
                }

            }

        // Pitch Forward Movement
        public void PFMovement()
        {
            string[] myArray1 = StartTimeList.ToArray();
            int[] myArray2 = IntervalList.ToArray();
            int i = 511;
            int j = 511;
            int caseSwitch = myArray1.Length;

            switch (caseSwitch)
            {
                case 1:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    break;
                case 2:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    break;
                case 3:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    break;
                case 4:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    break;
                case 5:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    if (mediaPlayerTimeStamp == myArray1[4])
                    {
                        uniqueinterval = myArray2[4];
                    }
                    break;
            }

            //Begins loop of movement values sent to the platform
            while (i <= 871)
            {
                for (i = 511; i <= 871; i++)
                {
                    
                        Thread.Sleep(uniqueinterval);
                        Console.Write("MotorA: " + i + " ");
                        Console.Write("MotorB: " + j + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        string byte5 = j.ToString("X4").Substring(0, 2);
                        string byte6 = j.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        motorB[2] = Convert.ToByte(byte5, 16);
                        motorB[3] = Convert.ToByte(byte6, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorA, 0, motorA.Length);
                            serialPort1.Write(motorB, 0, motorB.Length);
                        }
                        j = j - 1;
                    }
                
            }

            for (i = 872; i >= 511; i--)
            {
                                   Thread.Sleep(uniqueinterval);
                    Console.Write("MotorA: " + i + " ");
                    Console.Write("MotorB: " + j + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    string byte5 = j.ToString("X4").Substring(0, 2);
                    string byte6 = j.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    motorB[2] = Convert.ToByte(byte5, 16);
                    motorB[3] = Convert.ToByte(byte6, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorA, 0, motorA.Length);
                        serialPort1.Write(motorB, 0, motorB.Length);
                    }
                    j = j + 1;
                }
        }

        // Pitch Backward Movement
        public void PBMovement()
        {
            
            string[] myArray1 = StartTimeList.ToArray();
            int[] myArray2 = IntervalList.ToArray();
            int i = 511;
            int j = 511;
            int caseSwitch = myArray1.Length;

            switch (caseSwitch)
            {
                case 1:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    break;
                case 2:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    break;
                case 3:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    break;
                case 4:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    break;
                case 5:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    if (mediaPlayerTimeStamp == myArray1[4])
                    {
                        uniqueinterval = myArray2[4];
                    }
                    break;
            }

            //Begins loop of movement values sent to the platform
            while (i >= 151)
            {
                for (i = 511; i >= 151; i--)
                {
                    Thread.Sleep(uniqueinterval);
                    Console.Write("MotorA: " + i + " ");
                    Console.Write("MotorB: " + j + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    string byte5 = j.ToString("X4").Substring(0, 2);
                    string byte6 = j.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    motorB[2] = Convert.ToByte(byte5, 16);
                    motorB[3] = Convert.ToByte(byte6, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorA, 0, motorA.Length);
                        serialPort1.Write(motorB, 0, motorB.Length);
                    }
                    j = j + 1;
                }

            }
            for (i = 150; i <= 511; i++)
            {
                Thread.Sleep(uniqueinterval);
                Console.Write("MotorA: " + i + " ");
                Console.Write("MotorB: " + j + " ");
                string byte3 = i.ToString("X4").Substring(0, 2);
                string byte4 = i.ToString("X4").Substring(2, 2);
                string byte5 = j.ToString("X4").Substring(0, 2);
                string byte6 = j.ToString("X4").Substring(2, 2);
                motorA[2] = Convert.ToByte(byte3, 16);
                motorA[3] = Convert.ToByte(byte4, 16);
                motorB[2] = Convert.ToByte(byte5, 16);
                motorB[3] = Convert.ToByte(byte6, 16);
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(motorA, 0, motorA.Length);
                    serialPort1.Write(motorB, 0, motorB.Length);
                }
                j = j - 1;
            }

        }

        // Roll Left Movement
        public void RLMovement()
        {
            string[] myArray1 = StartTimeList.ToArray();
            int[] myArray2 = IntervalList.ToArray();
            int i = 511;
            
            int caseSwitch = myArray1.Length;

            switch (caseSwitch)
            {
                case 1:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    break;
                case 2:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    break;
                case 3:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    break;
                case 4:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    break;
                case 5:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    if (mediaPlayerTimeStamp == myArray1[4])
                    {
                        uniqueinterval = myArray2[4];
                    }
                    break;
            }

            //Begins loop of movement values sent to the platform
            while (i <= 870)
            {
                for (i = 511; i <= 871; i++)
                {
                        Thread.Sleep(uniqueinterval);
                        Console.Write("MotorA/B: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2); 
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        motorB[2] = Convert.ToByte(byte3, 16);
                        motorB[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorA, 0, motorA.Length);
                            serialPort1.Write(motorB, 0, motorB.Length);
                        }
                    
                }

            }

            for (i = 871; i >= 511; i--)
            {
                    Thread.Sleep(uniqueinterval);
                    Console.Write("MotorA/B: " + i + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2); 
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    motorB[2] = Convert.ToByte(byte3, 16);
                    motorB[3] = Convert.ToByte(byte4, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorA, 0, motorA.Length);
                        serialPort1.Write(motorB, 0, motorB.Length);
                    }
                }
            

        }

        // Roll Right Movement
        public void RRMovement()
        {
            string[] myArray1 = StartTimeList.ToArray();
            int[] myArray2 = IntervalList.ToArray();
            int i = 511;
            int caseSwitch = myArray1.Length;

            switch (caseSwitch)
            {
                case 1:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    break;
                case 2:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    break;
                case 3:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    break;
                case 4:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    break;
                case 5:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        uniqueinterval = myArray2[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        uniqueinterval = myArray2[1];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        uniqueinterval = myArray2[2];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        uniqueinterval = myArray2[3];
                    }
                    if (mediaPlayerTimeStamp == myArray1[4])
                    {
                        uniqueinterval = myArray2[4];
                    }
                    break;
            }

            //Begins loop of movement values sent to the platform
            while (i >= 152)
            {
                for (i = 511; i >= 152; i--)
                {
                    Thread.Sleep(uniqueinterval);
                    Console.Write("MotorA/B: " + i + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    motorB[2] = Convert.ToByte(byte3, 16);
                    motorB[3] = Convert.ToByte(byte4, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorA, 0, motorA.Length);
                        serialPort1.Write(motorB, 0, motorB.Length);
                    }
                }

            }
            for (i = 152; i <= 511; i++)
            {
                Thread.Sleep(uniqueinterval);
                Console.Write("MotorA/B: " + i + " ");
                string byte3 = i.ToString("X4").Substring(0, 2);
                string byte4 = i.ToString("X4").Substring(2, 2);
                motorA[2] = Convert.ToByte(byte3, 16);
                motorA[3] = Convert.ToByte(byte4, 16);
                motorB[2] = Convert.ToByte(byte3, 16);
                motorB[3] = Convert.ToByte(byte4, 16);
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(motorA, 0, motorA.Length);
                    serialPort1.Write(motorB, 0, motorB.Length);
                }
            }

        }

        // User set Custom Movement
        //This Joins the motor A and motor B movement thread together so they can run at the same time
        public void CustomMovement()
        {

            Thread ta = new Thread(new ThreadStart(LoopA));
            Thread tb = new Thread(new ThreadStart(LoopB));

            ta.Start();
            tb.Start();

            ta.Join();
            tb.Join();

        }

        //Begins loop of motor A movement values sent to the platform
        public void LoopA()
        {
            string[] myArray1 = StartTimeList.ToArray();
            int[] myArray2 = MotorABeginList.ToArray();
            int[] myArray5 = MotorAEndList.ToArray();
            int[] myArray6 = MotorAMiddleList.ToArray();
            int[] myArray3 = CMBeforeIntervalAList.ToArray();
            int[] myArray4 = CMAfterIntervalAList.ToArray();
            int caseSwitch = myArray1.Length;
            int i;
            switch (caseSwitch)
            {
                case 1:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    break;
                case 2:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    break;
                case 3:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    break;
                case 4:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    break;
                case 5:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    if (mediaPlayerTimeStamp == myArray1[4])
                    {
                        MotorABeginValueI = myArray2[0];
                        MotorAEndValueI = myArray5[0];
                        MotorAMiddleValueI = myArray6[0];
                        CMBeforeIntervalA = myArray3[0];
                        CMAfterIntervalA = myArray4[0];
                    }
                    break;
            }


            if (MotorAMiddleValueI > MotorABeginValueI)
            {

                for (i = MotorABeginValueI; i <= MotorAMiddleValueI; i++)
                {
                    Thread.Sleep(CMBeforeIntervalA);
                    Console.Write("MotorA: " + i + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorA, 0, motorA.Length);
                    }
                }


                Console.WriteLine("Motor A Midpoint ");
                if (MotorAMiddleValueI >= MotorAEndValueI)
                {
                    for (i = MotorAMiddleValueI; i >= MotorAEndValueI; i--)
                    {
                        Thread.Sleep(CMAfterIntervalA);
                        Console.Write("MotorA: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorA, 0, motorA.Length);
                        }
                    }
                }
                else if (MotorAMiddleValueI <= MotorAEndValueI)
                {
                    for (i = MotorAMiddleValueI; i <= MotorAEndValueI; i++)
                    {
                        Thread.Sleep(CMAfterIntervalA);
                        Console.Write("MotorA: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorA, 0, motorA.Length);
                        }
                    }
                }
            }
            else if (MotorAMiddleValueI < MotorABeginValueI)
            {

                for (i = MotorABeginValueI; i >= MotorAMiddleValueI; i--)
                {
                    Thread.Sleep(CMBeforeIntervalA);
                    Console.Write("MotorA: " + i + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorA, 0, motorA.Length);
                    }
                }


                Console.WriteLine("Motor A Midpoint ");
                if (MotorAMiddleValueI >= MotorAEndValueI)
                {
                    for (i = MotorAMiddleValueI; i >= MotorAEndValueI; i--)
                    {
                        Thread.Sleep(CMAfterIntervalA);
                        Console.Write("MotorA: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorA, 0, motorA.Length);
                        }
                    }
                }
                else if (MotorAMiddleValueI <= MotorAEndValueI)
                {
                    for (i = MotorAMiddleValueI; i <= MotorAEndValueI; i++)
                    {
                        Thread.Sleep(CMAfterIntervalA);
                        Console.Write("MotorA: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorA, 0, motorA.Length);
                        }
                    }
                }
            }
        }

        //Begins loop of motor B movement values sent to the platform
        public void LoopB()
        {
            
            string[] myArray1 = StartTimeList.ToArray();
            int[] myArray2 = MotorBBeginList.ToArray();
            int[] myArray5 = MotorBEndList.ToArray();
            int[] myArray6 = MotorBMiddleList.ToArray();
            int[] myArray3 = CMBeforeIntervalBList.ToArray();
            int[] myArray4 = CMAfterIntervalBList.ToArray();

            int i;
            int caseSwitch = myArray1.Length;

            switch (caseSwitch)
            {
                case 1:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    break;
                case 2:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    break;
                case 3:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    break;
                case 4:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    break;
                case 5:
                    if (mediaPlayerTimeStamp == myArray1[0])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[1])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[2])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[3])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    if (mediaPlayerTimeStamp == myArray1[4])
                    {
                        MotorBBeginValueI = myArray2[0];
                        MotorBEndValueI = myArray5[0];
                        MotorBMiddleValueI = myArray6[0];
                        CMBeforeIntervalB = myArray3[0];
                        CMAfterIntervalB = myArray4[0];

                    }
                    break;
            }

            if (MotorBBeginValueI > MotorBMiddleValueI)
            {

                for (i = MotorBBeginValueI; i >= MotorBMiddleValueI; i--)
                {
                    Thread.Sleep(CMBeforeIntervalB);
                    Console.Write("MotorB: " + i + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorB, 0, motorB.Length);
                    }
                }


                Console.WriteLine("Motor B Midpoint ");
                if (MotorBMiddleValueI >= MotorBEndValueI)
                {
                    for (i = MotorBMiddleValueI; i >= MotorBEndValueI; i--)
                    {
                        Thread.Sleep(CMAfterIntervalB);
                        Console.Write("MotorB: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorB, 0, motorB.Length);
                        }
                    }
                }
                else if (MotorBMiddleValueI <= MotorBEndValueI)
                {
                    for (i = MotorBMiddleValueI; i <= MotorBEndValueI; i++)
                    {
                        Thread.Sleep(CMAfterIntervalB);
                        Console.Write("MotorB: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorB, 0, motorB.Length);
                        }
                    }
                }
            }
            else if (MotorBBeginValueI < MotorBMiddleValueI)
            {

                for (i = MotorBBeginValueI; i <= MotorBMiddleValueI; i++)
                {
                    Thread.Sleep(CMBeforeIntervalB);
                    Console.Write("MotorB: " + i + " ");
                    string byte3 = i.ToString("X4").Substring(0, 2);
                    string byte4 = i.ToString("X4").Substring(2, 2);
                    motorA[2] = Convert.ToByte(byte3, 16);
                    motorA[3] = Convert.ToByte(byte4, 16);
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write(motorB, 0, motorB.Length);
                    }
                }


                Console.WriteLine("Motor B Midpoint ");
                if (MotorBMiddleValueI >= MotorBEndValueI)
                {
                    for (i = MotorBMiddleValueI; i >= MotorBEndValueI; i--)
                    {
                        Thread.Sleep(CMAfterIntervalB);
                        Console.Write("MotorB: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorB, 0, motorB.Length);
                        }
                    }
                }
                else if (MotorBMiddleValueI <= MotorBEndValueI)
                {
                    for (i = MotorBMiddleValueI; i <= MotorBEndValueI; i++)
                    {
                        Thread.Sleep(CMAfterIntervalB);
                        Console.Write("MotorB: " + i + " ");
                        string byte3 = i.ToString("X4").Substring(0, 2);
                        string byte4 = i.ToString("X4").Substring(2, 2);
                        motorA[2] = Convert.ToByte(byte3, 16);
                        motorA[3] = Convert.ToByte(byte4, 16);
                        if (serialPort1.IsOpen)
                        {
                            serialPort1.Write(motorB, 0, motorB.Length);
                        }
                    }
                }
            }
        }

        // Opening Video Fime Click Event
        private void OpenVideoFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach (string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    listFile.DataSource = files;
                    listFile.ValueMember = "Path";
                    listFile.DisplayMember = "FileName";
                }
            }
            Fullscreen.Enabled = true;
        }

        // Timestamp buttons are made visible everytime this event is triggered
        private void SetTimeStamps_Click(object sender, EventArgs e)
        {
            if (MovementFour.Visible == true)
            {
                MovementFive.Visible = true;
            }
            if (MovementThree.Visible == true)
            {
                MovementFour.Visible = true;
            }
            if (MovementTwo.Visible == true)
            {
                MovementThree.Visible = true;
            }
            if (MovementOne.Visible == true)
            {
                MovementTwo.Visible = true;
            }
            MovementOne.Visible = true;
            
        }

        //Closes Serial Connection Port
        private void ClosePort_Click(object sender, EventArgs e)
        {
            OpenPort.Enabled = true;
            ClosePort.Enabled = false;
            serialPort1.Close();
        }

        //Opens Serial Connection Port
        public void OpenPort_Click(object sender, EventArgs e)
        {
            OpenPort.Enabled = false;
            ClosePort.Enabled = true;
            OpenConnection();

        }

        //Open Connection
        public static void OpenConnection()
        {
            Form form1 = (Form1)Application.OpenForms["Form1"];
            ComboBox PL = (ComboBox)form1.Controls["portList"];
            try
            {
                serialPort1.PortName = PL.Text;

                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show("Connected To Serial Port", "Connected", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Failed To Connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ArgumentException ex)
            {
                exceptionname = "Argument";
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Fullscreen_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer.fullScreen = true;
            }
        }

        //Sets User Controlled Timestamps for Movements
        private void MovementOne_Click(object sender, EventArgs e)
        {
            Movements.TimestampCreation();
            StartTimeList.Add(StartTimeStamp);
            EndTimeList.Add(EndTimeStamp);
            IntervalList.Add(interval);
            Movement1.Visible = true;
            
        }

        private void MovementTwo_Click(object sender, EventArgs e)
        {
            Movements.TimestampCreation();
            StartTimeList.Add(StartTimeStamp);
            EndTimeList.Add(EndTimeStamp);
            IntervalList.Add(interval);
            Movement2.Visible = true;
            
        }

        private void MovementThree_Click(object sender, EventArgs e)
        {
            Movements.TimestampCreation();
            StartTimeList.Add(StartTimeStamp);
            EndTimeList.Add(EndTimeStamp);
            IntervalList.Add(interval);
            Movement3.Visible = true;
            
        }

        private void MovementFour_Click(object sender, EventArgs e)
        {
            Movements.TimestampCreation();
            StartTimeList.Add(StartTimeStamp);
            EndTimeList.Add(EndTimeStamp);
            IntervalList.Add(interval);
            Movement4.Visible = true;
            
        }

        private void MovementFive_Click(object sender, EventArgs e)
        {
            Movements.TimestampCreation();
            StartTimeList.Add(StartTimeStamp);
            EndTimeList.Add(EndTimeStamp);
            IntervalList.Add(interval);
            Movement5.Visible = true;
            
        }


        
            private void M2Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            M2 = Movement2.Text;
            Movements.Movementtwo();
        }

        private void M3Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            M3 = Movement3.Text;
            Movements.Movementthree();
        }

        private void M4Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            M4 = Movement4.Text;
            Movements.Movementfour();
        }

        private void M5Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            M5 = Movement5.Text;
            Movements.Movementfive();
        }

        private void M1Dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            M1 = Movement1.Text;
            Movements.Movementone();
        }

        private void SavePreset1_Click(object sender, EventArgs e)
        {
            PresetNo = "1";
            Presets.SaveData();
        }

        private void LoadPreset1_Click(object sender, EventArgs e)
        {
            PresetNo = "1";
            Presets.LoadData();
        }

        private void CreatePreset_Click(object sender, EventArgs e)
        {
            Presets.EnterPath();
            Presets.CreatePreset();
        }

        private void SavePreset2_Click(object sender, EventArgs e)
        {
            PresetNo = "2";
            Presets.SaveData();
        }

        private void LoadPreset2_Click(object sender, EventArgs e)
        {
            PresetNo = "2";
            Presets.LoadData();
        }

        private void SavePreset3_Click(object sender, EventArgs e)
        {
            PresetNo = "3";
            Presets.SaveData();
        }

        private void LoadPreset3_Click(object sender, EventArgs e)
        {
            PresetNo = "3";
            Presets.LoadData();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            PresetNo = "4";
            Presets.SaveData();
        }

        private void LoadPreset4_Click(object sender, EventArgs e)
        {
            PresetNo = "4";
            Presets.LoadData();
        }

        private void SavePreset5_Click(object sender, EventArgs e)
        {
            PresetNo = "5";
            Presets.SaveData();
        }

        private void LoadPreset5_Click(object sender, EventArgs e)
        {
            PresetNo = "5";
            Presets.LoadData();
        }

        private void MotorADropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            PIDTermA = comboBox2.Text;
            MotorSettings.MotorASettings();
        }

        private void MotorBDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            PIDTermB = comboBox3.Text;
            MotorSettings.MotorBSettings();
        }

        private void MotorASettings_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
        }

        private void MotorBSettings_Click(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
        }

        private void ChangePath_Click(object sender, EventArgs e)
        {
            Presets.ChangePath();
        }

        private void DeletePreset1_Click(object sender, EventArgs e)
        {
            PresetNo = "1";
            Presets.DeletePreset();
        }

        private void DeletePreset2_Click(object sender, EventArgs e)
        {
            PresetNo = "2";
            Presets.DeletePreset();
        }

        private void DeletePreset3_Click(object sender, EventArgs e)
        {
            PresetNo = "3";
            Presets.DeletePreset();
        }

        private void DeletePreset4_Click(object sender, EventArgs e)
        {
            PresetNo = "4";
            Presets.DeletePreset();
        }

        private void DeletePreset5_Click(object sender, EventArgs e)
        {
            PresetNo = "5";
            Presets.DeletePreset();
        }

        private void MotorAFeedbackEnable_Click(object sender, EventArgs e)
        {
            MotorSettings.MotorAFeedbackEnable();
        }

        private void MotorAFeedbackDisable_Click(object sender, EventArgs e)
        {
            MotorSettings.MotorAFeedbackDisable();
        }

        private void MotorBFeedbackEnable_Click(object sender, EventArgs e)
        {
            MotorSettings.MotorBFeedbackEnable();
        }

        private void MotorBFeedbackDisable_Click(object sender, EventArgs e)
        {
            MotorSettings.MotorBFeedbackDisable();
        }

    }
}









