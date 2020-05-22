namespace Doze.Nt.Client
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ApplicationName_Header = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ServerStatusButton = new Guna.UI2.WinForms.Guna2Button();
            this.DatabaseStatusButton = new Guna.UI2.WinForms.Guna2Button();
            this.VersionLabel_Header = new System.Windows.Forms.Label();
            this.ContentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplicationName_Header
            // 
            this.ApplicationName_Header.AutoSize = true;
            this.ApplicationName_Header.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationName_Header.ForeColor = System.Drawing.Color.White;
            this.ApplicationName_Header.Location = new System.Drawing.Point(12, 2);
            this.ApplicationName_Header.Name = "ApplicationName_Header";
            this.ApplicationName_Header.Size = new System.Drawing.Size(62, 30);
            this.ApplicationName_Header.TabIndex = 3;
            this.ApplicationName_Header.Text = "Doze";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator1.Location = new System.Drawing.Point(0, 51);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(728, 8);
            this.guna2Separator1.TabIndex = 5;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.BorderColor = System.Drawing.Color.White;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(679, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(18, 18);
            this.guna2ControlBox2.TabIndex = 9;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(703, 9);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(18, 18);
            this.guna2ControlBox1.TabIndex = 8;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.guna2Panel1.Controls.Add(this.ServerStatusButton);
            this.guna2Panel1.Controls.Add(this.DatabaseStatusButton);
            this.guna2Panel1.Location = new System.Drawing.Point(-1, 56);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(71, 358);
            this.guna2Panel1.TabIndex = 10;
            // 
            // ServerStatusButton
            // 
            this.ServerStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ServerStatusButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.ServerStatusButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ServerStatusButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
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
            this.ServerStatusButton.Location = new System.Drawing.Point(0, 309);
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
            this.DatabaseStatusButton.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
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
            this.DatabaseStatusButton.Location = new System.Drawing.Point(0, 0);
            this.DatabaseStatusButton.Name = "DatabaseStatusButton";
            this.DatabaseStatusButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.DatabaseStatusButton.ShadowDecoration.Parent = this.DatabaseStatusButton;
            this.DatabaseStatusButton.Size = new System.Drawing.Size(71, 49);
            this.DatabaseStatusButton.TabIndex = 11;
            this.DatabaseStatusButton.Click += new System.EventHandler(this.DatabaseStatusButton_Click);
            // 
            // VersionLabel_Header
            // 
            this.VersionLabel_Header.AutoSize = true;
            this.VersionLabel_Header.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel_Header.ForeColor = System.Drawing.Color.Silver;
            this.VersionLabel_Header.Location = new System.Drawing.Point(14, 32);
            this.VersionLabel_Header.Name = "VersionLabel_Header";
            this.VersionLabel_Header.Size = new System.Drawing.Size(145, 13);
            this.VersionLabel_Header.TabIndex = 11;
            this.VersionLabel_Header.Text = "v.1.0.7456.2389-f0b8c3ddef";
            // 
            // ContentPanel
            // 
            this.ContentPanel.Location = new System.Drawing.Point(70, 56);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.ShadowDecoration.Parent = this.ContentPanel;
            this.ContentPanel.Size = new System.Drawing.Size(658, 358);
            this.ContentPanel.TabIndex = 12;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(729, 413);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.VersionLabel_Header);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.ApplicationName_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ApplicationName_Header;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label VersionLabel_Header;
        private Guna.UI2.WinForms.Guna2Panel ContentPanel;
        public Guna.UI2.WinForms.Guna2Button ServerStatusButton;
        public Guna.UI2.WinForms.Guna2Button DatabaseStatusButton;
    }
}

