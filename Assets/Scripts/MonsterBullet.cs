using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //미사일 지우기
            Destroy(gameObject);
        }
    }
}
