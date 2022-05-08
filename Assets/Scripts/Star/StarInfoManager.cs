using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarInfoManager : MonoBehaviour
{

    public DataPoint Dpoint { get => _dpoint; set => _dpoint = value; }
    public int Id { get => _id; set => _id = value; }
    public float FadeTime = 2.0f;
    public TMP_Text Header;

    private float _origHeaderAlpha;
    private DataPoint _dpoint;
    private int _id;

    private IEnumerator HeaderFade(float targetAlpha)
    {
        var elapsedTime = 0.0f;
        var startAlpha = Header.color.a;

        // Gradually Fade Labels
        while (elapsedTime < FadeTime)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, (elapsedTime / FadeTime));
            Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public void ButtonClicked() {
        UserZoom.Instance.StarClicked(this);
        StartCoroutine(HeaderFade(0.0f));
    }
    void Start()
    {
        Header.text = _dpoint.Local.Header;
    }
    void Awake()
    {
        _origHeaderAlpha = Header.color.a;
    }
}
