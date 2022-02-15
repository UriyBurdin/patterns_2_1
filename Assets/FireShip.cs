using UnityEngine;

namespace Asteroids
{
    internal sealed class FireShip : IFire
    {
        private readonly Transform _barrel;

        public FireShip(Transform barrel)
        {
            _barrel = barrel;
        }

        public void Fire(Rigidbody2D bullet, float force)
        {
            var temAmmunition = MonoBehaviour.Instantiate(bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * force);
        }
    }
}