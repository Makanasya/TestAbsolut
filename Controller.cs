using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestAbsolut.Model;

namespace TestAbsolut
{
    internal static class Controller
    {
        private static string table = "";
        #region Обновление данных клиента
        public static void UpdatePerson(string filter, Person newp)
        {
            table = "Person";
            StringBuilder buildSet = new StringBuilder();
            buildSet.Append("FullName='" + newp.FullName + "', ");
            buildSet.Append("Age=" + newp.Age);
            if (newp.TelNumber != null)
                buildSet.Append(", TelNumber='" + newp.TelNumber + "'");
            if (newp.Email != null)
                buildSet.Append(", Email='" + newp.Email + "'");
            if (newp.AdressRegId != null)
                buildSet.Append(", AdressRegId=" + newp.AdressRegId);
            if (newp.AdressFactId != null)
                buildSet.Append(", AdressFactId=" + newp.AdressFactId);
            string sql = @"UPDATE " + table + " SET " + buildSet + " WHERE " + filter;
            DbConnector.QueryUpdate(sql);
        } 
        #endregion
        public static void UpdateAdress(object filter, Adress newa) { }//реализация аналогично обновления клиента
        public static void UpdateDoc(object filter,Doc newd){ }//реализация аналогично обновления клиента


        #region Вставка новой записи о клиенте
        public static void InsertPerson(Person newp)
        {
            table = "Person";
            StringBuilder buildField = new StringBuilder();
            StringBuilder buildValue = new StringBuilder();
            buildField.Append("FullName");
            buildValue.Append("'" + newp.FullName + "'");
            buildField.Append(",Age");
            buildValue.Append("," + newp.Age);
            if (newp.TelNumber != null)
            {
                buildField.Append(",TelNumber");
                buildValue.Append(",'" + newp.TelNumber + "'");
            }
            if (newp.Email != null)
            {
                buildField.Append(",Email");
                buildValue.Append(",'" + newp.Email + "'");
            }
            if (newp.AdressRegId != null)
            {
                buildField.Append(",AdressRegId");
                buildValue.Append("," + newp.AdressRegId);
            }
            if (newp.AdressFactId != null)
            {
                buildField.Append(",AdressFactId");
                buildValue.Append("," + newp.AdressFactId);
            }

            string sql = @"INSERT INTO " + table + "(" + buildField + ")" + " VALUES " + "(" + buildValue + ")";

            DbConnector.QueryInsert(sql);
        }
        #endregion

        #region Вставка новой записи об адресе
        public static void InsertAdress(Adress newa)
        {
            table = "Adress";
            StringBuilder buildField = new StringBuilder();
            StringBuilder buildValue = new StringBuilder();
            buildField.Append("Country");
            buildValue.Append("'" + newa.Country + "'");
            buildField.Append(",City");
            buildValue.Append(",'" + newa.City + "'");
            buildField.Append(",Street");
            buildValue.Append(",'" + newa.Street + "'");
            buildField.Append(",House");
            buildValue.Append("," + newa.House);

            if (newa.Build != null)
            {
                buildField.Append(",Build");
                buildValue.Append("," + newa.Build);
            }
            if (newa.Flat != null)
            {
                buildField.Append(",Flat");
                buildValue.Append("," + newa.Flat);
            }

            string sql = @"INSERT INTO " + table + "(" + buildField + ")" + " VALUES " + "(" + buildValue + ")";

            DbConnector.QueryInsert(sql);
        }
        #endregion

        #region Вставка новой записи о Документах
        public static void InsertDoc(Doc newd)
        {
            table = "Document";
            StringBuilder buildField = new StringBuilder();
            StringBuilder buildValue = new StringBuilder();
            buildField.Append("Seria");
            buildValue.Append("'" + newd.Seria + "'");
            buildField.Append(",Number");
            buildValue.Append(",'" + newd.Number + "'");
            buildField.Append(",Name");
            buildValue.Append(",'" + newd.Name + "'");
            buildField.Append(",DateStart");
            buildValue.Append(",'" + newd.DateStart + "'");
            buildField.Append(",DateEnd");
            buildValue.Append(",'" + newd.DateEnd + "'");
            if (newd.PersonDoc != null)
            {
                if (DbConnector.QSelect(@"SELECT * FROM Person WHERE id=" + newd.PersonDoc.Id.ToString()) != null)
                {
                    buildField.Append(",id_pers");
                    buildValue.Append("," + newd.PersonDoc.Id);
                }
            }

            string sql = @"INSERT INTO " + table + "(" + buildField + ")" + " VALUES " + "(" + buildValue + ")";

            DbConnector.QueryInsert(sql);
        } 
        #endregion

    }
}
