using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class ListaPozyczek
    {
        public int pozyczka_id { get; set; }
        public int uzytkownik_id { get; set; }
        public int kwota_pozyczona { get; set; }
        public int kwota_do_oddania { get; set; }
        public int procent { get; set; }
        public int splacone { get; set; }
        public int niesplacone { get; set; }
        public string data_pozyczenia { get; set; }
        public string data_do_oddania { get; set; }
        public string data_oddania { get; set; }
        public string status { get; set; }
    }
}
