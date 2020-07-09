using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank{
	public class TableCommands {
        SqliteHelper sql = SqliteHelper.SharedInstance;
        public int Create(Dictionary<string, string> tables)
        {
            var qs = new List<string>();
            foreach(KeyValuePair<string, string> table in tables) {
                //Debug.Log(table.Key + " " + table.Value);
                qs.Add($"CREATE TABLE IF NOT EXISTS {table.Key} ({table.Value});");
            }
            return sql.ExecuteNonQueries(qs);
        }
        public int Delete(List<string> tableNames)
        {   
            var qs = new List<string>();
            foreach(string table in tableNames) {
                //Debug.Log(table);
                qs.Add($"DROP TABLE IF EXISTS {table};");
            }
            return sql.ExecuteNonQueries(qs);
        }
        private int CreateTable(KeyValuePair<string, string> table)
        {
            return sql.ExecuteNonQuery($"CREATE TABLE IF NOT EXISTS {table.Key} ({table.Value});");
        }
        private int DeleteTable(string table)
        {
            return sql.ExecuteNonQuery($"DROP TABLE IF EXISTS {table};");
        }
    }
}