using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : MonoBehaviour
{

    public int damageOnHit;

    private Player player;

    void Start()
    {
        player = Player.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject objectCollided = col.gameObject;

        if (objectCollided.CompareTag("Player"))
        {
            player = objectCollided.GetComponentInParent<Player>();

            if (player != null)
            {
                player.ApplyDamage(damageOnHit);
            }
        }
    }
}
