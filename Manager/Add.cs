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
            if (!Directory.Exists("./root"))
            {
                Directory.CreateDirectory("./root");
            }
            Directory.CreateDirectory("./root/" + sb.Subject_Name);
            XmlSerializerNamespaces sr = new XmlSerializerNamespaces();
            StreamWriter tw = new StreamWriter("./root/subjects.xml");
            sr.Add("","");
            new XmlSerializer(typeof(Subject)).Serialize(tw, sb,sr);
            tw.Close();
        }
    }
}
