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
using System.Text.RegularExpressions;

namespace John_s_Media_Player
{
    public class Movements : Form1
    {
        public static int srtfirstsec { get; set; }
        public static int srtsecondsec { get; set; }
        public static int srtfirstmin { get; set; }
        public static int srtsecondmin { get; set; }
        public static int endfirstsec { get; set; }
        public static int endsecondsec { get; set; }
        public static int endfirstmin { get; set; }
        public static int endsecondmin { get; set; }
        public static int srtfirstminsecs { get; set; }
        public static int srtsecondminsecs { get; set; }
        public static int srtsecondsecsecs { get; set; }
        public static int endfirstminsecs { get; set; }
        public static int endsecondminsecs { get; set; }
        public static int endsecondsecsecs { get; set; }
       
        public Movements()
        {
           
        }

        // If the user chooses a custom movement, these are the values added to the movement data
        public static void Movementone()
        {
            if (M1 == "Custom Movement")
            {
                CMSettings();
                MidTimeStamp();
                MotorABeginList.Add(MotorABeginValueI);
                MotorBBeginList.Add(MotorBBeginValueI);
                MotorAMiddleList.Add(MotorAMiddleValueI);
                MotorBMiddleList.Add(MotorBMiddleValueI);
                MotorAEndList.Add(MotorAEndValueI);
                MotorBEndList.Add(MotorBEndValueI);
                CMBeforeIntervalAList.Add(CMBeforeIntervalA);
                CMBeforeIntervalBList.Add(CMBeforeIntervalB);
                CMAfterIntervalAList.Add(CMAfterIntervalA);
                CMAfterIntervalBList.Add(CMAfterIntervalB);
            }
        }

        public static void Movementtwo()
        {
            if (M2 == "Custom Movement")
            {
                CMSettings();
                MidTimeStamp();
                MotorABeginList.Add(MotorABeginValueI);
                MotorBBeginList.Add(MotorBBeginValueI);
                MotorAMiddleList.Add(MotorAMiddleValueI);
                MotorBMiddleList.Add(MotorBMiddleValueI);
                MotorAEndList.Add(MotorAEndValueI);
                MotorBEndList.Add(MotorBEndValueI);
                CMBeforeIntervalAList.Add(CMBeforeIntervalA);
                CMBeforeIntervalBList.Add(CMBeforeIntervalB);
                CMAfterIntervalAList.Add(CMAfterIntervalA);
                CMAfterIntervalBList.Add(CMAfterIntervalB);
            }
        }

        public static void Movementthree()
        {  
            if (M3 == "Custom Movement")
            {
                CMSettings();
                MidTimeStamp();
                MotorABeginList.Add(MotorABeginValueI);
                MotorBBeginList.Add(MotorBBeginValueI);
                MotorAMiddleList.Add(MotorAMiddleValueI);
                MotorBMiddleList.Add(MotorBMiddleValueI);
                MotorAEndList.Add(MotorAEndValueI);
                MotorBEndList.Add(MotorBEndValueI);
                CMBeforeIntervalAList.Add(CMBeforeIntervalA);
                CMBeforeIntervalBList.Add(CMBeforeIntervalB);
                CMAfterIntervalAList.Add(CMAfterIntervalA);
                CMAfterIntervalBList.Add(CMAfterIntervalB);
            }
        }

        public static void Movementfour()
        {
            if (M4 == "Custom Movement")
            {
                CMSettings();
                MidTimeStamp();
                MotorABeginList.Add(MotorABeginValueI);
                MotorBBeginList.Add(MotorBBeginValueI);
                MotorAMiddleList.Add(MotorAMiddleValueI);
                MotorBMiddleList.Add(MotorBMiddleValueI);
                MotorAEndList.Add(MotorAEndValueI);
                MotorBEndList.Add(MotorBEndValueI);
                CMBeforeIntervalAList.Add(CMBeforeIntervalA);
                CMBeforeIntervalBList.Add(CMBeforeIntervalB);
                CMAfterIntervalAList.Add(CMAfterIntervalA);
                CMAfterIntervalBList.Add(CMAfterIntervalB);
            }
        }

