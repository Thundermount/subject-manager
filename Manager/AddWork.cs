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
    public partial class AddWork : Form
    {
        string subject;
        public AddWork(string subject)
        {
            this.subject = subject;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Create(textBox1.Text);
            FileIO<Work> wk = new FileIO<Work>();
            Work work = new Work();
            work.name = textBox1.Text;
            work.state = State.NotReady;
            wk.Write("work.xml",work);
        }

        private void AddWork_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
