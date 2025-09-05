using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoveChecker
{
    public partial class Form1 : Form
    {
        private TextBox name1TextBox;
        private TextBox name2TextBox;
        private Button calculateButton;
        private Label resultLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeLoveCheckerControls();
        }

        private void InitializeLoveCheckerControls()
        {
            // Create and configure controls
            this.Text = "Love Compatibility Checker";
            name1TextBox = new TextBox { Location = new Point(10, 10), Width = 200, Text = "Enter first name" };
            name2TextBox = new TextBox { Location = new Point(10, 40), Width = 200, Text = "Enter second name" };
            calculateButton = new Button { Text = "Calculate", Location = new Point(10, 70) };
            resultLabel = new Label { Text = "Result: ", Location = new Point(10, 110), Width = 200 };

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
            string name1 = name1TextBox.Text;
            string name2 = name2TextBox.Text;

            if (string.IsNullOrWhiteSpace(name1) || string.IsNullOrWhiteSpace(name2) || name1 == "Enter first name" || name2 == "Enter second name")
            {
                MessageBox.Show("Please enter both names.");
                return;
            }

            int sum1 = 0;
            foreach (char c in name1)
            {
                sum1 += (int)c;
            }

            int sum2 = 0;
            foreach (char c in name2)
            {
                sum2 += (int)c;
            }

            int compatibility = (sum1 + sum2) % 101;

            resultLabel.Text = $"Compatibility: {compatibility}%";
        }
    }
}
