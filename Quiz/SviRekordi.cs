using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class SviRekordi : Form
    {
        List<Korisnik> lista = new List<Quiz.Korisnik>();

        public SviRekordi()
        {
            InitializeComponent();
        }

        private void SviRekordi_Load(object sender, EventArgs e)
        {
            Korisnik kor = new Korisnik();
            lista = kor.izlistaj_korisnike();

            ucitaj_graf();          
        }

        private void buttonTreci_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void ucitaj_graf()
        {

            cartesianChart1.Series = new LiveCharts.SeriesCollection { };


                 foreach (Korisnik k in lista)
                 {

                    cartesianChart1.Series.Add(
                    new LineSeries
                    {
                        Title = k.Ime,
                        Values = new ChartValues<int> { k.poeni1, k.poeni2, k.poeni3, k.poeni4 },
                        PointGeometry = DefaultGeometries.Square,
                        PointGeometrySize = 15
                    });

                 }
            

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Igra",
                Labels = new[] { "Kviz", "Moj Broj", "Asocijacije", "Igre vesala" }
            });

            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Poeni",
                LabelFormatter = value => value.ToString()
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
