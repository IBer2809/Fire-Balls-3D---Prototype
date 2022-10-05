using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootDelay;
    private float _timeAfterShoot;
    [SerializeField] private float _recoilDistance;


    private void Update()
    {
        
         _timeAfterShoot += Time.deltaTime;

         if (Input.GetMouseButton(0))
         {
            if (_timeAfterShoot > _shootDelay)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _shootDelay / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
         }
    }
        
    

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _bulletPoint.position, Quaternion.identity);
    }
}
