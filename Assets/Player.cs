using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : PlayerData
    {

        private Camera _camera;
        private Ship _ship;
        private FireShip _fire;
        private DamageObject _damageObject;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(gameObject, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _fire = new FireShip(_barrel);
            _damageObject = new DamageObject(_hp);
        }

        private void Update()
        {
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

        private void FixedUpdate()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _hp = _damageObject.Damage(gameObject);
        }
    }
}

