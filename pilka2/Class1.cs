using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace pilka2
{
    class Class1
    {
        private Random rnd = new Random();
        
        int pkt = 0;
        int iloscBlokow = 0;

        private void utworzBloki()
        {
            pkt = 0;
            iloscBlokow = 0;
            int x = 20;
            int y = 40;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    Panel blok = new Panel();
                    blok.Location = new Point(x, y);
                    blok.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    blok.Size = new Size(100, 40);
                    blok.Tag = "blok";
                    myForm.panel0.Controls.Add(blok);
                    x += blok.Width + 20;
                    iloscBlokow++;
                }
                x = 20;
                y += 60;
            }
        }

    }
}
