using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class FireShip : IFire
    {
        private readonly Transform _barrel;
        AmmunitionPool ammunitionPool = new AmmunitionPool(2);
        public FireShip(Transform barrel)
        {
            _barrel = barrel;
        }

        public void Fire(Rigidbody2D bullet, float force)
        {
            var ammo = ammunitionPool.GetAmmo("Bullet");
            ammo.transform.position = _barrel.position;
            ammo.gameObject.SetActive(true);
            ammo.GetComponent<Rigidbody2D>().AddForce(_barrel.right * force);
        }
    }
}