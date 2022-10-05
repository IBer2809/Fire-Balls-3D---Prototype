using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Vector3 _moveDirection;
    [SerializeField] private float _bounceForce = 100;
    [SerializeField] private float _bounceDistance = 100;

    private void Start()
    {
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _bulletSpeed * Time.deltaTime);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.BreakBlock();
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
            FindObjectOfType<GameManager>().ShowPannels(0);
        }

    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        Rigidbody _bulletRb = GetComponent<Rigidbody>();
        _bulletRb.isKinematic = false;
        _bulletRb.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, -1), _bounceDistance);
    }
}

