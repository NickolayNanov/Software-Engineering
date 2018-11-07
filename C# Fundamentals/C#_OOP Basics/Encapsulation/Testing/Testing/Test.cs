using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    class Test
    {

        private int a;

        public int A
        {
            get { return a; }
            set { a = value; }
        }

        private int b;

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public Test(int a)
        {
            this.A = a;
        }

        public Test(int a, int b) : this(a)
        {
            this.B = b;
        }
    }
}
