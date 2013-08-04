using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace codemarathon {
    class Program {

        static string fs(string x) {
            if (x == "feet")
                return "foot";
            if (x == "miles")
                return "mile";
            if (x.EndsWith("es"))
                return x.Substring(0, x.Length - 2);
            if (x.EndsWith("s"))
                return x.Substring(0, x.Length - 1);
            return x;
        }

        static void Main(string[] args) {
            var lines = File.ReadAllLines(@"E:\Code\github\length\input.txt");
            StreamWriter sw = new StreamWriter(@"E:\Code\github\length\output.txt");
            sw.WriteLine("licstar@sina.com");
            sw.WriteLine();
            bool start = true;
            Dictionary<string, double> x = new Dictionary<string, double>();

            foreach (var s in lines) {
                if (s == "") {
                    start = false;
                } else {
                    if (start) {
                        var t = s.Split(' ');
                        x[t[1]] = double.Parse(t[3]);
                    } else {
                        var t = s.Split(' ');
                        double ret = 0;
                        for (int i = 0; i < t.Length; i += 2) {
                            int add = 1;
                            if (i != 0) {
                                add = t[i] == "+" ? 1 : -1;
                                i++;
                            }
                            double v = 0;
                            if (x.ContainsKey(t[i + 1])) {
                                v = x[t[i + 1]];
                            } else {
                                v = x[fs(t[i + 1])];
                            }
                            ret += double.Parse(t[i]) * v * add;
                        }
                        sw.WriteLine("{0:0.00} m", ret);
                    }
                }
            }
            sw.Close();
        }
    }
}
