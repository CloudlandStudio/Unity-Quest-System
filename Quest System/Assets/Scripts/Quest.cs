using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public List<QuestEvent> questEvents = new List<QuestEvent>();
    List<QuestEvent> pathList = new List<QuestEvent>();

    public Quest()
    { }

    public QuestEvent AddQuestEvent(string n, string d)
    {
        QuestEvent questEvent = new QuestEvent(n, d);
        questEvents.Add(questEvent);
        return questEvent;
    }

    public void AddPath(string fromQuestEvent, string toQuestEvent)
    {
        questEvent from = findQuestEvent(fromQuestEvent),
    }

    QuestEvent findQuestEvent(string id)
    {

    }
}