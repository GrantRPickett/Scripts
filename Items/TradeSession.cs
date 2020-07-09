using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TradeSession : ScriptableObject {
    //extend baseSession?
    private readonly int id;
    private LineManager lines;
    private Person player;
    private Person npc;
    public TradeSession(LineManager lines, PeopleManager people) {
        Lines = lines;
        Player = people.player;
        Npc = people.currentNpc;
    }

    public LineManager Lines { get => lines; set => lines = value; }
    public Person Player { get => player; set => player = value; }
    public Person Npc { get => npc; set => npc = value; }

    // public HashSet<int> availableItems(Person currentNpc) {
    //     return currentNpc.items;
    // }
    // public string toString() {
    //     return $@"TradeSession: {id} with {Npc.id}";;
    // }
}