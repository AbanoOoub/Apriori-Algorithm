using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Apriori_Algorithm
{
    public partial class Form1 : Form
    {
        int TotalTrans = 0;
        float MinSup, MinCon = 0;
        String[] init_arr;
        Dictionary<string, int> Table_C = new Dictionary<string, int>();
        Dictionary<string, int> Table_L = new Dictionary<string, int>();
        Dictionary<int, Dictionary<string, int>> SolutionC = new Dictionary<int, Dictionary<string, int>>();
        Dictionary<int, Dictionary<string, int>> SolutionL = new Dictionary<int, Dictionary<string, int>>();
        bool stop = false;
        public Form1()
        {
            InitializeComponent();
            /*
             Data_GV.Rows.Add(1, "a,b,c,d,e,f");
             Data_GV.Rows.Add(2, "a,c,d,e");
             Data_GV.Rows.Add(3, "c,d,e");
             Data_GV.Rows.Add(4, "b,f");
             Data_GV.Rows.Add(5, "a,b,c,d");
             Data_GV.Rows.Add(6, "a,b,e");
             Data_GV.Rows.Add(7, "a,b,c");
             Data_GV.Rows.Add(8, "a,b,e");
             Data_GV.Rows.Add(9, "a,c");
             Data_GV.Rows.Add(10, "a,c,d,e");
            */
            /*
            Data_GV.Rows.Add(1, "m,o,n,k,e,y");
            Data_GV.Rows.Add(2, "d,o,n,k,e,y");
            Data_GV.Rows.Add(3, "m,a,k,e");
            Data_GV.Rows.Add(4, "m,u,c,k,y");
            Data_GV.Rows.Add(5, "c,o,o,k,i,e");
            */
        }

        private void Run_btn_Click(object sender, EventArgs e)
        {
            TotalTrans = (Data_GV.Rows.Count) - 1;
            init_arr = new string[TotalTrans];

            float val1 = float.Parse(MinSup_txtbx.Text);
            MinSup = (val1 / 100) * TotalTrans;
            MinCon = float.Parse(MinCon_txtbx.Text.ToString());
            

            for (int rows = 0; rows < TotalTrans; rows++)
            {

                init_arr[rows] = Data_GV.Rows[rows].Cells[1].Value.ToString().Trim().ToUpper();
            }
            int cnt_c = 1;
            int cnt_l = 1;
            Table_C = MakeC1table();
            SolutionC.Add(cnt_c, Table_C);
            cnt_c++;
            Table_L = MakeLtable(Table_C);
            while (Table_L.Count != 1)
            {
                SolutionL.Add(cnt_l, Table_L);
                cnt_l++;
                Table_C = MakeCtable(cnt_c, Table_L);
                if (stop) break;
                SolutionC.Add(cnt_c, Table_C);
                cnt_c++;
                Table_L = MakeLtable(Table_C);

            }
            if (!stop)
            {
                SolutionL.Add(cnt_c - 1, Table_L);
                cnt_l++;
            }
           

            
            foreach (var key1 in SolutionC.Keys)
            {
                string forBox1 = "";
                var value1 = SolutionC[key1];
                foreach (var key2 in value1.Keys)
                    forBox1 += key2 + " -> " + value1[key2] + "\r\n";

                MessageBox.Show(forBox1, "C" + key1);
            }

            foreach (var key1 in SolutionL.Keys)
            {
                    string forBox1 = "";
                    var value1 = SolutionL[key1];
                if (value1.Count > 0) { 
                    foreach (var key2 in value1.Keys)
                        forBox1 += key2 + " -> " + value1[key2] + "\r\n";

                    MessageBox.Show(forBox1, "L" + key1);
                }
            }

           
            List<string> StrongRules = new List<string>();
            Dictionary<string,float> Real_StrongRules = new Dictionary<string, float>();

            StrongRules = GenerateRules(SolutionL);
            Real_StrongRules = Filter(StrongRules,init_arr);
            foreach (var x in Real_StrongRules)
            {
                string v = x.Value.ToString();
                StrongRules_grid.Rows.Add(x.Key,v+"%");
            }

            Table_C.Clear();
            Table_L.Clear();
            SolutionC.Clear();
            SolutionL.Clear();
        }

        private Dictionary<string, int> MakeC1table()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            int Supcount = 0;
            for (int i = 0; i < TotalTrans; i++)
            {
                string[] x = init_arr[i].Split(',');
                foreach (string var in x)
                {
                    for (int j = 0; j < TotalTrans; j++)
                    {
                        string[] y = init_arr[j].Split(',');
                        foreach (string v in y)
                        {
                            if (var == v)
                            {
                                Supcount++;
                                break;
                            }
                        }
                    }
                    try
                    {
                        dic.Add(var, Supcount);

                    }
                    catch (Exception)
                    {
                        dic[var] = Supcount;
                    }
                    Supcount = 0;
                }
            }

            return dic;
        }

        //with join as c2 c3 c4 ....
        private Dictionary<string, int> MakeCtable(int cnt, Dictionary<string, int> d)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            if (cnt > 2)
                dic = BigJoin(cnt, d);
            else
                dic = SmallJoin(d);
            return dic;
        }


        //remove not freq
        private Dictionary<string, int> MakeLtable(Dictionary<string, int> d)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string key in d.Keys)
            {
                int sup = d[key];
                if (sup >= MinSup)
                    dic.Add(key, d[key]);
            }
            return dic;
        }
        //start from c3 and so on..
        private Dictionary<string, int> BigJoin(int cnt, Dictionary<string, int> d)
        {
            //first k-1 rule
            Dictionary<string, int> dic = new Dictionary<string, int>();
            // because I increased this cound above and I want make join from L2
            cnt = cnt - 1;
            foreach (string key in d.Keys)
            {
                foreach (string val in d.Keys)
                {
                    //k-1 element
                    string s1 = key.Substring(0, cnt - 1);
                    string s2 = val.Substring(0, cnt - 1);
                    bool canjoin = s1.Equals(s2); //accept k-1 rule
                    string str = String.Concat(key.Substring(0, cnt - 1), key[cnt - 1], val[cnt - 1]);
                    bool rep = false; //oke -- keo 

                    if (canjoin)
                    {
                        foreach (string x in dic.Keys)
                        {
                            rep = areAnagram(str, x);
                            if (rep)
                                break;
                        }
                    }
                    if (!(key.Equals(val)) && canjoin && !(dic.ContainsKey(ReverseString(str))) && !rep)
                    {
                        rep = false;
                        if(theory(d,str))  //**
                            dic.Add(str, GetSup(str, init_arr));
                    }
                }
            }
            if (dic.Count() == 0) stop = true;
            return dic;
        }
        //c2-- 2itemset
        private Dictionary<string, int> SmallJoin(Dictionary<string, int> d) 
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string key in d.Keys)
            {
                foreach (string val in d.Keys)
                {
                    string str = String.Concat(key, val);
                    string check_rev = ReverseString(str);
                    bool contain_rev = dic.ContainsKey(check_rev);
                    if (!key.Equals(val) && contain_rev == false) 
                    {
                        int sup = GetSup(str, init_arr);
                        dic.Add(str, sup);
                    }
                }
            }
            return dic;
        }
        //used in join
        private int GetSup(string s, Array arr)
        {
            int sb = 0;
            int len = s.Length;
            bool find = false;
            for (int j = 0; j < TotalTrans; j++)
            {
                string y = init_arr[j];
                y = y.Replace(",", "");
                foreach (char ch in s)
                {
                    if (!(y.Contains(ch)))
                    {
                        find = false;
                        break;
                    }
                    else
                        find = true;
                }
                if (find)
                    sb++;
            }
            return sb;
        }
        private string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray).ToString();
        }
        ////////////////////////////////////////////////////////////no repeat combinations///////////////////////////////////////////
        public static bool areAnagram(string str1, string str2)

        {
            // Get lenghts of both strings
            int n1 = str1.Count();
            int n2 = str2.Count();

            // If length of both strings is not
            // same, then they cannot be anagram
            if (n1 != n2)
            {
                return false;
            }

            // Sort both strings
            str1 = String.Concat(str1.OrderBy(c => c));
            str2 = String.Concat(str2.OrderBy(c => c));

            // Compare sorted strings
            for (int i = 0; i < n1; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }
        ////////////////////////////////////////////////////////////////// Rule Generation ///////////////////////////////////////

        private List<string> GenerateRules(Dictionary<int, Dictionary<string, int>> sol)
        {
            List<string> combination = new List<string>();
            List<string> Strongrules = new List<string>();
            sol.Remove(sol.Keys.First()); //remove the table of 1 item set 
            
            foreach (var key1 in sol.Keys)
            {
                var value1 = sol[key1];
                foreach (var key2 in value1.Keys)
                {
                    //key2
                    if (key2.Length > 2)
                    {
                        List<string> n = new List<string>();
                        foreach (var x in key2)
                        {
                            n.Add(x.ToString());
                        }
                        for (int i = 1; i < (key2.Length - 1); i++) // get all combination k-1 , k-2 ..... (k-(k-1))
                        {
                            foreach (IEnumerable<string> I in GetCombinations(n, (key2.Length - i)))
                            {
                                combination.Add(string.Join("", I));
                            }
                            for (int k = 0; k < combination.Count; k++)
                            {
                                for (int j = (k + 1); j < combination.Count; j++)
                                {
                                    if (areAnagram(combination.ElementAt(k), combination.ElementAt(j)))     // remove all combination will contains same items
                                    {
                                        combination.RemoveAt(j);
                                    }
                                }
                            }
                            foreach (var x in combination)
                            {
                                string s = "";
                                string ss = key2;
                                for (int z = 0; z < x.Length; z++)
                                {
                                    s = ss.Replace(x[z].ToString(), "");
                                    ss = s;
                                }
                                string check1 = x + " -> " + s;
                                string check2 = s + " -> " + x;
                                if(!(Strongrules.Contains(check1)))
                                    Strongrules.Add(x + " -> " + s);
                                if(!(Strongrules.Contains(check2)))
                                Strongrules.Add(s + " -> " + x);
                            }

                            combination.Clear();
                        }

                    }
                    else
                    {
                        string check1 = key2[0] + " -> " + key2[1];
                        string check2 = key2[1] + " -> " + key2[0];
                        if (!(Strongrules.Contains(check1)))
                            Strongrules.Add(key2[0] + " -> " + key2[1]);
                        if (!(Strongrules.Contains(check2)))
                            Strongrules.Add(key2[1] + " -> " + key2[0]);
                    }

                }
            }
            return Strongrules;
        }

        static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetCombinations(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        ////////////////////////////////////////////////////////////////// filter Strong rules  ///////////////////////////////////////

        private Dictionary<string,float> Filter(List<string> s, Array arr)
        {
            string [] parts = new string[2];
            char[] spearator = { '-', '>' ,' '};
            string all = "";
            Dictionary<string, float> MyStrongRules = new Dictionary<string, float>();
            foreach (var x in s)
            {
                parts = x.Split(spearator,StringSplitOptions.RemoveEmptyEntries);
                float leftsup = GetSup(parts[0], init_arr);
                foreach(var c in parts)
                     all += c;
                float allsup = GetSup(all, init_arr);
                all = "";
                if (leftsup > 0)
                {
                    float RuleConfidence = (allsup / leftsup)*100;
                    if (RuleConfidence >= MinCon)
                    {
                        MyStrongRules.Add(x, RuleConfidence);
                    }
                }
            }
            return MyStrongRules;
        }


        //explain : get elemnt and the every elemnt in last table so check if the table "all frq" contains the s 
        //then we will calculate sup for new join elemnt 
        //if the table "all frq" does not contains the s then the result of join will be unfrq 

        /* 
         * s after join -> ABC
         * frq:
         * 
         * AB 
         * AC 
         * AD 
         * then AB frq so we will cal support for ABC
         * 
         * s after join -> AED
         * frq:
         * 
         * AB 
         * AC 
         * AD 
         * then I don't need cal support for this 
         * */
        public bool theory(Dictionary<string, int> d ,string s)
        {
            foreach(string x in d.Keys)
            {
                
                string str = x;
                str = String.Concat(x.OrderBy(c => c));
                s = String.Concat(s.OrderBy(c => c));
                s = s.Substring(0, str.Length);
                if (str.Equals(s))
                    return true;
            }
            return false;
        } 
    }
}
