namespace UsageAlarm
{
    partial class UsageAlarm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_ElapsedTime = new System.Windows.Forms.Label();
            this.btn_StopPassword = new System.Windows.Forms.Button();
            this.btn_voice = new System.Windows.Forms.Button();
            this.lb_Voice = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.lb_StopTimer = new System.Windows.Forms.Label();
            this.lb_AllowedTime = new System.Windows.Forms.Label();
            this.lb_UsageTime = new System.Windows.Forms.Label();
            this.tb_AllowdTime = new System.Windows.Forms.TextBox();
            this.elapsedTimer = new System.Windows.Forms.Timer(this.components);
            this.lb_RemainedTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Uptime = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_emailAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_RepeatTime = new System.Windows.Forms.TextBox();
            this.btn_UpdateAllowedTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_ElapsedTime
            // 
            this.lb_ElapsedTime.AutoSize = true;
            this.lb_ElapsedTime.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_ElapsedTime.Location = new System.Drawing.Point(96, 18);
            this.lb_ElapsedTime.Name = "lb_ElapsedTime";
            this.lb_ElapsedTime.Size = new System.Drawing.Size(14, 13);
            this.lb_ElapsedTime.TabIndex = 20;
            this.lb_ElapsedTime.Text = "0";
            // 
            // btn_StopPassword
            // 
            this.btn_StopPassword.Location = new System.Drawing.Point(180, 189);
            this.btn_StopPassword.Name = "btn_StopPassword";
            this.btn_StopPassword.Size = new System.Drawing.Size(75, 23);
            this.btn_StopPassword.TabIndex = 2;
            this.btn_StopPassword.Text = "확인";
            this.btn_StopPassword.UseVisualStyleBackColor = true;
            this.btn_StopPassword.Click += new System.EventHandler(this.btn_StopPassword_Click);
            // 
            // btn_voice
            // 
            this.btn_voice.Location = new System.Drawing.Point(99, 148);
            this.btn_voice.Name = "btn_voice";
            this.btn_voice.Size = new System.Drawing.Size(75, 23);
            this.btn_voice.TabIndex = 5;
            this.btn_voice.Text = "찾기";
            this.btn_voice.UseVisualStyleBackColor = true;
            this.btn_voice.Click += new System.EventHandler(this.btn_voice_Click);
            // 
            // lb_Voice
            // 
            this.lb_Voice.AutoSize = true;
            this.lb_Voice.Location = new System.Drawing.Point(12, 153);
            this.lb_Voice.Name = "lb_Voice";
            this.lb_Voice.Size = new System.Drawing.Size(41, 12);
            this.lb_Voice.TabIndex = 23;
            this.lb_Voice.Text = "목소리";
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(97, 189);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(75, 21);
            this.tb_Password.TabIndex = 1;
            this.tb_Password.UseSystemPasswordChar = true;
            // 
            // lb_StopTimer
            // 
            this.lb_StopTimer.AutoSize = true;
            this.lb_StopTimer.Location = new System.Drawing.Point(12, 194);
            this.lb_StopTimer.Name = "lb_StopTimer";
            this.lb_StopTimer.Size = new System.Drawing.Size(81, 12);
            this.lb_StopTimer.TabIndex = 24;
            this.lb_StopTimer.Text = "정지 비밀번호";
            // 
            // lb_AllowedTime
            // 
            this.lb_AllowedTime.AutoSize = true;
            this.lb_AllowedTime.Location = new System.Drawing.Point(12, 52);
            this.lb_AllowedTime.Name = "lb_AllowedTime";
            this.lb_AllowedTime.Size = new System.Drawing.Size(83, 12);
            this.lb_AllowedTime.TabIndex = 22;
            this.lb_AllowedTime.Text = "허용 시간 (분)";
            // 
            // lb_UsageTime
            // 
            this.lb_UsageTime.AutoSize = true;
            this.lb_UsageTime.Location = new System.Drawing.Point(12, 19);
            this.lb_UsageTime.Name = "lb_UsageTime";
            this.lb_UsageTime.Size = new System.Drawing.Size(57, 12);
            this.lb_UsageTime.TabIndex = 21;
            this.lb_UsageTime.Text = "사용 시간";
            // 
            // tb_AllowdTime
            // 
            this.tb_AllowdTime.Location = new System.Drawing.Point(99, 48);
            this.tb_AllowdTime.Name = "tb_AllowdTime";
            this.tb_AllowdTime.Size = new System.Drawing.Size(75, 21);
            this.tb_AllowdTime.TabIndex = 3;
            // 
            // elapsedTimer
            // 
            this.elapsedTimer.Interval = 1000;
            this.elapsedTimer.Tick += new System.EventHandler(this.elapsedTimer_Tick);
            // 
            // lb_RemainedTime
            // 
            this.lb_RemainedTime.AutoSize = true;
            this.lb_RemainedTime.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_RemainedTime.Location = new System.Drawing.Point(98, 121);
            this.lb_RemainedTime.Name = "lb_RemainedTime";
            this.lb_RemainedTime.Size = new System.Drawing.Size(14, 13);
            this.lb_RemainedTime.TabIndex = 26;
            this.lb_RemainedTime.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "남은 시간";
            // 
            // cb_Uptime
            // 
            this.cb_Uptime.AutoSize = true;
            this.cb_Uptime.Location = new System.Drawing.Point(14, 221);
            this.cb_Uptime.Name = "cb_Uptime";
            this.cb_Uptime.Size = new System.Drawing.Size(148, 16);
            this.cb_Uptime.TabIndex = 28;
            this.cb_Uptime.Text = "부팅 후 사용 시간 기준";
            this.cb_Uptime.UseVisualStyleBackColor = true;
            this.cb_Uptime.CheckedChanged += new System.EventHandler(this.cb_Uptime_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "Email";
            // 
            // tb_emailAddr
            // 
            this.tb_emailAddr.Location = new System.Drawing.Point(97, 245);
            this.tb_emailAddr.Name = "tb_emailAddr";
            this.tb_emailAddr.Size = new System.Drawing.Size(158, 21);
            this.tb_emailAddr.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "반복 시간 (분)";
            // 
            // tb_RepeatTime
            // 
            this.tb_RepeatTime.Location = new System.Drawing.Point(99, 80);
            this.tb_RepeatTime.Name = "tb_RepeatTime";
            this.tb_RepeatTime.Size = new System.Drawing.Size(75, 21);
            this.tb_RepeatTime.TabIndex = 32;
            // 
            // btn_UpdateAllowedTime
            // 
            this.btn_UpdateAllowedTime.Location = new System.Drawing.Point(182, 48);
            this.btn_UpdateAllowedTime.Name = "btn_UpdateAllowedTime";
            this.btn_UpdateAllowedTime.Size = new System.Drawing.Size(75, 56);
            this.btn_UpdateAllowedTime.TabIndex = 4;
            this.btn_UpdateAllowedTime.Text = "적용";
            this.btn_UpdateAllowedTime.UseVisualStyleBackColor = true;
            this.btn_UpdateAllowedTime.Click += new System.EventHandler(this.btn_UpdateAllowedTime_Click);
            // 
            // UsageAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 281);
            this.Controls.Add(this.tb_RepeatTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_emailAddr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Uptime);
            this.Controls.Add(this.btn_UpdateAllowedTime);
            this.Controls.Add(this.lb_RemainedTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_ElapsedTime);
            this.Controls.Add(this.btn_StopPassword);
            this.Controls.Add(this.btn_voice);
            this.Controls.Add(this.lb_Voice);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.lb_StopTimer);
            this.Controls.Add(this.lb_AllowedTime);
            this.Controls.Add(this.lb_UsageTime);
            this.Controls.Add(this.tb_AllowdTime);
            this.Name = "UsageAlarm";
            this.Opacity = 0.9D;
            this.Text = "UsageAlarm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_ElapsedTime;
        private System.Windows.Forms.Button btn_StopPassword;
        private System.Windows.Forms.Button btn_voice;
        private System.Windows.Forms.Label lb_Voice;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label lb_StopTimer;
        private System.Windows.Forms.Label lb_AllowedTime;
        private System.Windows.Forms.Label lb_UsageTime;
        private System.Windows.Forms.TextBox tb_AllowdTime;
        private System.Windows.Forms.Timer elapsedTimer;
        private System.Windows.Forms.Label lb_RemainedTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_Uptime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_emailAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_RepeatTime;
        private System.Windows.Forms.Button btn_UpdateAllowedTime;
    }
}

