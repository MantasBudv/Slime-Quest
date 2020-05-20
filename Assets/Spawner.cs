using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public int counter;
    public int maxCount;

    public Transform[] path1;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    void Start()
    {
        counter = 0;
        Spawn();
        RestartTimer();
    }

    void Update()
    {
        if ((timeBtwSpawns <= 0) && (counter < maxCount)) 
        {
            //GameObject mole = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
            //mole.GetComponent<Mole>().path[0] = path1[0];
            //mole.GetComponent<Mole>().path[1] = path1[1];
            //Debug.Log("Spawned");
            //counter++;
            Spawn();
            RestartTimer();
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

    }


    void Spawn()
    {
        GameObject mole = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
        mole.GetComponent<Mole>().path[0] = path1[0];
        mole.GetComponent<Mole>().path[1] = path1[1];
        mole.GetComponent<EnemyHealth>().spawner = gameObject;
        Debug.Log("Spawned");
        counter++;
    }

    public void RestartTimer()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
}
