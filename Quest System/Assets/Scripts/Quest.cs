using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//main graph class for quest system
public class Quest
{
    public List<QuestEvent> questEvents = new List<QuestEvent>();
    //each event has a list of the paths that goes between one & the other: don't need another pathlist going on in this quest
    List<QuestEvent> pathList = new List<QuestEvent>(); //quest events in pathlist are events in the path, not the paths themselves. 

    public Quest()
    { }

    //main method for creating an event and add it to the Quest at the same time: pass through name & description, used by QuestManager
    public QuestEvent AddQuestEvent(string evtName, string evtDescription)
    {
        QuestEvent questEvent = new QuestEvent(evtName, evtDescription);
        questEvents.Add(questEvent);
        return questEvent;
    }

    //construct a path between fromQuestEvent & toQuestEvent ids: allow quests with the same names
    //before adding any paths: must add all events to serve those paths to prevent errors
    public void AddPath(string fromQuestEvent, string toQuestEvent)
    {
        QuestEvent from = FindQuestEvent(fromQuestEvent);
        QuestEvent to = FindQuestEvent(toQuestEvent);
        if (from != null && to != null)
        {
            QuestPath path = new QuestPath(from, to);
            from.pathList.Add(path);
        }
    }

    //Loop through all the quests it got hold off & find the correct one using id
    QuestEvent FindQuestEvent(string id)
    {
        foreach (QuestEvent evt in questEvents)
        {
            if (evt.GetID() == id)
            {
                return evt;
            }
        }
        return null;
    }

    //debug what you put in the graph afterwards: loop through all quest events & print their given name
    public void PrintPath()
    {
        foreach (QuestEvent evt in questEvents)
        {
            Debug.Log(evt.eventName);
        }
    }
}