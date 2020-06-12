using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Manager
{
    public partial class Form2 : Form
    {
        public const string subject_f = "./root/subjects.xml";
        public Form2()
        {
            InitializeComponent();
            if (!Directory.Exists("./root")) Directory.CreateDirectory("root");
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Add().Show();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            FileIO<Subject[]> s = new FileIO<Subject[]>();
            Subject[] subjects = s.Read(subject_f);
            if (subjects == null) return;
            foreach (var item in subjects)
            {
                listBox1.Items.Add(item.Subject_Name + "    " + item.Teacher);
            }
        }
    }
}
