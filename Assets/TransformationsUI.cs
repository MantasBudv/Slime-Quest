using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationsUI : MonoBehaviour
{
    public Transform itemsParent;
    public static ActiveTransformationTab[] Transformatios;
    public static bool[] activeTransformations;
    public GameObject UI;

    void Start()
    {

        UI.SetActive(true);
        Transformatios = itemsParent.GetComponentsInChildren<ActiveTransformationTab>();
    }
    void Update()
    {
        if (activeTransformations != Shapeshifting.Transformations)
            activeTransformations = Shapeshifting.Transformations;
        for (int i = 0; i < activeTransformations.Length; i++)
        {
            if (activeTransformations[i] == true)
                Transformatios[i].SetActive(true);
            else Transformatios[i].SetActive(false);
        }
    }
}
