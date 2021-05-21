using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject fish;
    public GameObject pufferFish;
    public GameObject bubble;
    public GameObject coin;
    float maxHorizontalSeaBorder = 40f, maxVerticalSeaBorder = 40f;
    private GameObject[] fishes = new GameObject[30];
    GameObject cloneFishes, clonePufferFishes, cloneBubbles, cloneCoins;
    float buoyancyOfWater = -0.5f;
    float normaGravity = 1f;
    void Start()
    {

        for (int i = 0; i < 30; i++)
        {
            Vector3 vec1 = new Vector3(Random.Range(-maxHorizontalSeaBorder, maxHorizontalSeaBorder), Random.Range(-maxVerticalSeaBorder, maxVerticalSeaBorder), 0);
            Vector3 vec2 = new Vector3(Random.Range(-maxHorizontalSeaBorder, maxHorizontalSeaBorder), Random.Range(-maxVerticalSeaBorder, maxVerticalSeaBorder), 0);
            Vector3 vec3 = new Vector3(Random.Range(-maxHorizontalSeaBorder, maxHorizontalSeaBorder), Random.Range(-maxVerticalSeaBorder, maxVerticalSeaBorder), 0);
            Vector3 vec4 = new Vector3(Random.Range(-maxHorizontalSeaBorder, maxHorizontalSeaBorder), Random.Range(-maxVerticalSeaBorder, maxVerticalSeaBorder), 0);
            cloneFishes = Instantiate(fish, vec1, Quaternion.identity);
            clonePufferFishes = Instantiate(pufferFish, vec2, Quaternion.identity);
            cloneBubbles = Instantiate(bubble, vec3, Quaternion.identity);
            cloneCoins = Instantiate(coin, vec4, Quaternion.identity);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = buoyancyOfWater;
        collision.GetComponent<Rigidbody2D>().drag = 1;
        collision.GetComponent<Rigidbody2D>().angularDrag = 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 1f;
        collision.GetComponent<Rigidbody2D>().drag = 0.5f;
        collision.GetComponent<Rigidbody2D>().angularDrag = 0.5f;
    }
}
