using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hafta_12
{
    public partial class Form1 : Form
    {
        Bitmap goruntu = new Bitmap(300,300);
        Bitmap gray_goruntu = new Bitmap(300,300);
        Bitmap bitmap_goruntu = new Bitmap(300, 300);
        Bitmap erosion_goruntu = new Bitmap(300, 300);
        Bitmap dilation_goruntu = new Bitmap(300, 300);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                textBox2.Text = "1";
                textBox3.Text = "0";
                textBox4.Text = "0";
            }
            Graphics.FromImage(goruntu).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(gray_goruntu).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(bitmap_goruntu).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(erosion_goruntu).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
            Graphics.FromImage(dilation_goruntu).DrawImage(pictureBox1.Image, 0, 0, 300, 300);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x1, x2, x3;
            x1 = 255;
            x2 = 255;
            x3 = 255;
            Color cl;
            int b1, b2, b3;
            int arti_renk;
            

            for (int y=1; y<2; y++)
            {
                for(int x=1; x<300-1;x++)
                {
                    cl = bitmap_goruntu.GetPixel(x, y);
                    b1 = cl.R;
                    cl = bitmap_goruntu.GetPixel(x-1, y);
                    b2 = cl.R;
                    cl = bitmap_goruntu.GetPixel(x+1, y);
                    b3 = cl.R;
                    if(b1==x1 && b2==x2 && b3==x3 )
                    {
                        erosion_goruntu.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        erosion_goruntu.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = erosion_goruntu;
            bitmap_goruntu = erosion_goruntu;
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color renk;
            int r, g, b;
            int gray;

            for(int x=0; x<300; x++)
            {
                for(int y=0; y<300;y++)
                {
                    renk = goruntu.GetPixel(x, y);
                    r = Convert.ToInt32(renk.R);
                    g = Convert.ToInt32(renk.G);
                    b = Convert.ToInt32(renk.B);
                    gray = (r + g + b) / 3;
                    gray_goruntu.SetPixel(x, y, Color.FromArgb(gray, gray, gray));

                }
            }
            pictureBox1.Image = gray_goruntu;
            this.Refresh();
            textBox2.Text = "0";
            textBox3.Text = "1";
            textBox4.Text = "0";

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int thereshold = Convert.ToInt32(textBox1.Text);
            if(textBox3.Text=="1")
            {
                Color renk;
                int gray;

                for(int x=0; x<300; x++)
                {
                    for(int y=0; y<300; y++)
                    {
                        renk = gray_goruntu.GetPixel(x, y);
                        gray = Convert.ToInt32(renk.R);

                        if(gray>thereshold)
                        {
                            bitmap_goruntu.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bitmap_goruntu.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "1";
                pictureBox1.Image = bitmap_goruntu;
                this.Refresh();
            }



           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Color cl;
            int r, g, b;
            int arti_renk;

            for(int x=0;x<150;x++)
            {
                for(int y=1; y<300; y++)
                {
                    cl = gray_goruntu.GetPixel(x, y);
                    Color tmp = gray_goruntu.GetPixel(300 - x - 1, y);
                    gray_goruntu.SetPixel(x, y, tmp);
                    gray_goruntu.SetPixel(300 - x - 1, y, cl);
                }
                pictureBox1.Image = gray_goruntu;
                this.Refresh();
                    
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             Color cl;
             int r, g, b;
             int arti_renk;
             arti_renk = Convert.ToInt32(textBox1.Text);

             for (int x = 0; x < 300; x++)
             {
                 for (int y = 1; y < 300; y++)
                 {
                     cl = gray_goruntu.GetPixel(x, y);
                     r = cl.R + arti_renk;
                     if (r > 255) r = 255;
                     g = cl.G + arti_renk;
                     if (g > 255) g = 255;
                     b = cl.B + arti_renk;
                     if (b > 255) b = 255;
                     gray_goruntu.SetPixel(x, y, Color.FromArgb(r, g, b));
                 }
             }
             pictureBox1.Image = gray_goruntu;
             this.Refresh();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
             Color cl;
            int r, g, b;
            int arti_renk;
            arti_renk = Convert.ToInt32(textBox1.Text);

            for (int x = 0; x < 300; x++)
            {
                for (int y = 1; y < 300; y++)
                {
                    cl = gray_goruntu.GetPixel(x, y);
                    r = cl.R - arti_renk;
                    if (r < 0) r = 0;
                    g = cl.G - arti_renk;
                    if (g < 0) g = 0;
                    b = cl.B - arti_renk;
                    if (b < 0) b = 0;
                    gray_goruntu.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = gray_goruntu;
            this.Refresh();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x1, x2, x3;
            x1 = 255;
            x2 = 255;
            x3 = 255;
            Color cl;
            int b1, b2, b3;
            int arti_renk;


            for (int y = 1; y < 2; y++)
            {
                for (int x = 1; x < 300 - 1; x++)
                {
                    cl = bitmap_goruntu.GetPixel(x, y);
                    b1 = cl.R;
                    cl = bitmap_goruntu.GetPixel(x - 1, y);
                    b2 = cl.R;
                    cl = bitmap_goruntu.GetPixel(x + 1, y);
                    b3 = cl.R;
                    if (b1 == x1 && b2 == x2 || b3 == x3)
                    {
                        dilation_goruntu.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        dilation_goruntu.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }
            pictureBox1.Image = dilation_goruntu;
            bitmap_goruntu = dilation_goruntu;
            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

