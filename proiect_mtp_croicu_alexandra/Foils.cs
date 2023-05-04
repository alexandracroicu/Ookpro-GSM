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
    public partial class Foils : Form
    {
        public Foils()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void btn_add_folis_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into Foils ([model], [material], [pret]) values(@mo, @ma, @pre)";
                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@mo", textBox1.Text);
                sc.Parameters.AddWithValue("@ma", textBox2.Text);
                sc.Parameters.AddWithValue("@pre", textBox3.Text);
                sc.ExecuteNonQuery();
                cnn.Close();
                //this.DialogResult = DialogResult.OK;
                //this.Close();
                string tabel = "select * from Foils";
                SqlDataAdapter da = new SqlDataAdapter(tabel, connect);
                DataSet ds = new DataSet();
                da.Fill(ds, "Foils");
                dataGridView2.DataSource = ds.Tables["Foils"].DefaultView;
             
            }
            else
            {
                MessageBox.Show("Please enter the required data!!");
            }
        }

        private void btn_view_folis_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            string tabel = "select * from Foils";
            SqlDataAdapter da = new SqlDataAdapter(tabel, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Foils");
            dataGridView2.DataSource = ds.Tables["Foils"].DefaultView;
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            gsm g = new gsm();
            g.Show();
        }

        private void btn_delete_folis_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string tabel = "delete Foils where model='" + textBox4.Text + "'";
            cnn.Open();
            adapter.UpdateCommand = cnn.CreateCommand();
            adapter.UpdateCommand.CommandText = tabel;
            adapter.UpdateCommand.ExecuteNonQuery();
            cnn.Close();
        }

        private void btn_search_cases_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string stmt = "select * from Foils where model='" + textBox6.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(stmt, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Foils");
            dataGridView2.DataSource = ds.Tables["Foils"].DefaultView;
            cnn.Close();
            da.Dispose();
            ds.Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            string tabel = "select * from Foils";
            SqlDataAdapter da = new SqlDataAdapter(tabel, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Foils");
            dataGridView2.DataSource = ds.Tables["Foils"].DefaultView;
            cnn.Close();
        }
    }
}
