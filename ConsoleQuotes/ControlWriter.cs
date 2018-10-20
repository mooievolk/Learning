using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleQuotes
{
    public class ControlWriter : TextWriter
    {

        private Control richTextBox1;

        public ControlWriter(Control richTextBox1)
        {
            this.richTextBox1 = richTextBox1;
        }

        public override void Write(char value)
        {
            richTextBox1.Text += value;
        }

        public override void Write(string value)
        {
            richTextBox1.Text += value;
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }

}
