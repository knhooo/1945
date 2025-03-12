using UnityEngine;

public class Item : MonoBehaviour
{
    public float itemVelocity = 100f;
    Rigidbody2D rd = null;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.AddForce(new Vector3(itemVelocity, itemVelocity, 0f));
    }

    void Update()
    {
        
    }
}
