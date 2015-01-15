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
    public partial class ReferenceForm : Form
    {
        ArrayList PowerArray = new ArrayList();
        //от main form сме предали arraylist data и го слагаме в powerarray
        public ReferenceForm(ArrayList Data)
        {
            
            InitializeComponent();
            this.PowerArray = Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {//проверяваме дали by year e чекнато
            if (radioButton1.Checked)
            {

                label1.Visible = true;
                label1.Text = "Total cars by selected Year";
                
               
                string selectedYear = comboBox1.Text;
                int br = 0;
                ArrayList yearArrayList = new ArrayList();
                foreach (Cars car in PowerArray)
                {
                    if (car.Year == selectedYear) {
                        yearArrayList.Add(car);
                        br ++;
                    }
                }
                dataGridView1.DataSource = yearArrayList;
                PriceOfAllCars.Text = br.ToString();
                PriceOfAllCars.Visible = true;
                
             }else if (radioButton2.Checked)
            {//проверяваме дали by Price Of All Cars e чекнато
                label1.Visible = true;
                label1.Text = "Total Price Of All Cars";
                PriceOfAllCars.Visible = true;
                 
                int totalPrice = 0;
                foreach (Cars car in PowerArray)
                {
                   int price =  int.Parse(car.Cena);
                   totalPrice += price;
                }
                PriceOfAllCars.Text = totalPrice.ToString();
                label1.Visible = true;
            }
            else if (radioButton3.Checked)
            {//проверяваме дали by Power e чекнато
                label1.Visible = true;
                label1.Text = "Total cars by selected Power";
                int brr = 0 ;
                
                string interval = comboBox2.Text;
                if (interval != "")
                {//раздяляме текста в combobox2 с "-" и получаваме две стойности(max min) и после проверяваме дали power на дадения обект от class car е в даден интервал
                    string[] intervaaal = interval.Split('-');
                    string first = intervaaal[0].Trim();
                    int max = int.Parse(first);
                    string second = intervaaal[1].Trim();
                    int min = int.Parse(second);
                    ArrayList powerArrayList = new ArrayList();
                    
                    foreach (Cars car in PowerArray)
                    {
                        int carPower = int.Parse(car.Moshtnost);
                        if ((carPower >= min) && (carPower <= max))
                        {
                            powerArrayList.Add(car);
                            brr++;
                        }
                    }
                    dataGridView1.DataSource = powerArrayList;
                    PriceOfAllCars.Text = brr.ToString();
                    PriceOfAllCars.Visible = true;
                }
            }
           
            
        }

        private void ReferenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ReferenceForm_Load(object sender, EventArgs e)
        {

        }
        //какво се случва при чекване на radiobutton 1 
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            ArrayList years = new ArrayList();
            foreach (Cars car in PowerArray)
            {
                int yearValue = int.Parse(car.Year);
                if (years.Contains(yearValue))
                {
                }
                else
                {
                    years.Add(yearValue);
                }

            }
           
            if(comboBox1.Items.Count==0)comboBox1.Items.Add(years);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
            comboBox1.Visible = false;
            comboBox2.Visible = false;
        }
      //въвеждаме интервали в  combobox 3
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
                comboBox2.Visible = true;
                comboBox1.Visible = false;
                if (comboBox2.Items.Count == 0)
                {
                    int minPower = 10000;
                    int maxPower = 0;
                    foreach (Cars car in PowerArray)
                    {
                        string asd = car.Moshtnost;
                        int power = int.Parse(asd);
                        if (power > maxPower) maxPower = power;
                        if (power < minPower) minPower = power;

                    }
                    int intervals;
                    intervals = (maxPower - minPower) / 50;
                    intervals += 1;
                    



                    for (int i = 0; i < intervals; i++)
                    {
                        string first = maxPower.ToString();
                        int lower = maxPower - 50;
                        string second = lower.ToString();
                        string str = first + " - " + second;
                        comboBox2.Items.Add(str);
                        maxPower -= 50;
                    }

                }
               
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(PowerArray);
            search.Visible = true;
            this.Hide();
        }
        //отваряме aboutform и предаваме powerArray(данните от файла)
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm(PowerArray);
            about.Visible = true;
            this.Hide();
        }

      

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        }
    
}
