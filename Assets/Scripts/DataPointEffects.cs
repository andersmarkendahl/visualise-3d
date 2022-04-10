using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPointEffects : MonoBehaviour
{
    private Vector3 _positionNorm;
    private Renderer _renderer;
    private Color _color;
    private float _scale = 10.0f;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _positionNorm = transform.position.normalized;
        _color = new Color(_positionNorm.x, _positionNorm.y, _positionNorm.z, 1f);
    }

    void Start()
    {         
        _renderer.material.color = _color;
    }
}
