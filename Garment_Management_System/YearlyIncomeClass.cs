﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garment_Management_System
{
    public partial class YearlyIncomeClass : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        YearlyIncome yrDb = new YearlyIncome();

        public YearlyIncomeClass()
        {
            InitializeComponent();
        }

        private void YearlyIncomeClass_Load(object sender, EventArgs e)
        {
            ///first
            YearlyIncome first = db.YearlyIncomes.SingleOrDefault(x => x.Id == 1);
            label19.Text = first.Id.ToString();
            textBox1.Text = first.year.ToString();
            textBox2.Text = first.income.ToString();

            ///second
            YearlyIncome second = db.YearlyIncomes.SingleOrDefault(x => x.Id == 2);
            label20.Text = second.Id.ToString();
            textBox4.Text = second.year.ToString();
            textBox3.Text = second.income.ToString();

            ///third
            YearlyIncome third = db.YearlyIncomes.SingleOrDefault(x => x.Id == 3);
            label21.Text = third.Id.ToString();
            textBox6.Text = third.year.ToString();
            textBox5.Text = third.income.ToString();

            ///forth
            YearlyIncome forth = db.YearlyIncomes.SingleOrDefault(x => x.Id == 4);
            label22.Text = forth.Id.ToString();
            textBox8.Text = forth.year.ToString();
            textBox7.Text = forth.income.ToString();

            ///fifth
            YearlyIncome fifth = db.YearlyIncomes.SingleOrDefault(x => x.Id == 5);
            label23.Text = fifth.Id.ToString();
            textBox10.Text = fifth.year.ToString();
            textBox9.Text = fifth.income.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Annual Income"].Points.AddXY(textBox1.Text,Convert.ToInt32(textBox2.Text));

            this.chart1.Series["Annual Income"].Points.AddXY(textBox4.Text, Convert.ToInt32(textBox3.Text));

            this.chart1.Series["Annual Income"].Points.AddXY(textBox6.Text, Convert.ToInt32(textBox5.Text));

            this.chart1.Series["Annual Income"].Points.AddXY(textBox8.Text, Convert.ToInt32(textBox7.Text));

            this.chart1.Series["Annual Income"].Points.AddXY(textBox10.Text, Convert.ToInt32(textBox9.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///forecasting
            double a, b, x, y, n, sumX, sumY, sumXY, sumX2;

            n = 5;

            sumX = 1 + 2 + 3 + 4 + 5;

            sumY = Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox9.Text);

            sumXY = 1*Convert.ToInt32(textBox2.Text) + 2*Convert.ToInt32(textBox3.Text) + 3*Convert.ToInt32(textBox5.Text) + 4*Convert.ToInt32(textBox7.Text) + 5*Convert.ToInt32(textBox9.Text);

            sumX2 = Math.Pow(Convert.ToInt32(textBox2.Text), 2) + Math.Pow(Convert.ToInt32(textBox3.Text), 2) + Math.Pow(Convert.ToInt32(textBox5.Text), 2) + Math.Pow(Convert.ToInt32(textBox7.Text), 2) + Math.Pow(Convert.ToInt32(textBox9.Text), 2);

            b = (n * sumXY - sumX * sumY) / (n * sumX2 - Math.Pow(sumX, 2));

            a = (sumY - b * sumX) / n;

            y = a + b * 6; //cause we want to find out the 6th value which is forecase value
            ///-----math done
            ///
            int resultYear = Convert.ToInt32(textBox10.Text) + 1;
            double resultIncome = Math.Round(y);
            textBox12.Text = resultYear.ToString();
            textBox11.Text = resultIncome.ToString();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeObj = new Home();
            homeObj.whoLoggedIn = this.whoLoggedIn;
            homeObj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //update button
                int yr = Convert.ToInt32(label19.Text);
                YearlyIncome yrDb = db.YearlyIncomes.SingleOrDefault(x => x.Id == yr);

                yrDb.year = Convert.ToInt32(textBox1.Text);
                yrDb.income = Convert.ToInt32(textBox2.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                YearlyIncomeClass newObj = new YearlyIncomeClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }

            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                //update button
                int yr = Convert.ToInt32(label20.Text);
                YearlyIncome yrDb = db.YearlyIncomes.SingleOrDefault(x => x.Id == yr);

                yrDb.year = Convert.ToInt32(textBox4.Text);
                yrDb.income = Convert.ToInt32(textBox3.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                YearlyIncomeClass newObj = new YearlyIncomeClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }

            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //update button
                int yr = Convert.ToInt32(label21.Text);
                YearlyIncome yrDb = db.YearlyIncomes.SingleOrDefault(x => x.Id == yr);

                yrDb.year = Convert.ToInt32(textBox6.Text);
                yrDb.income = Convert.ToInt32(textBox5.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                YearlyIncomeClass newObj = new YearlyIncomeClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }

            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //update button
                int yr = Convert.ToInt32(label22.Text);
                YearlyIncome yrDb = db.YearlyIncomes.SingleOrDefault(x => x.Id == yr);

                yrDb.year = Convert.ToInt32(textBox8.Text);
                yrDb.income = Convert.ToInt32(textBox7.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                YearlyIncomeClass newObj = new YearlyIncomeClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }

            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //update button
                int yr = Convert.ToInt32(label23.Text);
                YearlyIncome yrDb = db.YearlyIncomes.SingleOrDefault(x => x.Id == yr);

                yrDb.year = Convert.ToInt32(textBox10.Text);
                yrDb.income = Convert.ToInt32(textBox9.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                YearlyIncomeClass newObj = new YearlyIncomeClass();
                newObj.whoLoggedIn = this.whoLoggedIn;
                newObj.Show();
            }

            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }
    }
}
