public class House : IEntity
{
    private int regionId;
    private string sigil;
    private string rank;
    private string name;

    public string Name { get => name; set => name = value; }
    public string Rank { get => rank; set => rank = value; }
    public string Sigil { get => sigil; set => sigil = value; }
    public int RegionId { get => regionId; set => regionId = value; }
    public House(string n, string r, string s, int rId)
    {
        Name = n;
        Rank = r;
        Sigil = s;
        RegionId = rId;
    }
}