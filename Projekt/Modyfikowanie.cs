using System;
using System.IO;
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
    public partial class Modyfikowanie : Form
    {
        Form1 f1;
        public Modyfikowanie(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;

            id = f1.id;
            imie = f1.imie;
            nazwisko = f1.nazwisko;
            telefon = f1.telefon;
            plec = f1.plec;
            kategorie = f1.kategorie;
        }

        public int id;
        public string imie;
        public string nazwisko;
        public string telefon;
        public string plec;
        public string kategorie;

        private void Modyfikowanie_Load(object sender, EventArgs e)
        {
            textBox1.Text = imie;
            textBox2.Text = nazwisko;
            textBox3.Text = telefon;

            if (plec == "m") { radioButton1.Checked = true; }
            else { radioButton2.Checked = true; }
            
            if (kategorie.Contains("AM,")) { checkBox1.Checked = true; }
            if (kategorie.Contains("A,")) { checkBox2.Checked = true; }
            if (kategorie.Contains("B,")) { checkBox3.Checked = true; }
            if (kategorie.Contains("C+E,")) { checkBox4.Checked = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.odswiez_uzytkownikow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imie = textBox1.Text;
            string nazwisko = textBox2.Text;
            string telefon = textBox3.Text;
            string plec = "";
            string kategorie = "";

            if (!string.IsNullOrEmpty(imie) && !string.IsNullOrEmpty(nazwisko))
            {
                if (imie.Any(char.IsDigit))
                {
                    MessageBox.Show("Imię nie może zawierać liczby!");
                }
                if (nazwisko.Any(char.IsDigit))
                {
                    MessageBox.Show("Nazwisko nie może zawierać liczby!");
                }
                else
                {
                    if (imie.Length < 2)
                    {
                        MessageBox.Show("Imię za krótkie!");
                    }
                    if (nazwisko.Length < 2)
                    {
                        MessageBox.Show("Nazwisko za krótkie!");
                    }
                    else
                    {
                        imie = imie.ToLower();
                        nazwisko = nazwisko.ToLower();

                        string pierwsza_litera_imie = imie.Substring(0, 1);
                        string reszta_liter_imie = imie.Substring(1, imie.Length - 1);
                        pierwsza_litera_imie = pierwsza_litera_imie.ToUpper();
                        imie = pierwsza_litera_imie + reszta_liter_imie;

                        string pierwsza_litera_nazwisko = nazwisko.Substring(0, 1);
                        string reszta_liter_nazwisko = nazwisko.Substring(1, nazwisko.Length - 1);
                        pierwsza_litera_nazwisko = pierwsza_litera_nazwisko.ToUpper();
                        nazwisko = pierwsza_litera_nazwisko + reszta_liter_nazwisko;

                        if (telefon.Length != 9)
                        {
                            MessageBox.Show("Niepoprawna długość numeru telefonu!");
                        }

                        if (radioButton1.Checked) { plec = "m"; }
                        else { plec = "k"; }

                        if (checkBox1.Checked)
                        {
                            kategorie += checkBox1.Text;
                            if (checkBox2.Checked || checkBox3.Checked || checkBox4.Checked) { kategorie += ", "; }
                        }
                        if (checkBox2.Checked)
                        {
                            kategorie += checkBox2.Text;
                            if (checkBox3.Checked || checkBox4.Checked) { kategorie += ", "; }
                        }
                        if (checkBox3.Checked)
                        {
                            kategorie += checkBox3.Text;
                            if (checkBox4.Checked) { kategorie += ", "; }
                        }
                        if (checkBox4.Checked)
                        {
                            kategorie += checkBox4.Text;
                        }

                        SQLitePolecenia sQLitePolecenia = new SQLitePolecenia();
                        sQLitePolecenia.modyfikuj(id, imie, nazwisko, telefon, plec, kategorie);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wypełnij dane użytkownika aby go zmodyfikować!");
            }

            f1.odswiez_uzytkownikow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = imie;
            textBox2.Text = nazwisko;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
