using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarInfoManager : MonoBehaviour
{

    public DataPoint Dpoint { get => _dpoint; set => _dpoint = value; }
    public int Id { get => _id; set => _id = value; }
    public float HeaderFadeTime, PanelFadeTime;
    public TMP_Text Header;
    public Image PanelBackground;
    public TMP_Text PanelName, PanelText;
    public Button CloseButton;

    private static bool _selected = false;
    private float _origHeaderAlpha;
    private DataPoint _dpoint;
    private int _id;

    private IEnumerator PanelFade(float targetAlpha)
    {
        var elapsedTime = 0.0f;
        var startABackground = PanelBackground.color.a;
        var startAPanelName = PanelName.color.a;
        var startAPanelText = PanelText.color.a;

        // Gradually Fade Panel
        while (elapsedTime < PanelFadeTime)
        {
            float alpha1 = Mathf.Lerp(startABackground, targetAlpha, (elapsedTime / PanelFadeTime));
            float alpha2 = Mathf.Lerp(startAPanelName, targetAlpha, (elapsedTime / PanelFadeTime));
            float alpha3 = Mathf.Lerp(startAPanelText, targetAlpha, (elapsedTime / PanelFadeTime));
            PanelBackground.color = new Color(PanelBackground.color.r, PanelBackground.color.g, PanelBackground.color.b, alpha1);
            PanelName.color = new Color(PanelName.color.r, PanelName.color.g, PanelName.color.b, alpha2);
            PanelText.color = new Color(PanelText.color.r, PanelText.color.g, PanelText.color.b, alpha3);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PanelBackground.color = new Color(PanelBackground.color.r, PanelBackground.color.g, PanelBackground.color.b, targetAlpha);
        PanelName.color = new Color(PanelName.color.r, PanelName.color.g, PanelName.color.b, targetAlpha);
        PanelText.color = new Color(PanelText.color.r, PanelText.color.g, PanelText.color.b, targetAlpha);
    }
    private IEnumerator HeaderFade(float targetAlpha)
    {
        var elapsedTime = 0.0f;
        var startA = Header.color.a;

        // Gradually Fade Labels
        while (elapsedTime < HeaderFadeTime)
        {
            float alpha = Mathf.Lerp(startA, targetAlpha, (elapsedTime / HeaderFadeTime));
            Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, targetAlpha);
    }
    private IEnumerator ButtonFade(float targetAlpha)
    {
        Image CloseImage = CloseButton.image;
        var elapsedTime = 0.0f;
        var startA = CloseImage.color.a;

        // Gradually Fade Labels
        while (elapsedTime < PanelFadeTime)
        {
            float alpha = Mathf.Lerp(startA, targetAlpha, (elapsedTime / PanelFadeTime));
            CloseImage.color = new Color(CloseImage.color.r, CloseImage.color.g, CloseImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        CloseImage.color = new Color(CloseImage.color.r, CloseImage.color.g, CloseImage.color.b, targetAlpha);
    }
    public void StarSelected() {
        if (_selected)
            return;

        UserZoom.Instance.StarZoomIn(this);
        StartCoroutine(HeaderFade(0.0f));
        StartCoroutine(PanelFade(1.0f));
        StartCoroutine(ButtonFade(1.0f));
        _selected = true;
    }
    public void StarUnSelected() {
        UserZoom.Instance.StarZoomOut(this);
        StartCoroutine(HeaderFade(_origHeaderAlpha));
        StartCoroutine(PanelFade(0.0f));
        StartCoroutine(ButtonFade(0.0f));
        _selected = false;
    }
    void Start()
    {
        Header.text = _dpoint.Meta.Header;
        PanelName.text = _dpoint.Meta.Header;
        PanelText.text = 
            ConfigManager.Instance.Conf.Meta.XDescription + ": " + _dpoint.Coordinate.x.ToString() + Environment.NewLine +
            ConfigManager.Instance.Conf.Meta.YDescription + ": " + _dpoint.Coordinate.y.ToString() + Environment.NewLine +
            ConfigManager.Instance.Conf.Meta.ZDescription + ": " + _dpoint.Coordinate.z.ToString() + Environment.NewLine +
            Environment.NewLine + _dpoint.Meta.Description;

    }
    void Awake()
    {
        _origHeaderAlpha = Header.color.a;
    }
}
