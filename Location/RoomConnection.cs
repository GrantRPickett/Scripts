using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RoomConnection {
    int _roomId;
    List<int> _roomIds;
    public RoomConnection(int roomId, List<int> roomIds) {
        _roomId = roomId;
        _roomIds = roomIds;
    }
}