using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class Form1 : Form
    {

        private String text;
        private List<int> a, b, erb;
        private int k, r;
        private NumClass mc, pc;

        public Form1()
        {
            InitializeComponent();
        }

        private void BOutput_Click(object sender, EventArgs e)
        {

        }

        private List<int> BinNum(int n)
        {
            List<int> res = new List<int>();
            while (n > 0)
            {
                res.Add(n % 2);
                n = n / 2;
            }
            res.Reverse();
            return res;
        }

        private void set_mc()
        {
            int tryInt = (int)Math.Pow(2, r) +1;
            int old_i = r;
            if (r==1)
            {
                tryInt = 1;
            }
            int d = 3; // 2t+1 t = 1
            mc = new NumClass(BinNum(tryInt));
            int n = r + k;
           List<int> checkNum = new List<int>();
            checkNum.Add(1);
            for (int i = 0; i<n-1; i++)
            {
                checkNum.Add(0);
            }
            checkNum.Add(1);
            while ((mc.countsOne() < d) && (new NumClass(new NumClass(checkNum).Mod(mc.Num())).NumInt()!=0))
            {
                tryInt += 2;
                if (tryInt > (int)Math.Pow(2, r+1))
                {
                    ++r;
                    ++n;
                    checkNum.Insert(1, 0);
                }
                mc = new NumClass(BinNum(tryInt));
            }
        }

        private bool isTextAllowable()
        {
            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i]=='1')
                {
                    a.Add(1);
                } else if (text[i]=='0')
                {
                    a.Add(0);
                } else
                {
                    return false;
                }
            }
            k = text.Length;
            return true;
        }

        private void set_r()
        {
            int logK1=(int)Math.Log(k+1, 2);
            if (Math.Pow(2, logK1)< k+1)
            {
                logK1++;
            }

            r = (int)Math.Log(k + 1 + logK1, 2);
            if (Math.Pow(2, r) < k + 1 + logK1)
            {
                r++;
            }
        }

        private String ListString(List <int> a)
        {
            String res = "";
            foreach (int i in a)
            {
                res += i.ToString();
            }
            return res;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            errorLable.Visible = false;
            krn_Output.Text = "";
            H_Matrix.Text = "";
            BOutput.Text = "";
            ErBOutput.Text = "";
            ResOutput.Text = "";
            text = textInput.Text;
            a = new List<int>();
            if (!isTextAllowable())
            {
                errorLable.Visible = true;
                return;
            }

            set_r();

            krn_Output.Text = $"k = {k}    r = {r}";

            set_mc();
            pc = new NumClass(new NumClass(a).Mult(mc.Num().Count-1));
            NumClass ost = new NumClass(pc.Mod(mc.Num()));
            b = pc.Add(ost.Num());
            H_Matrix.Text = $"Образующий многочлен: {mc.ToString()}\nИнформационная комбинация на одночлен:{pc.ToString()}\nОстаток от деления:{ost.ToString()}";

            BOutput.Text = $"B = {ListString(b)}";

            int erInd = new Random().Next(b.Count);
            erb = new List<int>(b);
            
            if (erb[erInd]==1)
            {
                erb[erInd] = 0;
            } else
            {
                erb[erInd] = 1;
            }

            ErBOutput.Text = $"!B = {ListString(erb)}";

            int n = 0;
            NumClass erNum = new NumClass(erb);
            System.Console.WriteLine($"B = {ListString(b)}\nerNum{erNum.ToString()}\nОбразующий многочлен: {mc.ToString()}");
            if (new NumClass(erNum.Mod(mc.Num())).NumInt() !=0)
            {
                while (new NumClass(erNum.Mod(mc.Num())).countsOne() > 1)
                {
                    n++;
                    erNum.Left();
                }
                erNum = new NumClass( erNum.Sum(erNum.Mod(mc.Num())));
                for (int i = 0; i<n; ++i)
                {
                    erNum.Right();
                }
                erb = erNum.Num();
                ResOutput.Text = $"Исправленный код: {ListString(erb)}";

            }
            

        }
    }
}
