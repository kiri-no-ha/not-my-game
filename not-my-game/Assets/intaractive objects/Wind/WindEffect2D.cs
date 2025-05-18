using UnityEngine;
namespace Wind{
    public class WindEffect2D : MonoBehaviour
    {
        public enum WindType { None, Horizontal, Updraft, Downdraft }
        public enum WindDirection { None, Left, Right }

        public WindType windEffect = WindType.None;
        public WindDirection windDirection = WindDirection.None;

        [Range(0f, 30f)]
        public float windStrength = 5f;

        [Range(0f,30f)]
        public float liftStrength = 8f;

        [Range(1f, 5f)]
        public float gravityMultiplier = 2f;

        [Range(0.1f, 1f)]
        public float reducedMass = 0.2f;

        public bool enableUpdraft = true;
        public bool enablePushing = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile") || other.CompareTag("Player"))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    if (!rb.gameObject.TryGetComponent(out ObjectData objectData))
                    {
                        objectData = rb.gameObject.AddComponent<ObjectData>();
                    }

                    if (windEffect == WindType.Updraft)
                    {
                        objectData.originalMass = rb.mass; // ��������� ����������� �����
                        rb.mass *= reducedMass;
                    }

                    if (windEffect == WindType.Downdraft)
                    {
                        objectData.originalGravity = rb.gravityScale; // ��������� ����������� ����������
                        rb.gravityScale *= gravityMultiplier;
                    }

                    ApplyWindEffect(rb);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Projectile") || other.CompareTag("Player"))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null && rb.gameObject.TryGetComponent(out ObjectData objectData))
                {
                    if (windEffect == WindType.Updraft)
                        rb.mass = objectData.originalMass; // ��������������� �����

                    if (windEffect == WindType.Downdraft)
                        rb.gravityScale = objectData.originalGravity; // ��������������� ����������
                }
            }
        }

        private void ApplyWindEffect(Rigidbody2D rb)
        {
            Vector2 windForce = Vector2.zero;

            if (windEffect == WindType.Horizontal)
            {
                switch (windDirection)
                {
                    case WindDirection.Left:
                        rb.velocity = new Vector2(-windStrength, rb.velocity.y);
                        break;
                    case WindDirection.Right:
                        rb.velocity = new Vector2(windStrength, rb.velocity.y);
                        break;
                }
            }
            else if (windEffect == WindType.Updraft)
            {
                windForce += Vector2.up * liftStrength;
            }
            else if (windEffect == WindType.Downdraft)
            {
                windForce += Vector2.down * liftStrength;
            }

            rb.AddForce(windForce, ForceMode2D.Force);
        }
    }
}
