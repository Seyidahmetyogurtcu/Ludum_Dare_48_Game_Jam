using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShooter : MonoBehaviour
{
    Transform shooterTransform;
    public Transform shootposition;
    public GameObject eggPrefab;
    [HideInInspector]public GameObject egg;
    Rigidbody2D rb_egg;
    float launceForce = 50f;
    private Vector2 shooterPos;
    private Vector2 mausePos;
    private Vector2 diretion;
    bool Shooted = false;
    public static PlayerShooter singleton;

    void Start()
    {
        if (singleton != null)
        {
            singleton = null;
        }
        else
        {
            singleton = this;
        }
        shooterTransform = GetComponent<Transform>();
    }


    void Update()
    {
        shooterPos = transform.position;
        mausePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diretion = mausePos - shooterPos;
        transform.right = diretion;

        if (Input.GetMouseButtonDown(0) && !Shooted)
        {
            Shoot();
        }
        if (rb_egg != null)
        {
            if (rb_egg.velocity.y <= 0.1)
            {
                StartCoroutine(FinishTheLevel());
            }
            Debug.Log(rb_egg.velocity.y);
        }

    }

    void Shoot()
    {
        egg = Instantiate(eggPrefab, shootposition.position, Quaternion.identity);
        rb_egg = egg.GetComponent<Rigidbody2D>();
        rb_egg.velocity = shooterTransform.right * launceForce;
        Shooted = true;
    }
    private IEnumerator FinishTheLevel()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
