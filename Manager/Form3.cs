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
    public partial class Form3 : Form
    {
        int id;
        Subject record;
        string subject_folder;
        public Form3(int subject_id)
        {
            id = subject_id;
            InitializeComponent();
            FileIO<Subject> fl = new FileIO<Subject>();
            record = fl.Read(Form2.subject_f)[id];
            subject_folder = "./root/" + record.Subject_Name;
            this.Name = record.Subject_Name;
            if (!Directory.Exists(subject_folder)) Directory.CreateDirectory(subject_folder);
        }

        private void UpdateList()
        {
            FileIO<Work> fl = new FileIO<Work>();
            List<Work> wk = fl.Read(subject_folder + "/Works.xml");
            foreach (var item in wk)
            {
                listBox1.Items.Add(item.name);
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
