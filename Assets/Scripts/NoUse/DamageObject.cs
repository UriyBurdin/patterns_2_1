
using UnityEngine;
namespace Asteroids
{
    internal class DamageObject : IDamage
    {
        float _hp;
        public DamageObject(float hp)
        {
            _hp = hp;
        }

        public float Damage(GameObject damagObject)
        {
            if (_hp <= 0)
            {
               MonoBehaviour.Destroy(damagObject);
            }
            else
            {
                _hp-=10;
            }
            Debug.Log(_hp);
            return _hp;
        }

    }
}
