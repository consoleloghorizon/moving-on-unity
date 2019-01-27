using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : MonoBehaviour
{

    public float damageOnHit;
    public static bool isDefeated = false;

    private Player player;

    void Start()
    {
        Debug.Log(isDefeated);
        player = Player.instance;
        this.gameObject.SetActive(!isDefeated);
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
                this.gameObject.SetActive(isDefeated);
            }
            if (player != null)
            {
                player.ApplyDamage(damageOnHit);
            }
        }
    }
}
