using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Text.RegularExpressions;

public class trm {
    public static readonly string t = "TEXT";
    public static readonly string i = "INTEGER";
    public static readonly string n = "NOT NULL";
    public static readonly string p = "PRIMARY KEY";
    public static readonly string f = "FOREIGN KEY";
    public static readonly string r = "REFERENCES";
    public static readonly string id = "ROWID";
    public static readonly string u = "UNIQUE";
    public static readonly string r1 =$"id1 INTEGER, id2 INTEGER, FOREIGN KEY(id1) REFERENCES ";
    public static readonly string r2 =$"(ROWID), FOREIGN KEY(id2) REFERENCES ";
    public static readonly string r3 =$"(ROWID)";
}