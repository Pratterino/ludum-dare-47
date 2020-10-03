using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLogic : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collision)
   {
        collision.attachedRigidbody.gravityScale = -3;
   }
   
   void OnTriggerExit2D(Collider2D collision)
   {
        collision.attachedRigidbody.gravityScale = 3;
   }
}
