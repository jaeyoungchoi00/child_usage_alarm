using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography; 


namespace UsageAlarm
{
    public partial class UsageAlarm : Form
    {

        public static string limitedProgramFilePath;

        private TimeSpan elapsedTS;// elapsed time from start 
        private TimeSpan allowedTS; // alowed time in minute 
        private TimeSpan repeatTS; // repeat time in minute 
        private string soundFilePath;
        private List<String> limitedProgramList = new List<string>();
        private const int voiceRepeatCount = 1;
        private const int defaultAllowedTime = 30; // 30 min
        private const int defaultRepeatTime = 10; //10 min
        private bool usageTimeFromSystemUpFlag = true;  // ignore program list. just count from system up time  
        private smtpNoti mailSender; // send notification email when the allowed time exceeded. 
        private bool mailSentFlag = false; // Send only once. Subsequent mail can be regarded as spam. 
        private string mailToAddr = "jyoungchoi0@gmail.com"; 


        public UsageAlarm()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {

            
            this.allowedTS = new TimeSpan(0, defaultAllowedTime, 0);// initially 30 min 
            tb_AllowdTime.Text = this.allowedTS.ToString(); 
            

            TimeSpan remainedTS = new TimeSpan();
            remainedTS = remainedTS.Add(this.allowedTS);
            lb_RemainedTime.Text = remainedTS.ToString();
            
            this.elapsedTS = new TimeSpan();
            lb_ElapsedTime.Text = elapsedTS.ToString();

            this.repeatTS = new TimeSpan(0, defaultRepeatTime, 0); // initially 10 min 
            tb_RepeatTime.Text = this.repeatTS.ToString(); 

            //soundFilePath = Directory.GetCurrentDirectory() + "\\stop_01.wav";  //@"C:\Windows\Media\Alarm01.wav"; // Default 
            soundFilePath = String.Empty; 
            this.limitedProgramList.Clear();


            if (false == loadLimitedProgramList())
                MessageBox.Show("사용 제한 프로그램 목록 파일이 없습니다.");

            this.elapsedTimer.Interval = 1000; // 1s
            this.elapsedTimer.Start();

            this.cb_Uptime.Checked = usageTimeFromSystemUpFlag; 

            disableAllowedTime();

            mailSender = new smtpNoti();
            mailSentFlag = false;
            this.tb_emailAddr.Text = mailToAddr; 

        }



        /// <summary>
        /// expires every 1 min. increase elapsed time and reduce the remained time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elapsedTimer_Tick(object sender, EventArgs e)
        {
            
            if (isLimitedProgramExecuting())
            {
                this.elapsedTS = this.elapsedTS.Add(new TimeSpan(0,0,1));

                TimeSpan remainedTS = updateElapsedRemainedTimeText(); 

                if (remainedTS == TimeSpan.Zero)
                {


                    this.elapsedTimer.Stop();
                    disableAllowedTime();

                    // Play the predefined sound 
                    if (soundFilePath != String.Empty)
                    {
                        //SystemSounds.Beep.Play();
                        SoundPlayer Player = new SoundPlayer();
                        Player.SoundLocation = this.soundFilePath;
                        for (int i = 0; i < voiceRepeatCount; i++)
                            Player.PlaySync();

                    }
                    else
                    {
                        SoundPlayer Player2 = new SoundPlayer(Properties.Resources.stop_01);
                        for (int i = 0; i < voiceRepeatCount; i++)
                            Player2.PlaySync();
                    }

                    // Send notification email to parents.
                    sendEmail(); 


                    // Do not prohibit internet usage 
                    // Just remind again 
                    this.allowedTS = this.allowedTS.Add(this.repeatTS); // add more 10 min. 
                    this.elapsedTimer.Start(); // count more time 

                    // Need log messsage display box 


                    //MessageBox.Show("사용시간이 다 됐습니다.");


                }

            }

        }

        // Send only once. Subsequent mail can be regarded as spam. 
        private void sendEmail()
        {
            // send email only once 
            if (this.mailSentFlag == false)
            {
                this.mailSender.sendEmailAsync(tb_emailAddr.Text, this.elapsedTS.TotalMinutes.ToString()); 
                this.mailSentFlag = true; 
            }
        }

        #region executing program control 

        private bool loadLimitedProgramList()
        {
            bool bExist = false;

            limitedProgramFilePath = Directory.GetCurrentDirectory() + "\\limit.txt";

            if (!File.Exists(limitedProgramFilePath))
            {
                bExist = false;
            }
            else
            {
                bExist = true;
                foreach (string line in File.ReadLines(limitedProgramFilePath))
                {

                    Console.WriteLine(line);
                    this.limitedProgramList.Add(line); // prepare limited program list 
                }
            }

            return bExist;
        }



