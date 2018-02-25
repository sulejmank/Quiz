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
    public partial class brisanje : Form
    {
        List<Korisnik> lista = new List<Korisnik>();

        public brisanje()
        {
            InitializeComponent();

            Korisnik kor = new Korisnik();
            lista = kor.izlistaj_korisnike();

            foreach (Korisnik k in lista)
                listBox1.Items.Add(k.Ime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kor = listBox1.SelectedItem.ToString();

            try {

                foreach (Korisnik k in lista)
                    if (k.Ime == kor)
                        k.izbrisi_korisnika();

                listBox1.Items.Remove(kor);
                MessageBox.Show("Uspesno ste izbrisali korisnika", "Uspesno brisanje");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTreci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
