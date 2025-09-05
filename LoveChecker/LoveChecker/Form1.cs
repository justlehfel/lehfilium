using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoveChecker
{
    public partial class Form1 : Form
    {
        private TextBox name1TextBox;
        private TextBox name2TextBox;
        private RoundButton calculateButton;
        private Label resultLabel;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeLoveCheckerControls();
        }

        private void InitializeLoveCheckerControls()
        {
            // Create and configure controls
            this.Text = "💖 Love-O-Meter 💖";
            name1TextBox = new TextBox { Location = new Point(10, 10), Width = 200, Text = "Enter first name" };
            name2TextBox = new TextBox { Location = new Point(10, 40), Width = 200, Text = "Enter second name" };
            calculateButton = new RoundButton { Text = "❤️", Location = new Point(80, 70), Width = 80, Height = 80, Font = new Font("Segoe UI Emoji", 24) };
            resultLabel = new Label { Text = "Enter two names to find out!", Location = new Point(10, 160), Width = 240, Font = new Font("Arial", 12, FontStyle.Bold) };

            // Add controls to the form
            this.Controls.Add(name1TextBox);
            this.Controls.Add(name2TextBox);
            this.Controls.Add(calculateButton);
            this.Controls.Add(resultLabel);

            // Attach event handler
            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            string name1 = name1TextBox.Text.Trim();
            string name2 = name2TextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name1) || string.IsNullOrWhiteSpace(name2) || name1.ToLower() == "enter first name" || name2.ToLower() == "enter second name")
            {
                MessageBox.Show("Please enter both names.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int compatibility;

            string lowerName1 = name1.ToLower();
            string lowerName2 = name2.ToLower();

            if ((lowerName1 == "thomas" && lowerName2 == "alana") || (lowerName1 == "alana" && lowerName2 == "thomas"))
            {
                compatibility = 100;
            }
            else
            {
                compatibility = random.Next(0, 101);
            }

            resultLabel.Text = $"💖 Compatibility: {compatibility}% 💖";
        }
    }
}
