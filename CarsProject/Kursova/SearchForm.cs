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
    public partial class SearchForm : Form
    {
         ArrayList SearchArray = new ArrayList();
         //от main form сме предали arraylist data и го слагаме в SearchArray
        public SearchForm(ArrayList Data)
        {
            InitializeComponent();
            this.SearchArray = Data;
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            
        }
        //при чекване показваме combobox отговарящ на checkbox и го пълним с информация
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox1.Visible = true;
                foreach (Cars car in SearchArray)
                {
                   string brand = car.Brand;
                   if (comboBox1.Items.Contains(brand))
                    {
                    }
                    else
                    {
                        comboBox1.Items.Add(brand);
                    }

                }
            }
            else comboBox1.Visible = false;
            
       
        }
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox2.Visible = true;
               
                foreach (Cars car in SearchArray)
                {
                    int yearValue = int.Parse(car.Year);
                    if (comboBox2.Items.Contains(yearValue))
                    {
                    }
                    else
                    {
                        comboBox2.Items.Add(yearValue);
                    }

                }

                
                
            }
            else comboBox2.Visible = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                
                comboBox3.Visible = true;               
             
                }
          
            else comboBox3.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm(SearchArray);
            about.Visible = true;
            this.Hide();
        }

        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceForm reference = new ReferenceForm(SearchArray);
            reference.Visible = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string brand = comboBox1.Text;
            string year = comboBox2.Text;
            string power = comboBox3.Text;
            //правим всички възможни проверки за комбинация от checkboxs и проверяваме кои обекти от classa cars отговарят на посочените критерии и ги визуализираме в datagridview1
            if ((checkBox1.Checked) && (checkBox2.Checked) && (checkBox3.Checked))
            {



                if (power != "")
                {
                    string[] intervaaal = power.Split('-');
                    string first = intervaaal[0].Trim();
                    int max = int.Parse(first);
                    string second = intervaaal[1].Trim();
                    int min = int.Parse(second);
                
                    ArrayList searchContent = new ArrayList();

                    foreach (Cars car in SearchArray)
                    {
                        int carPower = int.Parse(car.Moshtnost);
                        if ((carPower >= min) && (carPower <= max) && (car.Brand == brand) && (car.Year == year))
                        {
                            searchContent.Add(car);
                        }

                    }
                    dataGridView1.DataSource = searchContent;
            }
                
            }else if ((checkBox1.Checked) && (checkBox2.Checked)){
               
                    ArrayList searchContent1 = new ArrayList();
                   
                    foreach (Cars car in SearchArray)
                    {
                        
                        if ((car.Brand == brand) && (car.Year == year))
                        {
                            searchContent1.Add(car);
                        }

                    }
                    dataGridView1.DataSource = searchContent1;
                
            }
            else if ((checkBox1.Checked) && (checkBox3.Checked))
            {
                if (power != "")
                {
                    string[] intervaaal = power.Split('-');
                    string first = intervaaal[0].Trim();
                    int max = int.Parse(first);
                    string second = intervaaal[1].Trim();
                    int min = int.Parse(second);

                    ArrayList searchContent2 = new ArrayList();
                    foreach (Cars car in SearchArray)
                    {
                        int carPower = int.Parse(car.Moshtnost);
                        if ((carPower >= min) && (carPower <= max) && (car.Brand == brand))
                        {
                            searchContent2.Add(car);
                        }

                    }
                    dataGridView1.DataSource = searchContent2;
                }
            }
            else if ((checkBox2.Checked) && (checkBox3.Checked))
            {
                ArrayList searchContent3 = new ArrayList();
                if (power != "")
                {
                    string[] intervaaal = power.Split('-');
                    string first = intervaaal[0].Trim();
                    int max = int.Parse(first);
                    string second = intervaaal[1].Trim();
                    int min = int.Parse(second);
                    foreach (Cars car in SearchArray)
                    {
                        int carPower = int.Parse(car.Moshtnost);
                        if ((carPower >= min) && (carPower <= max) && (car.Year == year))
                        {
                            searchContent3.Add(car);
                        }

                    }
                    dataGridView1.DataSource = searchContent3;
                }
            }
            else if (checkBox1.Checked)
            {
                ArrayList searchContent4 = new ArrayList();
                foreach (Cars car in SearchArray)
                {
                    
                    if (car.Brand == brand)
                    {
                        searchContent4.Add(car);
                    }

                }
                dataGridView1.DataSource = searchContent4;
            }
            else if (checkBox2.Checked)
            {
                ArrayList searchContent5 = new ArrayList();
                foreach (Cars car in SearchArray)
                {

                    if ((car.Year == year))
                    {
                        searchContent5.Add(car);
                    }

                }
                dataGridView1.DataSource = searchContent5;
            }
            else if (checkBox3.Checked)
            {
                ArrayList searchContent6 = new ArrayList();
                
                if (power != "")
                {
                    string[] intervaaal = power.Split('-');
                    string first = intervaaal[0].Trim();
                    int max = int.Parse(first);
                    string second = intervaaal[1].Trim();
                    int min = int.Parse(second);
                    foreach (Cars car in SearchArray)
                    {
                        int carPower = int.Parse(car.Moshtnost);
                        if ((carPower >= min) && (carPower <= max))
                        {
                            searchContent6.Add(car);
                        }

                    }
                    dataGridView1.DataSource = searchContent6;
                }
            }
    }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
