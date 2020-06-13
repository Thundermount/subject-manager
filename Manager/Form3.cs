using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class Form3 : Form
    {
        int id;
        Subject record;
        public Form3(int subject_id)
        {
            id = subject_id;
            InitializeComponent();
            FileIO<Subject> fl = new FileIO<Subject>();
            record = fl.Read(Form2.subject_f)[id];
            this.Name = record.Subject_Name;
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
