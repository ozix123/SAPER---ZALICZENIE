namespace SAPER___ZALICZENIE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int poziom = 0;
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 GameWindow = new Form2(poziom);
            GameWindow.Show();
        }
       

        private void button3_Click(object sender, EventArgs e)
        {

            Application.Restart();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            poziom = listBox1.SelectedIndex;
            Console.WriteLine(poziom.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}