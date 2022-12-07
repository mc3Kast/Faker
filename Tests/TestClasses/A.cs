using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestClasses
{
    public class A
    {
        public int Number;
        public string Text;
        public bool Check { get; set; }
        public static int Static { get; set; }

        public A(int number, string text)
        {
            Number = number;
            Text = text;
        }
    }
}
