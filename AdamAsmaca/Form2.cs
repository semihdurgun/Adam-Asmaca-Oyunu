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
using System.Collections;

namespace AdamAsmaca
{
    public partial class Form2 : Form
    {        
        static bool kontrol = true;
        public static int puan;
        int deger = 0;
        int asılacakSayı;
        public string secilenKelime;
        char[] yertutucu;
        int hak = 0;
        
        string[] adam5 = { " \t|\n", " O\n", " /|\\\n ", "/ ", "\\" };
        string[] adam6 = { "___\n", " |\n", " O\n", " /|\\ \n ", "/ ", " \\" };
        string[] adam7 = { "___\n", " |\n", " O\n", " /|\\ \n ", "/ ", " \\ \n", "_____" };
        string[] adam8 = { "___\n", " |\n", " O\n", " /|\\ \n ", "/ ", " \\ \n", "____", "__", "____" };
        string[] adam9 = { "___\n", " |\n", " O\n", " /", "|", "\\ \n", " /", " \\ \n", "___" };
        string[] adam10 = { "___\n", " |\n", " O\n", " /", "|", "\\ \n", " /", " \\ \n", "___", "_____" };
        string[] adam11 = { "____", "____\n", " |\n", " O\n", " /", "|", "\\ \n", " /" ," \\ \n", "____","____" };

        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public string UygunuAl(int a)
        {
            string[] words = System.IO.File.ReadAllLines(@"kelimeler.txt");
            ArrayList hazne = new ArrayList();
            
            for (int i = 0; i < words.Length ; i++)
            { 
                if (words[i].Length == a)
                {
                    hazne.Add(words[i]);
                }              
            }
            Random rnd = new Random();
            int index = rnd.Next(0, hazne.Count);
            secilenKelime = hazne[index].ToString();
            return secilenKelime;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            label1.Hide(); comboBox1.Hide(); button1.Hide(); label2.Hide(); button2.Hide(); button3.Show(); 
            richTextBox1.Show(); button4.Show();label12.Show();label5.Show();button5.Hide();
             
                string a = comboBox1.Text;
                KelimeAl(a);
                asılacakSayı = Convert.ToInt32(a);  
        }
        private void button5_Click(object sender, EventArgs e)
        {
            label1.Hide(); comboBox1.Hide(); button1.Hide(); label2.Hide(); button2.Hide(); button3.Show(); 
            richTextBox1.Show(); button4.Show(); label12.Show();button5.Hide(); label5.Show();
            string[] words = System.IO.File.ReadAllLines(@"kelimeler.txt");
            Random rnd = new Random();
            int index = rnd.Next(0, words.Length -1);
            secilenKelime = words[index];
           
            hak = secilenKelime.Length + 2;
            UygunuAl(secilenKelime.Length);
            asılacakSayı = secilenKelime.Length;
            yazdır();
        }

        public void yazdır()
        {
            yertutucu = new char[secilenKelime.Length];
            
            label13.Text = "";
            label14.Text = "";
            for (int i = 0; i < yertutucu.Length; i++)
            {
                yertutucu[i] = '-';
                label13.Text += yertutucu[i].ToString();
            }
            label3.Text = Convert.ToString(hak);
        }
        public void KelimeAl(string a)
        {
            if (Convert.ToInt32(a) == 3)
            {
                hak = 5;
                UygunuAl(3);
                yazdır();
            }
            else if (Convert.ToInt32(a) == 4)
            {
                hak = 6;
                UygunuAl(4);
                yazdır();

            }
            else if (Convert.ToInt32(a) == 5)
            {
                hak = 7;
                UygunuAl(5);
                yazdır();
            }
            else if (Convert.ToInt32(a) == 6)
            {
                hak = 8;
                UygunuAl(6);
                yazdır();
            }
            else if (Convert.ToInt32(a) == 7)
            {
                hak = 9;
                UygunuAl(7);
                yazdır();
            }
            else if (Convert.ToInt32(a) == 8)
            {
                hak = 10;
                UygunuAl(8);
                yazdır();
            }
            else if (Convert.ToInt32(a) == 9)
            {
                hak = 11;
                UygunuAl(9);
                yazdır();
            }            
        }             
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 1)
            {
                if (Char.IsLetter(Convert.ToChar(richTextBox1.Text)))
                {
                    
                    bool durum = false;
                    char harf = Convert.ToChar(richTextBox1.Text);
                    char[] dizil4 = label4.Text.ToCharArray();
                    for(int i = 0; i < dizil4.Length; i++)
                    {
                        if (dizil4[i] == harf)  kontrol = false;
                    }
                    if (kontrol)
                    {
                        label4.Text = label4.Text + " " + harf;
                        for (int i = 0; i < secilenKelime.Length; i++) //kelimenin uzunluğu kadar ilerleyip hangi kelimesi doğru ise
                        {                                              //yer tutan indexe o harfi yazar.
                            if (secilenKelime[i] == harf)
                            {
                                durum = true;
                                yertutucu[i] = harf;
                                richTextBox1.Clear();
                            }
                        }
                        label13.Text = "";
                        for (int i = 0; i < yertutucu.Length; i++)  // yer tutucunun uzunluğu kadar ilerleyip yer tutucunun değerlerini labela aktarır.
                        {
                            label13.Text += yertutucu[i].ToString();
                        }
                        int kalanHarf = 0;
                        for (int i = 0; i < yertutucu.Length; i++)
                        {
                            if (yertutucu[i] == '-')
                            {
                                kalanHarf++;
                            }
                        }
                        if (kalanHarf > 0)
                        {

                            if (!durum && asılacakSayı == 3 && deger < 5)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam5[deger];
                                deger++;
                                if (deger == 5)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                            else if (!durum && asılacakSayı == 4 && deger < 6)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam6[deger];
                                deger++;
                                if (deger == 6)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                            else if (!durum && asılacakSayı == 5 && deger < 7)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam7[deger];
                                deger++;
                                if (deger == 7)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                            else if (!durum && asılacakSayı == 6 && deger < 8)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam8[deger];
                                deger++;
                                if (deger == 8)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                            else if (!durum && asılacakSayı == 7 && deger < 9)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam9[deger];
                                deger++;
                                if (deger == 9)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                            else if (!durum && asılacakSayı == 8 && deger < 10)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam10[deger];
                                deger++;
                                if (deger == 10)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                            else if (!durum && asılacakSayı == 9 && deger < 11)
                            {
                                hak--;
                                label3.Text = Convert.ToString(hak);
                                label14.Text += adam11[deger];
                                deger++;
                                if (deger == 11)
                                {
                                    MessageBox.Show("Hakkınız Bitti. Aradığınız kelime: " + secilenKelime);
                                    this.Hide();
                                    Form1 form = new Form1();
                                    form.Show();
                                }
                            }
                        }
                        else
                        {
                            puan = hak * 10;
                            MessageBox.Show("Tebrikler Bildiniz..\nPuanınız : " + puan);
                            StreamWriter swSkor = new StreamWriter(@"Skorboard.txt", true);
                            swSkor.WriteLine(puan + " - " + Form1.isim.ToUpper());
                            swSkor.Close();
                            this.Hide();
                            Form1 form = new Form1();
                            form.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen girilmeyen bir değer giriniz");
                        kontrol = true;
                        richTextBox1.Clear();
                    }
                }  
                else
                {
                    MessageBox.Show("Lütfen harf giriniz");
                }
            }
            else
            {
                MessageBox.Show("Lüften tek harf girin");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}