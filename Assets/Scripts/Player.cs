using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Text text;
    public static int  coinCounter;
    Rigidbody2D rb_;
    float moveSpeed = 50f;
    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector2 force = new Vector2(1 * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,0);
            rb_.AddForce(force);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter += 1;
            text.text = coinCounter.ToString();
        }
    }
}
