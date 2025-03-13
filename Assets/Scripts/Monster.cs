using UnityEngine;

public class Monster : MonoBehaviour
{

    public float speed = 3;
    public float delay = 1f;

    public Transform ms1;
    public Transform ms2;
    public GameObject Bullet;


    void Start()
    {
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(Bullet, ms1.position, Quaternion.identity);
        Instantiate(Bullet, ms2.position, Quaternion.identity);

        //¿Á±Õ»£√‚
        Invoke("CreateBullet", delay);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
