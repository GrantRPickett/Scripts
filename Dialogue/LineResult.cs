using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//What is given to a person after seeing npc line the first time
[System.Serializable]
public class LineResult
{   
    //package to the ui
    //package to the data layer
    //data such as journal,items,money,decision,otherTopics
    public readonly int id;
    private int lineId;
    private string title;
    private bool playerSeen {get; set;} = false;
    private HashSet<int> itemIds {get; set;}
    private HashSet<int> topicIds {get; set;}
    private int money {get; set;}
    public int LineId { get => lineId; set => lineId = value; }
    public string Title { get => title; set => title = value; }

    //private JournalEntry journalEntry {get; set;}
    //private Decision decision {get; set;}

    public LineResult(int lineId, string title, HashSet<int> itemIds, HashSet<int> topicIds, int money){
        this.LineId = lineId;
        this.Title=title;
        this.itemIds=itemIds;
        this.topicIds=topicIds;
        this.money=money;
    }

    public string toString(){
        string retString =  $@"LineResult: {id} {Title}
        {itemIds.Count} items";
        foreach(int tempid in itemIds){
            retString += $"\n{tempid}";
        }
        retString+=$"{topicIds.Count} topics";
        foreach(int tempid in topicIds){
            retString += $"\n{tempid}";
        }
        return retString;
    }
}
