using UnityEngine;
using UnityEngine.Events;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.IsDead())
        {
            // hilangnya Time.deltaTime membuat gerak jadi makin cepet
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        
        if(bird)
        {
            Collider2D collider = GetComponent<Collider2D>();

            if(collider)
            {
                collider.enabled = false;
            }

            bird.Dead();
        }
    }
}
