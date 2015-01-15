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
{
    public partial class MainForm : Form
    {
        ArrayList Data = new ArrayList();
        public MainForm()
        {
            InitializeComponent();
            
            
        }
        //изход от приложението
        private void izhodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Искате ли да затворите приложението", "Изход от приложението", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { Application.Exit(); }
        }

        
        //зареждане на формата
        private void MainForm_Load(object sender, EventArgs e)
        {
            //четене на данни от файл
            string[] lines = System.IO.File.ReadAllLines("katalog.txt");
            for (int i = 0; i < lines.Length; i++)
            {

                string[] words = lines[i].Split('/');
                int a = words.Length;

                Data.Add(new Cars
                {
                    Brand = words[0],
                    Model = words[1],
                    Year = words[2],
                    Kubatura = words[3],
                    Moshtnost = words[4],
                    TipDvigatel = words[5],
                    VidKupe = words[6],
                    Ekstri = words[7],
                    Cena = words[8],
                });
            }
            this.Hide();
            Intro begin = new Intro();
            begin.ShowDialog();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
          //четем от файл и проверяваме дали има съществуващ акаунт
            string[] users = System.IO.File.ReadAllLines("users/users.txt");
            string[] blocked = System.IO.File.ReadAllLines("users/blockedAccounts.txt");
            int usersLength = users.Length;
            int match = 0;
            for (int i = 0; i < usersLength; i++)
            {
                string[] namepass = users[i].Split(',');
                if ((usernameBox.Text == namepass[0]) && (passwordBox.Text == namepass[1]))
                {
                    match++;           
                };
                
                
            }
            if (blocked.Contains(usernameBox.Text + "," + passwordBox.Text)) match = 0;
            if (match > 0)
            {
                
                loginPanel.Visible = false;
                menuStrip1.Visible = true;
               
                
            }else{
                    if  (MessageBox.Show("Wrong username or password", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK) ;
                }


                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {//проверяваме дали има такъв потребител
            string[] existingUsers = System.IO.File.ReadAllLines("users/users.txt");
            int usersLength = existingUsers.Length;
            int userMatch = 0;
            for (int i = 0; i < usersLength; i++)
            {
                string[] userCheck = existingUsers[i].Split(',');
                if ((userRegistration.Text == userCheck[0]) )
                {
                    userMatch = 0;
                    userMatch++;
                };

            }

            int passLength = 0;
            passLength = passRegistration.Text.Length;
            int userLength = 0;
            userLength = userRegistration.Text.Length;
            //проверка за въведените данни
            if (passLength < 6) {
                if (MessageBox.Show("Паролата трябва да съдържа минимум 6 символа", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
            }
            else if (userLength < 1)      
            {
              if  (MessageBox.Show("Въведете username", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
            }
            else if (passRegistration.Text != conPassRegistration.Text)      
            {
              if  (MessageBox.Show("Въведените пароли не съвпадат", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) ;
            }
            else if (userMatch > 0)
            {
               if (MessageBox.Show("Има вече потребител с такъв username", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK);
            }
                //записваме регистрирания потребител
            else {
                string user = userRegistration.Text;
                string pass = passRegistration.Text;
                string acc = user + ',' + pass;
                StreamWriter sw = new StreamWriter("users/users.txt", true);
                sw.WriteLine(acc);
                sw.Close();
                loginPanel.Visible = true;
                makeAccoutButton.Visible = false;
                accountPanel.Visible = false;
            }
            
            
           
        }
        //отваряме панела за регистрация
        private void makeAccoutButton_Click(object sender, EventArgs e)
        {                 
            loginPanel.Visible = false;
            accountPanel.Visible = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = true;
            accountPanel.Visible = false;
        }
        //скриваме паролата с "*"
        private void hideChar_CheckedChanged(object sender, EventArgs e)
        {
            if (hideChar.Checked) passwordBox.PasswordChar = '*';
            else passwordBox.PasswordChar='\0';
        }
        //часовник
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss tt");
            label1.Text = time;
            
        }
        //проверяваме администраторската парола
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (adminPass.Text == "admin1")
            {
                Admin admin = new Admin();
                admin.Visible = true;
                this.Hide();
            }
            else
            {
                if (MessageBox.Show("Wrong admin password", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK) ;
            }
                   }

       
        //отваряме формата със справки
        private void spravkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceForm reference = new ReferenceForm(Data);
            reference.Visible = true;
            this.Hide();
        }
        //отваряме формата About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm(Data);
            about.Visible = true;
            this.Hide();
        }
        //отваряме формата за търсене
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(Data);
            search.Visible = true;
            this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
