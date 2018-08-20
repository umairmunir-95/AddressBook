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
namespace Address_Book_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Person> people = new List<Person>();
        private void Form1_Load(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + "\\AddressBook-Umair"))
            {
                Directory.CreateDirectory(path + "\\AddressBook-Umair");
            }
            if (!File.Exists(path + "\\AddressBook-Umair\\settings.xml"))
            {
                File.Create(path + "\\AddressBook-Umair\\settings.xml");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.full_name = textBox1.Text;
            p.additional_notes = textBox2.Text;
            p.street_address = textBox3.Text;
            p.email = textBox4.Text;
            p.birthday = dateTimePicker1.Value;
            people.Add(p);
            listView1.Items.Add(p.full_name);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = people[listView1.SelectedItems[0].Index].full_name;
            textBox2.Text = people[listView1.SelectedItems[0].Index].additional_notes;
            textBox3.Text = people[listView1.SelectedItems[0].Index].street_address;
            textBox4.Text = people[listView1.SelectedItems[0].Index].email;
            dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].birthday;
        }
        class Person
        {
            public string full_name
            {
                get;
                set;
            }
            public string email
            {
                get;
                set;
            }
            public string street_address
            {
                get;
                set;
            }
            public string additional_notes
            {
                get;
                set;
            }
            public DateTime birthday
            {
                get;
                set;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            remove();
        }
        void remove()
        {
            try
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                people.RemoveAt(listView1.SelectedItems[0].Index);
            }
            catch
            {

            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remove();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            people[listView1.SelectedItems[0].Index].full_name = textBox1.Text;
            people[listView1.SelectedItems[0].Index].additional_notes = textBox2.Text;
            people[listView1.SelectedItems[0].Index].street_address = textBox3.Text;
            people[listView1.SelectedItems[0].Index].email = textBox4.Text;
            people[listView1.SelectedItems[0].Index].birthday = dateTimePicker1.Value;
            listView1.SelectedItems[0].Text = textBox1.Text;
        }
    }
}
