using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace formularz
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();

            textBox1.Text = Form1.Imie;
            textBox2.Text = Form1.Nazwisko;
            textBox3.Text = Form1.Numer;

            if(Form1.Plec == "mężczyzna")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            if (Form1.Zainteresowania.Contains(checkBox1.Text))
            {
                checkBox1.Checked = true;
            }
            if (Form1.Zainteresowania.Contains(checkBox2.Text))
            {
                checkBox2.Checked = true;
            }
            if (Form1.Zainteresowania.Contains(checkBox3.Text))
            {
                checkBox3.Checked = true;
            }

            richTextBox1.Text = Form1.Opis;
        }

        public static string Imie;
        public static string Nazwisko;
        public static string Numer;
        public static string Plec;
        public static string Zainteresowania;
        public static string Opis;
        public static string nowaOsoba;

        private void button2_Click(object sender, EventArgs e)
        {
            Imie = textBox1.Text;
            Nazwisko = textBox2.Text;
            Numer = textBox3.Text;

            if (radioButton1.Checked)
                Plec = radioButton1.Text;
            else
                Plec = radioButton2.Text;

            Zainteresowania = "";
            if (checkBox1.Checked)
            {
                Zainteresowania += checkBox1.Text;
                if (checkBox2.Checked || checkBox3.Checked)
                    Zainteresowania += ", ";
            }

            if (checkBox2.Checked)
            {
                Zainteresowania += checkBox2.Text;
                if (checkBox3.Checked)
                    Zainteresowania += ", ";
            }

            if (checkBox3.Checked)
            {
                Zainteresowania += checkBox3.Text;
            }

            Opis = richTextBox1.Text;


            var Id = Form1.Id;
            nowaOsoba = Id + ";" + Imie + ";" + Nazwisko + ";" + Numer + ";" + Plec + ";" + Zainteresowania + ";" + Opis + ";\n";
            
            this.Close();
        }
    }
}
