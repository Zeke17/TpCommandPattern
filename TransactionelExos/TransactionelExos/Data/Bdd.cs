using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TransactionelExos.Models;

namespace TransactionelExos.Data
{
    public class Bdd
    {
        private String pathData;

        public Bdd(String pathFileData)
        {
            this.pathData = pathFileData;
        }

        public List<Student> GetAllData()
        {
            string result = string.Empty;
            List<Student> listStudent = new List<Student>();
            try
            {
                result = File.ReadAllText(this.pathData);
                var data = JsonConvert.DeserializeObject(result);

                try
                {

                }
                catch (Exception ex)
                {
					Console.WriteLine("LogError: " + ex.Message);
                    throw ex;
				}

            }
            catch (Exception ex)
            {
                Console.WriteLine("LogError: " + ex.Message);
            }
            return listStudent;
        }



		public void AddStudentInBdd(Student student)
		{
			try
			{
				string convertStudent = JsonConvert.SerializeObject(student);
                //Get List Student
                //Add new Student to list
                //Rewrite in file


			}
			catch (Exception ex)
			{
				Console.WriteLine("LogError: " + ex.Message);
				throw ex;
			}
		}
    }
}
