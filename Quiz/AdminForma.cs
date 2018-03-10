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
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Quiz
{
    public partial class AdminForma : Form
    {
        public Korisnik korisnik { get; set; }
        List<Korisnik> lista = new List<Korisnik>();
        int kviz;
        int asoc;
        int igre;
        int moj;
        
        public AdminForma()
        {
            InitializeComponent();

            Brojac br = new Brojac();
            br.pokupi();
            kviz = br.Kviz;
            asoc = br.Asoc;
            igre = br.Igre;
            moj = br.MojBroj;

            
            grafovi(kviz,asoc,moj,igre);
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            brisanje bris = new brisanje();
            bris.ShowDialog();
        }

        private void grafovi(int k, int aso, int moj, int i)
        {

            solidGauge2.From = 0;
            solidGauge2.To = 100;
            solidGauge2.Value = i;
            solidGauge2.Base.LabelsVisibility = Visibility.Hidden;
            solidGauge2.Base.GaugeActiveFill = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.Yellow, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Red, 1)
                }
            };
            solidGauge1.Uses360Mode = true;
            solidGauge1.From = 0;
            solidGauge1.To = 100;
            solidGauge1.Value = moj;
            solidGauge1.HighFontSize = 60;
            solidGauge1.Base.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(66, 66, 66));
            solidGauge1.FromColor = Colors.White;
            solidGauge1.ToColor = Colors.Black;
            solidGauge1.InnerRadius = 0;

            angularGauge2.Value = k;
            angularGauge2.FromValue = 0;
            angularGauge2.ToValue = 250;
            angularGauge2.TicksForeground = System.Windows.Media.Brushes.White;
            angularGauge2.Base.Foreground = System.Windows.Media.Brushes.White;
            angularGauge2.Base.FontWeight = FontWeights.Bold;
            angularGauge2.Base.FontSize = 16;
            angularGauge2.SectionsInnerRadius = 0.5;

            angularGauge2.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 200,
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(247, 166, 37))
            });
            angularGauge2.Sections.Add(new AngularSection
            {
                FromValue = 200,

                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
            });

            solidGauge3.Uses360Mode = true;
            solidGauge3.From = 0;
            solidGauge3.To = 100;
            solidGauge3.Value = aso;
            solidGauge3.HighFontSize = 60;
            solidGauge3.Base.Foreground = System.Windows.Media.Brushes.White;
            solidGauge2.Base.Foreground = System.Windows.Media.Brushes.White;
            solidGauge1.Base.Foreground = System.Windows.Media.Brushes.White;




            solidGauge3.InnerRadius = 0;
            solidGauge3.GaugeBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 128, 181));


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

            cartesianChart1.LegendLocation = LegendLocation.Bottom;
            cartesianChart1.BackColor = System.Drawing.Color.FromArgb(23, 71, 90);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        public void pita()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            int brKor = 0;
            int brAdmin = 0;

            foreach (Korisnik k in lista)
                if (k.Uloga == "Korisnik")
                    brKor++;
                else if(k.Uloga == "Admin")
                    brAdmin++;


            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Korisnici",
                    Values = new ChartValues<double> {brKor},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Administratori",
                    Values = new ChartValues<double> {brAdmin},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }            
            };

            pieChart1.LegendLocation = LegendLocation.Bottom;
            pieChart1.ForeColor = System.Drawing.Color.WhiteSmoke;
            pieChart1.BackColor = System.Drawing.Color.FromArgb(23, 71, 90);
        }
        private void AdminForma_Load(object sender, EventArgs e)
        {
            Korisnik kro = new Korisnik();
            lista = kro.izlistaj_korisnike();
            ucitaj_graf();
            pita();
            labelAdmin.Text = korisnik.Ime;
            foreach (Korisnik k in lista)
                dataGridView1.Rows.Add(k.korisnicko_ime, k.poeni1, k.poeni2, k.poeni3, k.poeni4);

            dataGridView1.Sort(Korisnik, ListSortDirection.Descending);
        }
        /// <summary>
        /// game counter for each game with gauge to show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void buttonTreci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            KorisnikForma form = new KorisnikForma();
            form.korisnik = korisnik;
            form.WindowState = FormWindowState.Maximized;
            form.ShowDialog();
            grafovi(kviz, moj, asoc, igre);

            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void solidGauge1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dodajAdmina dod = new dodajAdmina();
            dod.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }
    }
}
