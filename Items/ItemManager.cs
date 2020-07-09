using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemManager
{
    //TODO: inheirt BaseRepository?
    public Dictionary<int, Item> allItems = new Dictionary<int, Item>();
    // Start is called before the first frame update
    private void Awake(){
        BuildDatabase();
    }
    public Item getById(int id){
        return allItems[id];
    }
    // public Item getByTitle(string itemName){
    //     return allItems.Find(item => item.title == itemName);
    // }
    public HashSet<Item> getById(List<int> ids){
        HashSet<Item> tempItems = new HashSet<Item>();
        foreach(int id in ids){
            tempItems.Add(getById(id));
        }
        return tempItems;
    }
    void Start()
    {
        Debug.Log("ItemManager Start" + allItems.Count);
    }
    void BuildDatabase() {
        allItems = new Dictionary<int, Item>() {
            // new Item(0, "sword", "sword",
            //     new Dictionary<string,int>{
            //         {"power",15},{"Defence",10}
            //     }
            // ),
            // new Item("axe", "axe",
            //     new Dictionary<string,int>{
            //         {"power",15},{"Defence",10}
            //     }
            // ),
            // new Item("spear", "spear",
            //     new Dictionary<string,int>{
            //         {"power",15},{"Defence",10}
            //     }
            // ),
            // new Item("coin", "coin",
            //     new Dictionary<string,int>{
            //         {"value",15}
            //     }
            // )
        };
    }
}
