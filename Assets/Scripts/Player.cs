using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    Animator ani;

    public GameObject[] bulletArr;
    public Transform pos = null;

    public int power;
    [SerializeField]
    private GameObject powerup;

    private Vector2 minBounds;
    private Vector2 maxBounds;
    void Start()
    {
        // 화면의 경계를 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);

        ani = GetComponent<Animator>();
    }

    void Update()
    {
        // 플레이어 이동
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetAxis("Horizontal") <= -0.5f)//왼쪽으로
            ani.SetBool("left",true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.5f)//오른쪽
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.5f)//위
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        //스페이스바 누르면 총알 발사
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(bulletArr[power], pos.position, Quaternion.identity);        
        }

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // 경계를 벗어나지 않도록 위치 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            //아이템 지우기
            Destroy(collision.gameObject);
            //총알 업그레이드
            if (power + 1 < bulletArr.Length)
            {
                power++;
                GameObject instance = Instantiate(powerup,new Vector2(0,0), Quaternion.identity);
                Destroy(instance, 1);
            }
        }
    }
}
