using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour, ITakeDamage
    {
        [SerializeField] public Transform target;
        private Camera _camera;
        private Transform _rotPool;
        private Health _health;
        private float _speed = 0.1f;
        private float _acceleration = 50f;
        private Moving _thisMoving;

        public void Initialization()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(gameObject, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _thisMoving = new Moving(moveTransform, rotation);
        }

        public void Execute()
        {
            var direction = target.transform.position -  transform.position;
            _thisMoving.Rotation(direction);
            _thisMoving.Move(direction.x, direction.y, Time.deltaTime);
            // thisMoving.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
       }

        public void TakeDamage(float damage)
        {
            Health.ChangeCurrentHealth(Health.Current - damage);
            Debug.Log(Health.Current);
        }
        public Health Health
        {
            get
            {
                  if (_health.Current <= 0.0f)
                {

                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_ENEMY);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }

        //public static Asteroid CreateAsteroidEnemy(Health hp)
        //{
        //    var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
        //    enemy.Health = hp;
        //    return enemy;
        //}

        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);

            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }
    }
}