# Разработка простого телефонного справочника

**Цель работы:** научиться использовать коллекции (**List**) и классы

## Телефонный справочник

Необходимо разработать простое приложение типа **Windows Forms**, представляющее телефонную записную книжку.


## Внешний вид приложения




## Прототип

В качестве прототипа можно использовать следующий код:

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;


namespace AddressBook
{
    public partial class AddressBook : Form
    {
        public AddressBook()
        {
            InitializeComponent();
        }

        List<Person> people = new List<Person>();

        private void AddressBook_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + "\\Address Book - Joe"))
                Directory.CreateDirectory(path + "\\Address Book - Joe");
            if (!File.Exists(path + "\\Address Book - Joe\\settings.xml"))
                File.Create((path + "\\Address Book - Joe\\settings.xml"));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.FirstName = txtFName.Text;
            p.Address = txtAddress.Text;
            p.City = txtCity.Text;
            p.State = comboState.Text;
            p.ZipCode = txtZip.Text;
            p.Email = txtEmail.Text;
            p.PhoneNumber = txtPhone.Text;
            p.Additional = rtxtAdd.Text;
            people.Add(p);
            listView1.Items.Add(p.FirstName);
            txtFName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            comboState.Text = "";
            txtZip.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            rtxtAdd.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFName.Text = people[listView1.SelectedItems[0].Index].FirstName;
            txtAddress.Text = people[listView1.SelectedItems[0].Index].Address;
            txtCity.Text = people[listView1.SelectedItems[0].Index].City;
            comboState.Text = people[listView1.SelectedItems[0].Index].State;
            txtZip.Text = people[listView1.SelectedItems[0].Index].ZipCode;
            txtEmail.Text = people[listView1.SelectedItems[0].Index].Email;
            txtPhone.Text = people[listView1.SelectedItems[0].Index].PhoneNumber;
            txtZip.Text = people[listView1.SelectedItems[0].Index].ZipCode;
            rtxtAdd.Text = people[listView1.SelectedItems[0].Index].Additional;

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Additional { get; set; }
    }
}
```

