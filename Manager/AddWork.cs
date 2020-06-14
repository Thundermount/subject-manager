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
            work_file = "./root/" + subject + "/work.xml";
            this.subject = subject;
            InitializeComponent();
            button1.Text = "Добавить";
            this.Text = "Добавить работу";
        }
        // This one is used only if changing work
        public AddWork(string subject, int work_id)
        {
            work_file = "./root/" + subject + "/work.xml";
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
            
        }
        // Creates new work in file
        private void Add_Work()
        {
            File.Create(textBox1.Text);
            FileIO<Work> wk = new FileIO<Work>();
            Work work = new Work();
            work.name = textBox1.Text;
            work.state = (State) comboBox1.SelectedIndex;
            wk.Write(work_file,work);
            MessageBox.Show("Работа добавлена");
            this.Close();
        }
        // Changes existing work
        private void Change_Work()
        {
            Work work = new Work();
            work.name = textBox1.Text;
            work.state = (State)comboBox1.SelectedIndex;
            File.Move(work.name, work.name);
            FileIO<Work> wk = new FileIO<Work>();
            wk.RemoveId(work.name, id);
            wk.Write(work_file,work);
            MessageBox.Show("Изменения успешно выполнены");
            this.Close();
        }

        private void AddWork_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        
    }
}
