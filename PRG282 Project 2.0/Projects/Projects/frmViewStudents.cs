using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    public partial class frmViewStudents : Form
    {
        DataHandler handler = new DataHandler();
        
        public frmViewStudents()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //this.Close();
            //frmHome frmHome = new frmHome();
            //frmHome.Show();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            frmHome home = new frmHome();
            this.Hide();
            home.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                handler.AddStudent(tbxName.Text, tbxSurname.Text, int.Parse(tbxDOB.Text), tbxGender.Text, int.Parse(tbxPhone.Text), tbxAddress.Text, clbDisplayCourse.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                handler.UpdateStudent(tbxName.Text, tbxSurname.Text, int.Parse(tbxDOB.Text), tbxGender.Text, int.Parse(tbxPhone.Text), tbxAddress.Text, clbDisplayCourse.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                handler.DeleteStudent(int.Parse(tbxNumber.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
