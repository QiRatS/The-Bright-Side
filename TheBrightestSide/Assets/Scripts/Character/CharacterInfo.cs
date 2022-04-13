using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character")]

public class CharacterInfo : ScriptableObject
{
    Rigidbody rb;

    public new string name;
    public int attackValue;
    public int energyCost;
    public int health;
    public int acell;
    public int jumpForce;
    public int floatForce;
    public float floatTime;
    public int recoilForce;
    public float recoilFixCoef;
    public float projTime;

    public int maxSpeed;
   

    public Sprite artwork;

    public GameObject Prefab;
   
}

//contains basic data information
