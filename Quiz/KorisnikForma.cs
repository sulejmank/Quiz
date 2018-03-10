using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class KorisnikForma : Form
    {
        public Korisnik korisnik { get; set; }
        Kviz kviz = new Kviz();
        public int brP = 0;

        Brojac brojac = new Brojac();

     

        public int brKviz { get; set; } 
        public int brMoj { get; set; } 
        public int brAs { get; set; } 
        public int brIgra { get; set; } 

        public int mojBroj;
        public int mojBrojPoeni;

        List<Asocijacije> asList = new List<Asocijacije>();
        Asocijacije a = new Asocijacije();
        public int br;
        public int brAsoc = 0;

        Igra igra = new Igra();
        List<Igra> igraLista = new List<Igra>();
        List<Label> labLista = new List<Label>();
        StringBuilder strb = new StringBuilder();

        int pob = 0;

        public int igraPoeni = 0;
        int index;
        int brPokusaja = 0;


        public KorisnikForma()
        {
            InitializeComponent();

            brojac.pokupi();
            brKviz = brojac.Kviz;
            brAs = brojac.Asoc;
            brIgra = brojac.Igre;
            brMoj = brojac.MojBroj;

        }

        private void KorisnikForma_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = korisnik.korisnicko_ime;
            labelMojRekord.Text = korisnik.poeni1.ToString();
            panel11.Enabled = false;
            panel7.Enabled = false;
            panel3.Enabled = false;
        }

        private void igreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void milionerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cetvrtaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nalogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kviz.lista[brP].tacan == "B" && kviz.lista.Count >= brP + 1)
            {

                kviz.poeni += 20;

                if (kviz.lista.Count > kviz.brPitanja)
                {
                    kviz.brPitanja++;
                    brP++;

                    brPitanjaLabel.Text = "";
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();

                    buttonPitanje.Text = kviz.lista[brP].text_pitanja;
                    buttonA.Text = "A." + kviz.lista[brP].odgA;
                    buttonB.Text = "B." + kviz.lista[brP].odgB;
                    buttonC.Text = "C." + kviz.lista[brP].odgC;
                    buttonD.Text = "D." + kviz.lista[brP].odgD;
                }
                else if (kviz.lista.Count == kviz.brPitanja)
                {
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();
                    kviz.brPitanja = 1;
                    korisnik.poeni1 = kviz.poeni;

                    if (Int32.Parse(labelMojRekord.Text) < kviz.poeni)
                    {
                        labelMojRekord.Text = kviz.poeni.ToString();
                        korisnik.poeni1 = kviz.poeni;
                        korisnik.izmeni_poene_korisnika();
                    }


                    buttonA.Enabled = false;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonD.Enabled = false;

                    Rezultat re = new Rezultat();
                    re.poeni = kviz.poeni;
                    re.ShowDialog();

                    kviz.poeni = 0;
                }


            }
            else
            {
                label6.Text = "";
                kviz.brPitanja = 1;
                korisnik.poeni1 = kviz.poeni;

                Rezultat re = new Rezultat();
                re.poeni = kviz.poeni;
                re.ShowDialog();

                buttonA.Enabled = false;
                buttonB.Enabled = false;
                buttonC.Enabled = false;
                buttonD.Enabled = false;

                kviz.poeni = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brKviz++;

           

            panel3.Enabled = true;

            if(kviz.lista.Count == 0)
                 kviz.pokupi_pitanja();

            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;

            int ukupno = kviz.lista.Count();
            label6.Text = "";
            brPitanjaLabel.Text = "";
            label2.Text = "";
            brP = 0;
           
             label6.Text = "od " + " " + ukupno.ToString();
            brPitanjaLabel.Text = kviz.brPitanja.ToString();
            label2.Text = kviz.poeni.ToString();

            buttonPitanje.Text = kviz.lista[brP].text_pitanja;
            buttonA.Text = "A." + kviz.lista[brP].odgA;
            buttonB.Text = "B." + kviz.lista[brP].odgB;
            buttonC.Text = "C." + kviz.lista[brP].odgC;
            buttonD.Text = "D." + kviz.lista[brP].odgD;

            brojac.Kviz = brKviz;
            brojac.promeni();

        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            if (kviz.lista[brP].tacan == "A" && kviz.lista.Count >= brP+1)
            {

                kviz.poeni += 20;

                if (kviz.lista.Count > kviz.brPitanja)
                {
                    kviz.brPitanja++;
                    brP++;

                    brPitanjaLabel.Text = "";
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();

                    buttonPitanje.Text = kviz.lista[brP].text_pitanja;
                    buttonA.Text = "A." + kviz.lista[brP].odgA;
                    buttonB.Text = "B." + kviz.lista[brP].odgB;
                    buttonC.Text = "C." + kviz.lista[brP].odgC;
                    buttonD.Text = "D." + kviz.lista[brP].odgD;
                }
                else if (kviz.lista.Count == kviz.brPitanja)
                {
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();
                    kviz.brPitanja = 1;
                    korisnik.poeni1 = kviz.poeni;

                    if (Int32.Parse(labelMojRekord.Text) < kviz.poeni)
                    {
                        labelMojRekord.Text = kviz.poeni.ToString();
                        korisnik.izmeni_poene_korisnika();
                    }

                    buttonA.Enabled = false;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonD.Enabled = false;

                    Rezultat re = new Rezultat();
                    re.poeni = kviz.poeni;
                    re.ShowDialog();

                    kviz.poeni = 0;
                }


            }
            else 
            {
                label6.Text = "";
                kviz.brPitanja = 1;
                korisnik.poeni1 = kviz.poeni;

                Rezultat re = new Rezultat();
                re.poeni = kviz.poeni;
                re.ShowDialog();

                buttonA.Enabled = false;
                buttonB.Enabled = false;
                buttonC.Enabled = false;
                buttonD.Enabled = false;
                kviz.poeni = 0;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (kviz.lista[brP].tacan == "C" && kviz.lista.Count >= brP + 1)
            {

                kviz.poeni += 20;

                if (kviz.lista.Count > kviz.brPitanja)
                {
                    kviz.brPitanja++;
                    brP++;

                    brPitanjaLabel.Text = "";
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();

                    buttonPitanje.Text = kviz.lista[brP].text_pitanja;
                    buttonA.Text = "A." + kviz.lista[brP].odgA;
                    buttonB.Text = "B." + kviz.lista[brP].odgB;
                    buttonC.Text = "C." + kviz.lista[brP].odgC;
                    buttonD.Text = "D." + kviz.lista[brP].odgD;
                }
                else if (kviz.lista.Count == kviz.brPitanja)
                {
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();
                    kviz.brPitanja = 1;
                    korisnik.poeni1 = kviz.poeni;

                    if (Int32.Parse(labelMojRekord.Text) < kviz.poeni)
                    {
                        labelMojRekord.Text = kviz.poeni.ToString();
                        korisnik.izmeni_poene_korisnika();
                    }

                    buttonA.Enabled = false;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonD.Enabled = false;
                    Rezultat re = new Rezultat();
                    re.poeni = kviz.poeni;
                    re.ShowDialog();

                    kviz.poeni = 0;
                }


            }
            else
            {
                label6.Text = "";
                kviz.brPitanja = 1;
                korisnik.poeni1 = kviz.poeni;
                Rezultat re = new Rezultat();
                re.poeni = kviz.poeni;
                re.ShowDialog();
                buttonA.Enabled = false;
                buttonB.Enabled = false;
                buttonC.Enabled = false;
                buttonD.Enabled = false;
                kviz.poeni = 0;
            }
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            if (kviz.lista[brP].tacan == "D" && kviz.lista.Count >= brP + 1)
            {

                kviz.poeni += 20;

                if (kviz.lista.Count > kviz.brPitanja)
                {
                    kviz.brPitanja++;
                    brP++;

                    brPitanjaLabel.Text = "";
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();

                    buttonPitanje.Text = kviz.lista[brP].text_pitanja;
                    buttonA.Text = "A." + kviz.lista[brP].odgA;
                    buttonB.Text = "B." + kviz.lista[brP].odgB;
                    buttonC.Text = "C." + kviz.lista[brP].odgC;
                    buttonD.Text = "D." + kviz.lista[brP].odgD;
                }
                else if (kviz.lista.Count == kviz.brPitanja)
                {
                    label2.Text = "";

                    brPitanjaLabel.Text = kviz.brPitanja.ToString();
                    label2.Text = kviz.poeni.ToString();
                    kviz.brPitanja = 1;
                    korisnik.poeni1 = kviz.poeni;

                    if (Int32.Parse(labelMojRekord.Text) < kviz.poeni)
                    {
                        labelMojRekord.Text = kviz.poeni.ToString();
                        korisnik.izmeni_poene_korisnika();
                    }
                    buttonA.Enabled = false;
                    buttonB.Enabled = false;
                    buttonC.Enabled = false;
                    buttonD.Enabled = false;
                    Rezultat re = new Rezultat();
                    re.poeni = kviz.poeni;
                    re.ShowDialog();


                    kviz.poeni = 0;
                }


            }
            else
            {
                label6.Text = "";
                kviz.brPitanja = 1;
                korisnik.poeni1 = kviz.poeni;
                Rezultat re = new Rezultat();
                re.poeni = kviz.poeni;
                re.ShowDialog();
                buttonA.Enabled = false;
                buttonB.Enabled = false;
                buttonC.Enabled = false;
                buttonD.Enabled = false;
                kviz.poeni = 0;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[a-z,A-Z]"))
            {
                MessageBox.Show("Molimo vas unesite samo broj.");
                if(textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int br = 0;

            if (textBox1.Text.Length > 0 && Int32.Parse(textBox1.Text) < 100)
            {
                br = Int32.Parse(textBox1.Text);
                int raz;
                raz = mojBroj - br;

                label7.Text = "";
                label7.Text = mojBroj.ToString();

                if (raz > 0)
                    mojBrojPoeni = 100 - raz;
                else if (raz < 0)
                    mojBrojPoeni = 100 + raz;
                else
                    mojBrojPoeni = 100;

                labelMojBrPoeni.Text = "";
                labelMojBrPoeni.Text = mojBrojPoeni.ToString();

                if (mojBrojPoeni > Int32.Parse(labelMojBrRekord.Text))
                {
                    korisnik.poeni2 = mojBrojPoeni;
                    korisnik.izmeni_poene_korisnika();
                }
                Rezultat rez = new Rezultat();
                rez.poeni = mojBrojPoeni;
                rez.ShowDialog();

                button3.Enabled = false;
            }
            else
                MessageBox.Show("Molim vas unesite validan broj.", "Broj nije unet");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            brMoj++;

            labelMojBrRekord.Text = korisnik.poeni2.ToString();
            labelMojBrPoeni.Text = "0";
            label7.Text = "";
            textBox1.Clear();
            button3.Enabled = true;
            generisi_broj();

            if (mojBroj > 9)
                label7.Text = "_ _";
            else
                label7.Text = " _ ";

            brojac.MojBroj = brMoj;
            brojac.promeni();
        }

        private void generisi_broj()
        {
            Random ran = new Random();
            mojBroj = ran.Next(0,99);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^A-Z_a-z ]"))
            {
                MessageBox.Show("Molimo vas unesite samo tekst.","Nevalidan unos");
                if (textBox2.Text.Length > 0)
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void mojiRekordiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MojRekord moj = new MojRekord();
            moj.korisnik = korisnik;
            moj.Show();
        }

        private void sviRekordiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SviRekordi rek = new SviRekordi();
            rek.ShowDialog();

        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(buttonCet.Text))
            {
                buttonCet.Text = asList[br].rec4;
                brAsoc++;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            brAs++;

            panel7.Enabled = true;
            labelMojRekordAsoc.Text = korisnik.poeni3.ToString();
            labelPoeniAsoc.Text = "0";

            brAsoc = 0;

            try
            {                
                asList = a.pokupi_asocijacije();

                Random r = new Random();
                br = r.Next(0, asList.Count);
            }
            catch (Exception)
            {
                MessageBox.Show("nezz");
            }

            button8.Enabled = true;

            buttonPrvi.Text = "";
            buttonDrug.Text = "";
            buttonTrec.Text = "";
            buttonCet.Text = "";
            buttonPet.Text = "";
            buttonSest.Text = "";

            brojac.Asoc = brAs;
            brojac.promeni();

        }

        private void buttonPrvi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(buttonPrvi.Text))
            {
                buttonPrvi.Text = asList[br].rec1;
                brAsoc++;
            }
        }

        private void buttonDrug_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(buttonDrug.Text))
            {
                buttonDrug.Text = asList[br].rec2;
                brAsoc++;
            }
        }

        private void buttonTrec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(buttonTrec.Text))
            {
                buttonTrec.Text = asList[br].rec3;
                brAsoc++;
            }
        }

        private void buttonPet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(buttonPet.Text))
            {
                buttonPet.Text = asList[br].rec5;
                brAsoc++;
            }
        }

        private void buttonSest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(buttonSest.Text))
            {
                buttonSest.Text = asList[br].rec6;
                brAsoc++;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int p;
            if(asList[br].resenje == textBox2.Text.ToLower())
            {
                if (brAsoc > 1)
                    p = 100 - (brAsoc - 2) * 10;
                else
                    p = 100;
                
                Rezultat rez = new Rezultat();
                rez.poeni = p;
                rez.ShowDialog();

                button8.Enabled = false;

                labelMojRekordAsoc.Text = "";
                labelMojRekordAsoc.Text = p.ToString();

                labelPoeniAsoc.Text = "";
                labelPoeniAsoc.Text = p.ToString();

                if(p > korisnik.poeni3)
                {
                    korisnik.poeni3 = p;
                    korisnik.izmeni_poene_korisnika();
                }
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Netacana rec\n" +
                    "Probajte ponovo!", "Greska");
                textBox2.Text = "";
            }
        }
       
        private void panel10_Paint(object sender, PaintEventArgs e)
        {
          //  AddButtons();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            brIgra++;

            panel11.Enabled = true;
            igraLista = igra.pokupi_reci();

            Random r = new Random();
            igraPoeni = 0;
            brPokusaja = 0;

            pictureBox1.Image = Image.FromFile(brPokusaja + ".png");
            labelMoREkordIgra.Text = korisnik.poeni4.ToString();
            labelPoeniIgra.Text = "0";
            labelaPogPro.Text = "";
            pob = 0;

            index = r.Next(0, igraLista.Count);
            labLista.Add(l0);
            labLista.Add(l1);
            labLista.Add(l2);
            labLista.Add(l3);
            labLista.Add(l4);
            labLista.Add(l5);
            labLista.Add(l6);
            labLista.Add(l7);
            labLista.Add(l8);
            labLista.Add(l9);
            labLista.Add(l10);

            brojac.Igre = brIgra;
            brojac.promeni();


            foreach (Button b in panel11.Controls)
                b.Enabled = true;

            foreach (Label l in labLista)
                l.Text = "";

            for(int i = 0; i<igraLista[index].rec.Length; i++)
            {
                labLista[i].Text = "_";
            }               

        }

        private void buttonGlavni_Click(object sender,EventArgs e)
        {
            Button b = (Button)sender;

            char kliknut = b.Text.ToCharArray()[0];

            if (igraLista[index].rec.Contains(kliknut))
            {
                char[] trazenaNiz = igraLista[index].rec.ToCharArray();
                strb.Clear();

                for (int i = 0; i < igraLista[index].rec.Length; i++)
                {
                    if (trazenaNiz[i] == kliknut)
                    {
                        labLista[i].Text = kliknut.ToString();
                        pob++;
                    }
                }


                labelaPogPro.Text = "Bravo!!";

                if (pob == trazenaNiz.Length)
                {
                    Rezultat rez = new Rezultat();
                    rez.poeni = 100 - brPokusaja * 10;
                    rez.ShowDialog();
                    panel11.Enabled = false;
                    if (rez.poeni > korisnik.poeni4)
                    {
                        labelMoREkordIgra.Text = rez.poeni.ToString();
                        korisnik.poeni4 = rez.poeni;
                        korisnik.izmeni_poene_korisnika();
                    }
                    labelPoeniIgra.Text = rez.poeni.ToString();
                }


            }
            else
            {
                brPokusaja++;

                if (brPokusaja > 6)
                {
                    labelaPogPro.Text = "";
                    labelaPogPro.Text = "Izgubili ste!";
                    panel11.Enabled = false;
                }
                else
                {
                    labelaPogPro.Text = "Ouu..";
                    pictureBox1.Image = Image.FromFile(brPokusaja + ".png");
                    pictureBox1.Invalidate();
                }
            }
            b.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void l10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            buttonGlavni_Click(sender, e);
        }

        private void izmeniNalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForma fo = new AdminForma();
            fo.Show();

        }
    }
}
