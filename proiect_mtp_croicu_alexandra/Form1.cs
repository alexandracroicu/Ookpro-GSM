using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_mtp_croicu_alexandra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Autentificare WHERE username = '" + textBox1.Text + "'", con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Autentificare_gsm WHERE username = '" + textBox1.Text + "'" + "and password = '" + textBox2.Text + "'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if ((sdr.Read() == true))
            {
                MessageBox.Show("The user is valid!");
                Form f = new gsm();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Form f1 = new Inregistrare();
            this.Hide();
            f1.ShowDialog();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se inchide aplicatia");
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void btn_x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True");
            // SqlCommand cmd = new SqlCommand("SELECT * FROM Autentificare WHERE username = '" + textBox1.Text + "'", con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Autentificare_gsm WHERE username = '" + textBox1.Text + "'" + "SELECT * FROM Autentificare_gsm WHERE password = '" + textBox2.Text + "'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if ((sdr.Read() == true))
            {
                MessageBox.Show("HERE IS YOUR PASSWORD!" + sdr[3].ToString());
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
            con.Close();

        }

        private void textBox1toolTip1(object sender, EventArgs e)
        {
            toolTip1.Show("Please enter your username",textBox1);
        }

        private void textBox2toolTip1(object sender, EventArgs e)
        {
            toolTip1.Show("Please enter your password",textBox2);
        }

        private void ValidareUsername(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
            {
                button1.Enabled = false;
                MessageBox.Show("The username must have at least 5 characters!");
            }
            else
                button1.Enabled = true;
        }

        private void ValidarePassword(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && !Char.IsUpper(textBox2.Text, 0) && textBox2.Text.Length <= 6)
            {
                button1.Enabled = false;
                MessageBox.Show("The password must have at least 6 characters and must start with a capital letter!");
            }
            else
                button1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new gsm();
            this.Hide();
            f.ShowDialog();
        }
    }
}
