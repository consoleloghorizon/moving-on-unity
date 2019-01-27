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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponentInParent<Player>();

            Vector3 dir = (col.gameObject.transform.position - gameObject.transform.position).normalized;

            Debug.Log(dir.y);
            // hit top
            if (dir.y > 0)
            {
                this.gameObject.SetActive(false);
            }
            if (player != null)
            {
                player.ApplyDamage(damageOnHit);
            }
        }
    }
}
