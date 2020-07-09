using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Person : IEntity
{
    private string name;
    private string state;
    private int money;
    private int age;
    private int gender;
    private int height;
    private int weight;
    private int hair;
    private int eye;
    private int hp;
    private int str;
    private int agi;
    private int inj;
    private int perceptive;//o
    private int disciplined;//c
    private int confedence;//e
    private int trusting;//a
    private int moody;//n
    private int faction;
    private int moral;
    private int bounty;
    private int xp;
    private int job;
    public string State { get => state; set => state = value; }
    public string Name { get => name; set => name = value; }
    public int Money { get => money; set => money = value; }
    public int Age { get => age; set => age = value; }
    public int Gender { get => gender; set => gender = value; }
    public int Height { get => height; set => height = value; }
    public int Weight { get => weight; set => weight = value; }
    public int Hair { get => hair; set => hair = value; }
    public int Eye { get => eye; set => eye = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Str { get => str; set => str = value; }
    public int Agi { get => agi; set => agi = value; }
    public int Inj { get => inj; set => inj = value; }
    public int Perceptive { get => perceptive; set => perceptive = value; }
    public int Disciplined { get => disciplined; set => disciplined = value; }
    public int Confedence { get => confedence; set => confedence = value; }
    public int Trusting { get => trusting; set => trusting = value; }
    public int Moody { get => moody; set => moody = value; }
    public int Faction { get => faction; set => faction = value; }
    public int Moral { get => moral; set => moral = value; }
    public int Bounty { get => bounty; set => bounty = value; }
    public int Xp { get => xp; set => xp = value; }
    public int Job { get => job; set => job = value; }
    public Person(string name, string state="0")
    {
    }
    public Person(string name, List<int> ints, string state="0")
    {
        Name = name;
        State = state;
        Money = ints[1];
        Age = ints[2];
        Gender = ints[3];
        Job = ints[4];
        Faction = ints[5];
        Hair = ints[6];
        Eye = ints[7];
        Inj = ints[8];
        Str = ints[9];
        Agi = ints[10];
        Height = ints[11];
        Weight = ints[12];
        Hp = ints[13];
        Perceptive = ints[14];
        Disciplined = ints[15];
        Confedence = ints[16];
        Trusting = ints[17];
        Moody = ints[18];
        Moral = ints[18];
        Bounty = ints[20];
        Xp = ints[21];
    }

    public static Person getFake()
    {
        g g = g.SharedInstance;
        var ints = new List<int>(){
            0,r(99),r(g.ages.Count),r(g.genders.Count),
            r(g.jobs.Count),r(1),r(g.hairColors.Count),
            r(g.eyeColors.Count),r(g.injuries.Count),
            r(3),r(3),r(3),r(3),r(3),
            r(3),r(3),r(3),r(3),r(3),
            r(3),r(3),r(3)};
        string[] fn = (r(2)==1)?
        g.ffirstNames.ToArray():g.mfirstNames.ToArray();//todo optimize
        string[] ln = g.lastNames.ToArray();
        string rfn = fn[r(fn.Length)];
        string rln = ln[r(ln.Length)];

        return new Person($"{rfn} {rln}", ints);
    }
    private static int r(int i){
        return UnityEngine.Random.Range(0, i);
    }
}
