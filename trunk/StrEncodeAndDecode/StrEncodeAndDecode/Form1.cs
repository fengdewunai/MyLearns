using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrEncodeAndDecode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.SystemColors.Control;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                string result = text.UrlEncode();
                this.textBox2.Text = result;
            }
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                var result = text.UrlDecode<int>();
                this.textBox2.Text = result.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
