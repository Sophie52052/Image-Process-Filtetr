using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

        }
        Bitmap raw_img;
        Bitmap img2;
        Bitmap img3;
        Bitmap img4;
        Bitmap img5;
        Bitmap img6;

        //select
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BPM;*.JPG;*.GIF;*.PNG)|*.BPM;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                chart1.Visible = false;
                chart2.Visible = false;
                chart3.Visible = false;

                raw_img = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = raw_img;
                label1.Visible = true;

                img2 = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = img2;
                pictureBox2.Visible = false;

                img3 = new Bitmap(openFileDialog1.FileName);
                pictureBox3.Image = img3;
                pictureBox3.Visible = false;

                img4 = new Bitmap(openFileDialog1.FileName);
                pictureBox4.Image = img4;
                pictureBox4.Visible = false;

                img5 = new Bitmap(openFileDialog1.FileName);
                pictureBox5.Image = img5;
                pictureBox5.Visible = false;

                img6 = new Bitmap(openFileDialog1.FileName);
                pictureBox6.Image = img6;
                pictureBox6.Visible = false;
                
            }
        }
//undo
        private void undo_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true){
                pictureBox2.Image = raw_img;
            }
            if (pictureBox3.Visible == true)
            {
                pictureBox3.Image = raw_img;
            }
            if (pictureBox4.Visible == true)
            {
                pictureBox4.Image = raw_img;
            }
            if (pictureBox5.Visible == true)
            {
                pictureBox5.Image = raw_img;
            }
            if (pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                //pictureBox6.Image = raw_img;
                //pictureBox6.Size = (256, 209);
                pictureBox3.Image = raw_img;
                pictureBox3.Visible = true;
                //this.pictureBox6.Size = new System.Drawing.Size(175, 139);
                //this.pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
            
            pictureBox3.Image = raw_img;
            pictureBox4.Image = raw_img;
            pictureBox5.Image = raw_img;
            pictureBox6.Image = raw_img;
            if (chart2.Visible == true)
            {
                chart2.Visible = false;
                chart3.Visible = true;
            }
            
        }
//Q1
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;


            for (int y = 0; y < raw_img.Height; y++)
            {
                for (int x = 0; x < raw_img.Width; x++)
                {
                    // 讀取影像平面上(x,y)的RGB資訊

                    Color RGB = raw_img.GetPixel(x, y);
                    // RGB 是 VS 內建的 class 可以直接讀取影像的色彩資訊 R = Red, G = Green, B =Blue                        
                    //int invR = Convert.ToInt32(RGB.R);
                    //int invG = Convert.ToInt32(RGB.G);
                    //int invB = Convert.ToInt32(RGB.B);
                    int r = RGB.R;

                    //channel.Text = Convert.ToString(count);
                    //int avg = (RGB.R + RGB.G + RGB.B) / 3;
                    int avg = (int)((RGB.R * 0.3) + (RGB.G * 0.59) + (RGB.B * 0.11));
                    //sb.AppendFormat("Red: {0} - Green: {1} - Blue: {2}", RGB.R, RGB.G, RGB.B);
                    //listBox1.Items.Add(sb.ToString());
                    //sb.Clear();


                    //img2.SetPixel(x, y, Color.FromArgb(RGB.R, 0, 0));
                    //img3.SetPixel(x, y, Color.FromArgb(0, RGB.R, 0));
                    //img4.SetPixel(x, y, Color.FromArgb(0, 0, RGB.B));

                    img2.SetPixel(x, y, Color.FromArgb(RGB.R, RGB.R, RGB.R));
                    img3.SetPixel(x, y, Color.FromArgb(RGB.G, RGB.G, RGB.G));
                    img4.SetPixel(x, y, Color.FromArgb(RGB.B, RGB.B, RGB.B));

                    img5.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                   
                }
            }
            pictureBox2.Visible = true;
            pictureBox2.Image = img2;
            label2.Text = "R channel";
            label2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox3.Image = img3;
            label3.Text = "G channel";
            label3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox4.Image = img4;
            label4.Text = "B channel";
            label4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox5.Image = img5;
            label5.Text = "Grayscale";
            label5.Visible = true;

        }


        //Q2
        float sum = 0;
        private void Q2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            //mean
            for (int i = 0; i <= raw_img.Width - 3; i++)
            {
                for (int j = 0; j <= raw_img.Height - 3; j++)
                {
                    for (int x = i; x <= i + 2; x++)
                        for (int y = j; y <= j + 2; y++)
                        {
                            Color RGB_mean = raw_img.GetPixel(x, y);
                            sum = sum + RGB_mean.R;//算一個channel即可
                        }
                    int color = (int)Math.Round(sum / 9);// ,10
                    img2.SetPixel(i+1 , j+1 , Color.FromArgb(color, color, color));//+1
                    sum = 0;

                }
            }
            //median
            List<byte> list_med = new List<byte>();
            for (int i = 0; i <= raw_img.Width - 3; i++)
            {
                for (int j = 0; j <= raw_img.Height - 3; j++)
                {
                    for (int x = i; x <= i + 2; x++)
                        for (int y = j; y <= j + 2; y++)
                        {
                            Color RGB_median = raw_img.GetPixel(x, y);
                            list_med.Add(RGB_median.R);

                        }
                    //byte[] terms = list_med.ToArray();
                    list_med.Sort();
                    byte color = list_med[4];
                    //foreach (var p in list_med)
                    //{
                    //    Console.WriteLine(p);

                    //}
                    //byte color = terms[4];
                    img3.SetPixel(i+1, j+1 , Color.FromArgb(color, color, color));
                    //Console.WriteLine(list_med);
                    list_med.Clear();


                }
            }
            pictureBox2.Visible = true;
            pictureBox2.Image = img2;
            label2.Text = "Mean";
            label2.Visible = true;

            pictureBox3.Visible = true;
            pictureBox3.Image = img3;
            label3.Text = "Median";
            label3.Visible = true;
        }



        private void pictureBox2_Click(object sender, EventArgs e){}
