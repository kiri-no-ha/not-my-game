using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class FullMob : MonoBehaviour
{
    public float damage;
    private GameObject mob;
    public float timeRNDtr = 0;

    [Header("Кадры анимации")]
    public List<Sprite> frames = new List<Sprite>();

    [Header("Настройки")]
    // Изначально анимация не воспроизводится, она запускается после входа в триггер
    public float framesPerSecond = 10f;
    public bool isPlaying = false;

    [Header("Связь с движением")]
    public float speedMultiplier = 1f;

    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private int currentFrame = 0;
    private Rigidbody2D rb;

    // Флаг завершения анимации (останавливаемся на последнем кадре)
    private bool animationCompleted = false;

    [Header("Параметры фиксации игрока")]
    public GameObject player; // Назначьте игрока в инспекторе
    private bool isPlayerFrozen = false;
    private Vector3 playerFixedPos;
    public int requiredSpacePresses = 10; // Число нажатий пробела для освобождения
    private int currentSpacePressCount = 0;

    // Флаг, активирующий логику, когда объект входит в триггер
    private bool activated = false;

    void Awake()
    {
        mob = this.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        isPlaying = false; // Начинаем только после срабатывания триггера
    }

    void FixedUpdate()
    {
        // Если объект не активирован триггером, ничего не делаем
        if (!activated) return;

        if (frames == null || frames.Count == 0) return;

        // Если анимация остановлена, отображаем первый кадр
        if (!isPlaying)
        {
            spriteRenderer.sprite = frames[0];
            return;
        }

        // Если анимация уже завершена, дальнейшее обновление не требуется
        if (animationCompleted) return;

        float speedFactor = rb ? rb.velocity.magnitude * speedMultiplier : 1f;
        float interval = 1f / Mathf.Max(framesPerSecond * speedFactor, 0.01f);

        timer += Time.fixedDeltaTime;
        if (timer >= interval)
        {
            timer -= interval;

            if (currentFrame < frames.Count - 1)
            {
                currentFrame++;
                spriteRenderer.sprite = frames[currentFrame];
            }
            else
            {
                // Достигли последнего кадра: останавливаем анимацию и запускаем фиксацию игрока
                currentFrame = frames.Count - 1;
                spriteRenderer.sprite = frames[currentFrame];
                animationCompleted = true;
                FreezePlayer();
            }
        }
    }

    /// <summary>
    /// Метод срабатывает, когда другой Collider2D (с опцией Is Trigger) соприкасается с этим объектом.
    /// Если это игрок, начинается выполнение логики.
    /// </summary>
    /// <param name="collision">Collider2D столкнувшегося объекта</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, что это игрок по тегу; при необходимости можно сравнить по ссылке
        if (!activated && collision.gameObject.CompareTag("Player"))
        {
            activated = true;
            // Сбросим текущую анимацию (если требуется), запускаем проигрывание
            isPlaying = true;
            animationCompleted = false;
            currentFrame = 0;
            timer = 0;
            Debug.Log("Триггер сработал. Запуск анимации.");
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("ColiderEnter");
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    /// <summary>
    /// Останавливает анимацию и сбрасывает её на первый кадр.
    /// </summary>
    public void Stop()
    {
        isPlaying = false;
        currentFrame = 0;
        spriteRenderer.sprite = frames[0];
    }

    /// <summary>
    /// Запускает анимацию с текущего кадра.
    /// </summary>
    public void Play()
    {
        isPlaying = true;
    }

    /// <summary>
    /// Устанавливает кадр анимации по заданному индексу.
    /// </summary>
    public void SetFrame(int index)
    {
        if (index >= 0 && index < frames.Count)
        {
            currentFrame = index;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }

    /// <summary>
    /// Фиксирует позицию игрока, наносит урон и активирует QTE.
    /// </summary>
    private void FreezePlayer()
    {
        if (player != null)
        {
            // Сохраняем текущую позицию игрока
            playerFixedPos = player.transform.position;
            isPlayerFrozen = true;
            // Наносим урон игроку — реализуйте свою логику внутри метода
            DealDamageToPlayer();
            Debug.Log("Игрок зафиксирован и нанесен урон.");
        }
    }

    /// <summary>
    /// Освобождает игрока после выполнения QTE.
    /// </summary>
    private void ReleasePlayer()
    {
        isPlayerFrozen = false;
        currentSpacePressCount = 0;
        Debug.Log("Игрок освобожден!");
    }

    /// <summary>
    /// Реализуйте здесь вашу логику нанесения урона игроку.
    /// </summary>
    private void DealDamageToPlayer()
    {
        // Здесь разместите свою логику урона
        Debug.Log("Урон нанесен игроку!");
    }

    /// <summary>
    /// Реализуйте необходимый эффект тряски камеры.
    /// </summary>
    private void CameraShake()
    {
        // Можно использовать Cinemachine или DOTween для реалистичной тряски камеры
        Debug.Log("Камера трясется!");
    }

    void Update()
    {
        // Если игрок зафиксирован, принудительно удерживаем его позицию и обрабатываем нажатия пробела
        if (isPlayerFrozen)
        {
            if (player != null)
            {
                player.transform.position = playerFixedPos;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentSpacePressCount++;
                CameraShake();

                if (currentSpacePressCount >= requiredSpacePresses)
                {
                    ReleasePlayer();
                }
            }
        }
    }
}
