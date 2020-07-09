using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;

public class DbTestBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RebuildDB();
	}

    private void RebuildDB(){
        baseDB();
		GoT();
		GenerateLines();
		GeneratePersons();
    }

    void GoT() {
		var tc = new TableCommands();
		InsertData i = new InsertData();
		var g = new g();
		tc.Delete(g.tableNames);
		tc.Create(g.tables);
		var qs = g.createTableData();
	}
	void baseDB(){
		Definitions d = Definitions.SharedInstance;
		TableCommands tables = new TableCommands();
		InsertData i = new InsertData();
		GetData g = new GetData();
		var qs = new List<string>();
		var del = tables.Delete(d.tableNames);
		Debug.Log(del);
		var cre =tables.Create(d.tables);
		Debug.Log(cre);
		//create map
		//create towns
		//create rooms
		var j=1;
		var roomCount = Random.Range(10,20);
		//var personCount = 1;
		var itemCount = Random.Range(10,20);
		for(j=1; j<roomCount;j++){
			qs.Add(i.add(new Room("RoomT","RoomD")));
		}
		//create people and put in room
		// for(j=1; j<=personCount;j++){
		// 	qs.Add(i.add(Person.getFake()));
		// 	qs.Add(i.add("RoomPerson", new BaseRelationship(Random.Range(1,roomCount+1),j)));
		// }
		//create items
		// for(j=1; j<=itemCount;j++){
		// 	qs.Add(i.add(new Item("ItemTitle"+j,"ItemD")));
		// 	qs.Add(i.add("PersonItem", new BaseRelationship(Random.Range(1,personCount+1),j)));
		// }
	
		//create quests
		i.transaction(qs);
	}
	void GenerateLines(){
	var lines = LineManager.GetInstance() as LineManager;
		var people = PeopleManager.GetInstance() as PeopleManager;
		var pl = PersonLineManager.GetInstance() as PersonLineManager;
		Debug.Log("dbtbs");
		pl.AllPersonBaseLines(
			people, lines);
	}
	void GeneratePersons() {
	}
}