//Q3
        private void Q3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            //origin histogram

            int[] count = new int[256];
            String[] x_value = new String[256];
            
            for (int i = 0; i < raw_img.Width; i++)
            {
                for (int j = 0; j < raw_img.Height; j++)
                {
                    int color = raw_img.GetPixel(i, j).R;
                    count[color] = count[color] + 1;
                }
            }
                
            for (int i = 0; i < 256; i++)
            {
                x_value[i] = Convert.ToString(i);
            }
                
            
            //var chartarea1 = chart1.ChartAreas.First();
            var series1 = chart1.Series.First();
            for (int i = 0; i < 256; i++)
            {
                series1.Points.AddXY(x_value[i], count[i]);
            }
            var series3 = chart3.Series.First();
            for (int i = 0; i < 256; i++)
            {
                series3.Points.AddXY(x_value[i], count[i]);
            }

            //histogram equalization

            Bitmap h_e = new Bitmap(raw_img);
            int[] count_per = new int[256];
            int[] count_h_e_final = new int[256];
            double[] gray_prob = new double[256];
            double[] cdf = new double[256];

            for (int i = 0; i < raw_img.Width; i++)
            {
                for (int j = 0; j < raw_img.Height; j++)
                {
                    int color = raw_img.GetPixel(i, j).R;
                    count_per[color] = count_per[color] + 1;
                }
            }


            int x_value_he = 0;

            for (int i = 0; i < 256; i++)
            {
                x_value_he = x_value_he + count_per[i];
            }

            for (int i = 0; i < 256; i++)
            {
                //Console.WriteLine(count_per[i]);
                gray_prob[i] = (double)count_per[i] / (double)x_value_he;
            }

            for (int i = 0; i < 256; i++)
            {
                //cumulative distribution function
                if (i == 0) cdf[i] = gray_prob[i];
                else cdf[i] = cdf[i - 1] + gray_prob[i];
            }

            for (int i = 0; i < 256; i++)
            {
                cdf[i] = cdf[i] * 255;
            }

            for (int i = 0; i < raw_img.Width; i++)
            {
                for (int j = 0; j < raw_img.Height; j++)
                {
                    int color = raw_img.GetPixel(i, j).R;
                    int replace_pixel_value = (int)cdf[color];
                    h_e.SetPixel(i, j, Color.FromArgb(replace_pixel_value, replace_pixel_value, replace_pixel_value));
                }
            }

            //int index = 0;
            for (int i = 0; i < h_e.Width; i++)
            {
                for (int j = 0; j < h_e.Height; j++)
                {
                    int color = h_e.GetPixel(i, j).R;
                    count_h_e_final[color] = count_h_e_final[color] + 1;
                }
            }

            pictureBox2.Image = h_e;
            String[] xvalue = new String[256];
            for (int i = 0; i < 256; i++) xvalue[i] = Convert.ToString(i);
            var chartarea = chart2.ChartAreas.First();
            var series = chart2.Series.First();
            for (int i = 0; i < 256; i++)
            {
                series.Points.AddXY(xvalue[i], count_h_e_final[i]);
            }
            

            


            //Array.Clear(count_h_e, 0, count_h_e.Length);
            //Array.Clear(count_h_e_final, 0, count_h_e_final.Length);
            //Array.Clear(gray_prob, 0, gray_prob.Length);
            //Array.Clear(cdf, 0, cdf.Length);
            //Array.Clear(xvalue, 0, xvalue.Length);


          

            

            

            pictureBox2.Visible = true;
            chart1.Visible = true;
            chart2.Visible = true;
            chart3.Visible = false;
            label2.Text = "Result";
            label2.Visible = true;

            label3.Text = "Source histogram";
            label3.Visible = true;

            label7.Text = "Result histogram";
            label7.Visible = true;




            //label3.Text = "Result";
            //label3.Visible = true;
            //pictureBox3.Visible = true;


        }

