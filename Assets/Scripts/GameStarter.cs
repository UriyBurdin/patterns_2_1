using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        int capacityPoolEnemy = 6;
        int createNewEnemy = 3;
        Enemy enemy;
        Enemy[] _enemyAll;

        Ammo ammo;

        private void Start()
        {

            EnemyPool enemyPool = new EnemyPool(capacityPoolEnemy);
            loadGroupEnemy("Asteroid", enemyPool, 3);;
            loadGroupEnemy("Asteroid2", enemyPool, 2);
            loadGroupEnemy("Asteroid3", enemyPool, 2);
            loadGroupEnemy("EmemyShip", enemyPool, 2);
            _enemyAll = FindObjectsOfType<EmemyShip>();
            startTarget(FindObjectOfType<Player>().transform);


        }


        public void Update()
        {

            for (var i = 0; i < _enemyAll.Length; i++) //
            {
                if (_enemyAll[i] != null)
                {
                    _enemyAll[i].Execute();
                }
            }
        }

        void loadGroupEnemy(string typeEnemy, EnemyPool enemyPool, int countEnemy)
        {
            for (int i = countEnemy; i > 0; i--)
            {
                enemy = enemyPool.GetEnemy(typeEnemy);
                enemy.transform.position = startRandomPosition();
                enemy.gameObject.SetActive(true);
            }
        }


        Vector2 startRandomPosition()
        {
            return new Vector2(Random.Range(-10,10),5);
        }

        void startTarget(Transform target)
        {
            for (var i = 0; i < _enemyAll.Length; i++) //
            {
                if (_enemyAll[i] != null)
                {
                    _enemyAll[i].target = target;
                }
            }
        }
    }
}