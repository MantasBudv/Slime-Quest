using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;

    public void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        if (SaveManager.hasLoaded)
            UpdateUI();
    }
    public void AcceptQuest()
    {
        titleText.text = Quest.title;
        descriptionText.text = Quest.description;
        Quest.Accept();
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
        descriptionText.text = "Go get a quest by talking to a witch living in a house near the woods.";
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
    public bool CheckItemFetched()
    {
        return QuestGoal.isItemCollected();
    }
    public void UpdateUI()
    {
        if (Quest.isActive)
        {
            titleText.text = Quest.title;
            descriptionText.text = Quest.description;
        }
        else
        {
            MakeQuestDefault();
        }
    }
}
public class Quest
{
    public static string title = "Adventures Begin!";
    public static string description = "Kill 3 enemies and go back to witch to collect your reward!";
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
    public static string questType = "Kill";
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
