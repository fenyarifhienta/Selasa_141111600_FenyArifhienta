﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volley
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        static int mod = 1000000007;
        static private long comb(int x, int y)
        {
            long result = 1;
            for (int i = 0; i < y; i++)
            {
                result = result * (x - i) / (i + 1);
            }
            return result % mod;
        }
        static long pow(long x, long y)
        {
            if (y == 0)
            {
                return 1;
            }
            if (y == 1)
            {
                return x;
            }
            if (x == 0)
            {
                return 0;
            }
            long half = pow(x, y / 2);
            if (y % 2 == 0)
            {
                return (half * half) % mod;
            }
            else
            {
                return (((half * half) % mod) * x) % mod;
            }
        }
        static long ans(int a, int b)
        {
            int tempSwap = 0;
            if (a < b)
            {
                tempSwap = a;
                a = b;
                b = tempSwap;
            }
            if (a < 25)
            {
                return 0;
            }
            if (a == 25)
            {
                if (b >= 24)
                {
                    return 0;
                }
                else
                {
                    return comb(a + b - 1, b);
                }
            }
            if (a - b != 2)
            {
                return 0;
            }
            else
            {
                return comb(48, 24) * pow(2, a - 26) % mod;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnHitung_Click(object sender, EventArgs e)
        {
            int text1 = Convert.ToInt32(Txt2.Text);
            int text2 = Convert.ToInt32(Txt1.Text);
            TxtHasil.Text = ans(text1, text2).ToString();
        }
    }
}
