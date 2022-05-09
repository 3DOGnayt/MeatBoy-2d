using UnityEngine;


[CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Configs/ Quest Story Cfg", order = 1)]

public class QuestStoryConfig : ScriptableObject
{
    public QuestConfig[] quests;
    public QuestStoryType questStoryType;

}

public enum QuestStoryType
{
    Common,
    Resettable
}