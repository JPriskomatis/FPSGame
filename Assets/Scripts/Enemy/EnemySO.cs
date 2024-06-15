using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data", fileName ="ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public int health;
    public GameObject enemyPrefab;


}

