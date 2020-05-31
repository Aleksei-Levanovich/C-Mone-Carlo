using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public partial class Form1 : Form
    {
        string series0Name = "f(x)";
        string series1Name = "g(x)";
        double fxMin = -Math.PI / 2;
        double fxMax = 0;
        double gxMin = -3;
        double gxMax = 3;
        int fR = 0;
        int fG = 0;
        int fB = 255;
        int gR = 255;
        int gG = 0;
        int gB = 0;
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Series.Add(series0Name);
            chart1.Series.Add(series1Name);
            chart1.Series[series0Name].ChartType = SeriesChartType.Spline;
            chart1.Series[series1Name].ChartType = SeriesChartType.Spline;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            textBox2.Text = "1";
            textBox3.Text = "1000000";
            numericUpDown1.Value = fR;
            numericUpDown2.Value = fG;
            numericUpDown3.Value = fB;
            numericUpDown4.Value = gB;
            numericUpDown5.Value = gG;
            numericUpDown6.Value = gR;
            double fx = fxMin;
            chart1.ChartAreas[0].AxisX.Minimum = -3;
            chart1.ChartAreas[0].AxisX.Maximum = 3;
            while (fx<fxMax)
            {
                double y = fX(fx);
                chart1.Series[series0Name].Points.AddXY(fx, y);
                chart1.Series[series0Name].Color = Color.FromArgb(fR, fG, fB);
                chart1.Series[series0Name].BorderWidth = Int32.Parse(textBox1.Text);
                fx += 0.001;
            }

            double gx = gxMin;
            while (gx < gxMax)
            {
                double y = gX(gx);
                chart1.Series[series1Name].Points.AddXY(gx, y);
                chart1.Series[series1Name].Color = Color.FromArgb(gR, gG, gB);
                chart1.Series[series1Name].BorderWidth = Int32.Parse(textBox2.Text);
                gx += 0.001;
            }
            label1.Text = MCint(fxMin, fxMax, Int32.Parse(textBox3.Text), 0).ToString();
            label2.Text = MCint(gxMin, gxMax, Int32.Parse(textBox3.Text), 1).ToString();
        }

        private double fX(double x) {
            return (x - 1) * Math.Sin(x) - x - 1;
        }

        private double gX(double x)
        {
            return 2 * x * x * x + 3 * x * x - 12 * x - 8;
        }

        private double MCint(double a, double b, double n, int fg) {
            double s = 0;
            Random rnd = new Random();
            for (int i = 0; i < n; i++) {
                double x = rnd.NextDouble();
                x = a + x * (b - a);
                if (fg == 0) {
                    s += fX(x);
                } else if (fg == 1)
                {
                    s += gX(x);
                }
            }  
            return (b-a)/n*s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
                try
                {
                    int width = Int32.Parse(textBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Not Valid Value");
                    textBox1.Text = "1";
                }
                chart1.Series[0].BorderWidth = Int32.Parse(textBox1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    int width = Int32.Parse(textBox2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Not Valid Value");
                    textBox2.Text = "1";
                }
                chart1.Series[series1Name].BorderWidth = Int32.Parse(textBox2.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                   int n = Int32.Parse(textBox2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Not Valid Value");
                    textBox3.Text = "100000";
                }
                label1.Text = MCint(fxMin, fxMax, Int32.Parse(textBox3.Text), 0).ToString();
                label2.Text = MCint(gxMin, gxMax, Int32.Parse(textBox3.Text), 1).ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fR = (int) numericUpDown1.Value;
            chart1.Series[series0Name].Color = Color.FromArgb(fR, fG, fB);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            fG = (int)numericUpDown2.Value;
            chart1.Series[series0Name].Color = Color.FromArgb(fR, fG, fB);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            fB = (int)numericUpDown3.Value;
            chart1.Series[series0Name].Color = Color.FromArgb(fR, fG, fB);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            gR = (int)numericUpDown6.Value;
            chart1.Series[series1Name].Color = Color.FromArgb(gR, gG, gB);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            gG = (int)numericUpDown5.Value;
            chart1.Series[series1Name].Color = Color.FromArgb(gR, gG, gB);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            gB = (int)numericUpDown4.Value;
            chart1.Series[series1Name].Color = Color.FromArgb(gR, gG, gB);
        }
    }
}
