using UnityEngine;

public class RunKynau : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // �������� ������
    [SerializeField] public bool moveRight ; // ����������� ��������
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("� ������");
        // ������ ��������� �������� � ����������� �� �����������
        float direction = moveRight ? 1f : -1f;
        rb.velocity = new Vector2(direction * speed, 0f);

        // ������������ ������ � ����������� ��������
        if (!moveRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    public void Update()
    {
        rb.velocity = new Vector2 (rb.velocity.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������� ����� ��� ������������ � ����� ��������
        
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // ���������� �����
            Destroy(gameObject);

        }
        if (collision.gameObject.tag!="Player" )
        {
            Destroy(gameObject);
        }
        
        // ����� �������� �������������� ������� ��� ������������
        // ��������, ������������� ���� ��� ������� ������ ������
    }

    
}