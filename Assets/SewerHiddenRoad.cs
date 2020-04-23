using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SewerHiddenRoad : MonoBehaviour
{

    [SerializeField]
    GameObject Hidden;

    [SerializeField]
    GameObject Open;



    // Start is called before the first frame update
    void Start()
    {
        if (SewerSwitch.state)
        {
            Hidden.SetActive(false);
            Open.SetActive(true);
        }
        else
            Open.SetActive(false);
        
    }

}
