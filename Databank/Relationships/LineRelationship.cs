public class LineRelationship : IEntity
{
    private string personal = "0";
    private string pseen = "0";
    private string plock;
    private string presult;
    private int id1;
    private int id2;
    public string Personal { get => personal; set => personal = value; }
    public string Pseen { get => pseen; set => pseen = value; }
    public string Plock { get => plock; set => plock = value; }
    public string Presult { get => presult; set => presult = value; }
    public int Id1 { get => id1; set => id1 = value; }
    public int Id2 { get => id2; set => id2 = value; }

    public LineRelationship(string personal, string pseen, string pLock, string presult, int id1, int id2)
    {
        Id1 = id1;
        Id2 = id2;
        Pseen = pseen;
        Personal = personal;
        Plock = pLock;
        Presult = presult;
    }
    public static LineRelationship getFakeRel()
    {
        return new LineRelationship("","","","",0, 0);
    }
}