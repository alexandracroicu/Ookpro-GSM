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
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into Autentificare_gsm ([name], [subname], [username], [password], [age]) values(@nam, @subn, @user, @pass, @ag)";
                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@nam", textBox1.Text);
                sc.Parameters.AddWithValue("@subn", textBox2.Text);
                sc.Parameters.AddWithValue("@user", textBox3.Text);
                sc.Parameters.AddWithValue("@pass", textBox4.Text);
                sc.Parameters.AddWithValue("@ag", textBox5.Text);
                sc.ExecuteNonQuery();
                cnn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter the required data!!");
            }
            Form f = new Form1();
            this.Hide();
            f.ShowDialog();

        }
        private void textBox5toolTip2(object sender, EventArgs e)
        {
            toolTip2.Show("Please enter your last age", textBox5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1toolTip2(object sender, EventArgs e)
        {
            toolTip2.Show("Please enter your last name",textBox1);
        }

        private void ValidareNume(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && !Char.IsUpper(textBox1.Text, 0))
                //if (textBox1.Text.Length < 4)
            {
                button1.Enabled = false;
                MessageBox.Show("The entered last name must start with a capital letter.");
            }
            else
                button1.Enabled = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2toolTip2(object sender, EventArgs e)
        {
            toolTip2.Show("Please enter your first name", textBox2);
        }

        private void ValidarePrenume(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && !Char.IsUpper(textBox2.Text, 0))
            {
                button1.Enabled = false;
                MessageBox.Show("The entered first name must start with a capital letter.");
            }
            else
                button1.Enabled = true;
        }

        private void textBox3toolTip2(object sender, EventArgs e)
        {
            toolTip2.Show("Please enter your username", textBox3);
        }

        private void ValidareUsername(object sender, EventArgs e)
        {
            if (textBox3.Text.Length < 4)
            {
                button1.Enabled = false;
                MessageBox.Show("The username must have at least 5 characters!");
            }
            else
                button1.Enabled = true;
        }

        private void textBox4toolTip2(object sender, EventArgs e)
        {
            toolTip2.Show("Please enter your password", textBox4);
        }

        private void ValidarePassword(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && !Char.IsUpper(textBox4.Text, 0) && textBox4.Text.Length <= 6)
            {
                button1.Enabled = false;
                MessageBox.Show("The password must have at least 6 characters and must start with a capital letter!");
            }
            else
                button1.Enabled = true;
        }

        private void ValidareVarsta(object sender, EventArgs e)
        {
            int ceva = int.Parse(textBox5.Text);
            if (ceva<=18)
            {
                button1.Enabled = false;
                MessageBox.Show("The age must have at least 18 years old!");
            }
            else
                button1.Enabled = true;
        }
    }
}

