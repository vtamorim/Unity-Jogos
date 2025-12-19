using UnityEngine;

public class FallingPlataform : MonoBehaviour
{


    public float fallingtime;
    private BoxCollider2D boxCollider;
    private TargetJoint2D target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Invoke("Fallng", fallingtime);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {

            Destroy(gameObject);

        }
    }

    void Fallng()
    {
        target.enabled = false;
        boxCollider.isTrigger = true;
    }
}
                        