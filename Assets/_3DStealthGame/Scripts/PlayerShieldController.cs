using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
    public bool hasShield = false;
    public GameObject shieldBubble; // assign the child bubble object in inspector

    public int shieldUses = 1;

    void Update()
    {
        // If shield is active, make sure the bubble follows the player (optional if child)
        if (hasShield && shieldBubble != null)
        {
            // If it's a child object, this may be optional
            shieldBubble.transform.position = transform.position + Vector3.up * 0.5f;
        }
    }

    public void PickupShield()
    {
        hasShield = true;
        shieldUses = 1; // reset uses
        if (shieldBubble != null)
            shieldBubble.SetActive(true); // show bubble
    }

    public void UseShield()
    {
        shieldUses--;

        if (shieldUses <= 0)
        {
            hasShield = false;
            if (shieldBubble != null)
                shieldBubble.SetActive(false); // hide bubble
        }
    }
}
