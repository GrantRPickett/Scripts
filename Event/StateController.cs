// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TalkController : ScriptableObject
// {
//     //todo give people ids and assign controler programatically
//     public int id;
//     public int val = 0;
//     // Start is called before the first frame update
//     Person p1;
//     Person p2;
//     void Start()
//     {
//         EventManager.SharedInstance.onTalk += OnTalking;
//         EventManager.SharedInstance.onTrade += OnTrading;
//         EventManager.SharedInstance.onLeave += OnLeaving;
//     }

//     private void OnTalking(int id){
//         if(id == this.id) {
//             this.val++; 
//         }
//     }
//     private void OnTrading(int id){
//         if(id == this.id) {
//             this.val = 0; 
//         }
//     }
//      private void OnLeaving(int id){
//         if(id == this.id) {
//             this.val--; 
//         }
//     }
//     public void onDestroy() {
//         EventManager.SharedInstance.onTalk -= OnTalking;
//         EventManager.SharedInstance.onTrade -= OnTrading;
//         EventManager.instance.onLeave -= OnLeaving;
//     }
//     /*
//     private Func<List<GameObject>> onReuestList;
//     public void SetOnRequestList(Func<List<GameObject>> returnEvent){
//         onReuestList = return event
//     }
//     */
// }
