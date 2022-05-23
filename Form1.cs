namespace SAPER___ZALICZENIE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int poziom = 0;
        static int sec = 0;
        static int min = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            sec = 0;
            min = 0;
            Random rdn = new Random();
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
        }
        private void BtnTemp_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Przegra³eœ!", "Wynik:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}