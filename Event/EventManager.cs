using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public event Action<int> onTalk;
    public void TalkTrigger(int id){
        if(onTalk != null) {
            onTalk(id);
        }
    }
    public event Action<int> onTrade;
    public void TradeTrigger(int id){
        if(onTrade != null) {
            onTrade(id);
        }
    }
    public event Action<int> onLeave;
    public void LeaveTrigger(int id){
        if(onLeave != null) {
            onLeave(id);
        }
    }
}
