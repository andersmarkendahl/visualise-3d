using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour
{
    private CameraControls _controls;
    private bool up = false, down = false, left = false, right = false;
    private void OnEnable() => _controls.Player.Enable();
	private void OnDisable() => _controls.Player.Disable();
    void Awake()
    {
        // Construct controls
        _controls = new CameraControls();
        // Quit Pressed
        //_controls.Player.Quit.performed += ctx => UIManager.Instance.Close();
        // Movement Pressed

        _controls.Player.Up.performed += ctx => up = true;
        _controls.Player.Down.performed += ctx => down = true;
        _controls.Player.Left.performed += ctx => left = true;
        _controls.Player.Right.performed += ctx => right = true;

    }
    void Update()
    {
        if(up) {
            Debug.Log("Got Up");
        } else if(down) {
            Debug.Log("Got Down");
        } else if(left) {
            Debug.Log("Got Left");
        } else if(right) {
            Debug.Log("Got Right");
        }

        up = false;
        down = false;
        left = false;
        right = false;
    }
}
