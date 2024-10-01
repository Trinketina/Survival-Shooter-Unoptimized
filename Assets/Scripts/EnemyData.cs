using UnityEngine;

[CreateAssetMenu(menuName = "Create Enemy Data")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float timeBetweenAttacks { get; private set; } = 0.5f;
    [field: SerializeField]  public int attackDamage { get; private set; } = 10;

    [field: SerializeField]  public float sinkSpeed { get; private set; } = 2.5f;
    [field: SerializeField] public int scoreValue { get; private set; } = 10;
    [field: SerializeField] public int startingHealth { get; private set; } = 100;

    public AudioClip deathClip;
    public AudioClip hurtClip;

    public readonly int id_playerDead = Animator.StringToHash("PlayerDead");
    public readonly int id_dead = Animator.StringToHash("Dead");
}
