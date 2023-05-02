using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mineral", menuName = "MineralChemicalPropertySO")]
public class MineralChemicalProperty : ScriptableObject
{
    public string mineralName;
    public enum Elements
    {
        Fe,
        Si,
        Ca,
        C,
        S,
        Pb,
        K,
        Al
    }
    public Elements[] elements;
    public bool isOxide;
}
