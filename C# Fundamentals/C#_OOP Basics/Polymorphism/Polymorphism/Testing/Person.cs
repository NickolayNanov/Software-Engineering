using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public class Person : Mamal
    {

        public void Speak(string phrase)
        {
            Console.WriteLine(phrase);
        }

        public override void Walk()
        {
            base.Walk();
            Console.WriteLine("On two feet");
        }
    }
}
