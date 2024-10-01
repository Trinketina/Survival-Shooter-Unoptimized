using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth health;
    NavMeshAgent agent;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        health = GetComponent<EnemyHealth>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        agent.enabled = true;
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
