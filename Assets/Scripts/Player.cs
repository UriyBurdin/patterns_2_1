
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : PlayerData
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
             _health.ChangeCurrentHealth(_health.Current - 5f);
            _hp = _health.Current;
            Debug.Log(_hp);
        }
    }
}

