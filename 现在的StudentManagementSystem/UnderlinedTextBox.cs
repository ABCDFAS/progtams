using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystem
{
    public class UnderlinedTextbox : UserControl
    {
        private TextBox textBox;
        private Label underlineLabel;

        public UnderlinedTextbox()
        {
            textBox = new TextBox();
            underlineLabel = new Label();

            this.Controls.Add(textBox);
            this.Controls.Add(underlineLabel);

            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Top;
            textBox.BackColor = Color.FromArgb(213, 188, 217);

            underlineLabel.Height = 2;
            underlineLabel.Dock = DockStyle.Bottom;
            underlineLabel.BackColor = Color.Black;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textBox.Height = this.Height - underlineLabel.Height;
        }

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public Color LineColor
        {
            get { return underlineLabel.BackColor; }
            set { underlineLabel.BackColor = value; }
        }

        public bool UseSystemPasswordChar
        {
            get { return textBox.UseSystemPasswordChar; }
            set { textBox.UseSystemPasswordChar = value; }
        }
    }
}
