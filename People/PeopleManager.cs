using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;

public class PeopleManager : Singleton<PeopleManager>
{
    public Dictionary<int, Person> people = new Dictionary<int, Person>();
    public List<string> qs = new List<string>();
    public Person player  {get; set;}
    public Person currentNpc {get; set;}

    public PeopleManager(){
        
    	InsertData i = new InsertData();
        var personCount = 10; 
        for(var j=1; j<=personCount;j++){
            Person temp = Person.getFake();
			qs.Add(i.add(temp));
            people.Add(j,temp);
		}
        i.transaction(qs);

    }
}
