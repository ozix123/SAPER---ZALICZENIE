using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPER___ZALICZENIE
{
    public partial class Form2 : Form
    {
        static int sec = 0;
        static int min = 0;
        string[] levelName = {"łatwy", "średni", "trudny"};
        public Form2(int poziom)
        {
            InitializeComponent();
            label6.Text = levelName[poziom];
            GeneratorPlanszy(poziom);
        }
        public void GeneratorPlanszy(int poziom)
        {
            sec = 0;
            min = 0;
            Random rdn = new Random();
            switch (poziom)
            {
                case 0:
                default:
                    int x = rdn.Next(1, 12);
                    int y = rdn.Next(13, 18);
                    int z = rdn.Next(19, 25);

                    for (int i = 1; i <= 25; i++)
                    {
                        Button btnTemp = new Button();
                        btnTemp.Cursor = System.Windows.Forms.Cursors.Arrow;
                        btnTemp.Name = "btnTemp" + i.ToString();
                        btnTemp.Size = new System.Drawing.Size(40, 40);
                        btnTemp.UseVisualStyleBackColor = true;
                        flowLayoutPanel1.Controls.Add(btnTemp);
                        btnTemp.Click += BtnTemp_Click;
                        if (x == i || y == i || z == i)
                            btnTemp.Tag = true;
                        else
                            btnTemp.Tag = false;

                    }
                    timer1.Enabled = true;
                    break;
                case 1:
                    int[] mina = new int[10];
                    for (int i = 0; i < 10; i++)
                    {
                        mina[i] = rdn.Next((8 * i) + 1, (8 * i) + 8);
                    }
                    for (int i = 0; i < 80; i++)
                    {
                        Button btnTemp = new Button();
                        btnTemp.Cursor = System.Windows.Forms.Cursors.Arrow;
                        btnTemp.Name = "btnTemp" + i.ToString();
                        btnTemp.Size = new System.Drawing.Size(40, 40);
                        btnTemp.UseVisualStyleBackColor = true;
                        flowLayoutPanel1.Controls.Add(btnTemp);
                        flowLayoutPanel1.Size = new System.Drawing.Size(500, 370);
                        btnTemp.Click += BtnTemp_Click;
                        btnTemp.Tag = false;
                        for (int ii = 0; ii < 10; ii++)
                        {
                            if (i == mina[ii]) btnTemp.Tag = true;
                        }
                    }
                    timer1.Enabled = true;
                    break;
            }
            }
        public void BtnTemp_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            bool tag = (bool)btnTemp.Tag;

            if (tag)
            {
                btnTemp.BackColor = Color.Red;
                int score = int.Parse(label4.Text);
                score++;
                label4.Text = score.ToString();

                if (score == 1)
                {
                    MessageBox.Show("Przegrałeś!", "Wynik:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                btnTemp.BackColor = Color.Green;
                int score = int.Parse(label3.Text);
                score++;
                label3.Text = score.ToString();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 60)
            {
                sec = 0;
                min++;
            }
            labeltimer.Text = Convert.ToString(min) + " : " + Convert.ToString(sec);
        }
    }
}
