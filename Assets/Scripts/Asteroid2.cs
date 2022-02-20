using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid2 : Enemy //для каждого Asteroid будет своя реализация
    {
        [SerializeField] public float _damage = 10f;
        [SerializeField] public float _hp = 10f;

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