using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject teleportDestination; // Destination GameObject where player will teleport
    public GameObject teleportTrigger; // Trigger GameObject to detect player's touch

    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player (or any object with the "Player" tag) touches the teleport trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player");
            // Teleport the player to the destination
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // Ensure there's a destination set
        if (teleportDestination != null)
        {
            // Teleport the player to the destination's position
            audioSource.Play();
            player.transform.position = teleportDestination.transform.position;
            Debug.Log("Player teleported to: " + teleportDestination.name);
        }
        else
        {
            Debug.LogWarning("Teleport destination is not set!");
        }
    }
}
