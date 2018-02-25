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
using System.Windows.Forms.DataVisualization.Charting;

namespace Quiz
{
    public partial class MojRekord : Form
    {
        public Korisnik korisnik { get; set; }

        public MojRekord()
        {
            InitializeComponent();
        }

        public void ucitaj_graf()
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {

                new LineSeries
                {
                    Title = "Broj poena",
                    Values = new ChartValues<int> {korisnik.poeni1,korisnik.poeni2,korisnik.poeni3,korisnik.poeni4},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 15
                }
            };

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

            cartesianChart1.LegendLocation = LegendLocation.Bottom;

        }

        private void MojRekord_Load(object sender, EventArgs e)
        {
            ucitaj_graf();
            textBox1.Text = korisnik.poeni1.ToString();
            textBox2.Text = korisnik.poeni2.ToString();
            textBox3.Text = korisnik.poeni3.ToString();
            textBox4.Text = korisnik.poeni4.ToString();

        }

        private void buttonTreci_Click(object sender, EventArgs e)
        {
            this.Close();
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
