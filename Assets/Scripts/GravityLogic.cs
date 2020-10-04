using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLogic : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
   {
        collision.attachedRigidbody.gravityScale = -3;
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<SpriteRenderer>().flipX = true;
            collision.transform.parent.Rotate(0, 0, 180);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
   {
        collision.attachedRigidbody.gravityScale = 3;
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<SpriteRenderer>().flipX = false;
            collision.transform.parent.Rotate(0, 0, -180);
        }
    }
}
