using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;

    public GameObject effect;
    public GameObject item;

    void Update()
    {
        //Y�� �̵�
        transform.Translate(Vector2.up* Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    //�浹ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //����Ʈ
            GameObject instanceEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1�� �ڿ� �����
            Destroy(instanceEffect,1);
            //����
            collision.gameObject.GetComponent<Monster>().Damage(1);

            
            
            //�̻��� ����
            Destroy(gameObject);

        }
    }
}