        private bool isLimitedProgramExecuting()
        {
            bool bExecute = false;

            if (this.usageTimeFromSystemUpFlag)
            {
                bExecute = true; 
            }
            else 
            {
                try
                {

                    // Get all instances of Notepad running on the local computer.
                    // This will return an empty array if notepad isn't running.
                    foreach (String limit in limitedProgramList)
                    {
                        Process[] localByName = Process.GetProcessesByName(limit);
                        if (localByName.Length > 0)
                        {
                            bExecute = true;
                            //Console.WriteLine("Find limited program : " + limit);
                            break;
                        }

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception to find whether the limited program is executed or not. " + e.Message);
                }
            }
            

            if (false == bExecute)
                Console.WriteLine("No limited program");

            return bExecute; 
        }


        private void cb_Uptime_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Uptime.Checked)
            {
                this.usageTimeFromSystemUpFlag = true;
            }
            else
            {
                this.usageTimeFromSystemUpFlag = false;
            }
        }

        #endregion


        #region Control time 
        private void btn_UpdateAllowedTime_Click(object sender, EventArgs e)
        {
            
            int atime = this.allowedTS.Minutes;
            if (true == int.TryParse(tb_AllowdTime.Text, out atime))
            {
                this.allowedTS = new TimeSpan(0, atime, 0);
                this.tb_AllowdTime.Text = this.allowedTS.ToString();
                TimeSpan remainedTS = updateElapsedRemainedTimeText();


                if ((remainedTS > TimeSpan.Zero) && (this.elapsedTimer.Enabled == false))
                {
                    this.elapsedTimer.Start();
                    Console.WriteLine("Timer start again");
                }

                disableAllowedTime(); // reschedule only once 

            }
            else
            {
                MessageBox.Show("제한 시간의 형식이 잘못되었습니다");
                //Console.WriteLine("시간 형식이 잘못되었습니다.");

            }


            ///////////////////
            // Update repeat time also 
            updateRepeatTime(); 

        }


        /// <summary>
        /// Update Elasped time and Remained Time Text. 
        /// </summary>
        /// <returns>Remained TimeSpan</returns>
        private TimeSpan updateElapsedRemainedTimeText()
        {

            this.lb_ElapsedTime.Text = this.elapsedTS.ToString();

            //this.tb_AllowdTime.Text = this.allowedTS.ToString(); 

            TimeSpan remainedTS = this.allowedTS - this.elapsedTS;
            if (remainedTS >= TimeSpan.Zero)
                this.lb_RemainedTime.Text = remainedTS.ToString();



            return remainedTS;
        }

        private void updateRepeatTime()
        {

            ///////////////////
            // Update repeat time also 
            int rtime = this.repeatTS.Minutes;
            if (true == int.TryParse(this.tb_RepeatTime.Text, out rtime))
            {
                this.repeatTS = new TimeSpan(0, rtime, 0);
                this.tb_RepeatTime.Text = this.repeatTS.ToString();
            }
            else
            {
                MessageBox.Show("반복 시간의 형식이 잘못되었습니다");
                //Console.WriteLine("시간 형식이 잘못되었습니다.");

            }

        }


        private void disableAllowedTime()
        {
            btn_UpdateAllowedTime.Enabled = false;
            tb_AllowdTime.Enabled = false;

            tb_RepeatTime.Enabled = false;

            tb_emailAddr.Enabled = false; 
        }

        private void enableAllowedTime()
        {
            btn_UpdateAllowedTime.Enabled = true;
            tb_AllowdTime.Enabled = true;

            tb_RepeatTime.Enabled = true;
            tb_emailAddr.Enabled = true;
        }

        #endregion


        #region Select Voice File 
        private void btn_voice_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            openFileDialog1.Filter = "wav files (*.wav)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //if ((myStream = openFileDialog1.OpenFile()) != null)
                    //{
                    //    using (myStream)
                    //    {
                    //        // Insert code to read the stream here.
                    //    }
                    //}
                    this.soundFilePath = openFileDialog1.FileName; 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        #endregion


        #region Password 
        private void btn_StopPassword_Click(object sender, EventArgs e)
        {


            string passwdFilePath = Directory.GetCurrentDirectory() + "\\password.txt";
            string passwd = String.Empty; 
            string userInputPassword = tb_Password.Text; 

            if (File.Exists(passwdFilePath))
            {
                passwd = File.ReadAllText(passwdFilePath);
                using (MD5 md5Hash = MD5.Create())
                {
                    if (VerifyMd5Hash(md5Hash, userInputPassword, passwd))
                    {
                        Console.WriteLine("Correct Password");
                        if (elapsedTimer.Enabled == true)
                        {
                            elapsedTimer.Stop();
                            Console.WriteLine("Timer Stops");
                            this.tb_AllowdTime.Text = this.allowedTS.TotalMinutes.ToString();
                            this.tb_RepeatTime.Text = this.repeatTS.TotalMinutes.ToString();
                            //this.tb_AllowdTime.Text = this.allowedTS
                        }
                        else
                        {
                            elapsedTimer.Start();
                            Console.WriteLine("Timer Starts. Button enabled.");
                        }

                        enableAllowedTime();

                    }                        
                    else
                    {
                        Console.WriteLine("Invalid Password");
                        MessageBox.Show("Invalid Password");
                    }
                        
                }
            }
            else
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    passwd = GetMd5Hash(md5Hash, userInputPassword);
                    File.WriteAllText(passwdFilePath, passwd); 
                }

            }

            tb_Password.Text = String.Empty; 

        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion

    }
}
