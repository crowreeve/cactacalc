using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cactacalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // main
        public List<int> vals = new List<int>();
        public List<int> possi = new List<int>();


        private void button1_Click(object sender, EventArgs e)
        {
            btn();

        }

        public void btn()
        {

            vals.Clear();
            possi.Clear();


            if ((int)numericUpDown1.Value != 0) vals.Add((int)numericUpDown1.Value);
            if ((int)numericUpDown2.Value != 0) vals.Add((int)numericUpDown2.Value);
            if ((int)numericUpDown3.Value != 0) vals.Add((int)numericUpDown3.Value);
            if ((int)numericUpDown4.Value != 0) vals.Add((int)numericUpDown4.Value);
            if ((int)numericUpDown5.Value != 0) vals.Add((int)numericUpDown5.Value);
            if ((int)numericUpDown6.Value != 0) vals.Add((int)numericUpDown6.Value);
            if ((int)numericUpDown7.Value != 0) vals.Add((int)numericUpDown7.Value);
            if ((int)numericUpDown8.Value != 0) vals.Add((int)numericUpDown8.Value);
            if ((int)numericUpDown9.Value != 0) vals.Add((int)numericUpDown9.Value);
            vals.Sort();
            if (vals.Count == 0)
            {
                label.Text = "Change at least one value.";
                return;
            }
            else
            {
                label.Text = "";
            }
            if (vals.Count() != vals.Distinct().Count())
            {
                label.Text = "Check for duplicate values.";
                return;
            }
            else
            {
                label.Text = "";
            }

            for (int a = 1; a < 10; a++)
            {
                if (!vals.Contains(a)) possi.Add(a);

            }


            foreach (object o in possi)
            {
                Console.WriteLine(o.ToString());
            }
            Console.WriteLine("=========");
            foreach (object o in vals)
            {
                Console.WriteLine(o.ToString());
            }

            textBox1.Text = value((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value).ToString();
            textBox2.Text = value((int)numericUpDown4.Value, (int)numericUpDown5.Value, (int)numericUpDown6.Value).ToString();
            textBox3.Text = value((int)numericUpDown7.Value, (int)numericUpDown8.Value, (int)numericUpDown9.Value).ToString();
            textBox4.Text = value((int)numericUpDown1.Value, (int)numericUpDown4.Value, (int)numericUpDown7.Value).ToString();
            textBox5.Text = value((int)numericUpDown2.Value, (int)numericUpDown5.Value, (int)numericUpDown8.Value).ToString();
            textBox6.Text = value((int)numericUpDown3.Value, (int)numericUpDown6.Value, (int)numericUpDown9.Value).ToString();
            textBox7.Text = value((int)numericUpDown1.Value, (int)numericUpDown5.Value, (int)numericUpDown9.Value).ToString();
            textBox8.Text = value((int)numericUpDown3.Value, (int)numericUpDown5.Value, (int)numericUpDown7.Value).ToString();
        }
        public int value (int a, int b, int c)
        {



            // 000
            if (a == 0 && b == 0 && c == 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = new List<int>();
                poss1 = possi;
                for (int cap = poss1.Count - 1; cap >= 0; cap--)
                {
                    Console.WriteLine("Loop numer: " + cap);
                    Console.WriteLine("Wielkosc poss1: " + poss1.Count);
                    index = poss1[cap]; // zwiekszam index o wartosc pierwszej wylosowanej liczby
                    Console.WriteLine("W glownym loopie jest elementow: " + poss1.Count());
                    List<int> poss2 = poss1.ToList();
                    poss2.RemoveAt(cap); // wyrzucam wylosowana liczbe z nowo utworzonej listy
                    Console.WriteLine("Tworze nowa liste z iloscia elementow: " + poss2.Count());
                    for (int cap2 = poss2.Count - 1; cap2 >= 0; cap2--)
                    {
                        Console.WriteLine("Loop wewn. numer: " + cap);
                        int index2 = index + poss2[cap2];
                        List<int> poss3 = poss2.ToList();
                        poss3 = poss2;
                        poss3.RemoveAt(cap2);
                        Console.WriteLine("Tworze nowa liste z iloscia elementow: " + poss3.Count());
                        for (int cap3 = poss3.Count - 1; cap3 >= 0; cap3--)
                        {
                            Console.WriteLine("XXXXXXXXXXXXXXXX: " + (index2 + poss3[cap3]));
                            payout += payoutCalc(index2 + poss3[cap3]);
                            payoutNr += 1;
                        }
                    }
                }
                return payout / payoutNr;
            }
            // 001
            if (a == 0 && b == 0 && c != 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                for (int cap = poss1.Count - 1; cap >= 0; cap--)
                {
                    index = poss1[cap]; // zwiekszam index o wartosc pierwszej wylosowanej liczby
                    List<int> poss2 = poss1.ToList();
                    poss2.RemoveAt(cap); // wyrzucam wylosowana liczbe z nowo utworzonej listy
                    for (int cap2 = poss2.Count - 1; cap2 >= 0; cap2--)
                    {
                        payout += payoutCalc(index + c + poss2[cap2]);
                        payoutNr += 1;
                    }
                }
                return payout / payoutNr;
            }
            // 010
            if (a == 0 && b != 0 && c == 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                for (int cap = poss1.Count - 1; cap >= 0; cap--)
                {
                    index = poss1[cap]; // zwiekszam index o wartosc pierwszej wylosowanej liczby
                    List<int> poss2 = poss1.ToList();
                    poss2.RemoveAt(cap); // wyrzucam wylosowana liczbe z nowo utworzonej listy
                    for (int cap2 = poss2.Count - 1; cap2 >= 0; cap2--)
                    {
                        payout += payoutCalc(index + b + poss2[cap2]);
                        payoutNr += 1;
                    }
                }
                return payout / payoutNr;
            }
            // 011
            if (a == 0 && b != 0 && c != 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                for (int cap = 0; cap < poss1.Count; cap++)
                {
                    index = index + b + c + poss1[cap];
                    payout += payoutCalc(index);
                    index = 0;
                    payoutNr += 1;
                }
                return payout / payoutNr;
            }
            // 100
            if (a != 0 && b == 0 && c == 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                for (int cap = poss1.Count - 1; cap >= 0; cap--)
                {
                    index = poss1[cap]; // zwiekszam index o wartosc pierwszej wylosowanej liczby
                    List<int> poss2 = poss1.ToList();
                    poss2.RemoveAt(cap); // wyrzucam wylosowana liczbe z nowo utworzonej listy
                    for (int cap2 = poss2.Count - 1; cap2 >= 0; cap2--)
                    {
                        payout += payoutCalc(index + a + poss2[cap2]);
                        payoutNr += 1;
                    }
                }
                return payout / payoutNr;
            }
            // 101
            if (a != 0 && b == 0 && c != 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                for (int cap = 0; cap < poss1.Count; cap++)
                {
                    index = index + a + c + poss1[cap];
                    payout += payoutCalc(index);
                    index = 0;
                    payoutNr += 1;
                }
                return payout / payoutNr;
            }
            // 110
            if (a != 0 && b != 0 && c == 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                for (int cap = 0; cap < poss1.Count; cap++)
                {
                    index = index + a + b + poss1[cap];
                    payout += payoutCalc(index);
                    index = 0;
                    payoutNr += 1;
                }
                return payout / payoutNr;
            }
            // 111
            if (a != 0 && b != 0 && c != 0)
            {
                int payout = 0;
                int payoutNr = 0;
                int index = 0;
                List<int> poss1 = possi.ToList();
                index = index + a + b + c;
                payoutNr = payoutNr + 1;
                payout = payout + payoutCalc(index);
                return payout / payoutNr;
            }









            return 0;
            //policz value

        }

        public int payoutCalc(int index)
        {
            if (index == 6) return 10000;
            if (index == 7) return 36;
            if (index == 8) return 720;
            if (index == 9) return 360;
            if (index == 10) return 80;
            if (index == 11) return 252;
            if (index == 12) return 108;
            if (index == 13) return 72;
            if (index == 14) return 54;
            if (index == 15) return 180;
            if (index == 16) return 72;
            if (index == 17) return 180;
            if (index == 18) return 119;
            if (index == 19) return 36;
            if (index == 20) return 306;
            if (index == 21) return 1080;
            if (index == 22) return 144;
            if (index == 23) return 1800;
            if (index == 24) return 3600;
            return 0;
        }



        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