//Q4
        private void Q4_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

            for (int y = 0; y < raw_img.Height; y++)
            {
                for (int x = 0; x < raw_img.Width; x++)
                {

                    Color RGB = raw_img.GetPixel(x, y);

                    int r = RGB.R;
                    if (RGB.R < Int32.Parse(textBox1.Text))
                    {
                        img2.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }

                    else
                    {
                        img2.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    

                    //Gray_img.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            pictureBox2.Image = img2;
            label2.Text = "Result";
            label2.Visible = true;
            pictureBox2.Visible = true;
        }
//Q5
        private void Q5_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

            int[] mask_x = { -1, 0, 1, -2, 0, 2, -1, 0, 1 };
            //int[][] mask_x = {new int[] {-1, 0, 1},
            //          new int[] {-2, 0, 2},
            //          new int[] {-1, 0, 1}};

            int[][] mask_y = {new int[] {-1, -2, -1},
                          new int[] { 0, 0, 0},
                          new int[] { 1, 2, 1}};
            

            for (int y = 1; y < raw_img.Height - 1; y++)
            {
                for (int x = 1; x < raw_img.Width - 1; x++)
                {
                    //int per_x = raw_img.GetPixel(x - 1, y - 1).R * mask_x[0][0] + raw_img.GetPixel(x, y - 1).R * mask_x[0][1] + raw_img.GetPixel(x + 1, y - 1).R * mask_x[0][2]
                    //          + raw_img.GetPixel(x - 1, y).R * mask_x[1][0] + raw_img.GetPixel(x, y).R * mask_x[1][1] + raw_img.GetPixel(x + 1, y).R * mask_x[1][2]
                    //          + raw_img.GetPixel(x - 1, y + 1).R * mask_x[2][0] + raw_img.GetPixel(x, y + 1).R * mask_x[2][1] + raw_img.GetPixel(x + 1, y + 1).R * mask_x[2][2];
                    int per_x = raw_img.GetPixel(x - 1, y - 1).R * mask_x[0] + raw_img.GetPixel(x, y - 1).R * mask_x[1] + raw_img.GetPixel(x + 1, y - 1).R * mask_x[2]
      + raw_img.GetPixel(x - 1, y).R * mask_x[3] + raw_img.GetPixel(x, y).R * mask_x[4] + raw_img.GetPixel(x + 1, y).R * mask_x[5]
      + raw_img.GetPixel(x - 1, y + 1).R * mask_x[6] + raw_img.GetPixel(x, y + 1).R * mask_x[7] + raw_img.GetPixel(x + 1, y + 1).R * mask_x[8];

                    int per_y = raw_img.GetPixel(x - 1, y - 1).R * mask_y[0][0] + raw_img.GetPixel(x, y - 1).R * mask_y[0][1] + raw_img.GetPixel(x + 1, y - 1).R * mask_y[0][2]
                           + raw_img.GetPixel(x - 1, y).R * mask_y[1][0] + raw_img.GetPixel(x, y).R * mask_y[1][1] + raw_img.GetPixel(x + 1, y).R * mask_y[1][2]
                           + raw_img.GetPixel(x - 1, y + 1).R * mask_y[2][0] + raw_img.GetPixel(x, y + 1).R * mask_y[2][1] + raw_img.GetPixel(x + 1, y + 1).R * mask_y[2][2];

                    double combine_x = Math.Sqrt((per_x * per_x));
                    double combine_y = Math.Sqrt((per_y * per_y));
                    double combine_all = Math.Sqrt((per_x * per_x) + (per_y * per_y));



                    //vertical
                    if (combine_x > 255)
                    {
                        img2.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }

                    else
                    {
                        //img2.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        img2.SetPixel(x, y, Color.FromArgb((int)combine_x, (int)combine_x, (int)combine_x));
                    }

                    //horizon
                    if (combine_y > 255)
                    {
                        img3.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        img3.SetPixel(x, y, Color.FromArgb((int)combine_y, (int)combine_y, (int)combine_y));
                    }

                    //sqrt(x^2+y^2)
                    if (combine_all > 255)
                    {
                        img4.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        img4.SetPixel(x, y, Color.FromArgb((int)combine_all, (int)combine_all, (int)combine_all));
                    }


                }
            }
            pictureBox2.Visible = true;
            pictureBox2.Image = img2;
            label2.Text = "vertical";
            label2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox3.Image = img3;
            label3.Text = "horizontal";
            label3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox4.Image = img4;
            label4.Text = "combined";
            label4.Visible = true;


            //pictureBox2.Image = img2;
            //pictureBox3.Image = img3;
            //pictureBox4.Image = img4;
        }

//Q6
 

        private void Q6_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

            int[][] mask_x = {new int[] {-1, 0, 1},
                          new int[] {-2, 0, 2},
                          new int[] {-1, 0, 1}};

            int[][] mask_y = {new int[] {-1, -2, -1},
                          new int[] { 0, 0, 0},
                          new int[] { 1, 2, 1}};

            for (int y = 1; y < raw_img.Height - 1; y++)
            {
                for (int x = 1; x < raw_img.Width - 1; x++)
                {
                    int per_x = raw_img.GetPixel(x - 1, y - 1).R * mask_x[0][0] + raw_img.GetPixel(x, y - 1).R * mask_x[0][1] + raw_img.GetPixel(x + 1, y - 1).R * mask_x[0][2]
                              + raw_img.GetPixel(x - 1, y).R * mask_x[1][0] + raw_img.GetPixel(x, y).R * mask_x[1][1] + raw_img.GetPixel(x + 1, y).R * mask_x[1][2]
                              + raw_img.GetPixel(x - 1, y + 1).R * mask_x[2][0] + raw_img.GetPixel(x, y + 1).R * mask_x[2][1] + raw_img.GetPixel(x + 1, y + 1).R * mask_x[2][2];

                    int per_y = raw_img.GetPixel(x - 1, y - 1).R * mask_y[0][0] + raw_img.GetPixel(x, y - 1).R * mask_y[0][1] + raw_img.GetPixel(x + 1, y - 1).R * mask_y[0][2]
                           + raw_img.GetPixel(x - 1, y).R * mask_y[1][0] + raw_img.GetPixel(x, y).R * mask_y[1][1] + raw_img.GetPixel(x + 1, y).R * mask_y[1][2]
                           + raw_img.GetPixel(x - 1, y + 1).R * mask_y[2][0] + raw_img.GetPixel(x, y + 1).R * mask_y[2][1] + raw_img.GetPixel(x + 1, y + 1).R * mask_y[2][2];

                    double combine_x = Math.Sqrt((per_x * per_x));
                    double combine_y = Math.Sqrt((per_y * per_y));
                    double combine_all = Math.Sqrt((per_x * per_x) + (per_y * per_y));
                    //combine_all = Math.Abs(combine_all);

                    Color RGB = raw_img.GetPixel(x, y);
                    //sqrt(x^2+y^2)
                    if (combine_all > 255)
                    {
                        img2.SetPixel(x, y, Color.FromArgb(255, 255, 255));

                    }
                    else
                    {
                        img4.SetPixel(x, y, Color.FromArgb(RGB.R, RGB.R, RGB.R));
                        //img2.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        img2.SetPixel(x, y, Color.FromArgb((int)combine_all, (int)combine_all, (int)combine_all));
                    }


                }
            }
            for (int y = 1; y < img2.Height - 1; y++)
            {
                for (int x = 1; x < img2.Width - 1; x++)
                {

                    Color RGB = img2.GetPixel(x, y);


                    if (RGB.R < Int32.Parse(textBox1.Text))
                    {
                        img3.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        //img4.SetPixel(x, y, Color.FromArgb(0, 255, 0));


                    }

                    else
                    {
                        //img3.SetPixel(x, y, Color.FromArgb(RGB.R, RGB.R, RGB.R));
                        img3.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        img4.SetPixel(x, y, Color.FromArgb(0, 255, 0));
                        //img4.SetPixel(x, y, Color.FromArgb(RGB.R, RGB.R, RGB.R));
                    }

                    //Gray_img.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }



            pictureBox2.Image = img2;
            pictureBox3.Image = img3;
            pictureBox4.Image = img4;
            pictureBox2.Visible = true;
            label2.Text = "The result of (5)";
            label2.Visible = true;
            pictureBox3.Visible = true;
            label3.Text = "The result after thresholding";
            label3.Visible = true;
            pictureBox4.Visible = true;
            label4.Text = "Overlap on the original image by green color";
            label4.Visible = true;
        }

        //Q7
        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox2.Image = raw_img;
            label3.Visible = false;
            pictureBox3.Visible = false;
            pictureBox3.Image = raw_img;
            label4.Visible = false;
            pictureBox4.Visible = false;
            pictureBox4.Image = raw_img;
            label5.Visible = false;
            pictureBox5.Visible = false;
            pictureBox5.Image = raw_img;
            pictureBox6.Visible = false;
            pictureBox6.Image = raw_img;
            label7.Visible = false;
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;

            //Rotation
            int degree = 330;
            
            Bitmap rotate = new Bitmap(raw_img.Width, raw_img.Height);
            
            for (int y = 0; y < raw_img.Height; y++)
            {
                for (int x = 0; x < raw_img.Width; x++)
                {
                    rotate.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }
            double x_center = (raw_img.Width - 1) * 0.5;
            double y_center = (raw_img.Height - 1) * 0.5;
            for (int y = 0; y < raw_img.Height; y++)
            {
                for (int x = 0; x < raw_img.Width; x++)
                {
                    double x_position = (double)x - x_center;
                    double y_position = (double)y - y_center;

                    double cos = Math.Cos(degree * Math.PI / 180);
                    double sin = Math.Sin(degree * Math.PI / 180);

                    double x_rotate = x_position * cos - y_position * sin + x_center;
                    double y_rotate = x_position * sin + y_position * cos + y_center;

                    if (x_rotate > 0 && x_rotate <= raw_img.Width && y_rotate > 0 && y_rotate <= raw_img.Height)
                        rotate.SetPixel(x, y, raw_img.GetPixel((int)x_rotate, (int)y_rotate));
                }
            }

            //Bitmap result = new Bitmap(raw_img.Width, raw_img.Height);
            ////init result to all black pixel
            //for (int y = 0; y < raw_img.Height; y++)
            //{
            //    for (int x = 0; x < raw_img.Width; x++)
            //    {
            //        result.SetPixel(x, y, Color.FromArgb(0, 0, 0));
            //    }
            //}
            //double x_center = (raw_img.Width - 1) * 0.5; //中心旋轉
            //double y_center = (raw_img.Height - 1) * 0.5;
            //for (int y = 0; y < raw_img.Height; y++)
            //{
            //    for (int x = 0; x < raw_img.Width; x++)
            //    {
            //        double a = (double)x-x_center;
            //        double b = (double)y-y_center;

            //        //float sin = (float)Math.Abs(Math.Sin(degree * Math.PI / 180.0)); // this function takes radians
            //        //float cos = (float)Math.Abs(Math.Cos(degree * Math.PI / 180.0)); // this one too

            //        double x_rotate = cos * a - sin * b + x_center;
            //        double y_rotate = sin * a + cos * b + y_center;
                    
            //        if (x_rotate > 0 && x_rotate <= raw_img.Width && y_rotate > 0 && y_rotate <= raw_img.Height)
            //            result.SetPixel(x, y, raw_img.GetPixel((int)x_rotate, (int)y_rotate));
            //    }
            //}
            


            pictureBox2.Image = rotate;
            pictureBox2.Visible = true;
            label2.Text = "Rotation";
            label2.Visible = true;


            //Stretching
            int width = 300;
            int height = 100;
            Bitmap img_s = new Bitmap(width, height);
            double x_s, y_s;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    x_s = (int)Math.Round((double)x / width * raw_img.Width);
                    y_s = (int)Math.Round((double)y / height * raw_img.Height);
                    
                    img_s.SetPixel(x, y, raw_img.GetPixel((int)x_s, (int)y_s));
                }
            }
            pictureBox6.Image = img_s;
            pictureBox6.Visible = true;
            label3.Text = "Stretching";
            label3.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
