using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarInfoManager : MonoBehaviour
{
    private DataPoint _dpoint;

    public int Id;
    public DataPoint Dpoint { get => _dpoint; set => _dpoint = value; }
    public TMP_Text Header;

    public void ButtonClicked() {
        UserZoom.Instance.StarClicked(this);
    }
    void Start()
    {
        Header.text = _dpoint.Local.Header;
    }
}
