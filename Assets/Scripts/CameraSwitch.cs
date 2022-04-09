using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public void SwitchToHere(Vector3 cameraPos, Vector3 cameraRot)
    {
        Camera.main.transform.position = cameraPos;
        Camera.main.transform.rotation = Quaternion.Euler(cameraRot);
    }
}