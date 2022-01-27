using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLearning.Model.Abstract;
using System.Data.SQLite;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WebAppLearning.Model
{
    public class SqliteDataAccess : DataAccess
    {
        public new string DbName = "database.sqlite";
        public bool IsDbRecentlyCreated = false;

        public SqliteDataAccess()
        {
            DbInit();
        }

        public override void DbInit()
         {

            if (!File.Exists(Path.GetFullPath(DbName)))
            {
                SQLiteConnection.CreateFile(DbName);
                IsDbRecentlyCreated = true;
            }

            using(var ctx = GetInstance(DbName))
            {
                if (IsDbRecentlyCreated)
                {
                    string query = @"
                            CREATE TABLE IF NOT EXISTS Courses(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name VARCHAR(100) NOT NULL,
                            Status BOOLEAN NOT NULL);

                            INSERT INTO Courses(Name, Status) VALUES ('Scrum Certification', true);
                            INSERT INTO Courses(Name, Status) VALUES ('Azure Fundamental', true);
                            INSERT INTO Courses(Name, Status) VALUES ('Comptia Plus', true);

                            CREATE TABLE IF NOT EXISTS Users(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name VARCHAR(100) NOT NULL,
                            Lastname VARCHAR(100) NOT NULL,
                            Birthday DATETIME NOT NULL);";

                    using (var command = new SQLiteCommand(query, ctx))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

        }

        public static SQLiteConnection GetInstance(string dbName)
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", dbName)
            );

            db.Open();

            return db;
        }

    }
}
