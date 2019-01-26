using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : MonoBehaviour
{

    public float damageOnHit;

    private Player player;

    void Start()
    {
        player = Player.instance;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collison");
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponentInParent<Player>();

            if (player != null)
            {
                player.ApplyDamage(damageOnHit);
            }
        }
    }
}
