using System.Data.SqlClient;
using TestAbsolut.Model;

namespace TestAbsolut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DbConnector.GetDBConnection(@"ANASTASIA_NOTEB\SQLEXPRESS", @"TestAbsolut");
            //DbConnector.QueryInsert();
            //DbConnector.ViewLastConnection();
            //Person pers2 = new Person() { FullName = "Иванов Иван Иванович", Age = 22, Email = "Ivan@Ivan.iva", TelNumber = "555555555" };
            Person pers1 = new Person() { FullName = "Жужикин Жужа Жужович", Age = 22, Email = "abc@abc.abc", TelNumber = "555555555", Id=13};
            Controller.InsertPerson(pers1);
            Adress adr1=new Adress() { Country ="Россия", City = "Москва", Street="Московская", House=5, Flat=111};
            Controller.InsertAdress(adr1);
            Doc doc1 = new Doc() { Seria = "111", Number = "111", Name = "Паспорт", DateStart = new DateTime(2000, 1, 1), DateEnd = new DateTime(2025, 1, 1), PersonDoc=pers1 };
            Controller.InsertDoc(doc1);
        }
    }
}