using System.Drawing.Drawing2D;

namespace NDP_Odev
{
    public partial class Form1 : Form
    {

        private bool isFirstChange = true;
        private string placeholderText = "Oyuncu Adý";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RoundButton(btnPlay);
            RoundButton(btnSkor);
            textBox1.Text = placeholderText;
            this.ActiveControl = btnPlay;
        }

        private void RoundButton(Button button)
        {
            int radius = 15;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            path.AddArc(0, 0, radius, radius, 180, 90); // Sol üst köþe
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90); // Sað üst köþe
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90); // Sað alt köþe
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90); // Sol alt köþe
            path.CloseFigure();

            button.Region = new Region(path);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isFirstChange)
            {
                if(textBox1.Text != placeholderText)
                {
                    isFirstChange = false;
                    textBox1.Text = "";
                }
            }

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == placeholderText)
            {
                MessageBox.Show("Lütfen bir oyuncu adý girin!");
                return;
            }

            GameScreen gameScreen = new GameScreen(textBox1.Text);
            this.Hide();
            gameScreen.ShowDialog();
            this.Show();

        }

        private void btnSkor_Click(object sender, EventArgs e)
        {
            HighScoreForm highScoreForm = new HighScoreForm();
            highScoreForm.ShowDialog();
        }

    }
}
