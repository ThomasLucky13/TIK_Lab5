using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class NumClass
    {
        private List<int> num;

        public NumClass()
        {
            num = new List<int>();
        }

        public NumClass(List<int> _num)
        {
            num = _num;
        }

        public NumClass(int _num)
        {
            num= new List<int>();
            int k = _num.ToString().Length - 1;
            while (k>1)
            {
                num.Add(_num / (10 * k));
                _num %= (10 * k);
                --k;
            }
        }

        public int countsOne()
        {
            int res = 0;
            for (int i = 0; i< num.Count; ++i)
            {
                if (num[i] == 1)
                    res++;
            }
            return res;
        }

        public List<int> Num() => num;

        public int NumInt()
        {
            int res = 0;
            for (int i = 0; i< num.Count; ++i)
            {
                res *= 10;
                res += num[i];
            }
            return res;
        }

        public void Left()
        {
            int i = num[0];
            num.RemoveAt(0);
            num.Add(i);
        }

        public void Right()
        {
            int i = num[num.Count-1];
            num.RemoveAt(num.Count - 1);
            num.Insert(0, i);
        }
        public override String ToString()
        {
            String res ="";
            int n=0;
            while ((n < num.Count) && (num[n] == 0)) ++n;
            for (int i = n; i<num.Count; i++)
            {
                res += num[i].ToString();
            }
            return res;
        }

        public List <int> Mult(int n)
        {
            List<int> res = new List<int>(num);
            for (int i = 0; i < n; ++i)
            {
               res.Add(0);
            }
            return res;
        }

        private int toDecimal()
        {
            int res = 0;
            for (int i = 0; i < num.Count; i++)
            {
                if (num[i]==1)
                {
                    res += (int)Math.Pow(2, num.Count - i - 1);
                }
            }
            return res;
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

        public List<int> Mod(List<int> b)
        {
            List<int> res = new List<int>(num);
            int i = 0;
            while ((i < num.Count - b.Count + 1) && (res[i] == 0)) ++i;
            while (i < num.Count - b.Count + 1)
            {
                for (int j = 0; j < b.Count; ++j)
                {
                    if (res[i+j]==b[j])
                    {
                        res[i + j] = 0;
                    } else
                    {
                        res[i + j] = 1;
                    }
                }
                ++i;
                while ((i < num.Count - b.Count + 1) && (res[i] == 0)) ++i;
            }
            return res;
        }
        public List<int> Sum (List<int> b)
        {

            List<int> res = new List<int>(num);
            int j = 0;
            for (int i = num.Count - b.Count; i < num.Count; ++i)
            {
                if (num[i] == b[j])
                {
                    res[i] = 0;
                }
                else
                {
                    res[i] = 1;
                }
                j++;
            }
            return res;
        }

        public List<int> Add(List<int> b)
        {

            List<int> res = new List<int>(num);
            int j = 0;
            bool flag = false;
            for (int i = num.Count - b.Count; i < num.Count; ++i)
            {
                if ((num[i]==1)&&(b[j]==1))
                {
                    res[i] = 0;
                    flag = true;
                    for (int c = 0; c <= i; ++c)
                    {
                        if (res[i-c]==0)
                        {
                            res[i - c] = 1;
                            flag = false;
                            break;
                        } else
                        {
                            res[i - c] = 0;
                        }
                    }
                }
                else
                {
                    res[i] = num[i]+b[j];
                }
                j++;
            }
            if (flag)
            {
                int i = num.Count - b.Count;
                while ((i>=0)&&(flag))
                {
                    if (res[i] == 0)
                    {
                        res[i] = 1;
                        flag = false;
                    } else
                    {
                        res[i] = 0;
                    }
                    --i;
                }
            }
            if (flag)
                res.Insert(0, 1);
            return res;
        }

    }
}
