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
    public partial class Dodaj_pozyczke : Form
    {
        Pozyczki p1;
        public int id;
        public Dodaj_pozyczke(Pozyczki p1)
        {
            InitializeComponent();
            this.p1 = p1;
            id = p1.id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
                sQLitePolecenia.dodaj_pozyczke(id, float.Parse(textBox1.Text), float.Parse(textBox2.Text), dateTimePicker1.Value.ToString("dd.mm.yyyy"));
            }
            else
            {
                MessageBox.Show("Uzupełnij dane!");
            }
            p1.zaladuj_pozyczki();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p1.zaladuj_pozyczki();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                label5.Text = (Math.Round(float.Parse(textBox1.Text) + float.Parse(textBox1.Text) * (float.Parse(textBox2.Text) / 100), 2)).ToString() + " zł";
            }
            else if(textBox2.Text == "")
            {
                label5.Text = (Math.Round(float.Parse(textBox1.Text) + float.Parse(textBox1.Text) * 0, 2)).ToString() + " zł";
            }
            else
            {
                label5.Text = "0 zł";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                label5.Text = (Math.Round(float.Parse(textBox1.Text) + float.Parse(textBox1.Text) * (float.Parse(textBox2.Text) / 100), 2)).ToString() + " zł";
            }
            else
            {
                label5.Text = "0 zł";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
