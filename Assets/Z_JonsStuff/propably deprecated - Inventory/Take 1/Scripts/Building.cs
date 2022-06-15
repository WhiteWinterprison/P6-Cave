using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Building", menuName ="Building/ Create new Building")]
public class Building : ScriptableObject
{
    public int id;
    public string buildingName;
    public int environmentalImpact;
    public int cost;
    public int sustainability;
    public Sprite img;
    public GameObject obj;
}
