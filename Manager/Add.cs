using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Manager
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject sb = new Subject();
            sb.Subject_Name = textBox1.Text;
            sb.Teacher = textBox2.Text;
            FileIO<Subject> wr = new FileIO<Subject>();
            wr.Write(Form2.subject_f, sb);
        }
    }
}
