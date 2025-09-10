namespace _14_LatinTranslator
{
    partial class frmLatinTranslator
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
            this.btnLatinSinister = new System.Windows.Forms.Button();
            this.btnLatinMedium = new System.Windows.Forms.Button();
            this.btnLatinDexter = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLatinSinister
            // 
            this.btnLatinSinister.Location = new System.Drawing.Point(12, 116);
            this.btnLatinSinister.Name = "btnLatinSinister";
            this.btnLatinSinister.Size = new System.Drawing.Size(75, 23);
            this.btnLatinSinister.TabIndex = 0;
            this.btnLatinSinister.Text = "Sinister";
            this.btnLatinSinister.UseVisualStyleBackColor = true;
            this.btnLatinSinister.Click += new System.EventHandler(this.btnLatinSinister_Click);
            // 
            // btnLatinMedium
            // 
            this.btnLatinMedium.Location = new System.Drawing.Point(103, 116);
            this.btnLatinMedium.Name = "btnLatinMedium";
            this.btnLatinMedium.Size = new System.Drawing.Size(75, 23);
            this.btnLatinMedium.TabIndex = 1;
            this.btnLatinMedium.Text = "Medium";
            this.btnLatinMedium.UseVisualStyleBackColor = true;
            this.btnLatinMedium.Click += new System.EventHandler(this.btnLatinMedium_Click);
            // 
            // btnLatinDexter
            // 
            this.btnLatinDexter.Location = new System.Drawing.Point(197, 116);
            this.btnLatinDexter.Name = "btnLatinDexter";
            this.btnLatinDexter.Size = new System.Drawing.Size(75, 23);
            this.btnLatinDexter.TabIndex = 2;
            this.btnLatinDexter.Text = "Dexter";
            this.btnLatinDexter.UseVisualStyleBackColor = true;
            this.btnLatinDexter.Click += new System.EventHandler(this.btnLatinDexter_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(119, 53);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 13);
            this.lblOutput.TabIndex = 3;
            // 
            // frmLatinTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 168);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnLatinDexter);
            this.Controls.Add(this.btnLatinMedium);
            this.Controls.Add(this.btnLatinSinister);
            this.Name = "frmLatinTranslator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Latin Translator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSinister;
        private System.Windows.Forms.Button btnDexter;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.Button btnLatinSinister;
        private System.Windows.Forms.Button btnLatinMedium;
        private System.Windows.Forms.Button btnLatinDexter;
        private System.Windows.Forms.Label lblOutput;
    }
}

