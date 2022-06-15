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
    public partial class Form1 : Form
    {
        public int od = 0;
        public Form1()
        {
            InitializeComponent();

            menu_kontekstowe.Visible = false;
            panel2.Visible = false;
            button5.Visible = false;
            panel3.Visible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LimeGreen;

            zaladuj_uzytkownikow();
        }

        

        private void zaladuj_uzytkownikow()
        {
            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            sQLitePolecenia.zaladuj_uzytkownikow(od);
            dataGridView1.DataSource = sQLitePolecenia.uzytkownicy;
        }

        public void odswiez_uzytkownikow()
        {
            dataGridView1.DataSource = null;
            zaladuj_uzytkownikow();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            sQLitePolecenia.zaladuj_uzytkownikow(od);
        }

        public void dodaj_uzytkownika()
        {
            Dodawanie dodawanie = new Dodawanie(this);
            dodawanie.Show();
        }

        private void dodaj_Click(object sender, EventArgs e)
        {
            dodaj_uzytkownika();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odswiez_uzytkownikow();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            menu_kontekstowe.Visible = false;
            panel2.Visible = false;
        }

        
        
        public void usun()
        {
            row = dataGridView1.CurrentCell.RowIndex;
            id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            sQLitePolecenia.usun(id);

            menu_kontekstowe.Visible = false;
            panel2.Visible = false;

            odswiez_uzytkownikow();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            usun();
        }

        public int row;
        public int id;
        public string imie;
        public string nazwisko;
        public string telefon;
        public string plec;
        public string kategorie;
        public void modyfikuj(int id_, string imie_, string nazwisko_, string telefon_, string plec_, string kategorie_)
        {
            id = id_;
            imie = imie_;
            nazwisko = nazwisko_;
            telefon = telefon_;
            plec = plec_;
            kategorie = kategorie_;

            Modyfikowanie modyfikowanie = new Modyfikowanie(this);
            modyfikowanie.Show();

            menu_kontekstowe.Visible = false;
            panel2.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            row = dataGridView1.CurrentCell.RowIndex;
            id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());

            SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
            sQLitePolecenia.modyfikacja(id);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            string text = textBox1.Text;
            if (string.IsNullOrEmpty(text))
            {
                odswiez_uzytkownikow();
            }
            else
            {
                SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
                sQLitePolecenia.wyszukaj(text);
                dataGridView1.DataSource = sQLitePolecenia.uzytkownicy;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            row = dataGridView1.CurrentCell.RowIndex;
            id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            imie = dataGridView1.Rows[row].Cells[1].Value.ToString();
            nazwisko = dataGridView1.Rows[row].Cells[2].Value.ToString();

            Pozyczki pozyczki = new Pozyczki(this);
            pozyczki.Show();
        }





        private void listView1_Click(object sender, EventArgs e)
        {
            
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public int strona;
        private void button5_Click(object sender, EventArgs e)
        {
            od -= 5;
            odswiez_uzytkownikow();

            if (od <= 0)
            {
                button5.Visible = false;
                panel3.Visible = false;
            }

            button6.Visible = true;
            panel4.Visible = true;
            strona = od / 5 + 1;
            label1.Text = strona.ToString();
        }
        int maxrow;
        private void button6_Click(object sender, EventArgs e)
        {
            od += 5;
            odswiez_uzytkownikow();
            oblicz_ilosc_uzytkownikow();

            if(maxrow - od <= 5)
            {
                button6.Visible = false;
                panel4.Visible = false;
            }

            button5.Visible = true;
            panel3.Visible = true;
            strona = od / 5 + 1;
            label1.Text = strona.ToString();
        }

        public void oblicz_ilosc_uzytkownikow()
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "SELECT row_number() over(ORDER BY uzytkownik_id) AS rownumber FROM `uzytkownicy` ORDER BY rownumber DESC LIMIT 1";
                    SQLiteDataReader dr;
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    maxrow = Int32.Parse(dr["rownumber"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            database.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int row = dataGridView1.CurrentCell.RowIndex;
                string id = dataGridView1.Rows[row].Cells[0].Value.ToString();

                menu_kontekstowe.Visible = true;
                panel2.Visible = true;

                Point p = this.PointToClient(Cursor.Position);
                menu_kontekstowe.Left = p.X;
                menu_kontekstowe.Top = p.Y;

                panel2.Left = p.X - 5;
                panel2.Top = p.Y + 5;
            }
            else
            {
                menu_kontekstowe.Visible = false;
                panel2.Visible = false;
            }
        }

        public string akcja;
        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            akcja = "dodaj";
            dodajToolStripMenuItem1.Checked = true;
            modyfikujToolStripMenuItem.Checked = false;
            usuńToolStripMenuItem.Checked = false;
        }

        private void modyfikujToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            akcja = "modyfikuj";
            dodajToolStripMenuItem1.Checked = false;
            modyfikujToolStripMenuItem.Checked = true;
            usuńToolStripMenuItem.Checked = false;
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            akcja = "usun";
            dodajToolStripMenuItem1.Checked = false;
            modyfikujToolStripMenuItem.Checked = false;
            usuńToolStripMenuItem.Checked = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //switch (akcja)
            //{
            //    case "dodaj":
            //        dodaj_uzytkownika();
            //        break;
            //    case "modyfikuj":
            //        modyfikuj();
            //        break;
            //    case "usun":
            //        usun();
            //        break;
            //}
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void dodajToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}
