using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public ParticleSystem muzzleFlash;
    public ParticleSystem collisionExplosionPrefab;
    public TrailRenderer bulletTrailPrefab;
    private Transform _transform;
    private RaycastHit _hitInfo;
    private bool _isHit;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _isHit = Physics.Raycast(_transform.position, _transform.forward, out _hitInfo);
        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.Play();
            TrailRenderer bulletTrail = Instantiate(bulletTrailPrefab, _transform.position, Quaternion.identity);
            bulletTrail.AddPosition(_transform.position);

            if (_isHit)
            {
                ParticleSystem collisionExplosion = Instantiate(collisionExplosionPrefab, _hitInfo.point, Quaternion.identity);
                collisionExplosion.transform.rotation = Quaternion.LookRotation(_hitInfo.normal);
                Destroy(collisionExplosion.gameObject, 1f);

                bulletTrail.AddPosition(_hitInfo.point);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_hitInfo.point, _hitInfo.point + _hitInfo.normal);
    }
}
