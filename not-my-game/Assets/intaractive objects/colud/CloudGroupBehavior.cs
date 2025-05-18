using UnityEngine;
using System.Collections;

public class Cloud2DBehavior : MonoBehaviour
{
    [Header("Настройки масштабирования")]
    public float scaleMultiplier = 2.5f;
    public float expandDuration = 0.2f;
    public float returnDelay = 0.5f;
    public float scaleReturnDuration = 0.2f;

    [Header("Настройки сжатия")]
    public float shrinkMultiplier = 0.8f;
    public float shrinkDuration = 0.1f;

    [Header("Настройки отталкивания")]
    public float pushForce = 10f;
    public float pushRadiusMultiplier = 1.5f;
    public float pushOffsetDistance = 0.5f; // Новое: смещение центра толчка вперёд по направлению облака

    private Vector3 originalScale;
    private CircleCollider2D circleCollider;
    private float originalColliderRadius;
    private bool isScaling = false;

    private void Start()
    {
        originalScale = transform.localScale;
        circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider != null)
            originalColliderRadius = circleCollider.radius;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isScaling)
            StartCoroutine(ScaleAndPush(collision));
    }

    private IEnumerator ScaleAndPush(Collision2D collision)
    {
        isScaling = true;

        Vector3 shrinkedScale = originalScale * shrinkMultiplier;
        float t = 0f;

        // Этап 1: Сжатие
        while (t < 1f)
        {
            t += Time.deltaTime / shrinkDuration;
            transform.localScale = Vector3.Lerp(originalScale, shrinkedScale, t);
            UpdateColliders();
            yield return null;
        }

        transform.localScale = shrinkedScale;
        UpdateColliders();

        // Этап 2: Расширение
        Vector3 targetScale = originalScale * scaleMultiplier;
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / expandDuration;
            transform.localScale = Vector3.Lerp(shrinkedScale, targetScale, t);
            UpdateColliders();
            yield return null;
        }

        transform.localScale = targetScale;
        UpdateColliders();

        // Этап 3: Отталкивание
        float pushRadius = Mathf.Max(transform.localScale.x, transform.localScale.y) * pushRadiusMultiplier;

        // Новое: центр отталкивания смещён по направлению "вперёд" (по rotation)
        Vector2 pushCenter = (Vector2)transform.position + (Vector2)(transform.up * pushOffsetDistance);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(pushCenter, pushRadius);
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject == gameObject)
                continue;

            Rigidbody2D rb = col.attachedRigidbody;
            if (rb != null)
            {
                Vector2 direction = ((Vector2)col.transform.position - pushCenter).normalized;
                rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
            }
        }

        yield return new WaitForSeconds(returnDelay);

        // Этап 4: Возврат масштаба
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / scaleReturnDuration;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            UpdateColliders();
            yield return null;
        }

        transform.localScale = originalScale;
        UpdateColliders();

        isScaling = false;
    }

    private void UpdateColliders()
    {
        if (circleCollider != null)
        {
            circleCollider.radius = originalColliderRadius * (transform.localScale.x / originalScale.x);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector2 forwardOffset = transform.up * pushOffsetDistance;
        float drawRadius = Mathf.Max(transform.localScale.x, transform.localScale.y) * pushRadiusMultiplier;
        Gizmos.DrawWireSphere(transform.position + (Vector3)forwardOffset, drawRadius);
    }
}
