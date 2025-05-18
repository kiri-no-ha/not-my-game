using UnityEngine;

namespace rock
{
    public class rockTransleta : MonoBehaviour
    {
        public GameObject trnControl1;
        public GameObject trnControl2;
        public Vector3 poz1;
        public Vector3 poz2;

        void Start()
        {
            poz1 = trnControl1.transform.position;
            poz2 = trnControl2.transform.position;
        }

        public GameObject GetRandomControl()
        {
            return Random.Range(0, 2) == 0 ? trnControl1 : trnControl2;
        }
    }
}
