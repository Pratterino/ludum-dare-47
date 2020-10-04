using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerWall : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        rb.gravityScale = rb.gravityScale * -1;
    }
}
