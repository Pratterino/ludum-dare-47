using UnityEngine;

public class Coin : MonoBehaviour
{
    private const float floatSpeed = 4.5f;
    private const float floatHeight = 0.08f;
    private Vector3 startPos;
    private GameLogic gameLogic;
    private AudioLogic audioLogic;

    void Start()
    {
        //gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        startPos = transform.position;
        gameLogic = FindObjectOfType<GameLogic>();
        audioLogic = FindObjectOfType<AudioLogic>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameObject.GetComponentInChildren<ParticleSystem>().Play();
            gameLogic.UpdateText();
            audioLogic.PlayCoinSound();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight + startPos.y;
        float newRot = Mathf.Sin(Time.time * floatSpeed) * floatHeight + startPos.y;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(0, 5 * newY, 0), newRot);
    }
}
