using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnonimusCache
{
    class Program
    {
        //dataSet -> dataKey -> dataSize
        //string  -> string  -> longeger
        static void Main(string[] args)
        {
            var sets = new Dictionary<string, Dictionary<string, long>>();
            var cache = new Dictionary<string, Dictionary<string, long>>();

            //1. read input
            //2. fill the data
            //3. save the keys and sizes without set
            //4. sort and prlong 

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "thetinggoesskrra") // break if true
                {
                    break;
                }

                string[] tokens = line
                    .Split(new string[] { " -> ", " | " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray(); // split
               
                // if the input is only a dataSet
                if (tokens.Length == 1)
                {
                    string dataSet = tokens[0];

                    //check wether the catche holds the previously missing data  
                    if(!sets.ContainsKey(dataSet) && cache.ContainsKey(dataSet))
                    {
                        sets.Add(dataSet, new Dictionary<string, long>());
                        foreach (var pair in cache[dataSet])// filling everything from the CACHE of the given dataSet to the SET
                        {
                            sets[dataSet].Add(pair.Key, pair.Value);
                        }
                    }

                    // check if the SET contains the given dataSet and if not we add it
                    if (!sets.ContainsKey(dataSet))
                    {
                        sets.Add(dataSet, new Dictionary<string, long>());
                        
                    }
                    
                }
                else if (tokens.Length == 3) // if we recive as an input more than one thing
                {
                    string dataSet = tokens[2];
                    string dataKey = tokens[0];
                    long dataSize = long.Parse(tokens[1]);

                    // check if the SET contains the given dataSet and if not we add it
                    if (!sets.ContainsKey(dataSet))
                    {
                        // check if the CACHE contains the given dataSet and if not we add it
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache.Add(dataSet, new Dictionary<string, long>());
                            cache[dataSet].Add(dataKey, dataSize);//adding all the rest 
                        }
                        else
                        {                           
                            cache[dataSet].Add(dataKey, dataSize);// if this statement returns true we just fill the data coresponding to the dataSet                            
                        }
                    }
                    else
                    {
                        if (!sets.ContainsKey(dataSet)) // check if the SET contains the given dataSet and if not we add it
                        {
                            sets.Add(dataSet, new Dictionary<string, long>());
                        }

                        if (!sets[dataSet].ContainsKey(dataKey))//here we are doing the same filling action as mentioned above
                        {
                            sets[dataSet].Add(dataKey, dataSize);
                        }
                    }
                }           
            }     
            
            //print if we have at least one thing in our SET
            if(sets.Count > 0)
            {
                //extracting with the help of LINQ the dataSet with the HIGHEST dataSize (SUM of all its dataSizes),               
                KeyValuePair<string, Dictionary<string, long>> result = sets
                    .OrderByDescending(ds => ds.Value.Sum(d => d.Value)).First();

                //just printing
                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Values.Sum()}");

                foreach (var dataKey in result.Value)
                {
                    Console.WriteLine("$." + dataKey.Key);
                }
            }

        }
    }
}
