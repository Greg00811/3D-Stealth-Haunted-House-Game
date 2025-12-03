using UnityEngine;

public class EnemyShieldHandler : MonoBehaviour
{
    Observer observer;

    void Start()
    {
        observer = GetComponent<Observer>();
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerShieldController shield = other.GetComponent<PlayerShieldController>();

        if (shield != null && shield.hasShield)
        {
            // Disable this enemy
            if (observer != null)
                observer.DisableEnemy();

            // Consume shield
            shield.UseShield();
        }
    }
}
