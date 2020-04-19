using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AdamAsmaca
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            string[] words = System.IO.File.ReadAllLines(@"kelimeler.txt");

            foreach (var i in words)
            {
                listBox1.Items.Insert(0, i);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && (String.IsNullOrWhiteSpace(textBox1.Text)) != true)
            {
                StreamWriter dosya = new StreamWriter(@"kelimeler.txt", true);
                string eklenilecek = textBox1.Text.Replace(" ", "");
                if (eklenilecek.Length <= 9)
                {
                    dosya.WriteLine(eklenilecek);
                }
                else
                {
                    MessageBox.Show("Kelimenin uzunluğu en fazla 9 olmalıdır");
                }
                dosya.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Geçerli bir kelime giriniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string yazi;
            string i = "";
            if (listBox1.SelectedItem != null)
            {
                string silinecekVeri = Convert.ToString(listBox1.SelectedItem);
                listBox1.Items.Remove(silinecekVeri);
                StreamReader sr = File.OpenText(@"kelimeler.txt");
                while ((yazi = sr.ReadLine()) != null)
                {
                    if (!yazi.Contains(silinecekVeri))  //contains yazinin içinde silinecek veri varsa true döndürür.
                    {
                        i += yazi + "\n";
                    }
                }
                sr.Close();
                File.WriteAllText(@"kelimeler.txt", i);
            }
            else
            {
                MessageBox.Show("Lütfen kelime seçiniz");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int bas = Convert.ToInt32(e.KeyChar);
            if (bas >= 48 && bas <= 57)
            {                
                e.Handled = true;
            }
        }
    }
}
            