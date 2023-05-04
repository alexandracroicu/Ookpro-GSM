using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_mtp_croicu_alexandra
{
    public partial class gsm : Form
    {
        public gsm()
        {
            InitializeComponent();
        }

        private void gsm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi, dear user!\nFor this step of the application, you just have to select from the menu buttons what interests you from your store! If you think you can't handle it, please contact me through the login page! Good luck!");
        }

        private void btn_phone_cases_Click(object sender, EventArgs e)
        {
            Form f = new Cases();
            this.Hide();
            f.ShowDialog();
        }

        private void btn_phone_foils_Click(object sender, EventArgs e)
        {
            Form f = new Foils();
            this.Hide();
            f.ShowDialog();
        }

        private void btn_phones_Click(object sender, EventArgs e)
        {
            Form f = new Phones();
            this.Hide();
            f.ShowDialog();
        }

        private void btn_phone_chargers_Click(object sender, EventArgs e)
        {
            Form f = new Chargers();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Headp();
            this.Hide();
            f.ShowDialog();
        }
    }
}
