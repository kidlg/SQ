using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://www.baidu.com/s?wd=金价";
            var path = @"C:\Users\liguang\Desktop\temp\t.txt";
            var page = SQ.Helper.HttpHelper.Get(url);
            Console.WriteLine(page);
            File.WriteAllText(path, page);

            Console.ReadLine();
        }
    }
}
