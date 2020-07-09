using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    //todo wire this to ui
    private static SaveData _current;
    public static SaveData current{get{
        if(_current == null){
            _current = new SaveData();
        }
        return _current;}
    }
    public PlayerProfile profilel;
}