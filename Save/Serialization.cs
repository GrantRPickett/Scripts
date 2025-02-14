﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Serialization {
    public static bool Save(string saveName, object saveDate) {
        BinaryFormatter formatter = GetBinaryFormatter();

        if(Directory.Exists(Application.persistentDataPath + "/saves")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        FileStream file = File.Create(path);
        formatter.Serialize(file,saveDate);
        file.Close();
        return true;
    }
    public static object Load(string path) {
        if(!File.Exists(path)){
           return null;
        }
        BinaryFormatter formatter = GetBinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        try{
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        } catch {
            Debug.LogErrorFormat("Failed load file {0}", path);
            file.Close();
            return null;
        }
    }
    public static BinaryFormatter GetBinaryFormatter() {
        return new BinaryFormatter();
    }
   
}
