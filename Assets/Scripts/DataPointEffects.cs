using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPointEffects : MonoBehaviour
{
    private Vector3 _positionNorm;
    private Renderer _renderer;
    private Color _color;
    private ParticleSystem _ps;
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _positionNorm = transform.position.normalized;
        _color = new Color(_positionNorm.x, _positionNorm.y, _positionNorm.z, 1f);
        _ps = GetComponentInChildren<ParticleSystem>();

    }
    void Start()
    {         
        var main = _ps.main;
        main.startColor = _color;
        _renderer.material.color = _color;
    }
}
