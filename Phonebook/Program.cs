using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = new string[10];
            string[] num = new string[10];
            string tempname, tempnum;
            int flag1, flag2, k = 0;
            while (true)
            {
                Console.WriteLine("i.	Enter New Record");
                Console.WriteLine("ii.	Fetch Record");
                Console.WriteLine("iii.	Delete Record");
                Console.WriteLine("iv.	Show The Complete Phonebook");
                Console.WriteLine("v.	Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        {
                            Console.WriteLine("Name: ");
                            tempname = Console.ReadLine();
                            Console.WriteLine("Number: ");
                            tempnum = Console.ReadLine();
                            bool b = name.Contains(tempname);
                            
                            flag2 = checknum(tempnum);
                            if (b==false && flag2 == 0)
                            {
                                name[k] = tempname;
                                num[k] = tempnum;
                                k++;
                                Console.WriteLine("added");
                            }
                            else
                                Console.WriteLine("not added, name already present or wrong number ");
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Name: ");
                            tempname = Console.ReadLine();
                            bool b = name.Contains(tempname);
                            if (b == false)
                                Console.WriteLine("name not found");
                            else
                            {
                                flag1 = Array.IndexOf(name, tempname);
                                Console.WriteLine("number for that is: " + num[flag1]);
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Name: ");
                            tempname = Console.ReadLine();
                            bool b = name.Contains(tempname);
                            if (b == false)
                                Console.WriteLine("name not found");
                            else
                            { flag1 = Array.IndexOf(name, tempname);
                                delete(flag1, name, num); Console.WriteLine("deleted"); }
                        }
                        break;
                    case 4:
                        {
                            display(name, num);
                        }
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
        public static int checknum(string tnum)
        { 
            Regex Pattern = new Regex("(0/91)?[7-9][0-9]{8}[9/0]{1}");
            bool b = Pattern.IsMatch(tnum);
            //bool b = true;
            if (b == true)
                return 0;
            else
                return 1;
        }
        public static void delete(int pos, string[] name, string[] num)
        {
            int i;
            for (i = pos; i < name.Length - 1; i++)
            {
                name[i] = name[i + 1];
                num[i] = num[i + 1];

            }
            name[i] = null;
            num[i] = null;
        }
        public static void display(string[] name, string[] num)
        {
            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine(name[i] + "\t" + num[i]);
            }
        }
    }
}
