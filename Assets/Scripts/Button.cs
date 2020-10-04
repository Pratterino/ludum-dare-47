using UnityEngine;

public class Button : MonoBehaviour
{
    public BlockerWall blockerWall;

    private bool activated = false;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        blockerWall = gameObject.GetComponentInParent<BlockerWall>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.CompareTag("Player") && !activated)
        {
            activated = true;
            sprite.color = Color.green;
            // activate connected thing.
            blockerWall.Toggle();
            print("ACTIVATED! -- " + activated);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // activated = false;
            // blockerWall.Toggle();
            // sprite.color = Color.yellow;
        }
    }
}
