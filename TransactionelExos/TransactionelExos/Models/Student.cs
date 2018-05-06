using System;
using Newtonsoft.Json;

namespace TransactionelExos.Models
{
    public class Student
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string classe { get; set; }


        public Student()
        { }

        public Student(string first, string last, int age, string cla)
        {
            this.firstname = first;
            this.lastname = last;
            this.age = age;
            this.classe = cla;
        }


    }
}