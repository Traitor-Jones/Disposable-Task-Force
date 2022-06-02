using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startHealth;
    public float currHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numFlashes;
    private SpriteRenderer spriteRend;

    [Header("GUI")]
    [SerializeField] private GameObject exitGUI;

    private void Awake()
    {
        currHealth = startHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currHealth = Mathf.Clamp(currHealth - damage, 0, startHealth);

        // Health Check
        if(currHealth > 0)
        {
            // Check if Player is still alive/hurt
            anim.SetTrigger("hurt");

            // iframes
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                // Player is dead
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;

                exitGUI.SetActive(true);
            }
        }
    }

    public void AddHealth(float value)
    {
        currHealth = Mathf.Clamp(currHealth + value, 0, startHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numFlashes * 2));
        }
        // Invulnerabilty Duration
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
