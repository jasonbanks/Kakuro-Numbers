using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace kakuroNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            var start_digits = new List<int>() {  1,2,3,4,5,6,7,8,9};

            //-- all 1 digit values
            
            for (int rightmost = 1; rightmost <= 9 ; rightmost++)
            {
                var digits = new List<int>();
                for (int j = 0; j < rightmost; j++) digits.Add(start_digits[j]);

                bool finished = false;
                var results = new Dictionary<int, string>();

                while (finished!=true)
                {
                    //-- calculate total of all digits
                    int total = 0;
                    string token = "";
                    digits.ForEach(x => { total += x;  token = $"{token}{x}"; }) ;

                    //-- add it to the results
                    if (results.ContainsKey(total))
                    {
                        results[total] = $"{results[total]},{token}";
                    }
                    else
                    {
                        results.Add(total, token);
                    }

                    //-- increment the digits
                    var toinc = rightmost - 1;
                    var cap = 9;
                    var done = false;

                    while (done!=true)
                    {
                        if (digits[toinc] < cap)
                        {
                            digits[toinc] += 1;
                            for (int i = toinc+1; i < rightmost; i++)
                            {
                                digits[i] = digits[i-1] + 1;
                            }
                            done = true;                            
                        }    
                        else
                        {
                            //-- this is where it starts to get iffy...
                            cap -= 1;
                            toinc -= 1;
                            if (toinc < 0)
                            {
                                done = true;
                                finished = true;
                            }
                        }
                    }                                                           
                }

                Console.WriteLine(rightmost);
                Console.WriteLine();
                foreach (int key in results.Keys)
                {
                    Console.WriteLine($"{key}--{results[key]}");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------");
                Console.WriteLine();
            }         
        }
    }
}
