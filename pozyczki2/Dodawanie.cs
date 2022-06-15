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
    public partial class Dodawanie : Form
    {
        Form1 f1;
        public Dodawanie(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        if (radioButton2.Checked) { plec = "k"; }
                        else if(!radioButton1.Checked && !radioButton2.Checked){ MessageBox.Show("Zaznacz płeć!"); }

                        if (checkBox1.Checked) { 
                            kategorie += checkBox1.Text; 
                            if (checkBox2.Checked || checkBox3.Checked || checkBox4.Checked) { kategorie += ", "; }
                        }
                        if (checkBox2.Checked){
                            kategorie += checkBox2.Text;
                            if (checkBox3.Checked || checkBox4.Checked) { kategorie += ", "; }
                        }
                        if (checkBox3.Checked){
                            kategorie += checkBox3.Text;
                            if (checkBox4.Checked) { kategorie += ", "; }
                        }
                        if (checkBox4.Checked){
                            kategorie += checkBox4.Text;
                        }

                        SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
                        database.Open();

                        using (SQLiteConnection conn = new SQLiteConnection(database))
                        {
                            SQLiteCommand cmd = new SQLiteCommand(conn);

                            try
                            {
                                cmd.CommandTimeout = 1;
                                cmd.CommandText = "INSERT INTO uzytkownicy(uzytkownik_id, imie, nazwisko, telefon, plec, kategorie) VALUES(@id, @imie, @nazwisko, @telefon, @plec, @kategorie)";
                                cmd.Parameters.AddWithValue("@id", null);
                                cmd.Parameters.AddWithValue("@imie", imie);
                                cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
                                cmd.Parameters.AddWithValue("@telefon", telefon);
                                cmd.Parameters.AddWithValue("@plec", plec);
                                cmd.Parameters.AddWithValue("@kategorie", kategorie);
                                cmd.Prepare();
                                cmd.ExecuteNonQuery();
                            }
                            catch(Exception excep)
                            {
                                Console.WriteLine(excep);
                            }
                        }

                        label5.Text = "Dodano użytkownika: " + imie + " " + nazwisko + Environment.NewLine + "tel. " + telefon + Environment.NewLine + plec + Environment.NewLine + kategorie;

                        database.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Wypełnij dane użytkownika aby go dodać!");
            }

            textBox1.Clear();
            textBox2.Clear();
        }
        private void Dodawanie_FormClosed(object sender, FormClosedEventArgs e)
        {
            label5.Text = "";
            f1.odswiez_uzytkownikow();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }








        private void Dodawanie_Load(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
