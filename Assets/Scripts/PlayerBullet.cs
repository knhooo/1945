using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;
    public int attack = 10;
    public GameObject effect;
    public GameObject item;

    void Update()
    {
        //Y축 이동
        transform.Translate(Vector2.up* Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //이펙트
            GameObject instanceEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1초 뒤에 지우기
            Destroy(instanceEffect,1);

            //PoolManager.Instance.Return(collision.gameObject);
            //몬스터
            collision.gameObject.GetComponent<Monster>().Damage(attack);  
            //미사일 삭제
            Destroy(gameObject);

        }
        if (collision.CompareTag("Boss"))
        {
            //이펙트
            GameObject instanceEffect = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //1초 뒤에 지우기
            Destroy(instanceEffect, 1);
            //미사일 삭제

        }
    }
}