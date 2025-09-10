namespace _17_NameFormatter
{
  partial class frmNameFormatter
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
      this.btnFormatName = new System.Windows.Forms.Button();
      this.txtTitle = new System.Windows.Forms.TextBox();
      this.txtLastName = new System.Windows.Forms.TextBox();
      this.txtMiddleName = new System.Windows.Forms.TextBox();
      this.txtFirstName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lstOutput = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // btnFormatName
      // 
      this.btnFormatName.Location = new System.Drawing.Point(128, 194);
      this.btnFormatName.Name = "btnFormatName";
      this.btnFormatName.Size = new System.Drawing.Size(100, 40);
      this.btnFormatName.TabIndex = 0;
      this.btnFormatName.Text = "Format Name";
      this.btnFormatName.UseVisualStyleBackColor = true;
      this.btnFormatName.Click += new System.EventHandler(this.btnFormatName_Click);
      // 
      // txtTitle
      // 
      this.txtTitle.Location = new System.Drawing.Point(128, 148);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.Size = new System.Drawing.Size(100, 20);
      this.txtTitle.TabIndex = 1;
      // 
      // txtLastName
      // 
      this.txtLastName.Location = new System.Drawing.Point(128, 105);
      this.txtLastName.Name = "txtLastName";
      this.txtLastName.Size = new System.Drawing.Size(100, 20);
      this.txtLastName.TabIndex = 2;
      // 
      // txtMiddleName
      // 
      this.txtMiddleName.Location = new System.Drawing.Point(128, 67);
      this.txtMiddleName.Name = "txtMiddleName";
      this.txtMiddleName.Size = new System.Drawing.Size(100, 20);
      this.txtMiddleName.TabIndex = 3;
      // 
      // txtFirstName
      // 
      this.txtFirstName.Location = new System.Drawing.Point(128, 28);
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.Size = new System.Drawing.Size(100, 20);
      this.txtFirstName.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(55, 31);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "First Name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(43, 70);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Middle Name";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(54, 108);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Last Name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(85, 151);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(27, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Title";
      // 
      // lstOutput
      // 
      this.lstOutput.FormattingEnabled = true;
      this.lstOutput.Location = new System.Drawing.Point(288, 28);
      this.lstOutput.Name = "lstOutput";
      this.lstOutput.Size = new System.Drawing.Size(212, 147);
      this.lstOutput.TabIndex = 9;
      // 
      // frmNameFormatter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(532, 265);
      this.Controls.Add(this.lstOutput);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtFirstName);
      this.Controls.Add(this.txtMiddleName);
      this.Controls.Add(this.txtLastName);
      this.Controls.Add(this.txtTitle);
      this.Controls.Add(this.btnFormatName);
      this.Name = "frmNameFormatter";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Name Formatter";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnFormatName;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.TextBox txtMiddleName;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ListBox lstOutput;
  }
}

