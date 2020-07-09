using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DataBank;
using System;

public class GetData {
    //getAllData(tablename) in parent
    SqliteHelper sql = SqliteHelper.SharedInstance;
    public DataTable select(){
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT");
        sb.Append("col(s)");
        sb.Append("FROM");
        sb.Append("table(s)");
        sb.Append("(join(s))");
        sb.Append("(WHERE)");
        sb.Append("(cond(s))");
        sb.Append(";");
        return new DataTable();//toDT(sql.ExecuteReader(sb.ToString()));
    }
    public DataTable selectRelationshipByT1Id (string t1, string t2, int id){
        return toDT(sql.ExecuteReader(
            $@"SELECT * FROM {t1} join {t1}{t2}
            on {t1}.rowid = {t1}{t2}.id1 
            join {t2} on {t2}.rowid = {t1}{t2}.id2
            WHERE {t1}.rowid = {id};")); 
    }
    public DataTable selectRelColsByT1Id (string t1, string t2, int id, List<string> cols){
        string str = string.Join(",",cols);
        return toDT(sql.ExecuteReader(
            $@"SELECT {str} FROM {t1} 
            join {t1}{t2} on {t1}.rowid = {t1}{t2}.id1 
            join {t2} on {t2}.rowid = {t1}{t2}.id2
            WHERE {t1}.rowid = {id};")); 
    }
    //TODO Join on res
    public DataTable lines(int id){
        string str = string.Join(", ",new List<string>{"PlayerSays","NpcSays","Topic","Seen","Color","LockCode","Result","Line.ROWID"});
        return toDT(sql.ExecuteReader(
            $@"SELECT {str}
            FROM Line 
            join PersonLine on Line.rowid = PersonLine.id2
            WHERE PersonLine.id1 = {id}
            ORDER BY Seen, PSeen;")); 
    }

    internal DataTable gtlines(int id)    {
        string str = string.Join(", ",new List<string>{"PlayerSays","NpcSays","Topic","Seen","Color","LockCode","Result","GTLine.ROWID","PersonGTLine.ROWID","Personal","PSeen","PLock","Presult"});
        return toDT(sql.ExecuteReader(
            $@"SELECT {str}
            FROM GTLine 
            join PersonGTLine on GTLine.rowid = PersonGTLine.id2
            WHERE PersonGTLine.id1 = {id}
            ORDER BY Seen, PSeen;")); 
    }
    public DataTable selectTable (string table){
        return toDT(sql.ExecuteReader(
            $@"SELECT rowid, * FROM {table};"));
    }
    public DataTable selectById (string table, int id){
        return toDT(sql.ExecuteReader(
            $@"SELECT rowid, * FROM {table}
            WHERE {table}.rowid = {id};"));
    }
    public DataTable selectColsById (string table, int id, List<string> cols){
        string str = string.Join(",",cols);
        return toDT(sql.ExecuteReader(
            $@"SELECT {str} FROM {table}
            WHERE {table}.rowid = {id};"));
    }
    public DataTable toDT(IDataReader reader){
        DataTable dataTable = new DataTable();  
        dataTable.Load(reader);
        LogDT(dataTable);
        return dataTable;
    }
    public void LogDT(DataTable dt){
        // foreach (DataRow columnRow in dt.Rows)  {
        //     Debug.Log(string.Join("|",columnRow.ItemArray.Select(p => p.ToString()).ToArray()));
        // }
    }
}    