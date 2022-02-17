
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : PlayerData, ITakeDamage
    {

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
            _fire = new FireShip(_barrel);
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

        public void takeDamage(float Damage)
        {
            _health.ChangeCurrentHealth(_health.Current - Damage);
            Debug.Log(_health.Current);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                collision.gameObject.GetComponent<Enemy>().takeDamage(_damage);
                takeDamage(_damage);
            }
        }
    }
}

