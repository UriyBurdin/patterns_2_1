using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Object_Pool
{

    internal sealed class AmmunitionPool
    {
        private readonly Dictionary<string, HashSet<Ammo>> _ammoPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public AmmunitionPool(int capacityPool)
        {
            _ammoPool = new Dictionary<string, HashSet<Ammo>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }

        public Ammo GetAmmo(string type)
        {
            Ammo result;
            switch (type)
            {
                case "Bullet":
                    result = GetBullet(GetListBullet(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }

        private HashSet<Ammo> GetListBullet(string type)
        {
            return _ammoPool.ContainsKey(type) ? _ammoPool[type] : _ammoPool[type] = new HashSet<Ammo>();
        }

        private Ammo GetBullet(HashSet<Ammo> bullets)
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null)
            {
                 var newBullet = Resources.Load<Bullet>("Ammo/Bullet");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(newBullet);
                    ReturnToPool(instantiate.transform);
                    bullets.Add(instantiate);
                }

                GetBullet(bullets);
            }
            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
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