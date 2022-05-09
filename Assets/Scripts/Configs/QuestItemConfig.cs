using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Configs/ Quest Item Cfg", order = 1)]

public class QuestItemConfig : ScriptableObject
{
    public int questId;
    public List<int> questItemCollection;

}
