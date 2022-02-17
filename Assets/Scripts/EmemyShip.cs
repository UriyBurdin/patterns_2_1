using UnityEngine;

namespace Asteroids
{
    internal sealed class EmemyShip : Enemy
    {

        [SerializeField] public float _damage = 25f;
        [SerializeField] public float _hp = 20f;

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