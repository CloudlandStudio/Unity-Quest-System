using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Quest quest = new Quest();

    // Start is called before the first frame update
    void Start()
    {
        QuestEvent a = quest.AddQuestEvent("test1", "description1");
        QuestEvent b = quest.AddQuestEvent("test2", "description2");
        QuestEvent cOpt = quest.AddQuestEvent("test3", "description3"); //optional quest
        QuestEvent dOpt = quest.AddQuestEvent("test4", "description4"); //optional quest
        QuestEvent e = quest.AddQuestEvent("test5", "description5");

        //define the paths between events: the order they must be completed
        quest.AddPath(a.GetID(), b.GetID());
        quest.AddPath(b.GetID(), cOpt.GetID()); //choosen 1 of the optional paths
        quest.AddPath(b.GetID(), dOpt.GetID()); //choosen 1 of the optional paths
        quest.AddPath(cOpt.GetID(), e.GetID()); //optional chosen path variant to end quest
        quest.AddPath(dOpt.GetID(), e.GetID()); //optional chosen path variant to end quest

        quest.PrintPath(); //check all paths have been added into quest
    }
}