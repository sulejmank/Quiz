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
    public partial class RegisterForma : Form
    {
        public RegisterForma()
        {
            InitializeComponent();


            this.AcceptButton = button1;
            textBox1.KeyDown += new KeyEventHandler(tb_keyDown);
            textBox2.KeyDown += new KeyEventHandler(tb_keyDown);
        }

        private void tb_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                textBox2.Focus();
            else if (e.KeyCode == Keys.Up)
                textBox1.Focus();
        }

        private void RegisterForma_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox4.UseSystemPasswordChar = false;
            else if (!checkBox1.Checked)
                textBox4.UseSystemPasswordChar = true;
            else
                textBox4.UseSystemPasswordChar = true;
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
                String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox4.Text))
                MessageBox.Show("Sva polja su obavezna!", "Greska");
            else 
            {
                try {

                    var pass = textBox4.Text;
                    var md5 = new MD5CryptoServiceProvider();
                    var data = Encoding.ASCII.GetBytes(pass);

                    var hash_pass = md5.ComputeHash(data);

                    Korisnik korinsik = new Korisnik();

                    korinsik.lozinka = Convert.ToBase64String(hash_pass);
                    korinsik.Ime = textBox1.Text;
                    korinsik.korisnicko_ime = textBox2.Text;
                    korinsik.Uloga = "Korisnik";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^A-Z,a-z_-]"))
            {

                if (textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                MessageBox.Show("Ime ne mogu biti brojevi!","Greska");

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^A-Z,a-z_-]"))
            {

                if (textBox1.Text.Length > 0)
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                MessageBox.Show("Korisnicko ime ne mogu biti brojevi!");

            }
        }
    }
}
