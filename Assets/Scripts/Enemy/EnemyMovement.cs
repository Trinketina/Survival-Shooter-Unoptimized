using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth health;
    NavMeshAgent agent;

    bool initialized = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        health = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update ()
    {
        if (health.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            agent.SetDestination (player.position);
        }
        else
        {
            agent.enabled = false;
        }
    }
}
