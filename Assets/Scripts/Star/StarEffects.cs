using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffects : MonoBehaviour
{
    private Vector3 _rotationAxis;
    private float _rotationSpeed = 10.0f;
    private float _scale = 10.0f;
    void Awake()
    {
        _rotationAxis = new Vector3(Random.value,Random.value, Random.value).normalized;
    }
    void Start()
    {
        var renderer = GetComponent<Renderer>();
        var ps = GetComponentInChildren<ParticleSystem>();
        var positionTranslated = transform.position - ConfigManager.Instance.CoordinateTranslation;
        var particles = ps.main;
        var color = new Color(positionTranslated.x/_scale, positionTranslated.y/_scale, positionTranslated.z/_scale, 1f);
        particles.startColor = color;
        renderer.material.color = color;
    }
    void Update()
    {
        // Rotate star around fixed axis
		transform.RotateAround(transform.position, _rotationAxis, _rotationSpeed * Time.deltaTime);
    }
}
