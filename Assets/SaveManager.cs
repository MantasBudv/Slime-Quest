using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public Item ms, ws;

    public static SaveManager instance;

    public SaveData activeSave;

    public static bool hasLoaded;

    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (!hasLoaded)
                Load();
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
        if (!hasLoaded)
        {
            ms.isUsed = false;
            ws.isUsed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
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
        //instance.activeSave.inventory = Inventory.instance.GetItems();        //Inventory
        instance.activeSave.questA = Quest.isActive;                            //Active quest
        instance.activeSave.questF = Quest.isFinished;                          //Finished quest
        instance.activeSave.questAmount = QuestGoal.currentAmount;              //Quest kills
        instance.activeSave.currScene = SceneManager.GetActiveScene().name;     //Current Scene


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

            if (SceneManager.GetActiveScene().name != instance.activeSave.currScene)    //Current scene
                SceneManager.LoadScene(instance.activeSave.currScene);
            //SceneManager.sceneLoaded += OnSceneLoaded;
            
            Shapeshifting.Transformations = instance.activeSave.transformations;        //Aquired Transformations
            SpaghettiLoad();                                                            //Shards 'spagetis' (pataisyti)
            HeroHealth.maxHealth = instance.activeSave.maxHP;                           //Max Health
            HeroHealth.currentHealth = instance.activeSave.currHP;                      //Current Health (known bug: issaugoti sliderio reikšmę)
            Shapeshifting.CurrentForm = instance.activeSave.currForm;                   //Current Form
            //Inventory.instance.SetItems(instance.activeSave.inventory);               //Inventory
            Quest.isActive = instance.activeSave.questA;                                //Active quest
            Quest.isFinished = instance.activeSave.questF;                              //Finished quest
            QuestGoal.currentAmount = instance.activeSave.questAmount;                  //Quest kills
            player.transform.position = instance.activeSave.respawnPosition;            //Possition


        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player.transform.position = instance.activeSave.respawnPosition;            //Possition
        Shapeshifting.Transformations = instance.activeSave.transformations;        //Aquired Transformations
        SpaghettiLoad();                                                            //Shards 'spagetis' (pataisyti)
        HeroHealth.maxHealth = instance.activeSave.maxHP;                           //Max Health
        HeroHealth.currentHealth = instance.activeSave.currHP;                      //Current Health (known bug: issaugoti sliderio reikšmę)
        Shapeshifting.CurrentForm = instance.activeSave.currForm;                   //Current Form
                                                                                    //Inventory.instance.SetItems(instance.activeSave.inventory);               //Inventory
        Quest.isActive = instance.activeSave.questA;                                //Active quest
        Quest.isFinished = instance.activeSave.questF;                              //Finished quest
        QuestGoal.currentAmount = instance.activeSave.questAmount;                  //Quest kills
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
    //volume
    public int currHP, maxHP;


    //inventory


}
