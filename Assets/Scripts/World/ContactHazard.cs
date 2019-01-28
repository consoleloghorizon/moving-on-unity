using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactHazard : MonoBehaviour
{

    public float damageOnHit;

    private Player player;
    private DankBirdAI bird;

    void Start()
    {
        player = Player.instance;
        bird = DankBirdAI.instance;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.gameObject.GetComponentInParent<Player>();
            bird = col.gameObject.GetComponentInParent<DankBirdAI>();

            Debug.Log(bird);

            Vector3 dir = (col.gameObject.transform.position - gameObject.transform.position).normalized;

            Debug.Log(dir.y);
            // hit top
            if (dir.y > 0)
            {
                bird.KillBird();
            }
            if (player != null)
            {
                player.ApplyDamage(damageOnHit);
            }
        }
    }
}
