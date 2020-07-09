using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[Table(Name = "Lines")]
public class Line : IEntity
{

    //[Column(Name = "EmpName", DbType = "VARCHAR")]
    private string playerSays;
    //[Column(Name = "EmpName", DbType = "VARCHAR")]
    private string npcSays = "0";
    private string topic = "0";
    private string seen = "0";
    private string color = "0";
    private string lockCode = "0";
    private string result = "0";
    private int segment = 0;
    private int subindex = 0;

    public string PlayerSays { get => playerSays; set => playerSays = value; }
    public string NpcSays { get => npcSays; set => npcSays = value; }
    public string Topic { get => topic; set => topic = value; }
    public string Seen { get => seen; set => seen = value; }
    public string Color { get => color; set => color = value; }
    public string LockCode { get => lockCode; set => lockCode = value; }
    public string Result { get => result; set => result = value; }
    public int Segment { get => segment; set => segment = value; }
    public int Subindex { get => subindex; set => subindex = value; }

    public Line(int segment, int subindex,
        string playerSays="---", string npcSays="---", string topic ="---", 
        string seen = "0", string color= "0", string lockCode = "", string result = "") {
        Segment = segment;
        Subindex = subindex;
        PlayerSays = playerSays;
        NpcSays = npcSays;
        Topic = topic;
        Seen = seen;
        Color = color;
        LockCode = lockCode;
        Result = result;
    }

    public static Line getFakeLine()
    {
        return new Line(0,0,"playerSays", "npcSays","topic","0","0","Item 1","Money 2");
    }
}
