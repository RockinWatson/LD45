using UnityEngine;

namespace Assets.Scripts
{
    public class Bully : MonoBehaviour
    {
        public float speed;

        public Transform target;

        private void Start()
        {
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, target.position) < 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
