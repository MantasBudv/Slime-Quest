using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsStorage : MonoBehaviour
{
    public static int index = 0;
    public static string[] titles = { "Adventures Begin!", "A Helping Hand" };
    public static string[] descriptions = { "Kill 3 enemies and go back to witch to collect your reward!", "Go to the dungeon and bring back the lost item to the Green Man" };
    public static string[] types = { "Kill", "Fetch" };
}
