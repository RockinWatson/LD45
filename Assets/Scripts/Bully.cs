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

        [SerializeField]
        private int _hitPoints = 3;

        [SerializeField]
        private int _candyCount = 12;

        [SerializeField]
        private float _stunCooldown = 2f;
        private float _stunTimer;
        private bool _isStunned = false;

        private SpriteRenderer _spriteRenderer = null;
        private Rigidbody2D _rigidBody = null;

        private void Awake()
        {
            _spriteRenderer = this.GetComponent<SpriteRenderer>();
            _rigidBody = this.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(_isStunned)
            {
                _stunTimer -= Time.deltaTime;
                Color color = Color.red;
                float colorScale = 1f - (_stunTimer / _stunCooldown);
                color.g = color.b = colorScale;
                _spriteRenderer.color = color;
                if(_stunTimer <= 0f)
                {
                    _isStunned = false;
                }
            }

            if (!_isStunned)
            {
                Transform target = Player.PlayerInstance.transform;
                if (Vector2.Distance(transform.position, target.position) < 4)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }

                _attackTimer = Mathf.Max(0f, _attackTimer - Time.deltaTime);
            }
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
            Vector3 spawnPos = Player.PlayerInstance.transform.position;
            CandyManager.Get().SpillCandy(spawnPos, 6f, candyStolen);
        }

        public void Damage(int amount)
        {
            if(_isStunned)
            {
                return;
            }

            Stun();

            int candyAmount = _candyCount / _hitPoints;
            SpillCandy(candyAmount);

            _hitPoints -= amount;
            if(_hitPoints <= 0)
            {
                SpillCandy(_candyCount);
                Destroy(this.gameObject);
            }
        }

        private void Stun()
        {
            _isStunned = true;
            _stunTimer = _stunCooldown;

            _spriteRenderer.color = Color.red;

            //@TODO: Knock back enemy away from Player.
            Vector2 force = (this.transform.position - Player.PlayerInstance.transform.position).normalized;
            force *= 100f;
            _rigidBody.AddForce(force);

        }

        private void SpillCandy(int count)
        {
            Vector3 spawnPos = this.transform.position;
            CandyManager.Get().SpillCandy(spawnPos, 6f, count);
            _candyCount -= count;
        }
    }
}
