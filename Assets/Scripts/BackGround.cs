using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scollSpeed = 0.01f;
    Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float newOffsetY = material.mainTextureOffset.y + scollSpeed * Time.deltaTime;

        Vector2 newOffset = new Vector2(0, newOffsetY);

        material.mainTextureOffset = newOffset;
    }
}
