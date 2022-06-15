using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace formularz
{
    public partial class Form1 : Form
    {
        string text;
        int ID = 0;

        public Form1()
        {
            InitializeComponent();
            listView1.Items.Clear();
            using (StreamWriter sw = File.CreateText(@"c:\tmp\Lista osób.txt"))
            {
                sw.WriteLine("");
            }
        }

        //zapisz
        private void button1_Click(object sender, EventArgs e)
        {
            //zapisywanie do listView
            string plec = "";
            if (radioButton1.Checked)
                plec = radioButton1.Text;
            else
                plec = radioButton2.Text;

            string z = "";
            if (checkBox1.Checked)
            {
                z += checkBox1.Text;
                if (checkBox2.Checked || checkBox3.Checked)
                    z += ", ";
            }

            if (checkBox2.Checked)
            {
                z += checkBox2.Text;
                if (checkBox3.Checked)
                    z += ", ";
            }

            if (checkBox3.Checked)
            {
                z += checkBox3.Text;
            }

            ListViewItem item = new ListViewItem(ID.ToString());


            if(!Regex.Match(textBox1.Text, @"^[A-Z][a-z]*$").Success || !Regex.Match(textBox2.Text, @"^[A-Z][a-z]*$").Success || !Regex.Match(textBox3.Text, @"^[0-9]\d{8}$").Success)
            {
                if (!Regex.Match(textBox1.Text, @"^[A-Z][a-z]*$").Success)
                    MessageBox.Show("Nieprawidłowe imię");

                if (!Regex.Match(textBox2.Text, @"^[A-Z][a-z]*$").Success)
                    MessageBox.Show("Nieprawidłowe nazwisko");

                if (!Regex.Match(textBox3.Text, @"^[0-9]\d{8}$").Success)
                    MessageBox.Show("Nieprawidłowy numer telefonu");
            }
            else
            {
                item.SubItems.Add(textBox1.Text);
                item.SubItems.Add(textBox2.Text);
                item.SubItems.Add(textBox3.Text);
                item.SubItems.Add(plec);
                item.SubItems.Add(z);
                item.SubItems.Add(richTextBox1.Text);
                listView1.Items.Add(item);

                ID++;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                richTextBox1.Clear();
            }

            //zapisywanie do pliku
            text += ID + ";" + textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";" + plec + ";" + z + ";" + richTextBox1.Text + ";\n";

            using (StreamWriter sw = File.CreateText(@"c:\tmp\Lista osób.txt"))
            {
                sw.WriteLine(text);
            }

        }

        private void lineChanger(string nowaOsoba, string plik, int linia)
        {
            string[] lista = File.ReadAllLines(plik);
            lista[linia] = nowaOsoba;
            File.WriteAllLines(plik, lista);
        }

        //usun
        private void button2_Click(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0].Text;  
            listView1.Items.RemoveAt(Int32.Parse(item));

            lineChanger(string.Empty, @"c:\tmp\Lista osób.txt", Int32.Parse(item));
        }

        public static string Id;
        public static string Imie;
        public static string Nazwisko;
        public static string Numer;
        public static string Plec;
        public static string Zainteresowania;
        public static string Opis;

        //modyfikuj
        private void button3_Click(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0];
            Id = item.SubItems[0].Text;
            Imie = item.SubItems[1].Text;
            Nazwisko = item.SubItems[2].Text;
            Numer = item.SubItems[3].Text;
            Plec = item.SubItems[4].Text;
            Zainteresowania = item.SubItems[5].Text;
            Opis = item.SubItems[6].Text;

            Form2 f2 = new Form2();
            f2.ShowDialog();

            listView1.Items.RemoveAt(Int32.Parse(Id));

            ListViewItem osoba = new ListViewItem(Id);
            osoba.SubItems.Add(Form2.Imie);
            osoba.SubItems.Add(Form2.Nazwisko);
            osoba.SubItems.Add(Form2.Numer);
            osoba.SubItems.Add(Form2.Plec);
            osoba.SubItems.Add(Form2.Zainteresowania);
            osoba.SubItems.Add(Form2.Opis);
            listView1.Items.Add(osoba);

            lineChanger(Form2.nowaOsoba, @"c:\tmp\Lista osób.txt", Int32.Parse(item.Text));
        }

        //wyczysc
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using (StreamWriter sw = File.CreateText(@"c:\tmp\Lista osób.txt"))
            {
                sw.WriteLine("");
            }
        }

        //wyszukaj
        private void textBox4_TextChanged(object sender, EventArgs e)
        { 
            for (int i=0; i<listView1.Items.Count; i++)
            {
                var Item = listView1.Items[i];
                var wpisane = textBox4.Text.ToLower();
                if (Item.SubItems[1].Text.ToLower().Contains(wpisane) ||
                    Item.SubItems[2].Text.ToLower().Contains(wpisane) ||
                    Item.SubItems[3].Text.ToLower().Contains(wpisane) ||
                    Item.SubItems[4].Text.ToLower().Contains(wpisane) ||
                    Item.SubItems[5].Text.ToLower().Contains(wpisane) ||
                    Item.SubItems[6].Text.ToLower().Contains(wpisane))
                {
                    Item.BackColor = Color.Yellow;
                }
                else
                {
                    Item.BackColor = Color.White;
                }

                if(wpisane == "" || String.IsNullOrEmpty(wpisane)) 
                {
                    Item.BackColor = Color.White;
                }
            }
        }

        public string zaznaczone;

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaznaczone = "zapisz";
            zapiszToolStripMenuItem.Checked = true;
            modyfikujToolStripMenuItem.Checked = false;
            usuńPojedynczyToolStripMenuItem.Checked = false;
            usuńWszystkoToolStripMenuItem.Checked = false;
        }

        private void modyfikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaznaczone = "modyfikuj";
            zapiszToolStripMenuItem.Checked = false;
            modyfikujToolStripMenuItem.Checked = true;
            usuńPojedynczyToolStripMenuItem.Checked = false;
            usuńWszystkoToolStripMenuItem.Checked = false;
        }

        private void usuńPojedynczyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaznaczone = "usunPojedynczy";
            zapiszToolStripMenuItem.Checked = false;
            modyfikujToolStripMenuItem.Checked = false;
            usuńPojedynczyToolStripMenuItem.Checked = true;
            usuńWszystkoToolStripMenuItem.Checked = false;
        }

        private void usuńWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zaznaczone = "usunWszystko";
            zapiszToolStripMenuItem.Checked = false;
            modyfikujToolStripMenuItem.Checked = false;
            usuńPojedynczyToolStripMenuItem.Checked = false;
            usuńWszystkoToolStripMenuItem.Checked = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(zaznaczone == "zapisz")
            {
                button1.PerformClick();
            }

            if (zaznaczone == "modyfikuj")
            {
                button3.PerformClick();
            }

            if (zaznaczone == "usunPojedynczy")
            {
                button2.PerformClick();
            }

            if (zaznaczone == "usunWszystko")
            {
                button4.PerformClick();
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
