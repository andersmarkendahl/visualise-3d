using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarInfoManager : MonoBehaviour
{
    private MetaLocal local;

    public MetaLocal Local { get => local; set => local = value; }
    public Text Header;
    void Start()
    {
        Header.text = local.Header;
    }
}
