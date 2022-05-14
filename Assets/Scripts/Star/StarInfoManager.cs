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
    public float FadeTime;
    public TMP_Text Header;
    public Image PanelBackground;
    public TMP_Text PanelName, PanelText;
    public Button CloseButton;

    private static bool _selected = false;
    private float _origHeaderAlpha;
    private DataPoint _dpoint;
    private int _id;
    private Image _closeImage;

    private IEnumerator PanelFade(float startAlpha, float targetAlpha)
    {
        var elapsedTime = 0.0f;
        float alpha;

        // Gradually Fade Panel
        while (elapsedTime < FadeTime)
        {
            alpha = Mathf.Lerp(startAlpha, targetAlpha, (elapsedTime / FadeTime));
            PanelBackground.color = new Color(PanelBackground.color.r, PanelBackground.color.g, PanelBackground.color.b, alpha);
            PanelName.color = new Color(PanelName.color.r, PanelName.color.g, PanelName.color.b, alpha);
            PanelText.color = new Color(PanelText.color.r, PanelText.color.g, PanelText.color.b, alpha);
            _closeImage.color = new Color(_closeImage.color.r, _closeImage.color.g, _closeImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        PanelBackground.color = new Color(PanelBackground.color.r, PanelBackground.color.g, PanelBackground.color.b, targetAlpha);
        PanelName.color = new Color(PanelName.color.r, PanelName.color.g, PanelName.color.b, targetAlpha);
        PanelText.color = new Color(PanelText.color.r, PanelText.color.g, PanelText.color.b, targetAlpha);
        _closeImage.color = new Color(_closeImage.color.r, _closeImage.color.g, _closeImage.color.b, targetAlpha);

    }
    private IEnumerator HeaderFade(float targetAlpha)
    {
        var elapsedTime = 0.0f;
        var startA = Header.color.a;

        // Gradually Fade Labels
        while (elapsedTime < FadeTime)
        {
            float alpha = Mathf.Lerp(startA, targetAlpha, (elapsedTime / FadeTime));
            Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Header.color = new Color(Header.color.r, Header.color.g, Header.color.b, targetAlpha);
    }
    public void StarSelected() {
        if (_selected)
            return;

        UserZoom.Instance.StarZoomIn(this);
        StartCoroutine(HeaderFade(0.0f));
        StartCoroutine(PanelFade(0.0f, 1.0f));
        _selected = true;
    }
    public void StarUnSelected() {
        UserZoom.Instance.StarZoomOut(this);
        StartCoroutine(HeaderFade(_origHeaderAlpha));
        StartCoroutine(PanelFade(1.0f, 0.0f));
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
        _closeImage = CloseButton.image;
    }
}
