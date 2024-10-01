using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Player Data")]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public int startingHealth { get; private set; } = 100;
    public int currentHealth;

    public Transform playerLocation;
}
