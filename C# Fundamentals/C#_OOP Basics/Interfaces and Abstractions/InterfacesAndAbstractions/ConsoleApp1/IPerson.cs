using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public interface IPerson
    {
        /// <summary>
        /// This method is not important
        /// </summary>
        void SayHi();
        void Grow();
        int Age { get; set; }
    }
}
