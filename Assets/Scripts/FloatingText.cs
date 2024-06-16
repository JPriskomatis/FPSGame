using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private float DestroyTime = 3f;
    [SerializeField] private GameObject player;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
    private void Update()
    {
        transform.LookAt(transform.position - (player.transform.position - transform.position));
    }
}
