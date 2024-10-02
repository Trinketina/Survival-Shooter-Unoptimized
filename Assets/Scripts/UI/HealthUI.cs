using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] PlayerHealth player;

    public Slider healthSlider;
    public Image damageImage;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float flashSpeed = 5f;


    // Start is called before the first frame update
    void OnEnable()
    {
        player.OnTakeDamage += TakeDamage;
    }

    void TakeDamage(int startingHealth, int currentHealth)
    {
        StartCoroutine(RedFlash());

        healthSlider.value = currentHealth;
    }

    IEnumerator RedFlash()
    {
        float time = 0;

        damageImage.color = flashColour;


        while (time < flashSpeed)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }

    void OnDisable()
    {
        player.OnTakeDamage += TakeDamage;
    }

}
