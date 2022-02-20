using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private int _capacityPoolEnemy = 6;
        private Enemy _enemy;
        private Enemy[] _enemyAll;

        private void Start()
        {

            EnemyPool _enemyPool = new EnemyPool(_capacityPoolEnemy);
            loadGroupEnemy("Asteroid", _enemyPool, 3);;
            loadGroupEnemy("Asteroid2", _enemyPool, 2);
            loadGroupEnemy("Asteroid3", _enemyPool, 2);
            loadGroupEnemy("EmemyShip", _enemyPool, 2);
            _enemyAll = FindObjectsOfType<Enemy>();
            StartTarget(FindObjectOfType<Player>().transform);
        }


        private void Update()
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
                _enemy = enemyPool.GetEnemy(typeEnemy);
                _enemy.transform.position = StartRandomPosition();
                _enemy.gameObject.SetActive(true);
            }
        }


        Vector2 StartRandomPosition()
        {
            return new Vector2(Random.Range(-10,10),5);
        }

        void StartTarget(Transform target)
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