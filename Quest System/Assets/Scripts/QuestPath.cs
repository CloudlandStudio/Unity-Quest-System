using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPath
{
    //keep track of start & end event: make sure to link all events together
    public QuestEvent startEvent;
    public QuestEvent endEvent;

    public QuestPath(QuestEvent from, QuestEvent to)
    {
        startEvent = from;
        endEvent = to;
    }
}