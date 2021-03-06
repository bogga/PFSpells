﻿namespace PFSpells
{
    partial class GeneratorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.d20Radio = new System.Windows.Forms.RadioButton();
            this.aonRadio = new System.Windows.Forms.RadioButton();
            this.sourceOptions = new System.Windows.Forms.GroupBox();
            this.darkRadio = new System.Windows.Forms.RadioButton();
            this.lightRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.sourceOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spell Names";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter spell names (one per line):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 126);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(238, 78);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Magic Missile\r\nFireball";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter name of file (e.g. character name):";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(18, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(238, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "EvilUncleMonty";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 336);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Launch page on completion";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(99, 359);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(157, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.d20Radio);
            this.groupBox1.Controls.Add(this.aonRadio);
            this.groupBox1.Location = new System.Drawing.Point(18, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 46);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Source";
            // 
            // d20Radio
            // 
            this.d20Radio.AutoSize = true;
            this.d20Radio.Location = new System.Drawing.Point(138, 20);
            this.d20Radio.Name = "d20Radio";
            this.d20Radio.Size = new System.Drawing.Size(79, 17);
            this.d20Radio.TabIndex = 1;
            this.d20Radio.Text = "d20PFSRD";
            this.d20Radio.UseVisualStyleBackColor = true;
            // 
            // aonRadio
            // 
            this.aonRadio.AutoSize = true;
            this.aonRadio.Checked = true;
            this.aonRadio.Location = new System.Drawing.Point(7, 20);
            this.aonRadio.Name = "aonRadio";
            this.aonRadio.Size = new System.Drawing.Size(109, 17);
            this.aonRadio.TabIndex = 0;
            this.aonRadio.TabStop = true;
            this.aonRadio.Text = "Archive of Nethys";
            this.aonRadio.UseVisualStyleBackColor = true;
            this.aonRadio.CheckedChanged += new System.EventHandler(this.aonRadio_CheckedChanged);
            // 
            // sourceOptions
            // 
            this.sourceOptions.Controls.Add(this.darkRadio);
            this.sourceOptions.Controls.Add(this.lightRadio);
            this.sourceOptions.Location = new System.Drawing.Point(18, 266);
            this.sourceOptions.Name = "sourceOptions";
            this.sourceOptions.Size = new System.Drawing.Size(238, 46);
            this.sourceOptions.TabIndex = 10;
            this.sourceOptions.TabStop = false;
            this.sourceOptions.Text = "Source Options";
            // 
            // darkRadio
            // 
            this.darkRadio.AutoSize = true;
            this.darkRadio.Location = new System.Drawing.Point(138, 20);
            this.darkRadio.Name = "darkRadio";
            this.darkRadio.Size = new System.Drawing.Size(84, 17);
            this.darkRadio.TabIndex = 1;
            this.darkRadio.Text = "Dark Theme";
            this.darkRadio.UseVisualStyleBackColor = true;
            // 
            // lightRadio
            // 
            this.lightRadio.AutoSize = true;
            this.lightRadio.Checked = true;
            this.lightRadio.Location = new System.Drawing.Point(7, 20);
            this.lightRadio.Name = "lightRadio";
            this.lightRadio.Size = new System.Drawing.Size(84, 17);
            this.lightRadio.TabIndex = 0;
            this.lightRadio.TabStop = true;
            this.lightRadio.Text = "Light Theme";
            this.lightRadio.UseVisualStyleBackColor = true;
            // 
            // GeneratorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 392);
            this.Controls.Add(this.sourceOptions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneratorWindow";
            this.Text = "Spell List Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.sourceOptions.ResumeLayout(false);
            this.sourceOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton d20Radio;
        private System.Windows.Forms.RadioButton aonRadio;
        private System.Windows.Forms.GroupBox sourceOptions;
        private System.Windows.Forms.RadioButton darkRadio;
        private System.Windows.Forms.RadioButton lightRadio;
    }
}

