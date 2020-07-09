using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;
//using Mono.Data.SqliteClient;
using Mono.Data.Sqlite;
using DataBank;
public class InsertData  {
    SqliteHelper sql = SqliteHelper.SharedInstance;
    StringBuilder sb1;
    StringBuilder sb2;
    Definitions d = Definitions.SharedInstance;
    
    public string add(IEntity data) {
        return add(data.GetType().Name, data);
    }
    public string add(string tableName, IEntity data) {
        sb1 = new StringBuilder();
        sb2 = new StringBuilder();
        var columns = data.GetType().GetProperties();
        if(columns.Length<1) return "-1";
        sb1.Append($"INSERT INTO {tableName} (");
        sb2.Append(") VALUES(");
        foreach(var column in columns){
            
            sb1.Append($"{column.Name}, ");
            sb2.Append($"'{column.GetValue(data)}', ");
        }
        sb1.Length--;sb1.Length--;
        sb2.Length--;sb2.Length--;
        sb2.Append(");");
        //Debug.Log(sb1.ToString()+sb2.ToString());
        return sb1.ToString()+sb2.ToString();
    }
    // public bool s(){
    //     DataTable result = null;
    //     SqlConnection conn = null;
    //     SqlCommand cmd = null;
    //      using (SQLiteConnection con = new SQLiteConnection(string.Format("Data Source={0};Version=3;New=False;Compress=True;Max Pool Size=100;", SQLiteDatabase)))
    //     {
    //         con.Open();
    //         using (SQLiteTransaction transaction = con.BeginTransaction())
    //         {
    //             foreach (DataRow row in result.Rows)
    //             {
    //                 using (SQLiteCommand sqlitecommand = new SQLiteCommand("insert into table(fh,ch,mt,pn) values ('" + Convert.ToString(row[0]) + "','" + Convert.ToString(row[1]) + "','"
    //                                                                                                                       + Convert.ToString(row[2]) + "','" + Convert.ToString(row[3]) + "')", con))
    //                 {
    //                     sqlitecommand.ExecuteNonQuery();
    //                 }
    //             }
    //             transaction.Commit();
    //             return true;
    //         }
    //     }
    // }
    public int transaction(List<string> strs){
        return sql.ExecuteNonQueries(strs);
    }
    public string update(string tableName, string col, object val, int id) {
        return $@"UPDATE {tableName} SET {col} = '{val}' WHERE rowid = {id};";
    }
}   