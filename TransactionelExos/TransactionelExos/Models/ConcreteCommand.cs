using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TransactionelExos.Models
{
    public class ConcreteCommand : Command
    {
        private List<Student> listTransactionData = new List<Student>();


        public ConcreteCommand(Receiver re):base(re)
        {
            
        }

        public List<Student> GetAllStudent()
        {
            List<Student> listResult = new List<Student>();
            try
            {
                string result = File.ReadAllText(Program.appSettings.PathBdd);
                var data = JsonConvert.DeserializeObject(result, typeof(List<Student>));
                return (List<Student>)data;
			}
            catch (Exception ex)
            {
				Console.WriteLine("Error Log: {0}", ex.Message);
                return listResult;
			}
        }

        public bool AddStudent(Student s)
        {
            try
            {
                List<Student> l = GetAllStudent();

                l.Add(s);

                CommitTransaction(l);

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Log: {0}", ex.Message);
                RollBackTransaction();
				return false;
            }
        }


        public void BeginTransaction()
        {
            //Read in file
            try
            {
				listTransactionData = GetAllStudent();

			}
            catch (Exception ex)
            {
				Console.WriteLine("Error Log: {0}", ex.Message);
			}
        }

        public void CommitTransaction(List<Student> l)
        {
			try
			{
				string roll = JsonConvert.SerializeObject(l);
				File.WriteAllText(receiver.pathFileData, roll);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error Log: {0}", ex.Message);
			}
		}

        public void RollBackTransaction()
        {
            try
            {
				string roll = JsonConvert.SerializeObject(listTransactionData);
				File.WriteAllText(receiver.pathFileData, roll);
            }
            catch (Exception ex)
            {
				Console.WriteLine("Error Log: {0}", ex.Message);
			}
           
		}


    }
}
