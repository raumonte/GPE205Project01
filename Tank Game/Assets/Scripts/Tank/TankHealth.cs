using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float health = 100f;
    public Slider slider;
    public Image fillableImage;
    public Color fullHealth = Color.green;
    public Color lowHealth = Color.red;
    public GameObject explosionPrefab;

    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;
    public float currentHealth;
    private bool isPlayerDead;

    private void Awake()
    {
     //  explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
     //  explosionAudio = explosionParticles.GetComponent<AudioSource>();

     //  explosionParticles.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        //sets the current health as the starting amount of health
        currentHealth = health;

        //Sets boolean as false
        isPlayerDead = false;

        //Sets the health UI
        SetHealthUI();
    }
    public void DamageAmount(float amount)
    {
        //TODO: Set the amount of damage from the bullet script.
        currentHealth -= amount;
        Debug.Log(amount);
        
        //Once the player(s) take damage it will call this function to update the UI
        SetHealthUI();

        //Once the player(s) reach less than 0 it will activate the death function.
        if (currentHealth <= 0f && !isPlayerDead)
        {
            OnDeath();
        }
    }

    //This function updates the slider each time the player(s) takes damage.
    private void SetHealthUI()
    {
        //Sets the value of the slider to the amount of health set to a player.
        slider.value = currentHealth;
    
        //Sets the color of the image background depending on the amount of health left.
        fillableImage.color = Color.Lerp(lowHealth, fullHealth, currentHealth / health);
    
    }
    
    //This function tells what to do once the player(s) die
    private void OnDeath()
    {
        //Sets Bool to true
        isPlayerDead = true;
        
        //Instantiates particles that would occur once the tank is dead.
        explosionParticles.transform.position = transform.position;
        
        //Sets the particle active
        explosionParticles.gameObject.SetActive(true);
        
        //Begins to play the particle
        explosionParticles.Play();
        
        //Plays the audio attached when the player dies
        explosionAudio.Play();
        
        //Sets the player as dead
        gameObject.SetActive(false);
    
    }
}
