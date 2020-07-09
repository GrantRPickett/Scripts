using System.Collections;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DataBank;

public class PersonLineManager : Singleton<PersonLineManager> {
    private InsertData ins = new InsertData(); 
    private Dictionary<string,int> segs = new Dictionary<string, int>();
    private List<string> qs;
    System.Random rnd = new System.Random();
    private g g = g.SharedInstance;
    private RHs rh = RHs.SharedInstance;
    LineManager lm;
    int rseg;
    int hseg;
    GetData gd = new GetData();
    DataTable rdt;
    DataTable hdt;
    DataTable hxr;
    int topicIndex = 1;
    public int AllPersonBaseLines(PeopleManager pm, LineManager l){
        lm = l;
        PersonBaseLines();
        rseg = qs.Count+1;
        rdt = gd.selectTable("Region");
        hdt = gd.selectTable("House");
        hxr = gd.selectTable("HouseRegion");
        RHBaseLines();//todo maybe config
        qs = new List<string>();
        foreach(var p in pm.people){
            PersonLinesRel(p.Key, p.Value);
        }
        ins.transaction(qs);
        qs = new List<string>();
        foreach(var p in pm.people){
            PersonHRLinesRel(p.Key, p.Value);
        }
        ins.transaction(qs);
        return 0;
    }

    private void RHBaseLines(){
        //todo pull the correct tables to get house.count from Reg 
        qs = new List<string>();
        rseg = 1;
        var si = 0;
        foreach(DataRow row in rdt.Rows){
            gl(new Line(rseg,si++,"Which kingdom are you from?",row["Name"].ToString(),"Which Kingdom"));
            gl(new Line(rseg,si++,$"What is {row["Name"]} like?",row["Desc"].ToString(),$"About {row["Name"]}","0","0",$"GTTopic {topicIndex}","Item 2"));
            gl(new Line(rseg,si++,$"What is the capital of {row["Name"]}?",row["Capital"].ToString(),$"{row["Name"]} Capital","0","0",$"GTTopic {topicIndex++}","Money -5"));
        }
        hseg = si+1; si = 0;
        foreach(DataRow row in hdt.Rows){
            gl(new Line(hseg,si++,"Which house are you from?",row["Name"].ToString(),"Which House"));
            gl(new Line(hseg,si++,$"What is the {row["Name"]} sigil?",row["Sigil"].ToString(),$"{row["Name"]} Sigil","0","0",$"GTTopic {topicIndex++}","Money 5"));
        }
        ins.transaction(qs);
    }

    private void PersonHRLinesRel(int key, Person value)
    {
        var seg = key;
        //var si = 0;
        int r = rnd.Next(0,rdt.Rows.Count);
        DataRow[] foundRows = hxr.Select($"id2 = '{r+1}'");
        int h = rnd.Next(0,foundRows.Length);
        Debug.Log($"{r} {h} {foundRows[h].ItemArray[1]}");
        int hi = int.Parse(foundRows[h].ItemArray[1].ToString())-1;
        int rid = r*3+1;
        int hid = rdt.Rows.Count*3 + hi*2+1; //27+54*2+1
        Debug.Log($"{r} {h} {hseg} {rid} {hi} {hid}");
        lr("PersonGTLine", key,rid, "1","0","0","");
        lr("PersonGTLine", key,rid+1, "2","0",$"PersonGTLine {qs.Count}","0");
        lr("PersonGTLine", key,rid+2, "2", "0",$"PersonGTLine {qs.Count-1}","0");
        lr("PersonGTLine", key,hid, "1","0","0","");
        lr("PersonGTLine", key,hid+1, "2","0",$"PersonGTLine {qs.Count}","0");
    }

    public int PersonBaseLines() {
        var seg = 1; var p = Person.getFake();
        qs = new List<string>();
        foreach(var trait in p.GetType().GetProperties()){
            var si = 0;
            var v = trait.GetValue(p);
            if(v.GetType() == typeof(int)){
                segs.Add(trait.Name,qs.Count+1);
                string ps = trait.Name+"?", ns = "";
                //segs.Add(trait.Name,seg); //todo change to table line count?
                switch (trait.Name) {
                    case "Job":
                        foreach(var job in g.jobs){
                            ns = "I work as {a} " + job.Value;
                            l(new Line(seg,si++,ps, ns, trait.Name));
                        }
                        seg++;
                    break;
                    case "Age":
                        foreach(var age in g.ages){
                            ns = age.Value;
                            l(new Line(seg,si++,ps, ns, trait.Name)); 
                        }
                        seg++;
                    break;
                    case "Hair":
                        foreach(var hc in g.hairColors){
                            ns = hc.Value;
                            l(new Line(seg,si++,ps, ns, trait.Name));
                        }
                        seg++;
                    break;
                    case "Eye":
                        foreach(var ec in g.eyeColors){
                            ns = ec.Value;
                            l(new Line(seg,si++,ps, ns, trait.Name)); 
                        }
                        seg++;
                    break;
                    case "Inj":
                        foreach(var inj in g.injuries){
                            ns = inj.Value;
                            l(new Line(seg,si++,ps, ns, trait.Name)); 
                        }
                        seg++;
                    break;
                    case "Money":
                        ns = "I have {money}";
                        l(new Line(seg++,si++,ps, ns, trait.Name)); 
                    break;
                    case "Gender":
                        foreach(var gn in g.genders){
                            ns = "I am "+ gn.Value;
                            l(new Line(seg,si++,ps, ns, trait.Name)); 
                        }
                        seg++;
                    break;
                    case "State":
                    // skip having a line saying I'm talking
                        continue;
                    case "Faction":
                    // skip having a line saying faction
                        continue;
                    //break;
                    default:
                        l(new Line(seg,si++,ps, "High "+trait.Name, trait.Name));
                        l(new Line(seg,si++,ps, "Some "+trait.Name, trait.Name));
                        l(new Line(seg,si++,ps, "Low "+trait.Name, trait.Name));
                        seg++;
                    break;
                }
            }
        }
        Debug.Log(qs.Count);
        return ins.transaction(qs);
    }
    public void PersonLinesRel(int id, Person p) {
        foreach(var trait in p.GetType().GetProperties()){
            var lid = -1; var seg = -1; var si = -1;
            var v = trait.GetValue(p);
            if(v.GetType() == typeof(int)){
                segs.TryGetValue(trait.Name, out seg);
                switch (trait.Name) {
                    case "Money":
                        si = 0;
                        //Debug.Log(id+ trait.Name+" "+ seg+" "+ si);
                    break;
                    default:
                        si = (int) trait.GetValue(p);
                        //Debug.Log(id+ trait.Name+" "+ seg+" "+ si);
                    break;
                }
                lid = seg+si;
                lr("PersonLine", id, lid, "0", "0","0","0");
            }
        }
        //Debug.Log(qs.Count);
    }
    public void gl(Line line){
        qs.Add(ins.add("GTLine", line));
        lm.lines.Add(lm.lines.Count,line);
    }
    public void l(Line line){
        qs.Add(ins.add(line));
        lm.lines.Add(lm.lines.Count,line);
    }
    public void lr(string table, int id1, int id2, string personal, string pseen, string plock, string presult){
        qs.Add(ins.add(table, new LineRelationship(personal, pseen, plock, presult, id1, id2)));
    }
}