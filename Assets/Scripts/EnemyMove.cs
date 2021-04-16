using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    private Transform _player;
    private Transform _transform;

    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        _transform = transform;
    }
    private void Update()
    {
        Vector3 target = new Vector3(_player.position.x, _transform.position.y, _player.position.z);
        _transform.LookAt(target);
        _transform.position += _transform.forward * Time.deltaTime * speed;
    }
}