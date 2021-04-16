using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public ParticleSystem muzzleFlash;
    public ParticleSystem collisionExplosionPrefab;
    public TrailRenderer bulletTrailPrefab;
    public float shootPeriod;
    public LayerMask destructibleLayer;
    private Transform _transform;
    private RaycastHit _hitInfo;
    private bool _isHit;
    private float _nextShootTime;

    private void Start()
    {
        _transform = transform;
        _nextShootTime = 0f;
    }

    private void Update()
    {
        _isHit = Physics.Raycast(_transform.position, _transform.forward, out _hitInfo);

        if (Input.GetMouseButton(0) && Time.time >= _nextShootTime)
        {
            muzzleFlash.Play();
            TrailRenderer bulletTrail = Instantiate(bulletTrailPrefab, _transform.position, Quaternion.identity);
            bulletTrail.AddPosition(_transform.position);

            if (_isHit)
            {
                GameObject hitObject = _hitInfo.collider.gameObject;
                if (LayerMask.LayerToName(hitObject.layer) == "Destructible")
                {
                    Destroy(hitObject);
                }

                ParticleSystem collisionExplosion = Instantiate(collisionExplosionPrefab, _hitInfo.point, Quaternion.identity);
                collisionExplosion.transform.rotation = Quaternion.LookRotation(_hitInfo.normal);
                Destroy(collisionExplosion.gameObject, 1f);
                bulletTrail.AddPosition(_hitInfo.point);
            }

            _nextShootTime = Time.time + shootPeriod;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_hitInfo.point, _hitInfo.point + _hitInfo.normal);
    }
}
