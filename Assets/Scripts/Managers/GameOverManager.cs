using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;


    Animator anim;
    int id_gameover = Animator.StringToHash("GameOver");
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger(id_gameover);

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
        }
    }
}
