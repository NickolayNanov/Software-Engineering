using System;

namespace Mankind
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] stundentInfo = Console.ReadLine().Split();

            string firstName = stundentInfo[0];
            string lastName = stundentInfo[1];
            string facultyNumber = stundentInfo[2];

            Student stundent = new Student(firstName, lastName, facultyNumber);
            

            string[] workerInfo = Console.ReadLine().Split();

            string firstNameW = workerInfo[0];
            string lastNameW = workerInfo[1];
            decimal salary = decimal.Parse(workerInfo[2]);
            decimal days = int.Parse(workerInfo[3]);

            Worker worker = new Worker(firstNameW, lastNameW, salary, days);
            Console.WriteLine(stundent);
            Console.WriteLine();
            Console.WriteLine(worker);
            
        }
    }
}
