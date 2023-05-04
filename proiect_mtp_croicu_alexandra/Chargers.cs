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
    public partial class Chargers : Form
    {
        public Chargers()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_add_chargers_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into Chargers ([model], [pret]) values(@mo, @pre)";
                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@mo", textBox1.Text);
                sc.Parameters.AddWithValue("@pre", textBox3.Text);
                sc.ExecuteNonQuery();
                cnn.Close();
                // this.DialogResult = DialogResult.OK;
                //this.Close();
                string tabel = "select * from Chargers";
                SqlDataAdapter da = new SqlDataAdapter(tabel, connect);
                DataSet ds = new DataSet();
                da.Fill(ds, "Chargers");
                dataGridView2.DataSource = ds.Tables["Chargers"].DefaultView;
            }
            else
            {
                MessageBox.Show("Please enter the required data!!");
            }
        }

        private void btn_view_chargers_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            string tabel = "select * from Chargers";
            SqlDataAdapter da = new SqlDataAdapter(tabel, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chargers");
            dataGridView2.DataSource = ds.Tables["Chargers"].DefaultView;
            cnn.Close();

        }

        private void btn_delete_chargers_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            SqlDataAdapter adapter = new SqlDataAdapter();
            string tabel = "delete Chargers where model='" + textBox4.Text + "'";
            cnn.Open();
            adapter.UpdateCommand = cnn.CreateCommand();
            adapter.UpdateCommand.CommandText = tabel;
            adapter.UpdateCommand.ExecuteNonQuery();
            cnn.Close();
        }

        private void btn_search_charger_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string stmt = "select * from Chargers where model='" + textBox6.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(stmt, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chargers");
            dataGridView2.DataSource = ds.Tables["Chargers"].DefaultView;
            cnn.Close();
            da.Dispose();
            ds.Dispose();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            string connect = @"Data Source=LAPTOP-0S6UU3MB\MSSQLSERVER03;Initial Catalog=GSM_OOKPRO;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            string tabel = "select * from Chargers";
            SqlDataAdapter da = new SqlDataAdapter(tabel, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Chargers");
            dataGridView2.DataSource = ds.Tables["Chargers"].DefaultView;
            cnn.Close();
        }

        private void btn_revenire_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            gsm g = new gsm();
            g.Show();
        }
    }
}

