using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(0.6f);
        }
    }
}