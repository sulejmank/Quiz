using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz
{
    public class Brojac
    {
        public int Kviz { get; set; }
        public int Asoc { get; set; }
        public int MojBroj { get; set; }
        public int Igre { get; set; }


        private OleDbConnection connection = new OleDbConnection();


        public Brojac()
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

        public void promeni()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "update Broj set Kviz=" + Kviz + ",Asoc=" + Asoc + ",MojB=" + MojBroj + ",Igra=" + Igre + " where id=" + 1 + ";";
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

        public void pokupi()
        {
            try
            {
                connection.Open();
                OleDbCommand kom = new OleDbCommand();
                kom.Connection = connection;

                kom.CommandText = "select * from Broj where id=1";

                OleDbDataReader reader = kom.ExecuteReader();

                while (reader.Read())
                {
                    Kviz = (int)reader["Kviz"];
                    Asoc = (int)reader["Asoc"];
                    MojBroj = (int)reader["MojB"];
                    Igre = (int)reader["Igra"];

                }
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
    }


}
