using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private AudioLogic audioLogic;

    private void Start()
    {
        audioLogic = FindObjectOfType<AudioLogic>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // TODO: Wait until respawn?
            collision.transform.parent.position = new Vector2(collision.transform.parent.position.x - 5, collision.transform.parent.position.y + (2 * collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale));
            audioLogic.PlayDeadSound();
            print("DEAD");
        }
    }
}
