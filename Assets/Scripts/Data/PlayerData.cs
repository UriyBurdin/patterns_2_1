using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _acceleration;
    [SerializeField] public float _hp;
    [SerializeField] public Rigidbody2D _bullet;
    [SerializeField] public Transform _barrel;
    [SerializeField] public float _force;
}
