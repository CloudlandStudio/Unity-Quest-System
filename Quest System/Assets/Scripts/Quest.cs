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

    //Loop through all the quests & find the correct one using id
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

    public void BreadthFirstSearch(string id, int orderNumber = 1)
    {
        QuestEvent thisEvent = FindQuestEvent(id); //find the quest from this id
        thisEvent.order = orderNumber;
        foreach (QuestPath e in thisEvent.pathList) //list of all the events you can get to from thisEvent
        {
            if (e.endEvent.order == -1) //run BFS for unordered event from that position
            {
                //recursive algorithm that keeps calling itself, working its way down through the graph & update order number each time as it comes through into the next node
                BreadthFirstSearch(e.endEvent.GetID(), orderNumber + 1);
            }
        }
    }

    //debug what you put in the graph afterwards: loop through all quest events & print their given name
    public void PrintPath()
    {
        foreach (QuestEvent evt in questEvents)
        {
            Debug.Log(evt.eventName + " order: " + evt.order);
        }
    }
}