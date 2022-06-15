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
        public Form1()
        {
            InitializeComponent();

            menu_kontekstowe.Visible = false;
            button5.Enabled = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        public int od = 0;

        private void zaladuj_uzytkownikow()
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using(SQLiteConnection conn = new SQLiteConnection(database))
            {
                try
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM uzytkownicy LIMIT 5 OFFSET " + od, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        this.dataGridView1.Rows.Add(row["uzytkownik_id"].ToString(), row["imie"].ToString(), row["nazwisko"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            database.Close();
        }

        public void odswiez_uzytkownikow()
        {
            dataGridView1.Rows.Clear();
            
            zaladuj_uzytkownikow();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zaladuj_uzytkownikow();
        }

        private void dodaj_Click(object sender, EventArgs e)
        {
            Dodawanie dodawanie = new Dodawanie(this);
            dodawanie.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odswiez_uzytkownikow();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            menu_kontekstowe.Visible = false;
        }

        public string imie;
        public string nazwisko;
        private void button2_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd = new SQLiteCommand("DELETE FROM uzytkownicy WHERE uzytkownik_id = " + id, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            database.Close();
            menu_kontekstowe.Visible = false;

            odswiez_uzytkownikow();
        }

        public int f1_id;
        public string telefon;
        public string plec;
        public string kategorie;

        private void button4_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            imie = dataGridView1.Rows[row].Cells[1].Value.ToString();
            nazwisko = dataGridView1.Rows[row].Cells[2].Value.ToString();

            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "SELECT * FROM uzytkownicy WHERE uzytkownik_id =" + id;
                    SQLiteDataReader dr;
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    telefon = dr["telefon"].ToString();
                    plec = dr["plec"].ToString();
                    kategorie = dr["kategorie"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            database.Close();

            f1_id = Int32.Parse(id);

            Modyfikowanie modyfikowanie = new Modyfikowanie(this);
            modyfikowanie.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string text = textBox1.Text;
            if (string.IsNullOrEmpty(text))
            {
                odswiez_uzytkownikow();
            }
            else
            {
                SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
                database.Open();

                using (SQLiteConnection conn = new SQLiteConnection(database))
                {
                    try
                    {
                        SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM uzytkownicy WHERE uzytkownik_id LIKE '%" + text + "%' OR imie LIKE '%" + text + "%' OR nazwisko LIKE '%" + text + "%'", conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            this.dataGridView1.Rows.Add(row["uzytkownik_id"].ToString(), row["imie"].ToString(), row["nazwisko"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                database.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "SELECT imie, nazwisko FROM uzytkownicy WHERE uzytkownik_id = 1";

                    SQLiteDataReader dr;
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    imie = dr["imie"].ToString();
                    nazwisko = dr["nazwisko"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            database.Close();

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

        private void button5_Click(object sender, EventArgs e)
        {
            od -= 5;
            odswiez_uzytkownikow();

            if (od <= 0)
            {
                button5.Enabled = false;
            }

            button6.Enabled = true;
        }
        int maxrow;
        private void button6_Click(object sender, EventArgs e)
        {
            od += 5;
            odswiez_uzytkownikow();
            oblicz_ilosc_uzytkownikow();

            if(maxrow - od <= 5)
            {
                button6.Enabled = false;
            }

            button5.Enabled = true;
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

                Point p = this.PointToClient(Cursor.Position);
                menu_kontekstowe.Left = p.X;
                menu_kontekstowe.Top = p.Y;
            }
            else
            {
                menu_kontekstowe.Visible = false;
            }
        }

    }
}
