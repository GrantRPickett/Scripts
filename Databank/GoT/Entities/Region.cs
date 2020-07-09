 using System;
public class Region : IEntity
{
    private int houseCount;
    private string desc;
    private string capital;
    private string name;

    public string Name { get => name; set => name = value; }
    public string Capital { get => capital; set => capital = value; }
    public string Desc { get => desc; set => desc = value; }
    public int HouseCount { get => houseCount; set => houseCount = value; }//todo remove
    public Region(string n, string c, string d, string hC)
    {
        Name = n;
        Capital = c;
        Desc = d;
        HouseCount = Int32.Parse(hC);
    }
}