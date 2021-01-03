using System;
namespace Copters
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LandingRadiusUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.CopterRadiusUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChanceLabel = new System.Windows.Forms.Label();
            this.StageLabel = new System.Windows.Forms.Label();
            this.AllLabel = new System.Windows.Forms.Label();
            this.BadLabel = new System.Windows.Forms.Label();
            this.MainBar = new System.Windows.Forms.ProgressBar();
            this.SecondBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LandingRadiusUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopterRadiusUpDown2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(476, 513);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Landing Platform Radius, mm";
            // 
            // LandingRadiusUpDown1
            // 
            this.LandingRadiusUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LandingRadiusUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.LandingRadiusUpDown1.Location = new System.Drawing.Point(6, 20);
            this.LandingRadiusUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LandingRadiusUpDown1.Name = "LandingRadiusUpDown1";
            this.LandingRadiusUpDown1.Size = new System.Drawing.Size(188, 20);
            this.LandingRadiusUpDown1.TabIndex = 3;
            this.LandingRadiusUpDown1.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.LandingRadiusUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // CopterRadiusUpDown2
            // 
            this.CopterRadiusUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CopterRadiusUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CopterRadiusUpDown2.Location = new System.Drawing.Point(6, 60);
            this.CopterRadiusUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CopterRadiusUpDown2.Name = "CopterRadiusUpDown2";
            this.CopterRadiusUpDown2.Size = new System.Drawing.Size(188, 20);
            this.CopterRadiusUpDown2.TabIndex = 5;
            this.CopterRadiusUpDown2.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.CopterRadiusUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Copter Radius, mm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(476, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 513);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ChanceLabel);
            this.panel3.Controls.Add(this.StageLabel);
            this.panel3.Controls.Add(this.AllLabel);
            this.panel3.Controls.Add(this.BadLabel);
            this.panel3.Controls.Add(this.MainBar);
            this.panel3.Controls.Add(this.SecondBar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.CopterRadiusUpDown2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.LandingRadiusUpDown1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(206, 242);
            this.panel3.TabIndex = 14;
            // 
            // ChanceLabel
            // 
            this.ChanceLabel.AutoSize = true;
            this.ChanceLabel.Location = new System.Drawing.Point(7, 135);
            this.ChanceLabel.Name = "ChanceLabel";
            this.ChanceLabel.Size = new System.Drawing.Size(110, 13);
            this.ChanceLabel.TabIndex = 18;
            this.ChanceLabel.Text = "Bad Landing Chance:";
            // 
            // StageLabel
            // 
            this.StageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StageLabel.AutoSize = true;
            this.StageLabel.BackColor = System.Drawing.Color.Transparent;
            this.StageLabel.Location = new System.Drawing.Point(45, 163);
            this.StageLabel.Name = "StageLabel";
            this.StageLabel.Size = new System.Drawing.Size(93, 13);
            this.StageLabel.TabIndex = 17;
            this.StageLabel.Text = "Experiment Stage:";
            // 
            // AllLabel
            // 
            this.AllLabel.AutoSize = true;
            this.AllLabel.Location = new System.Drawing.Point(7, 110);
            this.AllLabel.Name = "AllLabel";
            this.AllLabel.Size = new System.Drawing.Size(67, 13);
            this.AllLabel.TabIndex = 16;
            this.AllLabel.Text = "All Landings:";
            // 
            // BadLabel
            // 
            this.BadLabel.AutoSize = true;
            this.BadLabel.Location = new System.Drawing.Point(7, 87);
            this.BadLabel.Name = "BadLabel";
            this.BadLabel.Size = new System.Drawing.Size(75, 13);
            this.BadLabel.TabIndex = 15;
            this.BadLabel.Text = "Bad Landings:";
            // 
            // MainBar
            // 
            this.MainBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainBar.Location = new System.Drawing.Point(6, 158);
            this.MainBar.Name = "MainBar";
            this.MainBar.Size = new System.Drawing.Size(188, 23);
            this.MainBar.TabIndex = 14;
            // 
            // SecondBar
            // 
            this.SecondBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondBar.Location = new System.Drawing.Point(6, 187);
            this.SecondBar.Name = "SecondBar";
            this.SecondBar.Size = new System.Drawing.Size(188, 23);
            this.SecondBar.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Launch experiment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 513);
            this.panel2.TabIndex = 7;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(473, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 513);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 513);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Multiple CoaxCopter Landing Expetiment";
            this.Shown += new System.EventHandler(this.Activate);
            this.Click += new System.EventHandler(this.Activate);
            this.Resize += new System.EventHandler(this.Activate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LandingRadiusUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CopterRadiusUpDown2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown LandingRadiusUpDown1;
        private System.Windows.Forms.NumericUpDown CopterRadiusUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar MainBar;
        private System.Windows.Forms.ProgressBar SecondBar;
        private System.Windows.Forms.Label ChanceLabel;
        private System.Windows.Forms.Label StageLabel;
        private System.Windows.Forms.Label AllLabel;
        private System.Windows.Forms.Label BadLabel;
    }
}

