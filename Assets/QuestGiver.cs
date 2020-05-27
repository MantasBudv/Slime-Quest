using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;
    public Text counterText;
    private static int questIndex = 0;

    public void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }
    public void AcceptQuest()
    {
        if (!Quest.isActive)
        {
            Quest.UpdateQuest(QuestsStorage.titles[questIndex], QuestsStorage.descriptions[questIndex], QuestsStorage.types[questIndex]);
            titleText.text = Quest.title;
            descriptionText.text = Quest.description;
            Quest.Accept();
        }
    }
    public void FinishQuest()
    {
        Quest.Finish();
        QuestGoal.resetValues();
        MakeQuestDefault();
        questIndex++;
    }
    public void MakeQuestDefault()
    {
        titleText.text = "No active Quest";
        descriptionText.text = "No active Quest description";
        counterText.text = "";
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
            counterText.text = QuestGoal.currentAmount + " / " + QuestGoal.requiredAmount;
        }
        else
        {
            MakeQuestDefault();
        }
    }
}
public class Quest
{
    public static string title = "";
    public static string description = "";
    public static bool isActive = false;
    public static bool isFinished = false;
    public static string questType = "";

    public static void Accept()
    {
        isActive = true;
        isFinished = false;
    }
    public static void Finish()
    {
        isActive = false;
        isFinished = true;
    }
    public static void UpdateQuest(string titleNew, string descriptionNew, string typeNew)
    {
        title = titleNew;
        description = descriptionNew;
        questType = typeNew;
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
    public static void resetValues()
    {
        currentAmount = 0;
        currentItem = "nothing";
    }
}
