using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        int capacityPoolEnemy = 6;
        int createNewEnemy = 3;
        Enemy enemy;

        Ammo ammo;

        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(capacityPoolEnemy);

            for (int i= createNewEnemy; i>0; i--)
            {
                enemy = enemyPool.GetEnemy("Asteroid");
                enemy.transform.position = randOnCircle(3f);
                enemy.gameObject.SetActive(true);
            }


            AmmunitionPool ammunitionPool = new AmmunitionPool(8);

            for (int i= 5; i>0; i--)
            {
                ammo = ammunitionPool.GetAmmo("Bullet");
                ammo.transform.position = randOnCircle(3f);
                ammo.gameObject.SetActive(true);
            }


        }



        Vector2 randOnCircle(float radius)
        {
            float randAng = Random.Range(0, Mathf.PI * 2);
            return new Vector2(Mathf.Cos(randAng) * radius, Mathf.Sin(randAng) * radius);
        }
    }
}