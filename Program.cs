using System.Data.SqlClient;
using TestAbsolut.Model;

namespace TestAbsolut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Тест подключения
            DbConnector.GetDBConnection(@"ANASTASIA_NOTEB\SQLEXPRESS", @"TestAbsolut");
            //Тест вставки с запросом по умолчанию
            DbConnector.QueryInsert();
            //Тест обновления данных с запросом по умолчанию
            DbConnector.QueryInsert();
            //Тест получения параметров последнего подключения
            DbConnector.ViewLastConnection();
            //Тест получения данных с запросом по умолчанию
            DbConnector.QuerySelect();
            
            //Тестовые данные
            Person pers2 = new Person() { FullName = "Иванов Иван Иванович", Age = 22, Email = "Ivan@Ivan.iva", TelNumber = "555555555" };
            Adress adr1 = new Adress() { Country = "Россия", City = "Москва", Street = "Московская", House = 5, Flat = 111 };
            Person pers1 = new Person() { FullName = "Жужикин Жужа Жужович", Age = 22, Email = "abc@abc.abc", TelNumber = "555555555", AdressFactId = adr1};
            Adress adr2 = new Adress() { Country = "Россия", City = "Москва", Street = "Московская", House = 5, Flat = 111 };
            Doc doc1 = new Doc() { Seria = "111", Number = "111", Name = "Паспорт", DateStart = new DateTime(2000, 1, 1), DateEnd = new DateTime(2025, 1, 1), PersonDoc = pers1 };
            
            //Тесты контроллера: вставка данных клиента, адреса, документов
            Controller.InsertPerson(pers1); 
            Controller.InsertAdress(adr2);
            Controller.InsertDoc(doc1);
            
        }
    }
}