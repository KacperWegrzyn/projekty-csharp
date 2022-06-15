using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Projekt
{
    public class SQLitePolecenia
    {
        
        public List<Uzytkownicy> uzytkownicy { get; set; }
        public void zaladuj_uzytkownikow(int od)
        {
            uzytkownicy = new List<Uzytkownicy>();

            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            string sql = "SELECT * FROM uzytkownicy LIMIT 5 OFFSET " + od;
            SQLiteCommand cmd = new SQLiteCommand(sql, database);

            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    uzytkownicy.Add(new Uzytkownicy{ 
                        uzytkownik_id = dr["uzytkownik_id"].ToString(), 
                        imie = dr["imie"].ToString(), 
                        nazwisko = dr["nazwisko"].ToString() 
                    });
                }
            }
            database.Close();
        }


        public void usun(int id)
        {
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
        }

        public void wyszukaj(string text)
        {
            uzytkownicy = new List<Uzytkownicy>();

            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            string sql = "SELECT * FROM uzytkownicy WHERE uzytkownik_id LIKE '%" + text + "%' OR imie LIKE '%" + text + "%' OR nazwisko LIKE '%" + text + "%'";
            SQLiteCommand cmd = new SQLiteCommand(sql, database);

            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    uzytkownicy.Add(new Uzytkownicy { 
                        uzytkownik_id = dr["uzytkownik_id"].ToString(), 
                        imie = dr["imie"].ToString(), 
                        nazwisko = dr["nazwisko"].ToString() 
                    });
                }
            }
            database.Close();
        }

        public void modyfikuj(int id, string imie, string nazwisko, string telefon, string plec, string kategorie)
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "UPDATE uzytkownicy SET imie=@imie, nazwisko=@nazwisko, telefon=@telefon, plec=@plec, kategorie=@kategorie WHERE uzytkownik_id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@imie", imie);
                    cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@plec", plec);
                    cmd.Parameters.AddWithValue("@kategorie", kategorie);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            database.Close();
        }

        public int id_;
        public string imie_;
        public string nazwisko_;
        public string telefon_;
        public string plec_;
        public string kategorie_;
        public void modyfikacja(int id)
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();
            
            string sql = "SELECT * FROM uzytkownicy WHERE uzytkownik_id=" + id;
            SQLiteCommand cmd = new SQLiteCommand(sql, database);

            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    id_ = Int32.Parse(dr["uzytkownik_id"].ToString());
                    imie_ = dr["imie"].ToString();
                    nazwisko_ = dr["nazwisko"].ToString();
                    telefon_ = dr["telefon"].ToString();
                    plec_ = dr["plec"].ToString();
                    kategorie_ = dr["kategorie"].ToString();
                }
            }
            database.Close();

            Form1 f1 = new Form1();
            f1.modyfikuj(id_, imie_, nazwisko_, telefon_, plec_, kategorie_);
        }


        public void dodaj_uzytkownika(string imie, string nazwisko, string telefon, string plec, string kategorie)
        {
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
                catch (Exception excep)
                {
                    Console.WriteLine(excep);
                }
            }

            database.Close();
        }

        public List<ListaPozyczek> pozyczki { get; set; }
        public void pobierz_pozyczki(int id)
        {
            pozyczki = new List<ListaPozyczek>();

            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            string sql = "SELECT * FROM pozyczki WHERE uzytkownik_id=" + id;
            SQLiteCommand cmd = new SQLiteCommand(sql, database);

            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    pozyczki.Add(new ListaPozyczek { 
                        pozyczka_id = Int32.Parse(dr["pozyczka_id"].ToString()), 
                        uzytkownik_id = Int32.Parse(dr["uzytkownik_id"].ToString()), 
                        kwota_pozyczona = Int32.Parse(dr["kwota_pozyczona"].ToString()), 
                        kwota_do_oddania = Int32.Parse(dr["kwota_do_oddania"].ToString()), 
                        procent = Int32.Parse(dr["procent"].ToString()), 
                        splacone = Int32.Parse(dr["splacone"].ToString()), 
                        niesplacone = Int32.Parse(dr["niesplacone"].ToString()), 
                        data_pozyczenia = dr["data_pozyczenia"].ToString(), 
                        data_do_oddania = dr["data_do_oddania"].ToString(), 
                        data_oddania = dr["data_oddania"].ToString(), 
                        status = dr["status"].ToString() 
                    });
                }
            }
            database.Close();
        }


        public void dodaj_pozyczke(int id, float kwota_pozyczona, float procent, string termin_splaty)
        {
            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);

                cmd.CommandText = "INSERT INTO pozyczki VALUES(@pozyczka_id, @uzytkownik_id, @kwota_pozyczona, @kwota_do_oddania, @procent, @splacone, @niesplacone, @data_pozyczenia, @termin_splaty, @data_splacenia, @status)";
                cmd.Parameters.AddWithValue("@pozyczka_id", null);
                cmd.Parameters.AddWithValue("@uzytkownik_id", id);
                cmd.Parameters.AddWithValue("@kwota_pozyczona", kwota_pozyczona);
                cmd.Parameters.AddWithValue("@kwota_do_oddania", Math.Round(kwota_pozyczona + kwota_pozyczona * (procent / 100), 2));
                cmd.Parameters.AddWithValue("@procent", procent);
                cmd.Parameters.AddWithValue("@splacone", 0);
                cmd.Parameters.AddWithValue("@niesplacone", Math.Round(kwota_pozyczona + kwota_pozyczona * (procent / 100), 2));
                cmd.Parameters.AddWithValue("@data_pozyczenia", DateTime.Now.ToString("dd.mm.yyyy"));
                cmd.Parameters.AddWithValue("@termin_splaty", termin_splaty);
                cmd.Parameters.AddWithValue("@data_splacenia", null);
                cmd.Parameters.AddWithValue("@status", "niesplacone");
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }

            database.Close();
        }

        public List<ListaSplat> splaty { get; set; }
        public void pobierz_splaty(int pozyczka_id)
        {
            splaty = new List<ListaSplat>();

            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            string sql = "SELECT * FROM splaty WHERE pozyczka_id=" + pozyczka_id;
            SQLiteCommand cmd = new SQLiteCommand(sql, database);

            using (SQLiteDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    splaty.Add(new ListaSplat
                    {
                        kwota_splacona = float.Parse(dr["kwota_splacona"].ToString()),
                        data_splaty = dr["data_splaty"].ToString()
                    });
                }
            }

            database.Close();
        }


        public void dodaj_splate(int pozyczka_id, string status, float kwota)
        {
            Form1 f1 = new Form1();
            Pozyczki p1 = new Pozyczki(f1);
            Splaty sp = new Splaty(p1);

            SQLiteConnection database = new SQLiteConnection("Data Source=database.db");
            database.Open();

            using (SQLiteConnection conn = new SQLiteConnection(database))
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "SELECT status FROM pozyczki WHERE pozyczka_id=" + pozyczka_id;
                SQLiteDataReader dr;
                dr = cmd.ExecuteReader();
                dr.Read();

                status = dr["status"].ToString();
                dr.Close();

                if (status == "niesplacone")
                {
                    if (kwota != 0)
                    {
                        cmd.CommandText = "INSERT INTO splaty VALUES(@splata_id, @pozyczka_id, @kwota_splacona, @data_splaty)";
                        cmd.Parameters.AddWithValue("@splata_id", null);
                        cmd.Parameters.AddWithValue("@pozyczka_id", pozyczka_id);
                        cmd.Parameters.AddWithValue("@kwota_splacona", kwota);
                        cmd.Parameters.AddWithValue("@data_splaty", DateTime.Now.ToString("dd.mm.yyyy"));
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT splacone, niesplacone FROM pozyczki WHERE pozyczka_id=" + pozyczka_id;
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        string splacone = dr["splacone"].ToString();
                        string niesplacone = dr["niesplacone"].ToString();

                        dr.Close();

                        cmd.CommandText = "UPDATE pozyczki SET splacone=@splacone, niesplacone=@niesplacone WHERE pozyczka_id =" + pozyczka_id;
                        cmd.Parameters.AddWithValue("@splacone", float.Parse(splacone) + kwota);
                        cmd.Parameters.AddWithValue("@niesplacone", float.Parse(niesplacone) - kwota);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT splacone, niesplacone FROM pozyczki WHERE pozyczka_id=" + pozyczka_id;
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        niesplacone = dr["niesplacone"].ToString();

                        dr.Close();

                        if (float.Parse(niesplacone) <= 0)
                        {
                            cmd.CommandText = "UPDATE pozyczki SET status='splacone' WHERE pozyczka_id =" + pozyczka_id;
                            cmd.ExecuteNonQuery();

                            sp.komunikat("Spłacono pożyczkę!");

                            float nadplata = float.Parse(niesplacone) * -1;
                            if (nadplata > 0)
                            {
                                sp.komunikat("Nadpłata: " + nadplata + " zł");
                            }
                        }

                        sp.odswiez_splaty();
                        p1.odswiez_pozyczki();
                    }
                    else
                    {
                        sp.komunikat("Uzupełnij dane!");
                    }
                }
                else
                {
                    sp.komunikat("Ta pożyczka jest już spłacona!");
                }
            }

            database.Close();
        }
    }
}
