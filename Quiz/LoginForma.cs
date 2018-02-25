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
    public partial class LoginForma : Form
    {
        public LoginForma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) ||
                String.IsNullOrEmpty(textBox2.Text))
                MessageBox.Show("Sva polja su obavezna!", "Greska");
            else
            {
                try
                {
                    var pass = textBox2.Text;
                    var md5 = new MD5CryptoServiceProvider();
                    var data = Encoding.ASCII.GetBytes(pass);

                    var hash_pass = md5.ComputeHash(data);

                    Korisnik korisnik = new Korisnik();

                    korisnik.lozinka = Convert.ToBase64String(hash_pass);
                    korisnik.korisnicko_ime = textBox1.Text;

                    korisnik.proveri_korisnika();

                    if (korisnik.Uloga == "Korisnik")
                    {
                        KorisnikForma forma = new KorisnikForma();
                        forma.korisnik = korisnik;
                        
                        forma.WindowState = FormWindowState.Maximized;
                        this.Hide();
                        forma.ShowDialog();
                        this.Show();
                    }
                    else if (korisnik.Uloga == "Admin")
                    {
                        AdminForma form = new AdminForma();
                        form.korisnik = korisnik;
                        this.Hide();
                        form.WindowState = FormWindowState.Maximized;

                        form.ShowDialog();
                        this.Show();
                    }
                    else
                        MessageBox.Show("Pogresno korisnicko ime ili lozinka", "Greska");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Greska");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForma forma = new RegisterForma();
            forma.ShowDialog();

        }

        private void LoginForma_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^A-Z,a-z_-]"))
            {
              
                if(textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                MessageBox.Show("Korisnicko ime ne mogu biti brojevi!");

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else if (!checkBox1.Checked)
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = true;
        }
    }
}
