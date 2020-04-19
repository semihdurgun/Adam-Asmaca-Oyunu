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
    public partial class Form1 : Form
    {
        public static string isim;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0 && (String.IsNullOrWhiteSpace(textBox2.Text)) != true)
            {
                    
                    isim = textBox2.Text;
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen isminizi giriniz");
            }
                    
            FileStream fs = new FileStream(@"kelimeler.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();       
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fsSkor = new FileStream(@"Skorboard.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fsSkor.Close();
            skorBoardYaz();
        }
        public void skorBoardYaz()
        {
            StreamReader srSkor = new StreamReader(@"Skorboard.txt", true);
            string[] hazne = System.IO.File.ReadAllLines(@"Skorboard.txt");
            Array.Sort(hazne);
            Array.Reverse(hazne);
            for (int i = 0; i < hazne.Length; i++)
            {
                listBox1.Items.Add(hazne[i]);
            }
            srSkor.Close();
        }
    }
}
