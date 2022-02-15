using UnityEngine;

namespace Asteroids
{
     public interface IFire
    {
        void Fire(Rigidbody2D bullet, float force);
    }
}