        public static void Movementfive()
        {
            if (M5 == "Custom Movement")
            {
                CMSettings();
                MidTimeStamp();
                MotorABeginList.Add(MotorABeginValueI);
                MotorBBeginList.Add(MotorBBeginValueI);
                MotorAMiddleList.Add(MotorAMiddleValueI);
                MotorBMiddleList.Add(MotorBMiddleValueI);
                MotorAEndList.Add(MotorAEndValueI);
                MotorBEndList.Add(MotorBEndValueI);
                CMBeforeIntervalAList.Add(CMBeforeIntervalA);
                CMBeforeIntervalBList.Add(CMBeforeIntervalB);
                CMAfterIntervalAList.Add(CMAfterIntervalA);
                CMAfterIntervalBList.Add(CMAfterIntervalB);
            }
        }
       
        // User inputs Custom Movement Setting here
        public static void CMSettings()
        {
            try
            {
                
                string defaultValueBM = "511";
                string MotorABeginValue = Interaction.InputBox("Motor A Beginning Position Value", "Please Enter Value Between 151 and 871", defaultValueBM, -1, -1);
                MotorABeginValueI = Int32.Parse(MotorABeginValue);

                string MotorBBeginValue = Interaction.InputBox("Motor B Beginning Position Value", "Please Enter Value Between 151 and 871", defaultValueBM, -1, -1);
                MotorBBeginValueI = Int32.Parse(MotorBBeginValue);

                string defaultValueMM = "511";
                string MotorAMiddleValue = Interaction.InputBox("Motor A Middle Position Value", "Please Enter Value Between 151 and 871", defaultValueMM, -1, -1);
                MotorAMiddleValueI = Int32.Parse(MotorAMiddleValue);

                string MotorBMiddleValue = Interaction.InputBox("Motor B Middle Position Value", "Please Enter Value Between 151 and 871", defaultValueMM, -1, -1);
                MotorBMiddleValueI = Int32.Parse(MotorBMiddleValue);

                string defaultValueEM = "511";
                string MotorAEndValue = Interaction.InputBox("Motor A End Position Value", "Please Enter Value Between 151 and 871", defaultValueEM, -1, -1);
                MotorAEndValueI = Int32.Parse(MotorAEndValue);

                string MotorBEndValue = Interaction.InputBox("Motor B End Position Value", "Please Enter Value Between 151 and 871", defaultValueEM, -1, -1);
                MotorBEndValueI = Int32.Parse(MotorBEndValue);


                int errorcounter = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (MotorABeginValueI > 871 || MotorABeginValueI < 151)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MotorABeginValue = Interaction.InputBox("Motor A Beginning Position Value", "Please Enter Value Between 151 and 871", defaultValueBM, -1, -1);
                        MotorABeginValueI = Int32.Parse(MotorABeginValue);
                        errorcounter++;
                    }
                    if (MotorBBeginValueI > 871 || MotorBBeginValueI < 151)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MotorBBeginValue = Interaction.InputBox("Motor B Beginning Position Value", "Please Enter Value Between 151 and 871", defaultValueBM, -1, -1);
                        MotorBBeginValueI = Int32.Parse(MotorBBeginValue);
                        errorcounter++;
                    }
                    if (MotorAMiddleValueI > 871 || MotorAMiddleValueI < 151 || MotorAMiddleValueI == MotorABeginValueI)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MotorAMiddleValue = Interaction.InputBox("Motor A Middle Position Value", "Please Enter Value Between 151 and 871", defaultValueMM, -1, -1);
                        MotorAMiddleValueI = Int32.Parse(MotorAMiddleValue);
                        errorcounter++;
                    }
                    if (MotorBMiddleValueI > 871 || MotorBMiddleValueI < 151 || MotorBMiddleValueI == MotorBBeginValueI)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MotorBMiddleValue = Interaction.InputBox("Motor B Middle Position Value", "Please Enter Value Between 151 and 871", defaultValueMM, -1, -1);
                        MotorBMiddleValueI = Int32.Parse(MotorBMiddleValue);
                        errorcounter++;
                    }
                    if (MotorAEndValueI > 871 || MotorAEndValueI < 151 || MotorAEndValueI == MotorAMiddleValueI)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MotorAEndValue = Interaction.InputBox("Motor A End Position Value", "Please Enter Value Between 151 and 871", defaultValueEM, -1, -1);
                        MotorAEndValueI = Int32.Parse(MotorAEndValue);
                        errorcounter++;
                    }
                    if (MotorBEndValueI > 871 || MotorBEndValueI < 151 || MotorBEndValueI == MotorBMiddleValueI)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MotorBEndValue = Interaction.InputBox("Motor B End Position Value", "Please Enter Value Between 151 and 871", defaultValueEM, -1, -1);
                        MotorBEndValueI = Int32.Parse(MotorBEndValue);
                        errorcounter++;
                    }
                    Console.WriteLine("Error Count: " + errorcounter);
                }

                if (errorcounter == 5)
                {
                    throw new MovementValueException();
                }

            }
            catch (MovementValueException ex)
            {
                exceptionname = "MovementValue";
                MessageBox.Show(ex.Message, "OutofRange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                exceptionname = "Format";
                MessageBox.Show(ex.Message, "Format issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Set Middle Time Stamp
        public static void MidTimeStamp()
        {
            try
            {
                string defaultValue = "00:00";
                MiddleTimeStamp = Interaction.InputBox("Middle Time Stamp", "Please Enter Value", defaultValue, -1, -1);

                int errorcounter = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (MiddleTimeStamp.Length > 5 || Char.IsNumber(MiddleTimeStamp, 2) == true)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MiddleTimeStamp = Interaction.InputBox("Middle Time Stamp", "Please Enter Valid Value", defaultValue, -1, -1);
                        errorcounter++;
                    }
                    Console.WriteLine("Error Count: " + errorcounter);
                }

                if (errorcounter == 5) 
                {
                    throw new UnnecessayFormatException();
                }

                char midfirstsecchar = MiddleTimeStamp[4];
                int midfirstsec = int.Parse(midfirstsecchar.ToString());

                char midsecondsecchar = MiddleTimeStamp[3];
                int midsecondsec = int.Parse(midsecondsecchar.ToString());

                char midfirstminchar = MiddleTimeStamp[1];
                int midfirstmin = int.Parse(midfirstminchar.ToString());

                char midsecondminchar = MiddleTimeStamp[0];
                int midsecondmin = int.Parse(midsecondminchar.ToString());

                int midfirstminsecs = midfirstmin * 60;

                int midsecondminsecs = midsecondmin * 600;

                int midsecondsecsecs = midsecondsec * 10;

                int totalmiddletimestampsecs = midfirstminsecs + midsecondminsecs + midsecondsecsecs + midfirstsec;

                int TimeToMidpoint = totalmiddletimestampsecs - totalstarttimestampsecs;

                int beforenumberofpacketstosendA;
                int afternumberofpacketstosendA;
                int beforenumberofpacketstosendB;
                int afternumberofpacketstosendB;
                if (MotorAMiddleValueI > MotorABeginValueI)
                {
                    beforenumberofpacketstosendA = MotorAMiddleValueI - MotorABeginValueI;
                }
                else
                {
                    beforenumberofpacketstosendA = MotorABeginValueI - MotorAMiddleValueI;
                }

                if (MotorAEndValueI > MotorAMiddleValueI)
                {
                    afternumberofpacketstosendA = MotorAEndValueI - MotorAMiddleValueI;
                }
                else
                {
                    afternumberofpacketstosendA = MotorAMiddleValueI - MotorAEndValueI;
                }

                if (MotorBMiddleValueI > MotorBBeginValueI)
                {
                    beforenumberofpacketstosendB = MotorBMiddleValueI - MotorBBeginValueI;
                }
                else
                {
                    beforenumberofpacketstosendB = MotorBBeginValueI - MotorBMiddleValueI;
                }

                if (MotorBEndValueI > MotorBMiddleValueI)
                {
                    afternumberofpacketstosendB = MotorBEndValueI - MotorBMiddleValueI;
                }
                else
                {
                    afternumberofpacketstosendB = MotorBMiddleValueI - MotorBEndValueI;
                }

                 CMBeforeIntervalA = (int)Math.Ceiling((double)TimeToMidpoint * 950 / beforenumberofpacketstosendA);

                 CMBeforeIntervalB = (int)Math.Ceiling((double)TimeToMidpoint * 950 / beforenumberofpacketstosendB);

                int TimeFromMidpoint = totalendtimestampsecs - totalmiddletimestampsecs;

                 CMAfterIntervalA = (int)Math.Ceiling((double)TimeFromMidpoint * 950 / afternumberofpacketstosendA);

                 CMAfterIntervalB = (int)Math.Ceiling((double)TimeFromMidpoint * 950 / afternumberofpacketstosendB);

                if (TimeToMidpoint <= 0)
                {
                    throw new TimingException();
                }

                if (TimeFromMidpoint <= 0)
                {
                    throw new TimingException();
                }

            }
            catch (FormatException ex)
            {
                exceptionname = "Format";
                MessageBox.Show(ex.Message, "Format issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimingException ex)
            {
                exceptionname = "Timing";
                MessageBox.Show(ex.Message, "You have entered incorrectly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnnecessayFormatException ex)
            {
                exceptionname = "UnnecessayFormat";
                MessageBox.Show(ex.Message, "You have entered incorrectly too many times", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class TimingException : Exception
        {
            public TimingException()
            {
            }

            public TimingException(string message)
                : base(message)
            {
            }

            public TimingException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class UnnecessayFormatException : Exception
        {
            public UnnecessayFormatException()
            {
            }

            public UnnecessayFormatException(string message)
                : base(message)
            {
            }

            public UnnecessayFormatException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class MovementValueException : Exception
        {
            public MovementValueException()
            {
            }

            public MovementValueException(string message)
                : base(message)
            {
            }

            public MovementValueException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        // Timestamps are taken from user and conveted into a total number of seconds
        public static void TimestampCreation() 
        {
            
            try
            {

                string defaultValue = "00:00";
                StartTimeStamp = Interaction.InputBox("Start Time Stamp", "Please Enter Value", defaultValue, -1, -1);

                EndTimeStamp = Interaction.InputBox("End Time Stamp", "Please Enter Value", defaultValue, -1, -1);

                int errorcounter = 0;
                for (int i = 0; i < 5; i++) {

                    if (StartTimeStamp.Length > 5 || Char.IsNumber(StartTimeStamp, 2) == true)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StartTimeStamp = Interaction.InputBox("Start Time Stamp", "Please Enter Valid Value", defaultValue, -1, -1);
                        errorcounter++;
                    }

                    if (EndTimeStamp.Length > 5 || Char.IsNumber(EndTimeStamp, 2) == true)
                    {
                        MessageBox.Show("You have entered incorrectly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        EndTimeStamp = Interaction.InputBox("End Time Stamp", "Please Enter Valid Value", defaultValue, -1, -1);
                        errorcounter++;
                    }

                    Console.WriteLine("Error Count: " + errorcounter);
                }

                if (errorcounter == 5) 
                {   
                    throw new UnnecessayFormatException();
                }

                char srtfirstsecchar = StartTimeStamp[4];
                 srtfirstsec = int.Parse(srtfirstsecchar.ToString());

                char srtsecondsecchar = StartTimeStamp[3];
                 srtsecondsec = int.Parse(srtsecondsecchar.ToString());

                char srtfirstminchar = StartTimeStamp[1];
                 srtfirstmin = int.Parse(srtfirstminchar.ToString());

                char srtsecondminchar = StartTimeStamp[0];
                 srtsecondmin = int.Parse(srtsecondminchar.ToString());

                char endfirstsecchar = EndTimeStamp[4];
                 endfirstsec = int.Parse(endfirstsecchar.ToString());

                char endsecondsecchar = EndTimeStamp[3];
                 endsecondsec = int.Parse(endsecondsecchar.ToString());

                char endfirstminchar = EndTimeStamp[1];
                 endfirstmin = int.Parse(endfirstminchar.ToString());

                char endsecondminchar = EndTimeStamp[0];
                 endsecondmin = int.Parse(endsecondminchar.ToString());

                srtfirstminsecs = srtfirstmin * 60;

                srtsecondminsecs = srtsecondmin * 600;

                srtsecondsecsecs = srtsecondsec * 10;

                endfirstminsecs = endfirstmin * 60;

                endsecondminsecs = endsecondmin * 600;

                endsecondsecsecs = endsecondsec * 10;

                totalstarttimestampsecs = srtfirstminsecs + srtsecondminsecs + srtsecondsecsecs + srtfirstsec;

                totalendtimestampsecs = endfirstminsecs + endsecondminsecs + endsecondsecsecs + endfirstsec;

                totaltime = totalendtimestampsecs - totalstarttimestampsecs;

                interval = (int)Math.Ceiling((double)totaltime * 1000 / 720);

                intervalstring = interval.ToString();

                Console.Write("Interval: " + interval);

                if (totaltime <= 0)
                {
                    throw new TimingException();
                }

            }
            catch (FormatException ex)
            {
                exceptionname = "Format";
                MessageBox.Show(ex.Message, "Format issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimingException ex)
            {
                exceptionname = "Timing";
                MessageBox.Show(ex.Message, "You have entered incorrectly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnnecessayFormatException ex)
            {
                exceptionname = "UnnecessayFormat";
                MessageBox.Show(ex.Message, "You have entered incorrectly too many times", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
