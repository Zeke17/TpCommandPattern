using System;
using System.Collections.Generic;
using TransactionelExos.Data;
using TransactionelExos.Models;

namespace TransactionelExos
{
    class Program
    {
        public static AppSetting appSettings = new AppSetting();

        static void Main(string[] args)
        {
            appSettings.PathBdd = "Documents/BaseDeDonnée.txt";

            Receiver receiver = new Receiver(appSettings.PathBdd);
            ConcreteCommand cmd = new ConcreteCommand(receiver);

            Student s1 = new Student("Nam", "Nguyen", 24, "4AMOC");
			Student s2 = new Student("Thomas", "Pain", 45, "4AMOC");


            cmd.BeginTransaction();
            cmd.AddStudent(s1);

            cmd.AddStudent(s2);
        }
    }
}
