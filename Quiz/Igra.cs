using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz
{
    public class Igra
    {
        public string rec { get; set; }

        private OleDbConnection connection = new OleDbConnection();


        public Igra()
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
        public List<Igra> pokupi_reci()
        {
            List<Igra> lista = new List<Igra>();
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "select * from Igra;";

                OleDbDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Igra rec = new Igra();

                   rec.rec = reader["rec"].ToString();                
                    lista.Add(rec);

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
