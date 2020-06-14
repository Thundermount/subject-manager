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
        int id;
        Work work;
        string work_file;
        public AddWork(string subject)
        {
            work_file = "./root/" + subject + "/works.xml";
            this.subject = subject;
            InitializeComponent();
            button1.Text = "Добавить";
            this.Text = "Добавить работу";
        }
        // This one is used only if changing work
        public AddWork(string subject, int work_id)
        {
            work_file = "./root/" + subject + "/works.xml";
            this.subject = subject;
            id = work_id;
            FileIO<Work> wk = new FileIO<Work>();
            List<Work> works = wk.Read(work_file);
            work = works[id];
            InitializeComponent();
            textBox1.Text = work.name;
            comboBox1.SelectedIndex = (int) work.state;
            button1.Text = "Изменить";
            this.Text = "Изменить работу";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (work == null) Add_Work();
            else Change_Work();
        }
        // Creates new work in file
        private void Add_Work()
        {
            FileIO<Work> wk = new FileIO<Work>();
            Work add_work = new Work();
            add_work.name = textBox1.Text;
            add_work.state = (State) comboBox1.SelectedIndex;
            File.Create("./root/" + subject + "/" + add_work.name);
            wk.Write(work_file,add_work);
            MessageBox.Show("Работа добавлена");
            this.Close();
        }
        // Changes existing work
        private void Change_Work()
        {
            Work change_work = new Work();
            change_work.name = textBox1.Text;
            change_work.state = (State)comboBox1.SelectedIndex;
            File.Move("./root/" + subject + "/" + work.name, "./root/" + subject + "/" + change_work.name);
            FileIO<Work> wk = new FileIO<Work>();
            wk.RemoveId(work_file, id);
            wk.Write(work_file,change_work);
            MessageBox.Show("Изменения успешно выполнены");
            this.Close();
        }

        private void AddWork_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        
    }
}
