using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class FullMob : MonoBehaviour
{
    public float damage;
    private GameObject mob;
    public float timeRNDtr = 0;

    [Header("����� ��������")]
    public List<Sprite> frames = new List<Sprite>();

    [Header("���������")]
    // ���������� �������� �� ���������������, ��� ����������� ����� ����� � �������
    public float framesPerSecond = 10f;
    public bool isPlaying = false;

    [Header("����� � ���������")]
    public float speedMultiplier = 1f;

    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private int currentFrame = 0;
    private Rigidbody2D rb;

    // ���� ���������� �������� (��������������� �� ��������� �����)
    private bool animationCompleted = false;

    [Header("��������� �������� ������")]
    public GameObject player; // ��������� ������ � ����������
    private bool isPlayerFrozen = false;
    private Vector3 playerFixedPos;
    public int requiredSpacePresses = 10; // ����� ������� ������� ��� ������������
    private int currentSpacePressCount = 0;

    // ����, ������������ ������, ����� ������ ������ � �������
    private bool activated = false;

    void Awake()
    {
        mob = this.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        isPlaying = false; // �������� ������ ����� ������������ ��������
    }

    void FixedUpdate()
    {
        // ���� ������ �� ����������� ���������, ������ �� ������
        if (!activated) return;

        if (frames == null || frames.Count == 0) return;

        // ���� �������� �����������, ���������� ������ ����
        if (!isPlaying)
        {
            spriteRenderer.sprite = frames[0];
            return;
        }

        // ���� �������� ��� ���������, ���������� ���������� �� ���������
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
                // �������� ���������� �����: ������������� �������� � ��������� �������� ������
                currentFrame = frames.Count - 1;
                spriteRenderer.sprite = frames[currentFrame];
                animationCompleted = true;
                FreezePlayer();
            }
        }
    }

    /// <summary>
    /// ����� �����������, ����� ������ Collider2D (� ������ Is Trigger) ������������� � ���� ��������.
    /// ���� ��� �����, ���������� ���������� ������.
    /// </summary>
    /// <param name="collision">Collider2D �������������� �������</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ��� ��� ����� �� ����; ��� ������������� ����� �������� �� ������
        if (!activated && collision.gameObject.CompareTag("Player"))
        {
            activated = true;
            // ������� ������� �������� (���� ���������), ��������� ������������
            isPlaying = true;
            animationCompleted = false;
            currentFrame = 0;
            timer = 0;
            Debug.Log("������� ��������. ������ ��������.");
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("ColiderEnter");
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    /// <summary>
    /// ������������� �������� � ���������� � �� ������ ����.
    /// </summary>
    public void Stop()
    {
        isPlaying = false;
        currentFrame = 0;
        spriteRenderer.sprite = frames[0];
    }

    /// <summary>
    /// ��������� �������� � �������� �����.
    /// </summary>
    public void Play()
    {
        isPlaying = true;
    }

    /// <summary>
    /// ������������� ���� �������� �� ��������� �������.
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
    /// ��������� ������� ������, ������� ���� � ���������� QTE.
    /// </summary>
    private void FreezePlayer()
    {
        if (player != null)
        {
            // ��������� ������� ������� ������
            playerFixedPos = player.transform.position;
            isPlayerFrozen = true;
            // ������� ���� ������ � ���������� ���� ������ ������ ������
            DealDamageToPlayer();
            Debug.Log("����� ������������ � ������� ����.");
        }
    }

    /// <summary>
    /// ����������� ������ ����� ���������� QTE.
    /// </summary>
    private void ReleasePlayer()
    {
        isPlayerFrozen = false;
        currentSpacePressCount = 0;
        Debug.Log("����� ����������!");
    }

    /// <summary>
    /// ���������� ����� ���� ������ ��������� ����� ������.
    /// </summary>
    private void DealDamageToPlayer()
    {
        // ����� ���������� ���� ������ �����
        Debug.Log("���� ������� ������!");
    }

    /// <summary>
    /// ���������� ����������� ������ ������ ������.
    /// </summary>
    private void CameraShake()
    {
        // ����� ������������ Cinemachine ��� DOTween ��� ������������ ������ ������
        Debug.Log("������ ��������!");
    }

    void Update()
    {
        // ���� ����� ������������, ������������� ���������� ��� ������� � ������������ ������� �������
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
