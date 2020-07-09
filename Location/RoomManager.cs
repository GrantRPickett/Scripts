using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager 
{
    Dictionary<int, Room> _rooms = new Dictionary<int, Room>();
    Dictionary<int, RoomConnection> _connections = new Dictionary<int, RoomConnection>();

    public void addRoom(int id, Room room){
        _rooms.Add(id, room);
    }
    public void addRoomConnection(int id, List<int> connections){
        _connections.Add(id, new RoomConnection(id, connections));
    }
}
