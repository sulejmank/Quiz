using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class dodajAdmina : Form
    {
        public dodajAdmina()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox3.UseSystemPasswordChar = false;
            else if (!checkBox1.Checked)
                textBox3.UseSystemPasswordChar = true;
            else
                textBox3.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
               String.IsNullOrEmpty(textBox2.Text) ||
               String.IsNullOrEmpty(textBox3.Text))
                MessageBox.Show("Sva polja su obavezna!", "Greska");
            else
            {
                try
                {

                    var pass = textBox3.Text;
                    var md5 = new MD5CryptoServiceProvider();
                    var data = Encoding.ASCII.GetBytes(pass);

                    var hash_pass = md5.ComputeHash(data);

                    Korisnik korinsik = new Korisnik();

                    korinsik.lozinka = Convert.ToBase64String(hash_pass);
                    korinsik.Ime = textBox1.Text;
                    korinsik.korisnicko_ime = textBox2.Text;
                    korinsik.Uloga = "Admin";

                    korinsik.dodaj_korisnika();

                    MessageBox.Show("Uspesno ste kreirali nalog!", "Uspeh");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
