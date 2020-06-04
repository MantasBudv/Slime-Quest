using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Item ms, ws;

    public static SaveManager instance;

    public SaveData activeSave;

    public static bool hasLoaded;

    public GameObject player;

    private static Scene newScene;

    public GameObject loadingScreen;
    public Slider slider;

    public static float loadprog;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (!hasLoaded) 
            { 
                //Load();
                ms.isUsed = false;
                ws.isUsed = false;
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //if (!hasLoaded)
        //{
        //    ms.isUsed = false;
        //    ws.isUsed = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (loadprog == 1)
        {
            LoadValues();
            loadprog = 0;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DeleteSaveData();
        }
    }

    public void Save()
    {
        instance.activeSave.respawnPosition = player.transform.position;        //Possition
        instance.activeSave.transformations = Shapeshifting.Transformations;    //Aquired Transformations
        instance.activeSave.maxHP = HeroHealth.maxHealth;                       //Max Health
        instance.activeSave.currHP = HeroHealth.currentHealth;                  //Current Health
        instance.activeSave.currForm = Shapeshifting.CurrentForm;               //Current Form
        instance.activeSave.inventory = Inventory.instance.GetItems();        //Inventory
        instance.activeSave.questA = Quest.isActive;                            //Active quest
        instance.activeSave.questF = Quest.isFinished;                          //Finished quest
        instance.activeSave.questAmount = QuestGoal.currentAmount;              //Quest kills
        instance.activeSave.currScene = SceneManager.GetActiveScene().name;     //Current Scene
        instance.activeSave.complete = CompletionUI.completed;                  //game completed
        instance.activeSave.questFetch = QuestGoal.currentItem;
        instance.activeSave.WC = HeroQuest.witchQuestCompleted;
        instance.activeSave.GMC = HeroQuest.greenManQuestCompleted;
        instance.activeSave.Qind = QuestGiver.questIndex;
        instance.activeSave.startDialogue = HeroHealth.startDialogue;


        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();


        Debug.Log("Saved");

    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasLoaded = true;

            StartCoroutine(LoadScene(instance.activeSave.currScene));


        }

    }



    public void SpaghettiLoad()
    {
        if (instance.activeSave.transformations[1])
            ms.isUsed = true;

        if (instance.activeSave.transformations[2])
            ws.isUsed = true;
    }

    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
            File.Delete(dataPath + "/" + activeSave.saveName + "Inv" + ".save");
            Debug.Log("Deleted");
            hasLoaded = false;
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            loadprog = progress;

            yield return null;
        }
    }

    public void LoadValues()
    {
        string dataPath = Application.persistentDataPath;

        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasLoaded = true;

            HeroHealth.maxHealth = instance.activeSave.maxHP;                           //Max Health
            HeroHealth.currentHealth = instance.activeSave.currHP;                      //Current Health (known bug: issaugoti sliderio reikšmę)
            Shapeshifting.CurrentForm = instance.activeSave.currForm;                   //Current Form
                                                                                        //Inventory.instance.LoadItems(instance.activeSave.inventory);                //Inventory
            //Quest.isActive = instance.activeSave.questA;                                //Active quest
            Quest.isFinished = instance.activeSave.questF;                              //Finished quest
            QuestGoal.currentAmount = instance.activeSave.questAmount;                  //Quest kills
            player.transform.position = instance.activeSave.respawnPosition;            //Possition
            Shapeshifting.Transformations = instance.activeSave.transformations;        //Aquired Transformations
            SpaghettiLoad();                                                            //Shards 'spagetis' (pataisyti)
            if(instance.activeSave.inventory.Any())
               Inventory.instance.SetItems(instance.activeSave.inventory);
            CompletionUI.completed = instance.activeSave.complete;                      //game completed
            QuestGoal.currentItem = instance.activeSave.questFetch;
            HeroQuest.witchQuestCompleted = instance.activeSave.WC;
            HeroQuest.greenManQuestCompleted = instance.activeSave.GMC;
            QuestGiver.questIndex = instance.activeSave.Qind;
            HeroHealth.startDialogue = instance.activeSave.startDialogue;

            if (instance.activeSave.questA == true)
            {
                QuestGiver.instance.AcceptQuest();
            }
        }
    }


}

//--------------------SAVE-DATA-----------------------

[System.Serializable]
public class SaveData
{
    public string saveName;

    public Vector3 respawnPosition;
    public bool[] transformations;
    public int currForm;
    public string currScene;
    public bool questA, questF;
    public int questAmount;
    public string questFetch;
    //quest
    //volume
    public int currHP, maxHP;
    public List<Item> inventory;
    public bool complete;
    public bool WC, GMC;
    public int Qind;
    public bool startDialogue;

}
