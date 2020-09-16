using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent
{
    public enum EventStatus
    {
        WAITING, //not yet completed but can't be worked on because there's a prerequisite event
        CURRENT, //the one event which the player should be trying to achieve
        DONE //has been achieved
    }

    public string eventName;
    public string description;
    public string id; //unique identifier in quest system so code can find it later
    public EventStatus status;

    //keeps track of where the player can go to, once they've completed this event: pathList gives of the link to the next event that has to be done in the quest
    public List<QuestPath> pathList = new List<QuestPath>();

    public QuestEvent(string namestr, string descriptionstr)
    {
        id = Guid.NewGuid().ToString(); //generate unique event id
        eventName = namestr;
        description = descriptionstr;
        status = EventStatus.WAITING; //all initial events are set to WAITING status
    }

    public void UpdateQuestEvent(EventStatus eventStatus) //called from the outside to send a new event
    {
        status = eventStatus;
    }

    public string GetID()
    {
        return id;
    }

}