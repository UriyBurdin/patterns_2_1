using UnityEngine;

namespace Asteroids
{
    internal sealed class Asteroid : Enemy
    {


        private void Start()
        {
            Health = new Health(20, 20);
            Initialization();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health.ChangeCurrentHealth(Health.Current - 20f);
            Debug.Log(Health.Current);
        }

    }
}