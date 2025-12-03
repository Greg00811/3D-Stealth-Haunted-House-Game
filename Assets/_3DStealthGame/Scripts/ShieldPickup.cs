using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerShieldController shield = other.GetComponent<PlayerShieldController>();
        if (shield != null && !shield.hasShield)
        {
            shield.PickupShield();
            Destroy(gameObject); // remove the pickup from the level
        }
    }
}
