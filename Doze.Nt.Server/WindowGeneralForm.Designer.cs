namespace Doze.Nt.Server
{
    partial class WindowGeneralForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowGeneralForm));
            this.ApplicationName_Header = new System.Windows.Forms.Label();
            this.VersionLabel_Header = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ConsoleContentButton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.ServerStatusButton = new Guna.UI2.WinForms.Guna2Button();
            this.DatabaseStatusButton = new Guna.UI2.WinForms.Guna2Button();
            this.NetworkStatusButton = new Guna.UI2.WinForms.Guna2Button();
            this.ContentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.ServerIndicator = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationName_Header
            // 
            this.ApplicationName_Header.AutoSize = true;
            this.ApplicationName_Header.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationName_Header.ForeColor = System.Drawing.Color.White;
            this.ApplicationName_Header.Location = new System.Drawing.Point(12, 9);
            this.ApplicationName_Header.Name = "ApplicationName_Header";
            this.ApplicationName_Header.Size = new System.Drawing.Size(51, 30);
            this.ApplicationName_Header.TabIndex = 1;
            this.ApplicationName_Header.Text = "null";
            // 
            // VersionLabel_Header
            // 
            this.VersionLabel_Header.AutoSize = true;
            this.VersionLabel_Header.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel_Header.ForeColor = System.Drawing.Color.Silver;
            this.VersionLabel_Header.Location = new System.Drawing.Point(18, 38);
            this.VersionLabel_Header.Name = "VersionLabel_Header";
            this.VersionLabel_Header.Size = new System.Drawing.Size(27, 13);
            this.VersionLabel_Header.TabIndex = 2;
            this.VersionLabel_Header.Text = "null";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.White;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(819, 8);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(18, 18);
            this.guna2ControlBox1.TabIndex = 6;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.BorderColor = System.Drawing.Color.White;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(795, 11);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(18, 18);
            this.guna2ControlBox2.TabIndex = 7;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2Panel1.Controls.Add(this.ConsoleContentButton);
            this.guna2Panel1.Controls.Add(this.guna2Button4);
            this.guna2Panel1.Controls.Add(this.ServerStatusButton);
            this.guna2Panel1.Controls.Add(this.DatabaseStatusButton);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 73);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(71, 437);
            this.guna2Panel1.TabIndex = 9;
            // 
            // ConsoleContentButton
            // 
            this.ConsoleContentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ConsoleContentButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.ConsoleContentButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ConsoleContentButton.CheckedState.CustomBorderColor = System.Drawing.Color.Aqua;
            this.ConsoleContentButton.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.ConsoleContentButton.CheckedState.Parent = this.ConsoleContentButton;
            this.ConsoleContentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsoleContentButton.CustomBorderColor = System.Drawing.Color.Transparent;
            this.ConsoleContentButton.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.ConsoleContentButton.CustomImages.Parent = this.ConsoleContentButton;
            this.ConsoleContentButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ConsoleContentButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ConsoleContentButton.ForeColor = System.Drawing.Color.White;
            this.ConsoleContentButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("ConsoleContentButton.HoverState.Image")));
            this.ConsoleContentButton.HoverState.Parent = this.ConsoleContentButton;
            this.ConsoleContentButton.Image = ((System.Drawing.Image)(resources.GetObject("ConsoleContentButton.Image")));
            this.ConsoleContentButton.ImageSize = new System.Drawing.Size(28, 28);
            this.ConsoleContentButton.Location = new System.Drawing.Point(0, 146);
            this.ConsoleContentButton.Name = "ConsoleContentButton";
            this.ConsoleContentButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ConsoleContentButton.ShadowDecoration.Parent = this.ConsoleContentButton;
            this.ConsoleContentButton.Size = new System.Drawing.Size(71, 49);
            this.ConsoleContentButton.TabIndex = 12;
            this.ConsoleContentButton.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2Button4.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2Button4.CheckedState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Button4.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button4.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.HoverState.Image")));
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageSize = new System.Drawing.Size(28, 28);
            this.guna2Button4.Location = new System.Drawing.Point(-2, 388);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(73, 49);
            this.guna2Button4.TabIndex = 13;
            // 
            // ServerStatusButton
            // 
            this.ServerStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ServerStatusButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.ServerStatusButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ServerStatusButton.CheckedState.CustomBorderColor = System.Drawing.Color.Aqua;
            this.ServerStatusButton.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.ServerStatusButton.CheckedState.Parent = this.ServerStatusButton;
            this.ServerStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServerStatusButton.CustomBorderColor = System.Drawing.Color.Transparent;
            this.ServerStatusButton.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.ServerStatusButton.CustomImages.Parent = this.ServerStatusButton;
            this.ServerStatusButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ServerStatusButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ServerStatusButton.ForeColor = System.Drawing.Color.White;
            this.ServerStatusButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("ServerStatusButton.HoverState.Image")));
            this.ServerStatusButton.HoverState.Parent = this.ServerStatusButton;
            this.ServerStatusButton.Image = ((System.Drawing.Image)(resources.GetObject("ServerStatusButton.Image")));
            this.ServerStatusButton.ImageSize = new System.Drawing.Size(28, 28);
            this.ServerStatusButton.Location = new System.Drawing.Point(0, 97);
            this.ServerStatusButton.Name = "ServerStatusButton";
            this.ServerStatusButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ServerStatusButton.ShadowDecoration.Parent = this.ServerStatusButton;
            this.ServerStatusButton.Size = new System.Drawing.Size(71, 49);
            this.ServerStatusButton.TabIndex = 12;
            this.ServerStatusButton.Click += new System.EventHandler(this.ServerStatusButton_Click);
            // 
            // DatabaseStatusButton
            // 
            this.DatabaseStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DatabaseStatusButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.DatabaseStatusButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DatabaseStatusButton.CheckedState.CustomBorderColor = System.Drawing.Color.Aqua;
            this.DatabaseStatusButton.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.DatabaseStatusButton.CheckedState.Parent = this.DatabaseStatusButton;
            this.DatabaseStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DatabaseStatusButton.CustomBorderColor = System.Drawing.Color.Transparent;
            this.DatabaseStatusButton.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.DatabaseStatusButton.CustomImages.Parent = this.DatabaseStatusButton;
            this.DatabaseStatusButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DatabaseStatusButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DatabaseStatusButton.ForeColor = System.Drawing.Color.White;
            this.DatabaseStatusButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("DatabaseStatusButton.HoverState.Image")));
            this.DatabaseStatusButton.HoverState.Parent = this.DatabaseStatusButton;
            this.DatabaseStatusButton.Image = ((System.Drawing.Image)(resources.GetObject("DatabaseStatusButton.Image")));
            this.DatabaseStatusButton.ImageSize = new System.Drawing.Size(28, 28);
            this.DatabaseStatusButton.Location = new System.Drawing.Point(0, 48);
            this.DatabaseStatusButton.Name = "DatabaseStatusButton";
            this.DatabaseStatusButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DatabaseStatusButton.ShadowDecoration.Parent = this.DatabaseStatusButton;
            this.DatabaseStatusButton.Size = new System.Drawing.Size(71, 49);
            this.DatabaseStatusButton.TabIndex = 11;
            this.DatabaseStatusButton.Click += new System.EventHandler(this.DatabaseStatusButton_Click);
            // 
            // NetworkStatusButton
            // 
            this.NetworkStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NetworkStatusButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.NetworkStatusButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NetworkStatusButton.CheckedState.CustomBorderColor = System.Drawing.Color.Aqua;
            this.NetworkStatusButton.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.NetworkStatusButton.CheckedState.Parent = this.NetworkStatusButton;
            this.NetworkStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NetworkStatusButton.CustomBorderColor = System.Drawing.Color.Transparent;
            this.NetworkStatusButton.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.NetworkStatusButton.CustomImages.Parent = this.NetworkStatusButton;
            this.NetworkStatusButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NetworkStatusButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NetworkStatusButton.ForeColor = System.Drawing.Color.White;
            this.NetworkStatusButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("NetworkStatusButton.HoverState.Image")));
            this.NetworkStatusButton.HoverState.Parent = this.NetworkStatusButton;
            this.NetworkStatusButton.Image = ((System.Drawing.Image)(resources.GetObject("NetworkStatusButton.Image")));
            this.NetworkStatusButton.ImageSize = new System.Drawing.Size(28, 28);
            this.NetworkStatusButton.Location = new System.Drawing.Point(0, 72);
            this.NetworkStatusButton.Name = "NetworkStatusButton";
            this.NetworkStatusButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.NetworkStatusButton.ShadowDecoration.Parent = this.NetworkStatusButton;
            this.NetworkStatusButton.Size = new System.Drawing.Size(71, 49);
            this.NetworkStatusButton.TabIndex = 10;
            this.NetworkStatusButton.Click += new System.EventHandler(this.NetworkStatusButton_Click);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Location = new System.Drawing.Point(68, 72);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.ShadowDecoration.Parent = this.ContentPanel;
            this.ContentPanel.Size = new System.Drawing.Size(779, 438);
            this.ContentPanel.TabIndex = 11;
            // 
            // ServerIndicator
            // 
            this.ServerIndicator.BorderRadius = 8;
            this.ServerIndicator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ServerIndicator.Location = new System.Drawing.Point(140, 19);
            this.ServerIndicator.Name = "ServerIndicator";
            this.ServerIndicator.ShadowDecoration.Parent = this.ServerIndicator;
            this.ServerIndicator.Size = new System.Drawing.Size(15, 15);
            this.ServerIndicator.TabIndex = 12;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator2.Location = new System.Drawing.Point(-2, 66);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(849, 10);
            this.guna2Separator2.TabIndex = 52;
            // 
            // WindowGeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(846, 510);
            this.Controls.Add(this.ServerIndicator);
            this.Controls.Add(this.NetworkStatusButton);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.VersionLabel_Header);
            this.Controls.Add(this.ApplicationName_Header);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.guna2Separator2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowGeneralForm";
            this.Text = "Doze Server";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowGeneralForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowGeneralForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowGeneralForm_MouseUp);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ApplicationName_Header;
        private System.Windows.Forms.Label VersionLabel_Header;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button NetworkStatusButton;
        private Guna.UI2.WinForms.Guna2Button ServerStatusButton;
        private Guna.UI2.WinForms.Guna2Button DatabaseStatusButton;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Panel ContentPanel;
        private Guna.UI2.WinForms.Guna2Button ConsoleContentButton;
        private Guna.UI2.WinForms.Guna2Panel ServerIndicator;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}

