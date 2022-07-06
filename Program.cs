using System.Data.SqlClient;

namespace TestAbsolut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DbConnector.GetDBConnection(@"ANASTASIA_NOTEB\SQLEXPRESS", @"TestAbsolut");
            //DbConnector.QueryInsert();
            DbConnector.ViewLastConnection();
        }
    }
}