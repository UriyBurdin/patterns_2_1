
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, ITakeDamage
    {
        [SerializeField] public Transform barrel;
        private float _speed = 5;
        private float _damage = 20;
        private float _acceleration = 10;
        private float _hp = 100;
        private Rigidbody2D _bullet;
        private float _force = 600;

        private Camera _camera;
        private Moving _ship;
        private FireShip _fire;
        private Health _health;


        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(gameObject, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Moving(moveTransform, rotation);
            _fire = new FireShip(barrel);
            _health = new Health(_hp, _hp);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _fire.Fire(_bullet, _force);
            }
        }

        public void TakeDamage(float damage)
        {
            _health.ChangeCurrentHealth(_health.Current - damage);
            Debug.Log(_health.Current);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _enemy = collision.gameObject.GetComponent<Enemy>();
            if (_enemy)
            {
                _enemy.TakeDamage(_damage);
                TakeDamage(_damage);
            }
        }
    }
}

