using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TalkSession : ScriptableObject
{
    //extend baseSession?
    private readonly int id;
    private HashSet<int> peopleIds;
    private LineManager lines;
    private HashSet<int> unseenNpcLines;
    private Person player;
    private Person npc;
    public TalkSession(LineManager lines, PeopleManager people) {
        this.lines = lines;
        this.player = people.player;
        this.npc = people.currentNpc;
    }
    // public HashSet<int> availableLines(Person currentNpc) {
    //     return currentNpc.lineIds;
    // }
    // public HashSet<int> unseenLines(Person player, Person currentNpc) {
    //     unseenNpcLines = (HashSet<int>) currentNpc.lineIds.Except(player.lineIds);
    //     return unseenNpcLines;
    // }
    // public string toString() {
    //     return $@"TalkSession: {id} with {npc.id}";
    // }
}