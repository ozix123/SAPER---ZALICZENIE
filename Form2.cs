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
        public bool przegrana = false;
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
                        btnTemp.FlatStyle = FlatStyle.Flat;
                        btnTemp.FlatAppearance.CheckedBackColor = Color.Silver;
                        btnTemp.FlatAppearance.MouseDownBackColor = Color.Silver;
                        btnTemp.FlatAppearance.MouseOverBackColor = Color.Silver;
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
                        btnTemp.FlatStyle = FlatStyle.Flat;
                        btnTemp.FlatAppearance.CheckedBackColor = Color.Silver;
                        btnTemp.FlatAppearance.MouseDownBackColor = Color.Silver;
                        btnTemp.FlatAppearance.MouseOverBackColor = Color.Silver;
                    }
                    timer1.Enabled = true;
                    break;
                case 2:
                    int[] minah = new int[24];
                    for (int i = 0; i < 24; i++)
                    {
                        minah[i] = rdn.Next((5 * i) + 1, (5 * i) + 5);
                    }
                    for (int i = 0; i < 120; i++)
                    {
                        Button btnTemp = new Button();
                        btnTemp.Cursor = System.Windows.Forms.Cursors.Arrow;
                        btnTemp.Name = "btnTemp" + i.ToString();
                        btnTemp.Size = new System.Drawing.Size(40, 40);
                        btnTemp.UseVisualStyleBackColor = true;
                        flowLayoutPanel1.Controls.Add(btnTemp);
                        flowLayoutPanel1.Size = new System.Drawing.Size(570, 470);
                        btnTemp.Click += BtnTemp_Click;
                        btnTemp.Tag = false;
                        for (int ii = 0; ii < 24; ii++)
                        {
                            if (i == minah[ii]) btnTemp.Tag = true;
                        }
                        btnTemp.FlatStyle = FlatStyle.Flat;
                        btnTemp.FlatAppearance.CheckedBackColor = Color.Silver;
                        btnTemp.FlatAppearance.MouseDownBackColor = Color.Silver;
                        btnTemp.FlatAppearance.MouseOverBackColor = Color.Silver;
                    }
                    timer1.Enabled = true;
                    break;
            }
            }
        public void BtnTemp_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            bool tag = (bool)btnTemp.Tag;
            if (przegrana == true)
            {
                btnTemp.Enabled = false;
            }
            else
            {
                if (tag)
                {
                    btnTemp.BackColor = Color.Red;
                    int score = int.Parse(label4.Text);
                    score++;
                    label4.Text = score.ToString();
                    timer1.Enabled = false;
                    przegrana = true;
                    btnTemp.BackgroundImageLayout = ImageLayout.Stretch;
                    btnTemp.BackgroundImage = global::SAPER___ZALICZENIE.Properties.Resources.bomba;

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
                    btnTemp.Enabled=false;
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
