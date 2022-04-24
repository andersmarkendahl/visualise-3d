using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarInfoManager : MonoBehaviour
{
    private DataPoint _dpoint;

    public DataPoint Dpoint { get => _dpoint; set => _dpoint = value; }
    public TMP_Text Header;
    void Start()
    {
        Header.text = _dpoint.Local.Header;
    }
}
