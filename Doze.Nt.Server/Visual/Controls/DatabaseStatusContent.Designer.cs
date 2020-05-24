namespace Doze.Nt.Server.Visual.Controls
{
    partial class DatabaseStatusContent
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AccessesCountLabel = new System.Windows.Forms.Label();
            this.AccessesStatusLabel = new System.Windows.Forms.Label();
            this.AccessesProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.QueriesCountLabel = new System.Windows.Forms.Label();
            this.QueriesStatusLabel = new System.Windows.Forms.Label();
            this.QueriesProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2ProgressBar2 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.ProviderInfoLabel = new System.Windows.Forms.Label();
            this.ContextInfoLabel = new System.Windows.Forms.Label();
            this.VersionInfoLabel = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.SendButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SyncContextsInfoLabel = new System.Windows.Forms.Label();
            this.DatabaseInfoLabel = new System.Windows.Forms.Label();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ProgressBar5 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            this.ShutdownServerButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(19, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "database status information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Database";
            // 
            // AccessesCountLabel
            // 
            this.AccessesCountLabel.AutoSize = true;
            this.AccessesCountLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessesCountLabel.ForeColor = System.Drawing.Color.Gray;
            this.AccessesCountLabel.Location = new System.Drawing.Point(705, 248);
            this.AccessesCountLabel.Name = "AccessesCountLabel";
            this.AccessesCountLabel.Size = new System.Drawing.Size(29, 16);
            this.AccessesCountLabel.TabIndex = 32;
            this.AccessesCountLabel.Text = "998";
            // 
            // AccessesStatusLabel
            // 
            this.AccessesStatusLabel.AutoSize = true;
            this.AccessesStatusLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccessesStatusLabel.ForeColor = System.Drawing.Color.Gray;
            this.AccessesStatusLabel.Location = new System.Drawing.Point(29, 246);
            this.AccessesStatusLabel.Name = "AccessesStatusLabel";
            this.AccessesStatusLabel.Size = new System.Drawing.Size(60, 16);
            this.AccessesStatusLabel.TabIndex = 31;
            this.AccessesStatusLabel.Text = "Accesses";
            // 
            // AccessesProgress
            // 
            this.AccessesProgress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccessesProgress.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AccessesProgress.Location = new System.Drawing.Point(147, 253);
            this.AccessesProgress.Name = "AccessesProgress";
            this.AccessesProgress.ProgressColor2 = System.Drawing.Color.IndianRed;
            this.AccessesProgress.ShadowDecoration.Parent = this.AccessesProgress;
            this.AccessesProgress.Size = new System.Drawing.Size(544, 5);
            this.AccessesProgress.TabIndex = 30;
            this.AccessesProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.AccessesProgress.Value = 100;
            // 
            // QueriesCountLabel
            // 
            this.QueriesCountLabel.AutoSize = true;
            this.QueriesCountLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueriesCountLabel.ForeColor = System.Drawing.Color.Gray;
            this.QueriesCountLabel.Location = new System.Drawing.Point(705, 216);
            this.QueriesCountLabel.Name = "QueriesCountLabel";
            this.QueriesCountLabel.Size = new System.Drawing.Size(15, 16);
            this.QueriesCountLabel.TabIndex = 29;
            this.QueriesCountLabel.Text = "7";
            // 
            // QueriesStatusLabel
            // 
            this.QueriesStatusLabel.AutoSize = true;
            this.QueriesStatusLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueriesStatusLabel.ForeColor = System.Drawing.Color.Gray;
            this.QueriesStatusLabel.Location = new System.Drawing.Point(29, 214);
            this.QueriesStatusLabel.Name = "QueriesStatusLabel";
            this.QueriesStatusLabel.Size = new System.Drawing.Size(53, 16);
            this.QueriesStatusLabel.TabIndex = 28;
            this.QueriesStatusLabel.Text = "Queries";
            // 
            // QueriesProgress
            // 
            this.QueriesProgress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QueriesProgress.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.QueriesProgress.Location = new System.Drawing.Point(147, 221);
            this.QueriesProgress.Name = "QueriesProgress";
            this.QueriesProgress.ProgressColor2 = System.Drawing.Color.IndianRed;
            this.QueriesProgress.ShadowDecoration.Parent = this.QueriesProgress;
            this.QueriesProgress.Size = new System.Drawing.Size(544, 5);
            this.QueriesProgress.TabIndex = 27;
            this.QueriesProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.QueriesProgress.Value = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(705, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "387";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(705, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "1367";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(29, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Users";
            // 
            // guna2ProgressBar2
            // 
            this.guna2ProgressBar2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ProgressBar2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.guna2ProgressBar2.Location = new System.Drawing.Point(147, 173);
            this.guna2ProgressBar2.Name = "guna2ProgressBar2";
            this.guna2ProgressBar2.ProgressColor2 = System.Drawing.Color.IndianRed;
            this.guna2ProgressBar2.ShadowDecoration.Parent = this.guna2ProgressBar2;
            this.guna2ProgressBar2.Size = new System.Drawing.Size(544, 5);
            this.guna2ProgressBar2.TabIndex = 23;
            this.guna2ProgressBar2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ProgressBar2.Value = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(29, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Total tables:";
            // 
            // guna2ProgressBar1
            // 
            this.guna2ProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.guna2ProgressBar1.Location = new System.Drawing.Point(147, 110);
            this.guna2ProgressBar1.Name = "guna2ProgressBar1";
            this.guna2ProgressBar1.ProgressColor2 = System.Drawing.Color.IndianRed;
            this.guna2ProgressBar1.ShadowDecoration.Parent = this.guna2ProgressBar1;
            this.guna2ProgressBar1.Size = new System.Drawing.Size(544, 5);
            this.guna2ProgressBar1.TabIndex = 21;
            this.guna2ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ProgressBar1.Value = 46;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator1.Location = new System.Drawing.Point(0, 277);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(776, 10);
            this.guna2Separator1.TabIndex = 38;
            // 
            // ProviderInfoLabel
            // 
            this.ProviderInfoLabel.AutoSize = true;
            this.ProviderInfoLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProviderInfoLabel.ForeColor = System.Drawing.Color.Gray;
            this.ProviderInfoLabel.Location = new System.Drawing.Point(32, 306);
            this.ProviderInfoLabel.Name = "ProviderInfoLabel";
            this.ProviderInfoLabel.Size = new System.Drawing.Size(109, 16);
            this.ProviderInfoLabel.TabIndex = 41;
            this.ProviderInfoLabel.Text = "Provider:  MySQL";
            // 
            // ContextInfoLabel
            // 
            this.ContextInfoLabel.AutoSize = true;
            this.ContextInfoLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContextInfoLabel.ForeColor = System.Drawing.Color.Gray;
            this.ContextInfoLabel.Location = new System.Drawing.Point(32, 330);
            this.ContextInfoLabel.Name = "ContextInfoLabel";
            this.ContextInfoLabel.Size = new System.Drawing.Size(59, 16);
            this.ContextInfoLabel.TabIndex = 42;
            this.ContextInfoLabel.Text = "Context: ";
            // 
            // VersionInfoLabel
            // 
            this.VersionInfoLabel.AutoSize = true;
            this.VersionInfoLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionInfoLabel.ForeColor = System.Drawing.Color.Gray;
            this.VersionInfoLabel.Location = new System.Drawing.Point(553, 306);
            this.VersionInfoLabel.Name = "VersionInfoLabel";
            this.VersionInfoLabel.Size = new System.Drawing.Size(177, 16);
            this.VersionInfoLabel.TabIndex = 44;
            this.VersionInfoLabel.Text = "Version: 5.5.6.73 (Connected)";
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator2.Location = new System.Drawing.Point(3, 83);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(776, 10);
            this.guna2Separator2.TabIndex = 51;
            // 
            // SendButton
            // 
            this.SendButton.BorderColor = System.Drawing.Color.Teal;
            this.SendButton.BorderThickness = 1;
            this.SendButton.CheckedState.Parent = this.SendButton;
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.CustomImages.Parent = this.SendButton;
            this.SendButton.FillColor = System.Drawing.Color.Transparent;
            this.SendButton.FillColor2 = System.Drawing.Color.Transparent;
            this.SendButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.SendButton.HoverState.BorderColor = System.Drawing.Color.Teal;
            this.SendButton.HoverState.FillColor = System.Drawing.Color.Teal;
            this.SendButton.HoverState.FillColor2 = System.Drawing.Color.Teal;
            this.SendButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.SendButton.HoverState.Parent = this.SendButton;
            this.SendButton.Location = new System.Drawing.Point(22, 391);
            this.SendButton.Name = "SendButton";
            this.SendButton.ShadowDecoration.Parent = this.SendButton;
            this.SendButton.Size = new System.Drawing.Size(221, 31);
            this.SendButton.TabIndex = 55;
            this.SendButton.Text = "DATABASE CLEANING COMPONENT";
            // 
            // SyncContextsInfoLabel
            // 
            this.SyncContextsInfoLabel.AutoSize = true;
            this.SyncContextsInfoLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncContextsInfoLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.SyncContextsInfoLabel.Location = new System.Drawing.Point(540, 35);
            this.SyncContextsInfoLabel.Name = "SyncContextsInfoLabel";
            this.SyncContextsInfoLabel.Size = new System.Drawing.Size(209, 21);
            this.SyncContextsInfoLabel.TabIndex = 52;
            this.SyncContextsInfoLabel.Text = "Synchronized contexts: 87";
            this.SyncContextsInfoLabel.Click += new System.EventHandler(this.HealthInfoLabel_Click);
            // 
            // DatabaseInfoLabel
            // 
            this.DatabaseInfoLabel.AutoSize = true;
            this.DatabaseInfoLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseInfoLabel.ForeColor = System.Drawing.Color.Gray;
            this.DatabaseInfoLabel.Location = new System.Drawing.Point(553, 330);
            this.DatabaseInfoLabel.Name = "DatabaseInfoLabel";
            this.DatabaseInfoLabel.Size = new System.Drawing.Size(142, 16);
            this.DatabaseInfoLabel.TabIndex = 59;
            this.DatabaseInfoLabel.Text = "Database: doze_debug";
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator3.Location = new System.Drawing.Point(0, 365);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(779, 10);
            this.guna2Separator3.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(706, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "387";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(30, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Log errors";
            // 
            // guna2ProgressBar5
            // 
            this.guna2ProgressBar5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ProgressBar5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.guna2ProgressBar5.Location = new System.Drawing.Point(148, 141);
            this.guna2ProgressBar5.Name = "guna2ProgressBar5";
            this.guna2ProgressBar5.ProgressColor2 = System.Drawing.Color.IndianRed;
            this.guna2ProgressBar5.ShadowDecoration.Parent = this.guna2ProgressBar5;
            this.guna2ProgressBar5.Size = new System.Drawing.Size(544, 5);
            this.guna2ProgressBar5.TabIndex = 61;
            this.guna2ProgressBar5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ProgressBar5.Value = 22;
            // 
            // guna2Separator4
            // 
            this.guna2Separator4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator4.Location = new System.Drawing.Point(1, 192);
            this.guna2Separator4.Name = "guna2Separator4";
            this.guna2Separator4.Size = new System.Drawing.Size(776, 10);
            this.guna2Separator4.TabIndex = 64;
            // 
            // ShutdownServerButton
            // 
            this.ShutdownServerButton.BorderColor = System.Drawing.Color.IndianRed;
            this.ShutdownServerButton.BorderThickness = 1;
            this.ShutdownServerButton.CheckedState.Parent = this.ShutdownServerButton;
            this.ShutdownServerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShutdownServerButton.CustomImages.Parent = this.ShutdownServerButton;
            this.ShutdownServerButton.FillColor = System.Drawing.Color.Transparent;
            this.ShutdownServerButton.FillColor2 = System.Drawing.Color.Transparent;
            this.ShutdownServerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShutdownServerButton.ForeColor = System.Drawing.Color.IndianRed;
            this.ShutdownServerButton.HoverState.BorderColor = System.Drawing.Color.IndianRed;
            this.ShutdownServerButton.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.ShutdownServerButton.HoverState.FillColor2 = System.Drawing.Color.IndianRed;
            this.ShutdownServerButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.ShutdownServerButton.HoverState.Parent = this.ShutdownServerButton;
            this.ShutdownServerButton.Location = new System.Drawing.Point(627, 391);
            this.ShutdownServerButton.Name = "ShutdownServerButton";
            this.ShutdownServerButton.ShadowDecoration.Parent = this.ShutdownServerButton;
            this.ShutdownServerButton.Size = new System.Drawing.Size(128, 31);
            this.ShutdownServerButton.TabIndex = 65;
            this.ShutdownServerButton.Text = "WIPE DATABASE";
            // 
            // DatabaseStatusContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.ShutdownServerButton);
            this.Controls.Add(this.guna2Separator4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.guna2ProgressBar5);
            this.Controls.Add(this.guna2Separator3);
            this.Controls.Add(this.DatabaseInfoLabel);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SyncContextsInfoLabel);
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.VersionInfoLabel);
            this.Controls.Add(this.ContextInfoLabel);
            this.Controls.Add(this.ProviderInfoLabel);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.AccessesCountLabel);
            this.Controls.Add(this.AccessesStatusLabel);
            this.Controls.Add(this.AccessesProgress);
            this.Controls.Add(this.QueriesCountLabel);
            this.Controls.Add(this.QueriesStatusLabel);
            this.Controls.Add(this.QueriesProgress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2ProgressBar2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.guna2ProgressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "DatabaseStatusContent";
            this.Size = new System.Drawing.Size(779, 438);
            this.Load += new System.EventHandler(this.DatabaseStatusContent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AccessesCountLabel;
        private Guna.UI2.WinForms.Guna2ProgressBar AccessesProgress;
        private System.Windows.Forms.Label QueriesCountLabel;
        private Guna.UI2.WinForms.Guna2ProgressBar QueriesProgress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar2;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2GradientButton SendButton;
        public System.Windows.Forms.Label ProviderInfoLabel;
        public System.Windows.Forms.Label ContextInfoLabel;
        public System.Windows.Forms.Label VersionInfoLabel;
        public System.Windows.Forms.Label DatabaseInfoLabel;
        public System.Windows.Forms.Label SyncContextsInfoLabel;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar5;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private Guna.UI2.WinForms.Guna2GradientButton ShutdownServerButton;
        public System.Windows.Forms.Label QueriesStatusLabel;
        public System.Windows.Forms.Label AccessesStatusLabel;
    }
}
