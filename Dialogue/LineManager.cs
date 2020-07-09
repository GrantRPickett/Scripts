using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
public class LineManager : Singleton<LineManager> {
    public Dictionary<int, Line> lines {get; set;} = new Dictionary<int, Line>();
}
