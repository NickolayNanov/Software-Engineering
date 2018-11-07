using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Student
    {
        private string name;
        private int age;
        private List<Student> friends;
        private int[] grades;

        public Student(string name, int age, List<Student> friends, int[] grades)
        {
            this.Name = name;
            this.Age = age;
            this.Friends = new List<Student>();
            this.Grades = new int[5];
        }

        public Student(string gender) : this(name, age, friends, grades) 
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public List<Student> Friends
        {
            get { return friends; }
            set { friends = value; }
        }
        
        public int[] Grades
        {
            get { return grades; }
            set { grades = value; }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


    }
}
