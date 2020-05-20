using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;

    public void AcceptQuest()
    {
        titleText.text = Quest.title;
        descriptionText.text = Quest.description;
        Debug.Log(Quest.isActive);
        Quest.Accept();
        Debug.Log(Quest.isActive);
    }
    public void FinishQuest()
    {
        Quest.Finish();
        QuestGoal.resetAmount();
        MakeQuestDefault();
    }
    public void MakeQuestDefault()
    {
        titleText.text = "No active Quest";
        descriptionText.text = "No active Quest description";
    }
    public void IncrementKillCount()
    {
        if (Quest.isActive && !Quest.isFinished)
            QuestGoal.currentAmount++;
    }
    public bool CheckKillCount()
    {
        return QuestGoal.isReachedKillCount();
    }
}
public class Quest
{
    public static string title = "Adventures Begin!";
    public static string description = "Bring back the wand to witch from the dungeon";
    public static bool isActive = false;
    public static bool isFinished = false;

    public static void Accept()
    {
        isActive = true;
    }
    public static void Finish()
    {
        isActive = false;
        isFinished = true;
    }
}

public class QuestGoal
{
    public static int requiredAmount = 3;
    public static int currentAmount = 0;

    public static string requiredItem = "something";
    public static string currentItem = "nothing";

    public static bool isReachedKillCount()
    {
        return (currentAmount >= requiredAmount);
    }
    public static bool isItemCollected()
    {
        return (requiredItem == currentItem);
    }
    public static void resetAmount()
    {
        currentAmount = 0;
    }
}
