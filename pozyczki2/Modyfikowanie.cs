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
        }

        
        public int Id;

        private void Modyfikowanie_Load(object sender, EventArgs e)
        {
            Id = f1.f1_id;
            textBox1.Text = f1.imie;
            textBox2.Text = f1.nazwisko;
            textBox3.Text = f1.telefon;

            if (f1.plec == "m") { radioButton1.Checked = true; }
            else { radioButton2.Checked = true; }

            if (f1.kategorie.Contains("AM")) { checkBox1.Checked = true; }
            if (f1.kategorie.Contains("A")) { checkBox2.Checked = true; }
            if (f1.kategorie.Contains("B")) { checkBox3.Checked = true; }
            if (f1.kategorie.Contains("C+E")) { checkBox4.Checked = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f1.odswiez_uzytkownikow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = Id.ToString();
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

                        SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
                        database.Open();

                        using (SQLiteConnection conn = new SQLiteConnection(database))
                        {
                            try
                            {
                                SQLiteCommand cmd = new SQLiteCommand(conn);
                                cmd.CommandText = "UPDATE uzytkownicy SET imie=@imie, nazwisko=@nazwisko, telefon=@telefon, plec=@plec, kategorie=@kategorie WHERE uzytkownik_id = @id;";
                                cmd.Parameters.AddWithValue("@imie", imie);
                                cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@telefon", telefon);
                                cmd.Parameters.AddWithValue("@plec", plec);
                                cmd.Parameters.AddWithValue("@kategorie", kategorie);
                                cmd.ExecuteNonQuery();
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }

                        database.Close();

                        textBox1.Clear();
                        textBox2.Clear();
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
            textBox1.Text = f1.imie;
            textBox2.Text = f1.nazwisko;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
