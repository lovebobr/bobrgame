using UnityEngine;
using UnityEngine.SceneManagement;

public class ememy : MonoBehaviour
{
    [SerializeField] private float damage;
    public float speed;
    public Vector3[] positions;

    private int currentTarget;
    
    public void FixedUpdate()
    {
        transform.position=Vector3.MoveTowards(transform.position, positions[currentTarget],speed*0.1f);
        if (transform.position == positions[currentTarget])
            {
                if (currentTarget< positions.Length-1)
                {
                    currentTarget++;
                }else
                {
                    currentTarget=0;
                }
            }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.y < transform.position.y)
            {
                
               Destroy(gameObject);
            }
            else
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}