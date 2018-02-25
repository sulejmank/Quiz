using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public class Kviz
    {
        public int poeni = 0;
        public int brPitanja = 1;
        public List<Pitanje> lista = new List<Pitanje>();


        private OleDbConnection connection = new OleDbConnection();


        public Kviz()
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

        public List<Pitanje> pokupi_pitanja()
        {
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;
                comm.CommandText = "select * from Kviz;";

                OleDbDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Pitanje pit = new Pitanje();

                    pit.text_pitanja = reader["Pitanje"].ToString();
                    pit.odgA = reader["A"].ToString();
                    pit.odgB = reader["B"].ToString();
                    pit.odgC = reader["C"].ToString();
                    pit.odgD = reader["D"].ToString();
                    pit.tacan = reader["Tacan"].ToString();

                    lista.Add(pit);

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

            return lista;

        }


    }
}
