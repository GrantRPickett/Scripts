using System.Collections;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinesView : MonoBehaviour
{
    PeopleManager pm;
    int npcId = 1;
    int money = 0;
    GetData gd;
    InsertData ins;
    g g;
    public Text tempMoneyTest;
    public Button Leave;
    public Button Talk;
    public Button Inv;
    public Text npc;
    public GameObject ButtonFab;
    public GameObject TextFab;
    List<DataTable> dts = new List<DataTable>();
    public HashSet<string> topics;
    public HashSet<string> pLines;
    //todo move this
    public HashSet<string> seen = new HashSet<string>();
    public HashSet<string> inv = new HashSet<string>();
    public List<string> qs = new List<string>();
    public List <GameObject> buttons = new List<GameObject>();
    public List <GameObject> texts = new List<GameObject>();
    private class js {
        public string Type = "Error";
        public string Val = "Error";
    }
    void Start () {
        gd = new GetData();
        //pm= PeopleManager.GetInstance() as PeopleManager;
        ins = new InsertData();
        g = g.SharedInstance;
        var b = Talk.GetComponent<Button>();
        b.onClick.AddListener(() => talkCallBack(b));
        var l = Leave.GetComponent<Button>();
        l.onClick.AddListener(() => leaveCallBack(l));
        l.interactable = false;
        var t = Inv.GetComponent<Button>();
        t.onClick.AddListener(() => leaveCallBack(t));
        t.interactable = false;
    }

    void OnEnable()
    {
        //updateLines
    }
    void OnDisable()
    {
        //Un-Register Button Events
        //.onClick.RemoveAllListeners();
    }
    private void greet(){
        var r = Resources.Load("TextFab");
        var c = GameObject.Find("NPCcontent");
        GameObject npcText = Instantiate(r as GameObject, new Vector2(0, 0), Quaternion.identity, c.transform);
        texts.Add(npcText);
        var nt = npcText.GetComponent<Text>();
        nt.text = "Hello";
        nt.color = Color.blue;
        DataTable npcs = gd.selectById("Person",npcId);
        var name = npc.GetComponent<Text>();
        name.text = npcs.Rows[0]["Name"].ToString();
    }
    private void updateLines(){
        cleanButtons(buttons);
        dts.Clear();
        //add line to display
        var gt = true; //todo config content expansions
        //dts.Add(gd.lines(npcId));
        if(gt)
            dts.Add(gd.gtlines(npcId));
        //get locks
        var c = GameObject.Find("Content");
        var r = Resources.Load("ButtonFab");
        topics = new HashSet<string>();
        foreach (DataTable dt in dts)  {
            foreach (DataRow dr in dt.Rows)  {
                //Debug.Log(++codex);
                var str = dr["Topic"].ToString();
                //update locked topics
                var mode = 2;//Random.Range(0,4);
                var locked = false;
                var personal = dr["Personal"].ToString();
                var s = dr["Seen"].ToString();
                if(personal == "1"){
                    s = dr["Pseen"].ToString();
                }
                var lck = dr["LockCode"].ToString();
                if(dr["Personal"].ToString() == "2"){
                    lck = dr["Plock"].ToString();
                }
                if(lck != null) {
                    var lockCode = lck;
                    var locks = lockCode.Split('|');
                    if(lockCode != null && lockCode != "" && locks != null && locks.Length > 0 ){
                        foreach(var l in locks){
                            locked = checkLock(l, dt);
                            if(locked)
                                break;
                        }
                        if(locked){
                            mode = 0;
                            if(mode == 0 ){
                                continue;
                            }
                            if(mode > 0 ){
                                str = "[Locked";
                                if(mode > 1 )
                                    str += $" {lockCode} ";
                                str += "]";
                            }
                        }
                    }
                }
                //todo sort seen topics
                if(!topics.Contains(str)){
                    topics.Add(str);
                    //Debug.Log("new button");
                    GameObject bext = Instantiate(r as GameObject, new Vector2(0, 0), Quaternion.identity, c.transform);
                    buttons.Add(bext);
                    var b = bext.GetComponent<Button>();
                    var pt = bext.GetComponentInChildren<Text>();
                    pt.text = str;
                    //TODO add hover preview b.on .AddListener(() => buttonCallBack(b));
                    b.onClick.AddListener(() => buttonCallBack(b));
                    if(locked)
                        b.interactable = false;
                    if(s!="0"){
                        b.colors = color(Color.gray);
                    }
                    if(dr["Color"].ToString()=="1"){
                        b.colors = color(Color.yellow);
                    }
                }
            }
        }
    }
    private int giveResult(string result)
    {
        var parts = result.Split(' ');
        //Debug.Log(result+"!");
        switch (parts[0]){
            case "Money":
                return money += int.Parse(parts[1]);
            case "Item":
                inv.Add(parts[1]);
                return inv.Count;
            case "Topic":
            case "GTTopic":
                seen.Add(parts[1]);
                return inv.Count;
            default:
                //todo reflect player trait 
                var trait = parts[0];
                var traitVal = 0;
                return traitVal += int.Parse(parts[1]); 
        }
    }
    private bool checkLock(string lck, DataTable dt){
        //Debug.Log(lck+"?");
        var parts = lck.Split(' ');
        switch (parts[0]){
            case "Line":{
                var row = dt.Select($"rowid = '{parts[1]}'");
                return row[0]["Seen"].ToString()!="1";
            }
            case "GTLine": {
                var row = dt.Select($"rowid = '{parts[1]}'");
                return row[0]["Seen"].ToString()!="1";
            }
            case "PersonGTLine":{
                var row = dt.Select($"rowid1 = '{parts[1]}'");
                return row[0]["Pseen"].ToString()!="1";
            }
            case "Topic":
            case "GTTopic":
                return !seen.Contains(parts[1]);
                // DataRow[] foundRows = dt.Select($"rowid = '{parts[1]}'");
                // if(foundRows.Length > 0 && foundRows[0].ItemArray[3].ToString() == "1"){
                //     return false;
                // }
            case "Money":
                if(">" == parts[1])
                    return money <= int.Parse(parts[2]);
                if("<" == parts[1])
                    return money >= int.Parse(parts[2]);
            break;
            case "Item":
                return !inv.Contains(parts[1]);
            default:
                //todo reflect player trait 
                var trait = parts[0];
                if(">" == parts[1])
                    return 0 <= int.Parse(parts[2]);
                if("<" == parts[1])
                    return 0 >= int.Parse(parts[2]);
            break;   
        }
        return true;
    }
    private void talkCallBack(Button b){
        npcId = Random.Range(1,11);
        var l = Leave.GetComponent<Button>();
        l.interactable = true;
        b.interactable = false;
        Debug.Log("Talk");
        greet();
        updateLines();
    }
    private void leaveCallBack(Button b)
    {
        var t = Talk.GetComponent<Button>();
        t.interactable = true;
        b.interactable = false;
        Debug.Log("Leave");
        leave();
    }
    private void buttonCallBack(Button buttonPressed)
    {
        //do i need to check for leave button?
        var tx = buttonPressed.GetComponentInChildren<Text>();
        //Debug.Log("Clicked: " + tx.text);
        var expression = $"Topic = '{tx.text}'";
        foreach(DataTable dt in dts){
            DataRow[] foundRows = dt.Select(expression);
            foreach(DataRow dr in foundRows) {
                pLines = new HashSet<string>();
                Debug.Log(string.Join("|",dr.ItemArray));
                var personal = dr["Personal"].ToString();
                var s = dr["Seen"].ToString();
                if(personal == "1"){
                    s = dr["Pseen"].ToString();
                }
                var re = dr["Result"].ToString();
                var lid = dr[7].ToString();
                var p = dr["PlayerSays"].ToString();
                if(!pLines.Contains(p)){//skip playerline dups
                    var r = Resources.Load("TextFab");
                    var c = GameObject.Find("NPCcontent");
                    var n = dr["NpcSays"].ToString();
                    var tp = dr["Topic"].ToString();
                    pLines.Add(p);
                    GameObject playerText = Instantiate(r as GameObject, new Vector2(0, 0), Quaternion.identity, c.transform);
                    var pt = playerText.GetComponent<Text>();
                    GameObject npcText = Instantiate(r as GameObject, new Vector2(0, 0), Quaternion.identity, c.transform);
                    var nt = npcText.GetComponent<Text>();
                    pt.text = p.ToString();
                    pt.color = Color.black;
                    nt.text = n.ToString();
                    nt.color = Color.blue;
                    texts.Add(playerText);
                    texts.Add(npcText);
                }
                if(s=="0"){
                    buttonPressed.colors = color(Color.gray);
                    var table = "GTLine"; var seen = "Seen";
                    if(personal == "1"){
                        table = "PersonGTLine";
                        seen = "Pseen";
                        lid = dr[8].ToString();
                        re = dr["Presult"].ToString();
                    }
                    //Debug.Log($"t{table} s{seen} l{lid}");
                    qs.Add(ins.update(table, seen,"1",int.Parse(lid)));// send to correct db table
                    if(re!=null && re!="" && re!="0"){
                        var temp = tempMoneyTest.GetComponent<Text>();
                        //temp.text = re;
                        var results = re.Split('|');
                        //todo handle multiple results by loop over chunks
                        foreach(var result in results){
                            giveResult(result);
                        }  
                        //db call todo fix
                    }
                }
                //set seen and give result
            }
        }
        ins.transaction(qs);
        updateLines();
    }
    private void cleanButtons(List<GameObject> gos){
        //todo disconnect button listeners
        foreach(var go in gos){
            var b = go.GetComponent<Button>();
            b.onClick.RemoveListener(() => buttonCallBack(b));
            Destroy(go);
        }
        gos.Clear();
    }
    private void leave(){
        var name = npc.GetComponent<Text>();
        name.text = "NPC";
        cleanButtons(buttons);
        cleanText(texts);
        dts.Clear();
    }

    private void cleanText(List<GameObject> gos)
    {
        foreach(var go in gos){
            Destroy(go);
        }
        gos.Clear();
    }

    private ColorBlock color(Color c){
        ColorBlock cb = new ColorBlock();
        cb.highlightedColor = c;
        cb.normalColor = c;
        cb.pressedColor = c;
        cb.selectedColor = c;
        cb.colorMultiplier = 1;
        return cb;
    }
}
