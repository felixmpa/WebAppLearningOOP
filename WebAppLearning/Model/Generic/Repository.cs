using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAppLearning.Model.Abstract;
using WebAppLearning.Model.Delegates;

namespace WebAppLearning.Model.Generic
{
    public class Repository
    {
        private static Repository _repository;
        
        static public Repository SharedRepository()
        {
            if(_repository == null)
            {
                _repository = new Repository();
            }


            return _repository;
        }


        public string InsertRecord<T>(SqliteDataAccess db, string table)
        {

            
            T obj = default(T);

            obj = Activator.CreateInstance<T>();

            var prop = typeof(T).GetProperties();


            //string columns = String.Join(",", prop.ToList());

            //string values = String.Empty.PadLeft(columns.Length, ",?");

            //string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";




            //string query = $"INSERT INTO {table} () ";
            /*
            using (var ctx = SqliteDataAccess.GetInstance(db.DbName))
            {
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obj = ReaderGeneric<T>(reader);
                        }
                    }
                }
            }*/





            return "Created";
        }
        

        public T GetRecordById<T>(SqliteDataAccess db, string table, int id)
        {
            T obj = default(T);

            string query = $"SELECT * FROM {table} WHERE ID = {id} LIMIT 1";

            using (var ctx = SqliteDataAccess.GetInstance(db.DbName))
            {
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obj = ReaderGeneric<T>(reader);
                        }
                    }
                }
            }

            return obj;
        }

        public List<T> GetRecords<T>(SqliteDataAccess db, string table)
        {
            List<T> list = new List<T>();
            T obj = default(T);

            string query = $"SELECT * FROM {table};";

            using (var ctx = SqliteDataAccess.GetInstance(db.DbName))
            {
                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReaderGeneric<T>(reader));
                        }
                    }
                }
            }

            return list;
        }


        private T ReaderGeneric<T>(SQLiteDataReader reader)
        {
            T obj = default(T);
        
            obj = Activator.CreateInstance<T>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                if (!object.Equals(reader[prop.Name], DBNull.Value))
                {
                    prop.SetValue(obj, reader[prop.Name], null);
                }
            }

            return obj;
        }

            


    }
}
