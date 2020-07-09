using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Personbak : ScriptableObject 
{   
    public readonly int id;
    public string firstName {get;set;} = "ERROR";
    public string lastName {get;set;} = "ERROR";
    public HashSet<int> lineIds;
    public HashSet<int> items;
    public Dictionary<string, int> traits = new Dictionary<string, int>();
    private enum levels {
        Low, Middle, High
    }
    private enum State{
        Idle, Talk, Trade, Fight, Dead 
    }
    private int state { get; set; } = (int) State.Idle;
    private List<string> events = new List<string>() {
        "birth"
    };
    private HashSet<int> lines; 
    public static List<string> traitNames = new List<string>(){
        "Height","Weight","Wealth",
        "Constitution","Agility","Strength",
        "Perceptive","Creative","Intelligent",
        "Organized","Disciplined","Trustworthy",
        "Energetic","Assertive","Social",
        "Gentle","Trusting","Generous",
        "Content","Brave","Moody",
    };
    private int traitCount = traitNames.Count;
    public Personbak() {
        traits = new Dictionary<string,int>();
        for(int i=0; i<traitCount; i++) {
            traits.Add(traitNames[i], 0);
        }
    } 
    public string toString(){
        return this.name;
    }
    // public void changeText() {
    //     string dictionaryString = "";
    //     foreach(KeyValuePair < string, int > keyValues in traits) {
    //          dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";  
    //     }  
    //     Ctext.text = string.Join(",", dictionaryString.TrimEnd(',', ' '));
    //     Ctext2.GetComponent<Text>().text = firstName+lastName;
    // }
    // public void changeScrollText() {
    //     string s = Stext.GetComponent<Text>().text;

    //     Stext.GetComponent<Text>().text = s +"\n" + s.Length;
    // }
}
