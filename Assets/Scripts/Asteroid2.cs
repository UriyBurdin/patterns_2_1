using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid2 : Enemy
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
            if (collision.gameObject.GetComponent<Player>())
            {
                collision.gameObject.GetComponent<Player>().takeDamage(_damage);
            }
        }

    }
}