using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake<T> : IEnumerable<int>
    {
        private int[] lake;
        private int[] tempEvens;
        private int[] tempOdds;
        public Lake(params int[] input)
        {
            this.tempEvens = input.Where(num => num % 2 == 0).ToArray();
            this.tempOdds = input.Where(num => num % 2 != 0).ToArray();

            this.lake = this.tempOdds.Concat(this.tempEvens.Reverse()).ToArray();
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.lake.Length; i++)
            {
                yield return this.lake[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
