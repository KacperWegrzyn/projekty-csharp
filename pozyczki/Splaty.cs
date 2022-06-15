using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Projekt
{
    public partial class Splaty : Form
    {
        Pozyczki p1;
        public int pozyczka_id;
        public Splaty(Pozyczki p1)
        {
            InitializeComponent();
            this.p1 = p1;
            pozyczka_id = p1.pozyczka_id_;
        }

        public void zaladuj_splaty()
        {
            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            sQLitePolecenia.pobierz_splaty(pozyczka_id);
            dataGridView1.DataSource = sQLitePolecenia.splaty;
        }

        public void odswiez_splaty()
        {
            dataGridView1.DataSource = null;
            zaladuj_splaty();
        }

        private void Splaty_Load(object sender, EventArgs e)
        {
            zaladuj_splaty();
        }


        public string status;
        private void button1_Click(object sender, EventArgs e)
        {
            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            
            float kwota = float.Parse(textBox1.Text);

            sQLitePolecenia.dodaj_splate(pozyczka_id, status, kwota);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p1.zaladuj_pozyczki();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            zaladuj_splaty();
        }

        public void komunikat(string komunikat)
        {
            MessageBox.Show(komunikat);
        }
    }
}
