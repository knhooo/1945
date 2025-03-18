using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;
    public int attack = 10;
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

            //PoolManager.Instance.Return(collision.gameObject);
            //����
            collision.gameObject.GetComponent<Monster>().Damage(attack);  
            //�̻��� ����
            Destroy(gameObject);

        }
        if (collision.CompareTag("Boss"))
        {
            //����Ʈ
            GameObject instanceEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1�� �ڿ� �����
            Destroy(instanceEffect, 1);
            //�̻��� ����

        }
    }
}