using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telephone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] hash = new string[10000];
        
        private void savebtn_Click(object sender, EventArgs e)
        {
            //string[] hash = new string[] { };
            if (inputsvalue())
            {
                byte[] nameascii = Encoding.ASCII.GetBytes(name_txt.Text);
                byte[] familyascii = Encoding.ASCII.GetBytes(family_txt.Text);
                int sumname = 0, sumfamily = 0;
                foreach (var nam in nameascii)
                {
                    sumname += (int)nam;
                }
                foreach (var famil in familyascii)
                {
                    sumfamily += (int)famil;
                }
                int location = (sumname * (sumname + sumfamily) * 30) / (sumfamily * name_txt.Text.Length * family_txt.Text.Length * 10);
                hash[location] = mobile_txt.Text;
                hash_txt.Text = location.ToString();
            }
        }
        bool inputsvalue()
        {
            if (name_txt.Text == "")
            {
                MessageBox.Show("please enter name", "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (family_txt.Text == "")
            {
                MessageBox.Show("please enter family", "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (mobile_txt.Text == "")
            {
                MessageBox.Show("please enter mobile", "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (name_txt.Text != "" && family_txt.Text != "")
            {
                byte[] nameascii = Encoding.ASCII.GetBytes(name_txt.Text);
                byte[] familyascii = Encoding.ASCII.GetBytes(family_txt.Text);
                int sumname = 0, sumfamily = 0;
                foreach (var nam in nameascii)
                {
                    sumname += (int)nam;
                }
                foreach (var famil in familyascii)
                {
                    sumfamily += (int)famil;
                }
                int location = (sumname * (sumname + sumfamily) * 30) / (sumfamily * name_txt.Text.Length * family_txt.Text.Length * 10);
                if (hash[location] == null)
                {
                    MessageBox.Show("Contact not source", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    notifi.ForeColor = Color.DarkGreen;
                    notifi.Text = "find it";
                    hash_txt.Text = location.ToString();
                    view_txt.Text = name_txt.Text;
                    ftxt.Text = family_txt.Text;
                    mtxt.Text = hash[location];
                }
            }
            else
            {
                MessageBox.Show("Please input name and family", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            byte[] nameascii = Encoding.ASCII.GetBytes(name_txt.Text);
            byte[] familyascii = Encoding.ASCII.GetBytes(family_txt.Text);
            int sumname = 0, sumfamily = 0;
            foreach (var nam in nameascii)
            {
                sumname += (int)nam;
            }
            foreach (var famil in familyascii)
            {
                sumfamily += (int)famil;
            }
            int location = (sumname * (sumname + sumfamily) * 30) / (sumfamily * name_txt.Text.Length * family_txt.Text.Length * 10);
            if (hash[location] != null)
            {
                hash[location] = null;
                notifi.Text = "";
                hash_txt.Text = "";
                view_txt.Text = "";
                ftxt.Text = "";
                mtxt.Text = "";
                MessageBox.Show($"Contact {name_txt.Text} {family_txt.Text} deleted", 
                    "information", MessageBoxButtons
                    .OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Contact not source", "information"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
