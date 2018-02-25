using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz
{
    public class Asocijacije
    {
        public string rec1 { get; set; }
        public string rec2 { get; set; }
        public string rec3 { get; set; }
        public string rec4 { get; set; }
        public string rec5 { get; set; }
        public string rec6 { get; set; }


        public string resenje { get; set; }

        //public List<Asocijacije> list { get; set; }

        private OleDbConnection connection = new OleDbConnection();


        public Asocijacije()
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

        public List<Asocijacije> pokupi_asocijacije()
        {
            List<Asocijacije> lista = new List<Asocijacije>();
            
            try
            {
                connection.Open();
                OleDbCommand comm = new OleDbCommand();
                comm.Connection = connection;

                comm.CommandText = "select * from Asoc;";

                OleDbDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Asocijacije kor = new Asocijacije();

                    kor.rec1 = reader["Asoc1"].ToString();
                    kor.rec2 = reader["Asoc2"].ToString();
                    kor.rec3 = reader["Asoc3"].ToString();
                    kor.rec4 = reader["Asoc4"].ToString();
                    kor.rec5 = reader["Asoc5"].ToString();
                    kor.rec6 = reader["Asoc6"].ToString();
                    kor.resenje = reader["Resenje"].ToString();

                    lista.Add(kor);

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
                    MessageBox.Show(ex.Message, "Areska");
                else
                    MessageBox.Show(ex.Message, "DGreska");
            }
            return lista;
        }

    }
}
