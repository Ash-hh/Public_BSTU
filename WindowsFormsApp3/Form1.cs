using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        const int  ScaleDistance= 10;

        public Form1()
        {
            InitializeComponent();
            
        }


        private void DrawXline(Point start, Point end, Graphics g)
        {
            g.DrawLine(Pens.Black, start, end);

            for (int i = ScaleDistance; i < end.X; i += ScaleDistance)
            {
                g.DrawLine(Pens.Black, i, -1, i, 1);
            }
            for (int i = -ScaleDistance; i > start.X; i -= ScaleDistance)
            {
                g.DrawLine(Pens.Black, i, -1, i, 1);
            }
        }

        private void DrawYline(Point start, Point end, Graphics g)
        {
            g.DrawLine(Pens.Black, start, end);

            for (int i = ScaleDistance; i < start.Y; i += ScaleDistance)
            {
                g.DrawLine(Pens.Black, -1, i, 1, i);
            }

            for (int i = -ScaleDistance; i > end.Y; i -= ScaleDistance)
            {
                g.DrawLine(Pens.Black, -1, i, 1, i);
            }
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            Graphics draw = pictureBox1.CreateGraphics();
           

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Введите А и B!!!");
                return;
            }
            int A = int.Parse(textBox1.Text), B = int.Parse(textBox2.Text);

            int[] pointsX,pointsY;
            int n = A*-1+B+1;            
            pointsX = new int[n];
            pointsY = new int[n];
            Point[] points = new Point[n];
            int i = 0;
            while(A<=B)
            {
                pointsX[i] = A;                
                i++;
                A++;                
            }                                    
            
            if (checkBox1.Checked == true)
            {
                Pen grn = new Pen(Color.Green, 3);
                int x, y;
               for ( i =0;i<n;i++)
               {
                    pointsY[i] = pointsX[i] * pointsX[i];
                    
                    x = 200 - (pointsX[i] * -10);
                    y = 200 - (pointsY[i] * 10);
                    points[i] = new Point(x, y);
               }
                draw.DrawCurve(grn, points);

            }
            if(checkBox2.Checked==true)
            {
                Pen red = new Pen(Color.Red, 3);
                int x, y;
                for (i = 0; i < n; i++)
                {
                    pointsY[i] = pointsX[i] * pointsX[i] * pointsX[i];

                    x = 200 - (pointsX[i] * -10);
                    y = 200 - (pointsY[i] * 10);
                    points[i] = new Point(x, y);
                }
                draw.DrawCurve(red, points);
            }
            if(checkBox3.Checked==true)
            {
                Pen blue = new Pen(Color.Blue, 3);
                int x, y;
                for (i = 0; i < n; i++)
                {
                    pointsY[i] = (2 * pointsX[i] * pointsX[i])-(5* pointsX[i])-11 ;

                    x = 200 - (pointsX[i] * -10);
                    y = 200 - (pointsY[i] * 10);
                    points[i] = new Point(x, y);
                }
                draw.DrawCurve(blue, points);
            }
            if(checkBox4.Checked==true)
            {
                Pen black = new Pen(Color.Black, 3);
                int x, y;
                for (i = 0; i < n; i++)
                {
                    pointsY[i] = Math.Abs(pointsX[i] * pointsX[i] * pointsX[i]);

                    x = 200 - (pointsX[i] * -10);
                    y = 200 - (pointsY[i] * 10);
                    points[i] = new Point(x, y);
                }
                draw.DrawCurve(black, points);
            }

            Console.WriteLine("ssss");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int width = pictureBox1.ClientSize.Width / 2;
            int heigh = pictureBox1.ClientSize.Height / 2;

            e.Graphics.TranslateTransform(width, heigh);

            DrawXline(new Point(-width, 0), new Point(width, 0), e.Graphics);
            DrawYline(new Point(0, heigh), new Point(0, -heigh), e.Graphics);

            e.Graphics.FillEllipse(Brushes.Red, -2, -2, 4, 4);
        }
    }
}
