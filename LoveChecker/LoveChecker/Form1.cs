using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoveChecker
{
    public partial class Form1 : Form
    {
        private TableLayoutPanel tableLayoutPanel;
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
            this.Text = "💖 Love-O-Meter 💖";
            this.Size = new Size(400, 500); // Set a default size

            // Create the TableLayoutPanel
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
            };
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            // Create and configure controls
            name1TextBox = new TextBox { Dock = DockStyle.Fill, Font = new Font("Arial", 18, FontStyle.Bold), TextAlign = HorizontalAlignment.Center, Text = "Enter first name" };
            name2TextBox = new TextBox { Dock = DockStyle.Fill, Font = new Font("Arial", 18, FontStyle.Bold), TextAlign = HorizontalAlignment.Center, Text = "Enter second name" };
            calculateButton = new RoundButton { Dock = DockStyle.Fill, Text = "❤️", Font = new Font("Segoe UI Emoji", 48), FlatStyle = FlatStyle.Flat };
            calculateButton.FlatAppearance.BorderSize = 0;
            resultLabel = new Label { Dock = DockStyle.Fill, Text = "Enter two names to find out!", Font = new Font("Arial", 16, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };

            // Add controls to the TableLayoutPanel
            tableLayoutPanel.Controls.Add(name1TextBox, 0, 0);
            tableLayoutPanel.Controls.Add(name2TextBox, 0, 1);
            tableLayoutPanel.Controls.Add(calculateButton, 0, 2);
            tableLayoutPanel.Controls.Add(resultLabel, 0, 3);

            // Add the TableLayoutPanel to the form
            this.Controls.Add(tableLayoutPanel);

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
