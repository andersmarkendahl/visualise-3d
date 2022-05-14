using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour
{
    private Controls _controls;
    private bool _up = false, _down = false, _left = false, _right = false, _quit = false;
    private void OnEnable() => _controls.Player.Enable();
	private void OnDisable() => _controls.Player.Disable();
    void Awake()
    {
        // Construct controls
        _controls = new Controls();
        // Camera Movement
        _controls.Player.Up.performed += ctx => _up = true;
        _controls.Player.Down.performed += ctx => _down = true;
        _controls.Player.Left.performed += ctx => _left = true;
        _controls.Player.Right.performed += ctx => _right = true;
        // Quit Pressed
        _controls.Player.Quit.performed += ctx => _quit = true;
    }
    void FixedUpdate()
    {
        if(_quit)
            SceneryManager.Instance.LoadLevel("Intro");
            
        if(_up) {
            CameraControl.Instance.UserRotate(Control.UP);
        } else if(_down) {
            CameraControl.Instance.UserRotate(Control.DOWN);
        } else if(_left) {
            CameraControl.Instance.UserRotate(Control.LEFT);
        } else if(_right) {
            CameraControl.Instance.UserRotate(Control.RIGHT);
        }

        _up = false;
        _down = false;
        _left = false;
        _right = false;
    }
}
