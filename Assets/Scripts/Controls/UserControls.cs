using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour
{
    private Controls _controls;
    private bool up = false, down = false, left = false, right = false, quit = false;
    private void OnEnable() => _controls.Player.Enable();
	private void OnDisable() => _controls.Player.Disable();
    void Awake()
    {
        // Construct controls
        _controls = new Controls();
        // Camera Movement
        _controls.Player.Up.performed += ctx => up = true;
        _controls.Player.Down.performed += ctx => down = true;
        _controls.Player.Left.performed += ctx => left = true;
        _controls.Player.Right.performed += ctx => right = true;
        // Quit Pressed
        _controls.Player.Quit.performed += ctx => quit = true;
    }
    void FixedUpdate()
    {
        if(quit)
            SceneryManager.Instance.LoadLevel("Intro");
            
        if(up) {
            CameraControl.Instance.UserRotate(Control.UP);
        } else if(down) {
            CameraControl.Instance.UserRotate(Control.DOWN);
        } else if(left) {
            CameraControl.Instance.UserRotate(Control.LEFT);
        } else if(right) {
            CameraControl.Instance.UserRotate(Control.RIGHT);
        }

        up = false;
        down = false;
        left = false;
        right = false;
    }
}