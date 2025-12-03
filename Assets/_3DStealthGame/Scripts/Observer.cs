using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    PlayerShieldController shield;

    bool isDisabled = false;
    Renderer enemyRenderer;
    Color originalColor;


    bool m_IsPlayerInRange;

    Renderer[] renderers;

    void Start()
    {
        // Grab all Renderers in this enemy
        renderers = GetComponentsInChildren<Renderer>();
    }



    void OnTriggerEnter(Collider other)
    {
        PlayerShieldController shield = other.GetComponent<PlayerShieldController>();

        if (shield != null && shield.hasShield)
        {
            shield.UseShield();
            Destroy(gameObject);
            return;
        }

        // Original detection logic
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    public void DisableEnemy()
    {
        isDisabled = true;

        if (renderers != null)
        {
            foreach (Renderer rend in renderers)
            {
                // Make a copy of the material so we don’t affect shared materials
                Material mat = rend.material;
            
                // Multiply color by 0.4 to dim it
                Color c = mat.color;
                c *= 0.4f;
                mat.color = c;
            }
        }
    }


    
    void Update()
    {
        // Lazy assignment (only once)
        if (shield == null && player != null)
        {
            shield = player.GetComponent<PlayerShieldController>();
        }

        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    if (shield != null && shield.hasShield)
                    {
                        // Enemy dies, shield is consumed
                        shield.UseShield();
                        Destroy(gameObject); // This destroys the enemy
                    }
                    if (!isDisabled && raycastHit.collider.transform == player)
                    {
                        gameEnding.CaughtPlayer();
                    }

                }
            }
        }
    }
}