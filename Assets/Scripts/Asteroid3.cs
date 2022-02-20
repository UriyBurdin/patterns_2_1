using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid3 : Enemy //для каждого Asteroid будет своя реализация
    {
        [SerializeField] public float _damage = 25f;
        [SerializeField] public float _hp = 30f;

        private void Start()
        {
            Health = new Health(_hp, _hp);
            Initialization();
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _player = collision.gameObject.GetComponent<Player>();
            if (_player)
            {
                _player.TakeDamage(_damage);
            }
        }

    }
}