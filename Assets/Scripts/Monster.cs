using UnityEngine;

public class Monster : MonoBehaviour
{

    public float speed = 3;
    public float delay = 1f;

    public Transform ms1;
    public Transform ms2;
    public GameObject Bullet;
    public GameObject item = null;


    void Start()
    {
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(Bullet, ms1.position, Quaternion.identity);
        Instantiate(Bullet, ms2.position, Quaternion.identity);

        //재귀호출
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

    public void Damage(int attack)
    {
        ItemDrop();
        Destroy(gameObject);
    }

    public void ItemDrop()
    {
        int per = Random.Range(0, 100);
        //아이템 생성
        if (per > 50)
        {
            //아이템 생성
            Instantiate(item, transform.position, Quaternion.identity);
        }
        
    }
}
