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
    class MotorSettings : Form1
    {
        public static byte[] PotentialMotorA = new byte[5];
        public static byte[] IntegralMotorA = new byte[5];
        public static byte[] DerivativeMotorA = new byte[5];
        public static byte[] SmoothingMotorA = new byte[5];
        public static byte[] PotentialMotorB = new byte[5];
        public static byte[] IntegralMotorB = new byte[5];
        public static byte[] DerivativeMotorB = new byte[5];
        public static byte[] SmoothingMotorB = new byte[5];
        public static byte[] PWMMotorA = new byte[5];
        public static byte[] PWMMotorB = new byte[5];

        public static bool ActiveA { get; set; }
        public static bool ActiveB { get; set; }


        public MotorSettings()
        {
            PotentialMotorA[0] = 0x5B;
            PotentialMotorA[1] = 0x44;
            PotentialMotorA[4] = 0x5D;
            IntegralMotorA[0] = 0x5B;
            IntegralMotorA[1] = 0x47;
            IntegralMotorA[4] = 0x5D;
            DerivativeMotorA[0] = 0x5B;
            DerivativeMotorA[1] = 0x4A;
            DerivativeMotorA[4] = 0x5D;
            SmoothingMotorA[0] = 0x5B;
            SmoothingMotorA[1] = 0x4D;
            SmoothingMotorA[4] = 0x5D;
            PWMMotorA[0] = 0x5B;
            PWMMotorA[1] = 0x50;
            PWMMotorA[4] = 0x5D;
            PotentialMotorB[0] = 0x5B;
            PotentialMotorB[1] = 0x45;
            PotentialMotorB[4] = 0x5D;
            IntegralMotorB[0] = 0x5B;
            IntegralMotorB[1] = 0x48;
            IntegralMotorB[4] = 0x5D;
            DerivativeMotorB[0] = 0x5B;
            DerivativeMotorB[1] = 0x4B;
            DerivativeMotorB[4] = 0x5D;
            SmoothingMotorB[0] = 0x5B;
            SmoothingMotorB[1] = 0x4E;
            SmoothingMotorB[4] = 0x5D;
            PWMMotorB[0] = 0x5B;
            PWMMotorB[1] = 0x51;
            PWMMotorB[4] = 0x5D;
        }

        //Checks if combobox list selection matches a specific motor settings string which in turn runs the method
        public static void MotorBSettings()
        {
            if (PIDTermB == "Potential Term")
            {
                PTSettingsB();
            }
            if (PIDTermB == "Integral Term")
            {
                ITSettingsB();
            }
            if (PIDTermB == "Derivative Term")
            {
                DTSettingsB();
            }
            if (PIDTermB == "Smoothing Term")
            {
                STSettingsB();
            }
            if (PIDTermB == "PWM")
            {
                PWMB();
            }
        }

        public static void MotorASettings()
        {
            if (PIDTermA == "Potential Term")
            {
                PTSettingsA();
            }
            if (PIDTermA == "Integral Term")
            {
                ITSettingsA();
            }
            if (PIDTermA == "Derivative Term")
            {
                DTSettingsA();
            }
            if (PIDTermA == "Smoothing Term")
            {
                STSettingsA();
            }
            if (PIDTermA == "PWM")
            {
                PWMA();
            }
        }

        //Feedback Enable and Disable Logic
        public static void MotorAFeedbackEnable()
        {
            Thread read = new Thread(new ThreadStart(ReadMotion));
            if (ActiveA == false)
            {
                read.Start();
                ActiveA = true;
                byte[] MotorAFeedback = new byte[5];
                MotorAFeedback[0] = 0x5B; ;
                MotorAFeedback[1] = 0x6D;
                MotorAFeedback[2] = 0x6F;
                MotorAFeedback[3] = 0x31;
                MotorAFeedback[4] = 0x5D;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(MotorAFeedback, 0, MotorAFeedback.Length);
                }
            }
        }

        public static void MotorAFeedbackDisable()
        {
            if (ActiveA == true)
            {
                ActiveA = false;
                byte[] DisableMotorAFeedback = new byte[5];
                DisableMotorAFeedback[0] = 0x5B; ;
                DisableMotorAFeedback[1] = 0x6D;
                DisableMotorAFeedback[2] = 0x6F;
                DisableMotorAFeedback[3] = 0x30;
                DisableMotorAFeedback[4] = 0x5D;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(DisableMotorAFeedback, 0, DisableMotorAFeedback.Length);
                }
            }
        }

        public static void MotorBFeedbackEnable()
        {
            Thread read = new Thread(new ThreadStart(MotorSettings.ReadMotion));
            if (ActiveB == false)
            {
                read.Start();
                ActiveB = true;
                byte[] MotorBFeedback = new byte[5];
                MotorBFeedback[0] = 0x5B; ;
                MotorBFeedback[1] = 0x6D;
                MotorBFeedback[2] = 0x6F;
                MotorBFeedback[3] = 0x32;
                MotorBFeedback[4] = 0x5D;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(MotorBFeedback, 0, MotorBFeedback.Length);
                }
            }
        }

        public static void MotorBFeedbackDisable()
        {
            if (ActiveB == true)
            {
                ActiveB = false;
                byte[] DisableMotorBFeedback = new byte[5];
                DisableMotorBFeedback[0] = 0x5B; ;
                DisableMotorBFeedback[1] = 0x6D;
                DisableMotorBFeedback[2] = 0x6F;
                DisableMotorBFeedback[3] = 0x30;
                DisableMotorBFeedback[4] = 0x5D;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(DisableMotorBFeedback, 0, DisableMotorBFeedback.Length);
                }
            }
        }
    


        //Potential Term Motor A method
        public static void PTSettingsA()
        {
            
            try
            {
                string defaultValueP = "400";
                int PotentialValueI;
                string PotentialValue = Interaction.InputBox("Potential Term Value", "Please Enter Value Between 0 and 1000", defaultValueP, -1, -1);
                PotentialValueI = Int32.Parse(PotentialValue);
                string byte3 = PotentialValueI.ToString("X4").Substring(0, 2);
                string byte4 = PotentialValueI.ToString("X4").Substring(2, 2);         
                PotentialMotorA[2] = Convert.ToByte(byte3, 16);
                PotentialMotorA[3] = Convert.ToByte(byte4, 16);
                
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(PotentialMotorA, 0, PotentialMotorA.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Integral Term Motor A method
        public static void ITSettingsA()
        {
            try
            {
                string defaultValueI = "0";
                int IntegralValueI;
                string IntegralValue = Interaction.InputBox("Integral Term Value", "Please Enter Value Between 0 and 1000", defaultValueI, -1, -1);
                IntegralValueI = Int32.Parse(IntegralValue);
                string byte3 = IntegralValueI.ToString("X4").Substring(0, 2);
                string byte4 = IntegralValueI.ToString("X4").Substring(2, 2);

                IntegralMotorA[2] = Convert.ToByte(byte3, 16);
                IntegralMotorA[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(IntegralMotorA, 0, IntegralMotorA.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Derivative Term Motor A method
        public static void DTSettingsA()
        {
            try
            {
                string defaultValueD = "0";
                int DerivativeValueI;
                string DerivativeValue = Interaction.InputBox("Derivative Term Value", "Please Enter Value Between 0 and 1000", defaultValueD, -1, -1);
                DerivativeValueI = Int32.Parse(DerivativeValue);
                string byte3 = DerivativeValueI.ToString("X4").Substring(0, 2);
                string byte4 = DerivativeValueI.ToString("X4").Substring(2, 2);

                DerivativeMotorA[2] = Convert.ToByte(byte3, 16);
                DerivativeMotorA[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(DerivativeMotorA, 0, DerivativeMotorA.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Smoothing Term Motor A method
        public static void STSettingsA()
        {
            try
            {
                string defaultValueS = "1";
                int SmoothingValueI;
                string SmoothingValue = Interaction.InputBox("Smoothing Term Value", "Please Enter Value Between 1 and 20", defaultValueS, -1, -1);
                SmoothingValueI = Int32.Parse(SmoothingValue);
                string byte3 = SmoothingValueI.ToString("X4").Substring(0, 2);
                string byte4 = SmoothingValueI.ToString("X4").Substring(2, 2);

                SmoothingMotorA[2] = Convert.ToByte(byte3, 16);
                SmoothingMotorA[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(SmoothingMotorA, 0, SmoothingMotorA.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Pulse Width Modulation Motor A
        public static void PWMA()
        {
            try
            {
                string PWMmindefaultValueA = "1";
                int PWMminValueAI;
                string PWMminValueA = Interaction.InputBox("PWMmin Value", "Please Enter Value Between 0 and 255", PWMmindefaultValueA, -1, -1);
                PWMminValueAI = Int32.Parse(PWMminValueA);
                string PWMmaxdefaultValueA = "1";
                int PWMmaxValueAI;
                string PWMmaxValueA = Interaction.InputBox("PWMmax Value", "Please Enter Value Between 0 and 255", PWMmaxdefaultValueA, -1, -1);
                PWMmaxValueAI = Int32.Parse(PWMmaxValueA);
                string byte3 = PWMminValueAI.ToString("X2");
                string byte4 = PWMmaxValueAI.ToString("X2");

                PWMMotorA[2] = Convert.ToByte(byte3, 16);
                PWMMotorA[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(PWMMotorA, 0, PWMMotorA.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Potential Term Motor B method
        public static void PTSettingsB()
        {
            try
            {
                string defaultValueP = "400";
                int PotentialValueI;
                string PotentialValue = Interaction.InputBox("Potential Term Value", "Please Enter Value Between 0 and 1000", defaultValueP, -1, -1);
                PotentialValueI = Int32.Parse(PotentialValue);
                string byte3 = PotentialValueI.ToString("X4").Substring(0, 2);
                string byte4 = PotentialValueI.ToString("X4").Substring(2, 2);

                PotentialMotorB[2] = Convert.ToByte(byte3, 16);
                PotentialMotorB[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(PotentialMotorB, 0, PotentialMotorB.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Integral Term Motor B method
        public static void ITSettingsB()
        {
            try
            {
                string defaultValueI = "0";
                int IntegralValueI;
                string IntegralValue = Interaction.InputBox("Integral Term Value", "Please Enter Value Between 0 and 1000", defaultValueI, -1, -1);
                IntegralValueI = Int32.Parse(IntegralValue);
                string byte3 = IntegralValueI.ToString("X4").Substring(0, 2);
                string byte4 = IntegralValueI.ToString("X4").Substring(2, 2);

                IntegralMotorB[2] = Convert.ToByte(byte3, 16);
                IntegralMotorB[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(IntegralMotorB, 0, IntegralMotorB.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Derivative Term Motor B method
        public static void DTSettingsB()
        {
            try
            { 
                string defaultValueD = "0";
                int DerivativeValueI;
                string DerivativeValue = Interaction.InputBox("Derivative Term Value", "Please Enter Value Between 0 and 1000", defaultValueD, -1, -1);
                DerivativeValueI = Int32.Parse(DerivativeValue);
                string byte3 = DerivativeValueI.ToString("X4").Substring(0, 2);
                string byte4 = DerivativeValueI.ToString("X4").Substring(2, 2);

                DerivativeMotorB[2] = Convert.ToByte(byte3, 16);
                DerivativeMotorB[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(DerivativeMotorB, 0, DerivativeMotorB.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Smoothing Term Motor B method
        public static void STSettingsB()
        {
            try
            {
                string defaultValueS = "1";
                int SmoothingValueI;
                string SmoothingValue = Interaction.InputBox("Smoothing Term Value", "Please Enter Value Between 1 and 20", defaultValueS, -1, -1);
                SmoothingValueI = Int32.Parse(SmoothingValue);
                string byte3 = SmoothingValueI.ToString("X4").Substring(0, 2);
                string byte4 = SmoothingValueI.ToString("X4").Substring(2, 2);

                SmoothingMotorB[2] = Convert.ToByte(byte3, 16);
                SmoothingMotorB[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(SmoothingMotorB, 0, SmoothingMotorB.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Pulse Width Modulation Motor B
        public static void PWMB()
        {
            try
            {     
                string PWMmindefaultValueB = "1";
                int PWMminValueBI;
                string PWMminValueB = Interaction.InputBox("PWMmin Value", "Please Enter Value Between 0 and 255", PWMmindefaultValueB, -1, -1);
                PWMminValueBI = Int32.Parse(PWMminValueB);
                string PWMmaxdefaultValueB = "1";
                int PWMmaxValueBI;
                string PWMmaxValueB = Interaction.InputBox("PWMmax Value", "Please Enter Value Between 0 and 255", PWMmaxdefaultValueB, -1, -1);
                PWMmaxValueBI = Int32.Parse(PWMmaxValueB);
                string byte3 = PWMminValueBI.ToString("X2");
                string byte4 = PWMmaxValueBI.ToString("X2");

                PWMMotorB[2] = Convert.ToByte(byte3, 16);
                PWMMotorB[3] = Convert.ToByte(byte4, 16);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(PWMMotorB, 0, PWMMotorB.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void ReadMotion()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10;
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerEventProcessor);
            timer.Start();

        }

        // Reads incoming Platform Data
        public static void TimerEventProcessor(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    string incoming = serialPort1.ReadLine();
                    Console.WriteLine(incoming);
                }
                catch (TimeoutException) { }
            }
        }
    }
}
