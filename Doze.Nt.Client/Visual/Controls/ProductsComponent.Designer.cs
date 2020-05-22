namespace Doze.Nt.Client.Visual.Controls
{
    partial class ProductsComponent
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
            this.label4 = new System.Windows.Forms.Label();
            this.ConsoleModeComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(370, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Game:";
            // 
            // ConsoleModeComboBox
            // 
            this.ConsoleModeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.ConsoleModeComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConsoleModeComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsoleModeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ConsoleModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConsoleModeComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ConsoleModeComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.ConsoleModeComboBox.FocusedState.Parent = this.ConsoleModeComboBox;
            this.ConsoleModeComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ConsoleModeComboBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.ConsoleModeComboBox.FormattingEnabled = true;
            this.ConsoleModeComboBox.HoverState.Parent = this.ConsoleModeComboBox;
            this.ConsoleModeComboBox.IntegralHeight = false;
            this.ConsoleModeComboBox.ItemHeight = 20;
            this.ConsoleModeComboBox.Items.AddRange(new object[] {
            "PUBG ( Steam )",
            "PUBG ( Lite )",
            "Rust",
            "Hurtworld"});
            this.ConsoleModeComboBox.ItemsAppearance.Parent = this.ConsoleModeComboBox;
            this.ConsoleModeComboBox.Location = new System.Drawing.Point(417, 24);
            this.ConsoleModeComboBox.Name = "ConsoleModeComboBox";
            this.ConsoleModeComboBox.ShadowDecoration.Parent = this.ConsoleModeComboBox;
            this.ConsoleModeComboBox.Size = new System.Drawing.Size(218, 26);
            this.ConsoleModeComboBox.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 14);
            this.label2.TabIndex = 39;
            this.label2.Text = "my subscriptions information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 26);
            this.label3.TabIndex = 38;
            this.label3.Text = "Subscriptions";
            // 
            // ProductsComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConsoleModeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "ProductsComponent";
            this.Size = new System.Drawing.Size(658, 358);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox ConsoleModeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
