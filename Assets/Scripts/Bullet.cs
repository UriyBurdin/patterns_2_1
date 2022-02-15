using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet : Ammo
    {
        private void Start()
        {
            Health = new Health(20, 20);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health.ChangeCurrentHealth(Health.Current - 20f);
            Debug.Log(Health.Current);
        }

    }
}