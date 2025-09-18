using System;
using System.Windows.Forms;

namespace _14_LatinTranslator
{
  public partial class frmLatinTranslator : Form
  {
    public frmLatinTranslator()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnLatinSinister_Click(object sender, EventArgs e)
    {
      lblOutput.Text = "Left";
      lblOutput.Left = 50;
    }

    private void btnLatinMedium_Click(object sender, EventArgs e)
    {
      lblOutput.Text = "Center";
      lblOutput.Left = (this.ClientSize.Width -lblOutput.Width) / 2;
    }

    private void btnLatinDexter_Click(object sender, EventArgs e)
    {
      lblOutput.Text = "Right";
      lblOutput.Left = 240;
    }
  }
}
