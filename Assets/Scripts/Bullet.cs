using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet : Ammo
    {
        [SerializeField] public float _damage = 10f;
        [SerializeField] public float _hp = 1f;

        private void Start()
        {
            Health = new Health(_hp, _hp);
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
   
          //if (collision as ITakeDamage != null)
            if (collision.gameObject.GetComponent<ITakeDamage>()!=null) 
            {
                collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(_damage);
                TakeDamage(_damage);
            }
        }



    }
}