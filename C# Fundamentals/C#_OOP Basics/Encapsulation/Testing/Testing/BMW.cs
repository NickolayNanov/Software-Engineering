using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    class BMW : Car
    {
        public BMW(int fuel) : base(fuel)
        {
                   
        }

        public override void StartEngine()
        {
            base.StartEngine();
        }
    }    
}
