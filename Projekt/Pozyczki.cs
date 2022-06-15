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
    public partial class Pozyczki : Form
    {
        Form1 f1;
        public int id;
        public int pozyczka_id_;
        public Pozyczki(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            label1.Text = "Pożyczki użytkownika " + f1.imie + " " + f1.nazwisko;
            id = f1.id;

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Spłaty");
            menuItem.Click += new EventHandler(MenuItem_Click);
            menuItem.Name = "Spłaty";
            menu.Items.Add(menuItem);
            this.ContextMenuStrip = menu;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            pozyczka_id_ = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if(menuItem.Name == "Spłaty")
            {
                Splaty splaty = new Splaty(this);
                splaty.Show();
            }
        }

        public void zaladuj_pozyczki()
        {
            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            sQLitePolecenia.pobierz_pozyczki(id);
            dataGridView1.DataSource = sQLitePolecenia.pozyczki;
        }

        public void odswiez_pozyczki()
        {
            dataGridView1.DataSource = null;
            zaladuj_pozyczki();
        }
        

        private void Pozyczki_Load(object sender, EventArgs e)
        {
            zaladuj_pozyczki();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dodaj_pozyczke dodaj_pozyczke = new Dodaj_pozyczke(this);
            dodaj_pozyczke.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
