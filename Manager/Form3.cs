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
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Manager
{
    public partial class Form3 : Form
    {
        int id;
        Subject record;
        string subject_folder;
        string filename;
        public Form3(int subject_id)
        {
            id = subject_id;
            InitializeComponent();
            FileIO<Subject> fl = new FileIO<Subject>();
            record = fl.Read(Form2.subject_f)[id];
            subject_folder = "./root/" + record.Subject_Name;
            this.Name = record.Subject_Name;
            filename = subject_folder + "/works.xml";
            if (!Directory.Exists(subject_folder)) Directory.CreateDirectory(subject_folder);
        }

        private void UpdateList()
        {
            listBox1.Items.Clear();
            FileIO<Work> s = new FileIO<Work>();
            List<Work> wk = s.Read(filename);
            if (wk == null) return;
            foreach (var item in wk)
            {
                this.listBox1.Items.Add(new Dictionary<string, object> { { "Text", item.name + "    " + Work.StateStrings[((int)item.state)]},
                                                         { "ForeColor", Work.StateColors[(int)item.state]}});
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddWork(record.Subject_Name).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            new AddWork(record.Subject_Name, listBox1.SelectedIndex).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            FileIO<Work> fl = new FileIO<Work>();
            List<Work> works = fl.Read(subject_folder + "/works.xml");
            File.Delete(subject_folder + "/" + works[listBox1.SelectedIndex].name);
            fl.RemoveId(subject_folder + "/works.xml", listBox1.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.GetFullPath(subject_folder));
        }
    }
}
