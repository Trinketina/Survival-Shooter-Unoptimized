using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    public AudioClip hurtClip;


    Animator anim;
    int id_dead = Animator.StringToHash("Dead");

    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    ObjectPool<EnemyHealth> pool;


    void Awake()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        //currentHealth = startingHealth;
    }
    private void OnEnable()
    {
        currentHealth = startingHealth;
        isDead = false;
        isSinking = false;
        capsuleCollider.isTrigger = false;

        enemyAudio.clip = hurtClip;
    }

    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (id_dead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        //Destroy (gameObject, 2f);

        StartCoroutine(ReleaseEnemy());
    }

    IEnumerator ReleaseEnemy()
    {
        yield return new WaitForSeconds(2);

        pool.Release(this);
    }

    public void SetPool(ObjectPool<EnemyHealth> _pool)
    {
        pool = _pool;
    }
}
