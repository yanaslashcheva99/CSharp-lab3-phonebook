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
using System.Web;
using Newtonsoft.Json;


namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<PersonTuples> People = new List<PersonTuples>();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\lab3\\lab3\\json1.json") == true)
            {
                PersonTuples p = new PersonTuples();
                string stringList = File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\lab3\\lab3\\json1.json");
                PersonList PERSONLIST = JsonConvert.DeserializeObject<PersonList>(File.ReadAllText("C:\\Users\\Яна\\Documents\\Visual Studio 2015\\Projects\\lab3\\lab3\\json1.json"));
                foreach(var PersonTuples in PERSONLIST.BestFriends)
                {
                    listView1.Items.Add(PersonTuples.FirstName);
                    People.Add(PersonTuples);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
            else
            { 
                textBox1.Text = People[listView1.SelectedItems[0].Index].FirstName;
                textBox2.Text = People[listView1.SelectedItems[0].Index].Address;
                textBox3.Text = People[listView1.SelectedItems[0].Index].PhoneNumber;
                textBox4.Text = People[listView1.SelectedItems[0].Index].Email;
                textBox5.Text = People[listView1.SelectedItems[0].Index].Additional;
                //dateTimePicker1.Value = People[listView1.SelectedItems[0].Index].Birthday;
            }
        }

        void Remove()
        {
            try
            {
                People.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
           catch { }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                People[listView1.SelectedItems[0].Index].FirstName = textBox1.Text;
                People[listView1.SelectedItems[0].Index].Address = textBox2.Text;
                People[listView1.SelectedItems[0].Index].PhoneNumber = textBox3.Text;
                People[listView1.SelectedItems[0].Index].Email = textBox4.Text;
                People[listView1.SelectedItems[0].Index].Additional = textBox5.Text;
                People[listView1.SelectedItems[0].Index].Birthday = dateTimePicker1.Value;
                listView1.SelectedItems[0].Text = textBox1.Text;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonTuples p = new PersonTuples();
            p.FirstName = textBox1.Text;
            p.Address = textBox2.Text;
            p.PhoneNumber = textBox3.Text;
            p.Email = textBox4.Text;
            p.Additional = textBox5.Text;
            p.Birthday = dateTimePicker1.Value;
            People.Add(p);
            listView1.Items.Add(p.FirstName);
            textBox1.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove();
        }

    }
}
