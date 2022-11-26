using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace StudentMangement
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textPass.UseSystemPasswordChar = false;
            else
                textPass.UseSystemPasswordChar = true;
        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            textPass.Clear();
            textName.Clear();
        }

        private void LogInBut_Click(object sender, EventArgs e)
        {
            var state = MyDB.LoginVerfication(textName.Text, textPass.Text);
            if (state == true) MessageBox.Show("YES");
            else MessageBox.Show("NO");
        }
    }
}
