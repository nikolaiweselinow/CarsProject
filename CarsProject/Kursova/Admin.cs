using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace Kursova
{//това е формата на Администратора, който може да си изтрива и блокира регистрираните потребители.
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string[] existingUsers = System.IO.File.ReadAllLines("users/users.txt");
            for (int i = 0; i < existingUsers.Length; i++)
            {
                listBox1.Items.Add(existingUsers[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Remove(listBox1.SelectedItem);
            
            
            StreamWriter sw = new StreamWriter("users/users.txt", false);
            
            
            foreach(String item in listBox1.Items)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            StreamWriter asd = new StreamWriter("users/blockedAccounts.txt", true);

            string[] blockedUsers = System.IO.File.ReadAllLines("users/users.txt");


            if (blockedUsers.Contains(listBox1.SelectedItem) != true) asd.WriteLine(listBox1.SelectedItem);
            
           asd.Close();
        }

       
    }
}
