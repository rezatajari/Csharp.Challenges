using System;
using System.Windows.Forms;

namespace Gaddis_02_02_ClickableImages
{
  public partial class frmClickableImages : Form
  {
    public frmClickableImages()
    {
      InitializeComponent();
    }

    private void frmClickableImages_Load(object sender, EventArgs e)
    {

    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      MessageBox.Show("One", "Clickable Image");
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Two", "Clickable Image");
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Three", "Clickable Image");
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Four", "Clickable Image");
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Five", "Clickable Image");
    }
  }
}
