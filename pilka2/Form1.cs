using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace pilka2
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();

        bool wPrawo = false;
        bool wLewo = false;

        int krok = 10;
        int krokX;
        int krokY;
        int predkosc;
        int pkt = 0;
        bool start = false;
        int iloscBlokow = 0;

        
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            predkosc = -1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            predkosc = 0;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            predkosc = 1;
        }

        // zatwierdz
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            label1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            button1.Enabled = false;

            panel1.Visible = false;
            label1.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            button1.Visible = false;

            pilka1.Visible = true;
            pilka2.Visible = true;
            pilka3.Visible = true;
            pilka4.Visible = true;

            panel2.Enabled = false;
            label2.Enabled = false;
            button2.Enabled = false;

            panel2.Visible = false;
            label2.Visible = false;
            button2.Visible = false;

            panel3.Enabled = false;
            label3.Enabled = false;
            button3.Enabled = false;

            panel3.Visible = false;
            label3.Visible = false;
            button3.Enabled = false;

            start = true;
            pilka.Left = this.Width / 2 - pilka.Width / 2;
            pilka.Top = 400;

            krokX = rnd.Next(2, 8);
            krokY = 10 - krokX;

            utworzBloki();
        }

        public Form1()
        {
            InitializeComponent();
            krokX = rnd.Next(2, 8);
            krokY = 10 - krokX;
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && rakietka.Left > 0)
            {
                wLewo = true;
            }

            if (e.KeyCode == Keys.Right && rakietka.Left < this.Width - rakietka.Width)
            {
                wPrawo = true;
            }
        }
        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                wLewo = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                wPrawo = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (start)
            {
                // sterowanie rakietka
                if (rakietka.Left <= 2)
                {
                    wLewo = false;
                }
                if (rakietka.Left + 2 >= this.Width - rakietka.Width)
                {
                    wPrawo = false;
                }
                if (wLewo == true)
                {
                    rakietka.Left -= krok;
                }
                if (wPrawo == true)
                {
                    rakietka.Left += krok;
                }

                
                // odbijanie pilki od scian
                if (pilka.Left + 3 >= this.Width - pilka.Width)
                {
                    pilka.Left -= 5;
                    krokX *= -1;
                }
                if (pilka.Left <= 3)
                {
                    krokX *= -1;
                    pilka.Left += 5;
                }
                if (pilka.Top <= 30)
                {
                    pilka.Top += 1;
                    krokY *= -1;
                }

                // odbijanie od rakietki
                if(pilka.Top + pilka.Height > rakietka.Top - 10 && pilka.Top + pilka.Height < rakietka.Top && pilka.Left + pilka.Width >= rakietka.Left && pilka.Left <= rakietka.Left + rakietka.Width)
                {
                    krokY *= -1;
                    SoundPlayer dzwiek = new SoundPlayer(@"c:\Windows\Media\dzwiek1.wav");
                    dzwiek.Play();
                }
                if(pilka.Top + pilka.Height >= rakietka.Top)
                {
                    if(pilka.Left + pilka.Width > rakietka.Left - 10 && pilka.Left + pilka.Width < rakietka.Left || pilka.Left < rakietka.Left + rakietka.Width + 10 && pilka.Left > rakietka.Left + rakietka.Width)
                    {
                        krokX *= -1;
                    }
                }

                

                // tracenie zycia
                if (pilka.Top >= this.Height - pilka.Height - 35)
                {
                    krokX = 0;
                    krokY = 0;

                    Thread.Sleep(1000);

                    pilka.Left = 400;
                    pilka.Top = 400;

                    krokX = rnd.Next(2, 8);
                    krokY = 10 - krokX;

                    if (pilka4.Visible == false)
                    {
                        if (pilka3.Visible == false)
                        {
                            if (pilka2.Visible == false)
                            {
                                pilka1.Visible = false;
                            }
                            else
                            {
                                pilka2.Visible = false;
                            }
                        }
                        else
                        {
                            pilka3.Visible = false;
                        }
                    }
                    else
                    {
                        pilka4.Visible = false;
                    }
                }


                // kolizja z blokiem
                foreach (Control blok in panel0.Controls)
                {
                    if (blok is Panel && blok.Tag == "blok")
                    {
                        if(pilka.Left + pilka.Width >= blok.Left && pilka.Left <= blok.Left + blok.Width)
                        {
                            //od dolu
                            if (pilka.Top < blok.Top + blok.Height + 10 && pilka.Top > blok.Top + blok.Height)
                            {
                                krokY *= -1;
                                blok.Dispose();
                                pkt++;
                                iloscBlokow--;
                                punkty.Text = "Punkty: " + pkt;
                            }

                            //od gory
                            if(pilka.Top + pilka.Height > blok.Top - 10 && pilka.Top + pilka.Height < blok.Top)
                            {
                                krokY *= -1;
                                blok.Dispose();
                                pkt++;
                                iloscBlokow--;
                                punkty.Text = "Punkty: " + pkt;
                            }
                        }

                        if(pilka.Top + pilka.Height >= blok.Top && pilka.Top <= blok.Top + blok.Height)
                        {
                            //od lewej
                            if(pilka.Left + pilka.Width > blok.Left - 10 && pilka.Left + pilka.Width < blok.Left)
                            {
                                krokX *= -1;
                                blok.Dispose();
                                pkt++;
                                iloscBlokow--;
                                punkty.Text = "Punkty: " + pkt;
                            }

                            //od prawej
                            if(pilka.Left < blok.Left + blok.Width + 10 && pilka.Left > blok.Left + blok.Width)
                            {
                                krokX *= -1;
                                blok.Dispose();
                                pkt++;
                                iloscBlokow--;
                                punkty.Text = "Punkty: " + pkt;
                            }
                        }
                    }
                }
                
                // sterowanie pilka
                if (krokX > 0)
                {
                    pilka.Left += krokX + predkosc;
                }
                else
                {
                    pilka.Left += krokX - predkosc;
                }
                if (krokY > 0)
                {
                    pilka.Top -= krokY + predkosc;
                }
                else
                {
                    pilka.Top -= krokY - predkosc;
                }
                
                // przegrywanie
                if (pilka.Top >= this.Height - pilka.Height - 35 && pilka1.Visible == false)
                {
                    panel2.Enabled = true;
                    label2.Enabled = true;
                    button2.Enabled = true;

                    panel2.Visible = true;
                    label2.Visible = true;
                    button2.Visible = true;

                    start = false;
                }

                // wygrywanie
                if (iloscBlokow <= 0) {
                    panel3.Enabled = true;
                    label3.Enabled = true;
                    button3.Enabled = true;

                    panel3.Visible = true;
                    label3.Visible = true;
                    button3.Visible = true;
                    
                    krokX = 0;
                    krokY = 0;

                    pilka.Left = this.Width / 2 - pilka.Width / 2;
                    pilka.Top = 400;
                }
                
                if (Cursor.Position.Y <= 290)
                {
                    menuStrip1.Enabled = true;
                    button4.Enabled = true;
                }
                else
                {
                    menuStrip1.Enabled = false;
                    button4.Enabled = false;
                }
            }
        }

        
        //sprobuj ponownie
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            label1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            button1.Enabled = true;

            panel1.Visible = true;
            label1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            button1.Visible = true;

            panel2.Enabled = false;
            label2.Enabled = false;
            button2.Enabled = false;

            panel2.Visible = false;
            label2.Visible = false;
            button2.Visible = false;

            rakietka.Left = 350;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            label1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            button1.Enabled = true;

            panel1.Visible = true;
            label1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            button1.Visible = true;

            panel3.Enabled = false;
            label3.Enabled = false;
            button3.Enabled = false;

            panel3.Visible = false;
            label3.Visible = false;
            button3.Visible = false;

            rakietka.Left = 350;
        }

        // restart
        private void button4_Click(object sender, EventArgs e)
        {
            pilka1.Visible = true;
            pilka2.Visible = true;
            pilka3.Visible = true;
            pilka4.Visible = true;

            panel2.Enabled = false;
            label2.Enabled = false;
            button2.Enabled = false;

            panel2.Visible = false;
            label2.Visible = false;
            button2.Visible = false;

            panel3.Enabled = false;
            label3.Enabled = false;
            button3.Enabled = false;

            panel3.Visible = false;
            label3.Visible = false;
            button3.Enabled = false;

            Thread.Sleep(1000);

            start = true;
            rakietka.BackColor = Color.White;
            pilka.Left = this.Width / 2 - pilka.Width / 2;
            pilka.Top = 400;

            krokX = rnd.Next(2, 8);
            krokY = 10 - krokX;

            utworzBloki();
        }

        private void bialyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rakietka.BackColor = Color.White;
            bialyToolStripMenuItem.Checked = true;
            czerwonyToolStripMenuItem.Checked = false;
            niebieskiToolStripMenuItem.Checked = false;
        }
        private void czerwonyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rakietka.BackColor = Color.Red;
            czerwonyToolStripMenuItem.Checked = true;
            bialyToolStripMenuItem.Checked = false;
            niebieskiToolStripMenuItem.Checked = false;
        }
        private void niebieskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rakietka.BackColor = Color.Blue;
            niebieskiToolStripMenuItem.Checked = true;
            bialyToolStripMenuItem.Checked = false;
            czerwonyToolStripMenuItem.Checked = false;
        }
      

        private void pictureBox49_Click(object sender, EventArgs e)
        {

        }
        private void kolorRakietkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
