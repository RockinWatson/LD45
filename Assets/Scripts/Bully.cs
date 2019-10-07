using UnityEngine;

namespace Assets.Scripts
{
    public class Bully : MonoBehaviour
    {
        public float speed;

        [SerializeField]
        private float _attackCooldown = 2f;
        private float _attackTimer = 0f;

        [SerializeField]
        private int _attackPower = 3;

        private void Update()
        {
            Transform target = Player.PlayerInstance.transform;
            if (Vector2.Distance(transform.position, target.position) < 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            _attackTimer = Mathf.Max(0f, _attackTimer - Time.deltaTime);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                TryToAttackPlayer();
            }
        }

        private void TryToAttackPlayer()
        {
            if(Mathf.Approximately(0f, _attackTimer))
            {
                AttackPlayer();
                _attackTimer = _attackCooldown;
            }
        }

        private void AttackPlayer()
        {
            int candyStolen = Player.PlayerInstance.AttemptToStealCandy(_attackPower);
            for(int i = 0; i < candyStolen; ++i)
            {
                Vector3 spawnPos = Player.PlayerInstance.transform.position;
                Candy candy = CandyManager.Get().GetCandy(spawnPos);

                //@TODO: Apply mild random force downward from the house
                Rigidbody2D rigidBody = candy.GetComponent<Rigidbody2D>();
                Vector2 force;
                force.x = Random.Range(-1f, 1f);
                force.y = Random.Range(-1f, 1f);
                force *= 6f;
                rigidBody.AddForceAtPosition(force, candy.transform.position, ForceMode2D.Impulse);
            }
        }
    }
}
