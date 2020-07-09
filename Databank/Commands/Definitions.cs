using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Text.RegularExpressions;

namespace DataBank
{
    public class Definitions {
        private static Definitions instance = null;
        public static Definitions SharedInstance {
            get {
                if (instance == null) {
                    instance = new Definitions();
                }
                return instance;
            }
        }
        public readonly Dictionary<string, string> tables;
        private static readonly List<string> Entities = new List<string>(){
            "Line","Item","Person","Room","Topic","PersonLine"
        };
        public static readonly List<string> Relationships = new List<string>(){
           "PersonItem","RoomPerson"
        };
        public readonly List<string> tableNames = Entities.Concat(Relationships).ToList();

        //TODO build tables better
        public readonly Dictionary<string, string> columns = new Dictionary<string, string>(){//<name,columnns>
            //Entities
            { "Item", $"Title {trm.t} {trm.n}, Description {trm.t} {trm.n}"},
            { "Line", 
                $@"Segment {trm.t} {trm.n}, Subindex {trm.t} {trm.n},
                PlayerSays {trm.t} {trm.n}, NpcSays {trm.t} {trm.n},
                Topic {trm.t} {trm.n}, Seen {trm.t} {trm.n}, Color {trm.t} {trm.n},
                LockCode {trm.t} {trm.n}, Result {trm.t} {trm.n}"},//json parse since the db design got too hard
            { "Person",
                $@"Name {trm.t} {trm.n}, State {trm.t} {trm.n}, Age {trm.i} {trm.n},
                    Money {trm.i} {trm.n}, Gender {trm.i} {trm.n},
                    Job {trm.i} {trm.n}, Faction {trm.i} {trm.n}, 
                    Hair {trm.i} {trm.n}, Eye {trm.i} {trm.n}, Inj {trm.i} {trm.n},
                    Str {trm.i} {trm.n}, Agi {trm.i} {trm.n}, Height {trm.i} {trm.n}, 
                    Weight {trm.i} {trm.n}, Hp {trm.i} {trm.n},
                    Perceptive {trm.i} {trm.n}, Disciplined {trm.i} {trm.n},
                    Confedence {trm.i} {trm.n}, Trusting {trm.i} {trm.n},
                    Moody {trm.i} {trm.n}, Moral {trm.i} {trm.n}, 
                    Bounty {trm.i} {trm.n}, Xp {trm.i} {trm.n}"},
            { "Room", $"Title {trm.t} {trm.n}, Description {trm.t} {trm.n}, North {trm.i}, East {trm.i}, South {trm.i}, West {trm.i}"},
            { "Topic", $"Title {trm.t} {trm.n}, Description {trm.t} {trm.n}"},
            { "PersonLine", $@"Personal {trm.t} {trm.n}, 
                Pseen {trm.t} {trm.n}, Plock {trm.t} {trm.n}, Presult {trm.t} {trm.n},
                {trm.r1}Person{trm.r2}Line{trm.r3}" }
            };        
        
        public Definitions(){
            tables = columns;
            foreach(var r in Relationships){
                var temp = Regex.Split(r,"(\\B[A-Z])");
                if(temp.Length != 3) Debug.Log("db split error" +temp[1]+temp[2]);//todo remove
            //Relationships eg "LineTopic",  $"id1 {i}, id2 {i}, {f}(id1) {r} Lines({id}), {f}(id2) {r} Topics({id})"
                tables.Add(r,$"{trm.r1}{temp[0]}{trm.r2}{temp[1]+temp[2]}{trm.r3}");
            }
        }

    }
}