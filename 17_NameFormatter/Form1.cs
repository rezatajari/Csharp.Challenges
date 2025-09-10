using System;
using System.Windows.Forms;

namespace _17_NameFormatter
{
  public partial class frmNameFormatter : Form
  {
    public frmNameFormatter()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnFormatName_Click(object sender, EventArgs e)
    {
      string firstName;
      string middleName;
      string lastName;
      string title;

      firstName = txtFirstName.Text;
      middleName = txtMiddleName.Text;
      lastName = txtLastName.Text;
      title = txtTitle.Text;

      lstOutput.Items.Add(title + " " + firstName + " " + middleName + " " + lastName);//Ms.Kelly Jane Smith 
      lstOutput.Items.Add(firstName + " " + middleName + " " + lastName);//Kelly Jane Smith 
      lstOutput.Items.Add(firstName + " " + lastName); //Kelly Smith 
      lstOutput.Items.Add(lastName + ", " + firstName + " " + middleName + ", " + title); //Smith, Kelly Jane, Ms. 
      lstOutput.Items.Add(lastName + ", " + firstName + " " + middleName); //Smith, Kelly Jane 
      lstOutput.Items.Add(lastName + ", " + firstName);//Smith, Kelly
    }
  }
}
