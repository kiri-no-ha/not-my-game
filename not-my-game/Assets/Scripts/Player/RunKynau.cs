using UnityEngine;

public class RunKynau : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Скорость полета
    [SerializeField] public bool moveRight ; // Направление движения
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Я рожден");
        // Задаем начальную скорость в зависимости от направления
        float direction = moveRight ? 1f : -1f;
        rb.velocity = new Vector2(direction * speed, 0f);

        // Поворачиваем спрайт в направлении движения
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
        // Уничтожаем кунай при столкновении с любым объектом
        
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Уничтожаем врага
            Destroy(gameObject);

        }
        if (collision.gameObject.tag!="Player" )
        {
            Destroy(gameObject);
        }
        
        // Можно добавить дополнительные эффекты при столкновении
        // Например, воспроизвести звук или создать эффект взрыва
    }

    
}