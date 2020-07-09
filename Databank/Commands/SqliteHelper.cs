using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;

namespace DataBank
{
    public class SqliteHelper
    {   
        private static SqliteHelper instance = null;
        public static SqliteHelper SharedInstance {
            get {
                if (instance == null) {
                    instance = new SqliteHelper();
                }
                return instance;
            }
        }
        private const string database_name = "db.db";

        public string db_connection_string;
        public IDbConnection db_connection;

        public SqliteHelper()
        {
            db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;
            //Debug.Log("db_connection_string" + db_connection_string);
            db_connection = new SqliteConnection(db_connection_string);
            db_connection.Open();
        }
        public int ExecuteNonQuery(string commandText){
                IDbCommand dbcmd = getDbCommand();
                dbcmd.CommandText = commandText;
                var ret = dbcmd.ExecuteNonQuery();
                return ret;
        }
        public int ExecuteNonQueries(List<string> queries){
            var ret = 0;
            using (var tra = db_connection.BeginTransaction()){
                try{ 
                    foreach(var query in queries){ 
                        IDbCommand dbcmd = getDbCommand();
                        dbcmd.CommandText = query;
                        //Debug.Log(query);
                        ret += dbcmd.ExecuteNonQuery();
                    }

                    tra.Commit();
                }
                catch(Exception ex)
                {
                    tra.Rollback();
                    Debug.Log("I did nothing, because something wrong happened: "+ex);
                    throw;
                }
                return ret;
            }
        }
        public IDataReader ExecuteReader(string commandText){
            //Debug.Log(commandText);
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = commandText;
            return dbcmd.ExecuteReader();
        }
        ~SqliteHelper()
        {
            db_connection.Close();
        }

        //vitual functions
        public virtual IDataReader getDataById(int id)
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

        public virtual IDataReader getDataByString(string str)
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

        public virtual void deleteDataById(int id)
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

		public virtual void deleteDataByString(string id)
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

        public virtual IDataReader getAllData()
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

        public virtual void deleteAllData()
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

        public virtual IDataReader getNumOfRows()
        {
            Debug.Log("This function is not implemented");
            throw null;
        }

        //helper functions
        public IDbCommand getDbCommand()
        {
            return db_connection.CreateCommand();
        }

        public IDataReader getAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public void deleteAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader getNumOfRows(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

		public void close (){
			db_connection.Close ();
		}
    }
}