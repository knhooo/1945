using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;



    void Update()
    {
        //Y�� �̵�
        transform.Translate(Vector2.up* Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    //2D�浹 Ʈ�����̺�Ʈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�̻��ϰ� ���� �΋H����
        //if(collision.gameObject.tag == "Enemy")
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    //���� ����Ʈ ����
        //    //Instantiate(exposion, transform.position, Quaternion.identity);
        //    //��������
        //    //SoundManager.instance.SoundDie(); //�� ���� ����
        //    //�����÷��ֱ�
        //    //GameManager.intance.AddScore(10);
        //    //�������
        //    Destroy(collision.gameObject);
        //    //�Ѿ� ����� �ڱ��ڽ�
        //    Destroy(gameObject);
        //}
    }








}