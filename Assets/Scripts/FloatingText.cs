using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingText : MonoBehaviour
{
    private float DestroyTime = 1f;
    [SerializeField] private GameObject player;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + 0.5f, 1f).SetEase(Ease.OutQuad);

        Destroy(gameObject, DestroyTime);
    }
    private void Update()
    {
        transform.LookAt(transform.position - (player.transform.position - transform.position));
    }
}
