using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public class Korisnik
    {
        public string korisnicko_ime { get; set; }
        public string lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Uloga { get; set; }
        public int id { get; set; }
        public int poeni1 { get; set; }
        public int poeni2 { get; set; }
        public int poeni3 { get; set; }
        public int poeni4 { get; set; }



        private OleDbConnection connection = new OleDbConnection();


        public Korisnik()
        {
            try
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=KvizDB.accdb; Persist Security Info=False;";
                connection.Open();
                connection.Close();

            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.ToString());

                if (connection != null)
                    connection.Close();

            }

        }
         
        public void proveri_korisnika()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;
                comm.CommandText = "select * from Nalog where Username='" + korisnicko_ime + "' and Lozinka='" + lozinka + "';";

                OleDbDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Ime = reader["Ime"].ToString();
                    Uloga = reader["Uloga"].ToString();
                    poeni1 = Int32.Parse(reader["Poeni1"].ToString());
                    poeni2 = Int32.Parse(reader["Poeni2"].ToString());
                    poeni3 = Int32.Parse(reader["Poeni3"].ToString());
                    poeni4 = Int32.Parse(reader["Poeni4"].ToString());
                    id = Int32.Parse(reader["ID"].ToString());

                }

                connection.Close();

            }
            catch (Exception ex)
            {
                if (ex is SystemException             ||
                    ex is OleDbException              ||
                    ex is NotSupportedException       ||
                    ex is UnauthorizedAccessException ||
                    ex is FormatException             ||
                    ex is IndexOutOfRangeException    ||
                    ex is InsufficientMemoryException ||
                    ex is EntryPointNotFoundException ||
                    ex is EntryPointNotFoundException ||
                    ex is InvalidCastException        ||
                    ex is InvalidProgramException)
                    MessageBox.Show(ex.Message, "aGreska");
                else
                    MessageBox.Show(ex.Message, "Greska");
            }

        }

        public void dodaj_korisnika()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();

                comm.Connection = connection;
                comm.CommandText = "insert into Nalog(Ime,Username,Lozinka,Uloga) values('" + Ime +
                                                                                      "','" + korisnicko_ime + "','"
                                                                                            + lozinka +
                                                                                       "','"+ Uloga + "');";
                comm.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                if (ex is SystemException             ||
                    ex is OleDbException              ||
                    ex is NotSupportedException       ||
                    ex is UnauthorizedAccessException ||
                    ex is FormatException             ||
                    ex is IndexOutOfRangeException    ||
                    ex is InsufficientMemoryException ||
                    ex is EntryPointNotFoundException ||
                    ex is EntryPointNotFoundException ||
                    ex is InvalidCastException        ||
                    ex is InvalidProgramException)
                    MessageBox.Show(ex.Message, "Greska");
                else
                    MessageBox.Show(ex.Message, "Greska");
            }

        }


        public List<Korisnik> izlistaj_korisnike()
        {
            List<Korisnik> lista = new List<Korisnik>();
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "select * from Nalog;";

                OleDbDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Korisnik kor = new Korisnik();

                    kor.korisnicko_ime = reader["Username"].ToString();
                    kor.Ime = reader["Ime"].ToString();
                    kor.Uloga = reader["Uloga"].ToString();
                    kor.id = Int32.Parse(reader["ID"].ToString());
                    kor.poeni1 = Int32.Parse(reader["Poeni1"].ToString());
                    kor.poeni2 = Int32.Parse(reader["Poeni2"].ToString());
                    kor.poeni3 = Int32.Parse(reader["Poeni3"].ToString());
                    kor.poeni4 = Int32.Parse(reader["Poeni4"].ToString());

                    lista.Add(kor);

                }

                connection.Close();

            }
            catch (Exception ex)
            {
                if (ex is SystemException             ||
                    ex is OleDbException              ||
                    ex is NotSupportedException       ||
                    ex is UnauthorizedAccessException ||
                    ex is FormatException             ||
                    ex is IndexOutOfRangeException    ||
                    ex is InsufficientMemoryException ||
                    ex is EntryPointNotFoundException ||
                    ex is EntryPointNotFoundException ||
                    ex is InvalidCastException        ||
                    ex is InvalidProgramException)
                    MessageBox.Show(ex.Message, "Greska");
                else
                    MessageBox.Show(ex.Message, "Greska");
            }

            return lista;

        }

        public void izmeni_korisnika()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "update Nalog set korisnicko_ime='" + korisnicko_ime + "',sifra='" + lozinka + "',ime='" + Ime + "',prezime='" + Prezime + "',uloga='" + Uloga + "' where id=" + id + ";";
                comm.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                if (ex is SystemException             ||
                    ex is OleDbException              ||
                    ex is NotSupportedException       ||
                    ex is UnauthorizedAccessException ||
                    ex is FormatException             ||
                    ex is IndexOutOfRangeException    ||
                    ex is InsufficientMemoryException ||
                    ex is EntryPointNotFoundException ||
                    ex is EntryPointNotFoundException ||
                    ex is InvalidCastException        ||
                    ex is InvalidProgramException)
                    MessageBox.Show(ex.Message, "Greska");
                else
                    MessageBox.Show(ex.Message, "Greska");
            }

        }

        public void izmeni_poene_korisnika()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "update Nalog set Poeni1=" + poeni1 + ",Poeni2=" + poeni2 + ",Poeni3=" + poeni3 + ",Poeni4=" + poeni4 + " where id=" + id + ";";
                comm.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                if (ex is SystemException ||
                    ex is OleDbException ||
                    ex is NotSupportedException ||
                    ex is UnauthorizedAccessException ||
                    ex is FormatException ||
                    ex is IndexOutOfRangeException ||
                    ex is InsufficientMemoryException ||
                    ex is EntryPointNotFoundException ||
                    ex is EntryPointNotFoundException ||
                    ex is InvalidCastException ||
                    ex is InvalidProgramException)
                    MessageBox.Show(ex.Message, "Greska");
                else
                    MessageBox.Show(ex.Message, "Greska");
            }

        }
        public void izbrisi_korisnika()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "delete from Nalog where ID="+ id+";";
                comm.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                if (ex is SystemException             ||
                    ex is OleDbException              ||
                    ex is NotSupportedException       ||
                    ex is UnauthorizedAccessException ||
                    ex is FormatException             ||
                    ex is IndexOutOfRangeException    ||
                    ex is InsufficientMemoryException ||
                    ex is EntryPointNotFoundException ||
                    ex is EntryPointNotFoundException ||
                    ex is InvalidCastException        ||
                    ex is InvalidProgramException)
                    MessageBox.Show(ex.Message, "Greska");
                else
                    MessageBox.Show(ex.Message, "Greska");
            }

        }


    }
}
