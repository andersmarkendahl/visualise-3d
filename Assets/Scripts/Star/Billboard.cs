using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
    public Transform Cam;
    private void Start() {
        Cam = Camera.main.transform;
    }
    void Update() {
        transform.LookAt(transform.position + Cam.forward);
    }
}