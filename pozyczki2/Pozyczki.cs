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
    public partial class Pozyczki : Form
    {
        Form1 f1;
        public int id;
        public Pozyczki(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            label1.Text = "Pożyczki użytkownika " + f1.imie + " " + f1.nazwisko;
            id = f1.f1_id;
        }

        public void zaladuj_pozyczki()
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using(SQLiteConnection conn = new SQLiteConnection(database))
            {
                string sql = "SELECT * FROM pozyczki WHERE uzytkownik_id =" + id;
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row["pozyczka_id"].ToString());
                    Console.WriteLine(row["uzytkownik_id"].ToString());
                    dataGridView1.Rows.Add(new object[]
                    {
                        row["pozyczka_id"].ToString(),
                        row["uzytkownik_id"].ToString(),
                        row["kwota_pozyczona"].ToString(),
                        row["kwota_do_oddania"].ToString(),
                        row["procent"].ToString(),
                        row["splacone"].ToString(),
                        row["niesplacone"].ToString(),
                        row["data_pozyczenia"].ToString(),
                        row["data_do_oddania"].ToString(),
                        row["data_oddania"].ToString(),
                        row["status"].ToString()
                    });
                }
            }

            database.Close();
        }

        public void zaladuj_pozyczki1()
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            string sql = "SELECT * FROM pozyczki WHERE uzytkownik_id =" + id;
            SQLiteCommand cmd = new SQLiteCommand(sql, database);

            using (SQLiteDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    dataGridView1.Rows.Add(new object[] 
                    {
                        read.GetValue(read.GetOrdinal("pozyczka_id")),
                        read.GetValue(read.GetOrdinal("uzytkownik_id")),
                        read.GetValue(read.GetOrdinal("kwota_pozyczona")),
                        read.GetValue(read.GetOrdinal("kwota_do_oddania")),
                        read.GetValue(read.GetOrdinal("procent")),
                        read.GetValue(read.GetOrdinal("splacone")),
                        read.GetValue(read.GetOrdinal("niesplacone")),
                        read.GetValue(read.GetOrdinal("data_pozyczenia")),
                        read.GetValue(read.GetOrdinal("data_do_oddania")),
                        read.GetValue(read.GetOrdinal("data_oddania")),
                        read.GetValue(read.GetOrdinal("status"))
                    });
                }
            }
            database.Close();
        }

        private void Pozyczki_Load(object sender, EventArgs e)
        {
            zaladuj_pozyczki1();
        }
    }
}
