using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    Animator ani;

    public GameObject[] bulletArr;
    public GameObject laser;
    public float laserValue;
    public Transform pos = null;

    public int power;
    [SerializeField]
    private GameObject powerup;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    public Image gauge;

    void Start()
    {
        // ȭ���� ��踦 ����
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);

        ani = GetComponent<Animator>();
    }

    void Update()
    {
        // �÷��̾� �̵�
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") <= -0.5f)//��������
            ani.SetBool("left",true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.5f)//������
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.2f)//��
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        //�����̽��� ������ �Ѿ� �߻�
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(bulletArr[power], pos.position, Quaternion.identity);        
        }
        else if (Input.GetKey(KeyCode.Space))//������
        {
            laserValue += Time.deltaTime;
            gauge.fillAmount = laserValue;

            if (laserValue >= 1)
            {
                GameObject go = Instantiate(laser, pos.position, Quaternion.identity);
                Destroy(go, 3);
                laserValue = 0;
            }
        }
        else
        {
            laserValue -= Time.deltaTime;
            if(laserValue <= 0)
            {
                laserValue = 0;
            }
            gauge.fillAmount = laserValue;
        }


            Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // ��踦 ����� �ʵ��� ��ġ ����
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;

        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            //������ �����
            Destroy(collision.gameObject);
            //�Ѿ� ���׷��̵�
            if (power + 1 < bulletArr.Length)
            {
                power++;
                GameObject instance = Instantiate(powerup,new Vector2(0,0), Quaternion.identity);
                Destroy(instance, 1);
            }
        }
    }

}
