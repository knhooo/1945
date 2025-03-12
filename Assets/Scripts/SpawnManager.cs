using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //���Ͱ�������� 
    public GameObject enemy;

    //���� �����ϴ� �Լ�
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); //���� ��Ÿ�� x��ǥ�� �������� �����ϱ�

        //���� �����Ѵ�. randomX������ x��
        Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);



    }

    void Start()
    {
        //SpawnEnemy  1  0.5f 
        InvokeRepeating("SpawnEnemy", 1, 2f);
    }


    void Update()
    {

    }
}