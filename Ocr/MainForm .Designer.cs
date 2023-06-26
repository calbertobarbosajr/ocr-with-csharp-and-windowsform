namespace Ocr
{
    partial class MainForm
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
            this.buttonCapturaTela = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSelectNone = new System.Windows.Forms.RadioButton();
            this.radioButtonSelect = new System.Windows.Forms.RadioButton();
            this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCapturaTela
            // 
            this.buttonCapturaTela.Location = new System.Drawing.Point(88, 12);
            this.buttonCapturaTela.Name = "buttonCapturaTela";
            this.buttonCapturaTela.Size = new System.Drawing.Size(152, 33);
            this.buttonCapturaTela.TabIndex = 0;
            this.buttonCapturaTela.Text = "Captura Tela";
            this.buttonCapturaTela.UseVisualStyleBackColor = true;
            this.buttonCapturaTela.Click += new System.EventHandler(this.buttonCapturaTela_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSelectNone);
            this.groupBox1.Controls.Add(this.radioButtonSelect);
            this.groupBox1.Location = new System.Drawing.Point(318, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButtonSelectNone
            // 
            this.radioButtonSelectNone.AutoSize = true;
            this.radioButtonSelectNone.Checked = true;
            this.radioButtonSelectNone.Location = new System.Drawing.Point(163, 20);
            this.radioButtonSelectNone.Name = "radioButtonSelectNone";
            this.radioButtonSelectNone.Size = new System.Drawing.Size(111, 17);
            this.radioButtonSelectNone.TabIndex = 1;
            this.radioButtonSelectNone.TabStop = true;
            this.radioButtonSelectNone.Text = "Deselecionar àrea";
            this.radioButtonSelectNone.UseVisualStyleBackColor = true;
            this.radioButtonSelectNone.CheckedChanged += new System.EventHandler(this.radioButtonSelectNone_CheckedChanged);
            // 
            // radioButtonSelect
            // 
            this.radioButtonSelect.AutoSize = true;
            this.radioButtonSelect.Location = new System.Drawing.Point(21, 20);
            this.radioButtonSelect.Name = "radioButtonSelect";
            this.radioButtonSelect.Size = new System.Drawing.Size(99, 17);
            this.radioButtonSelect.TabIndex = 0;
            this.radioButtonSelect.Text = "Selecionar área";
            this.radioButtonSelect.UseVisualStyleBackColor = true;
            this.radioButtonSelect.CheckedChanged += new System.EventHandler(this.radioButtonSelect_CheckedChanged);
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Location = new System.Drawing.Point(318, 141);
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownOpacity.TabIndex = 2;
            this.numericUpDownOpacity.ValueChanged += new System.EventHandler(this.numericUpDownOpacity_ValueChanged);
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(70, 211);
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(641, 45);
            this.trackBarOpacity.TabIndex = 3;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBarOpacity);
            this.Controls.Add(this.numericUpDownOpacity);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCapturaTela);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCapturaTela;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSelectNone;
        private System.Windows.Forms.RadioButton radioButtonSelect;
        private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
        private System.Windows.Forms.TrackBar trackBarOpacity;
    }
}

