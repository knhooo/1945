using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float leftX = -2;
    public float rightX = 2;
    public float StartTime = 1;
    public float SpawnStop = 10;//스폰 끝나는 시간
    public GameObject[] monsters;

    bool swi = true;
    int num = 0;

    void Start()
    {
        StartCoroutine("RandomSpawn");
        num = 1;
        Invoke("Stop", SpawnStop);
    }

    void Update()
    {

    }

    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime);

            float x = Random.Range(leftX, rightX);

            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(monsters[0], pos, Quaternion.identity);
        }
    }
    IEnumerator RandomSpawn2()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime+2);

            float x = Random.Range(leftX, rightX);

            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(monsters[1], pos, Quaternion.identity);
        }
    }

    void Stop()
    {
        //swi = false;
        //두번째 몬스터 코루틴
        StopCoroutine("RandomSpawn");
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", SpawnStop + 20);
    }

    void Stop2()
    {
        //swi2 = false;
        //두번째 몬스터 코루틴
        StopCoroutine("RandomSpawn2");
        //StartCoroutine("RandomSpawn2");
    }

}