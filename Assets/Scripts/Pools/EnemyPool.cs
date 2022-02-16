using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Object_Pool
{

    internal sealed class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public EnemyPool(int capacityPool)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_ENEMY).transform;
            }
        }

        public Enemy GetEnemy(string type)
        {
            Enemy result;
            string pathLoad = "Enemy/" + type;
                 switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type), Resources.Load<Asteroid> (pathLoad));
                    break;
                case "Asteroid2":
                    result = GetAsteroid(GetListEnemies(type), Resources.Load<Asteroid2>(pathLoad));
                    break;
                case "Asteroid3":
                    result = GetAsteroid(GetListEnemies(type), Resources.Load<Asteroid3>(pathLoad));
                    break;
                case "EmemyShip":
                    result = GetAsteroid(GetListEnemies(type), Resources.Load<EmemyShip>(pathLoad));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }

        private HashSet<Enemy> GetListEnemies(string type)
        {
               return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies, Enemy newEnemy)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(newEnemy);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies, newEnemy);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}