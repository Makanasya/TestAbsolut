using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestAbsolut
{
    public static class DbConnector
    {
        private static SqlConnection _dbInstance;
        private static string ConnectionString;
        private static DateTime LastConnect;

        #region Создание подключения
        public static SqlConnection GetDBConnection(string datasource = @"ANASTASIA_NOTEB\SQLEXPRESS", string database = @"TestAbsolut")
        {
            //комбинируем строку подключения
            ConnectionString = @"Data Source=" + datasource
                                        + ";Initial Catalog=" + database
                                        + ";Integrated Security=True;Connect Timeout=30;Encrypt = False; TrustServerCertificate = False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _dbInstance = new SqlConnection(ConnectionString);
            
            return _dbInstance;
        } 
        #endregion

        #region Сохранение параметров последнего подключения
        private static void SaveLastConnection()
        {
            LastConnect = DateTime.Now;
            File.WriteAllText("lastConnection.txt", LastConnect.ToString());
            File.AppendAllText("lastConnection.txt", "\n" + ConnectionString);
        }
        #endregion

        #region Вывод параметров последнего подключения
        public static void ViewLastConnection()
        {
            try
            {
                List<string> dataLastConn = new List<string>();
                foreach (var item in File.ReadLines("lastConnection.txt"))
                    dataLastConn.Add(item);
                LastConnect = DateTime.Parse(dataLastConn[0]);
                ConnectionString = dataLastConn[1];
                Console.WriteLine("параметры подключения: {0}\nдата последнего подключения: {1}", ConnectionString, LastConnect);
            }
            catch { Console.WriteLine("Еще не подключались к БД"); }
        } 
        #endregion

        //Запросы CRUD

        #region Вставка данных
        public static void QueryInsert(string sql = @"INSERT INTO Document (seria,number,dateStart,dateEnd) VALUES ('22','222','01.01.2000','01.01.2026')")
        {
            GetDBConnection();

            using (_dbInstance)
            {
                _dbInstance.Open();
                SqlCommand command = new SqlCommand(sql, _dbInstance);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
            }
            SaveLastConnection();
        } 
        #endregion

        #region Обновление данных
        public static void QueryUpdate(string sql = @"UPDATE Document SET seria=444,number=4444,dateStart='01.01.2000',dateEnd='01.01.2030' WHERE id=1")
        {
            GetDBConnection();

            using (_dbInstance)
            {
                _dbInstance.Open();
                SqlCommand command = new SqlCommand(sql, _dbInstance);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Обновлено объектов: {0}", number);
            }
            SaveLastConnection();
        } 
        #endregion

        #region Удаление данных
        public static void QueryDelete(string sql = @"DELETE FROM Document WHERE id=1")
        {
            GetDBConnection();

            using (_dbInstance)
            {
                _dbInstance.Open();
                SqlCommand command = new SqlCommand(sql, _dbInstance);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Удалено объектов: {0}", number);
            }
            SaveLastConnection();
        } 
        #endregion

        #region Выборка данных
        public static void QuerySelect(string sql = @"SELECT * FROM Document")
        {
            GetDBConnection();
            using (_dbInstance)
            {
                _dbInstance.Open();
                SqlCommand command = new SqlCommand(sql, _dbInstance);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write("{0}\t", reader.GetName(i));
                    }
                    Console.WriteLine("\n");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write("{0}\t", reader.GetValue(i));
                        }
                        Console.WriteLine("\n");
                    }
                    reader.Close();
                }
            }
            SaveLastConnection();
        }
        #endregion

        #region Проверка есть ли данные по запросу
        public static object QSelect(string sql = @"SELECT * FROM Document")
        {
            object obj = null;
            GetDBConnection();
            using (_dbInstance)
            {
                _dbInstance.Open();
                SqlCommand command = new SqlCommand(sql, _dbInstance);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            obj = reader.GetValue(i);
                        }
                    }
                    reader.Close();
                }
            }
            SaveLastConnection();
            return obj;
        } 
        #endregion
    }
}
