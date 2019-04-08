using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public IList<string> Interests { get; set; } = new List<string>();
    }
}
