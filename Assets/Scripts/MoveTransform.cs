using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private Vector3 _move;
        private GameObject _moveObject;
        public float Speed { get; protected set; }

        public MoveTransform(GameObject moveObject, float speed)
        {
            _moveObject = moveObject;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            //var speed = deltaTime * Speed;
            //_move.Set(horizontal * speed, vertical * speed, 0.0f);
            //_moveObject.GetComponent<Rigidbody2D>().AddForce(_move);
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _moveObject.transform.localPosition += _move;
        }
    }
}