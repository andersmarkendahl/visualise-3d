using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    private MetaDataPoint info;

    public MetaDataPoint Info { get => info; set => info = value; }
    public Text Header;
    void Start()
    {
        Header.text = info.Header;
    }
}
