using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.0f;



    void Update()
    {
        //Y축 이동
        transform.Translate(Vector2.up* Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    //2D충돌 트리거이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //미사일과 적이 부딫혔다
        //if(collision.gameObject.tag == "Enemy")
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    //폭발 이펙트 생성
        //    //Instantiate(exposion, transform.position, Quaternion.identity);
        //    //죽음사운드
        //    //SoundManager.instance.SoundDie(); //적 죽음 사운드
        //    //점수올려주기
        //    //GameManager.intance.AddScore(10);
        //    //적지우기
        //    Destroy(collision.gameObject);
        //    //총알 지우기 자기자신
        //    Destroy(gameObject);
        //}
    }








}