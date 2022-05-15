using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoordinateSystemManager : MonoBehaviour
{
    public static CoordinateSystemManager Instance;
    public GameObject UpLabel, DownLabel, LeftLabel, RightLabel;
    public float FadeTime;

    private TMP_Text _upText, _downText, _leftText, _rightText;
    private float _origLabelAlpha, _origAxisAlpha;
    private SpriteRenderer[] _axisSpriteRenderers;

    private IEnumerator AxisFade(float targetAlpha)
    {
        var elapsedTime = 0.0f;
        var startAlpha = _axisSpriteRenderers[0].color.a;

        // Gradually Fade Labels
        while (elapsedTime < FadeTime)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, (elapsedTime / FadeTime));
            foreach (SpriteRenderer sr in _axisSpriteRenderers)
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    private IEnumerator LabelFade(float targetAlpha)
    {
        var elapsedTime = 0.0f;
        var startAlpha = _upText.color.a;

        // Gradually Fade Labels
        while (elapsedTime < FadeTime)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, (elapsedTime / FadeTime));
            _upText.color = new Color(_upText.color.r, _upText.color.g, _upText.color.b, alpha);
            _downText.color = new Color(_downText.color.r, _downText.color.g, _downText.color.b, alpha);
            _leftText.color = new Color(_leftText.color.r, _leftText.color.g, _leftText.color.b, alpha);
            _rightText.color = new Color(_rightText.color.r, _rightText.color.g, _rightText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    private IEnumerator LabelChange(int newIndex)
    {
        var elapsedTime = 0.0f;
        var halfFadeTime = FadeTime/2;

        // Gradually Fade Out Labels
        while (elapsedTime < halfFadeTime)
        {
            float alpha = Mathf.Lerp(_origLabelAlpha, 0.0f, (elapsedTime / halfFadeTime));
            _upText.color = new Color(_upText.color.r, _upText.color.g, _upText.color.b, alpha);
            _downText.color = new Color(_downText.color.r, _downText.color.g, _downText.color.b, alpha);
            _leftText.color = new Color(_leftText.color.r, _leftText.color.g, _leftText.color.b, alpha);
            _rightText.color = new Color(_rightText.color.r, _rightText.color.g, _rightText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        switch (newIndex)
        {
        case 0:
            _upText.text = ConfigManager.Instance.Conf.Meta.YLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Meta.YLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Meta.XLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Meta.XLabelEnd;
            break;
        case 1:
            _upText.text = ConfigManager.Instance.Conf.Meta.YLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Meta.YLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Meta.ZLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Meta.ZLabelEnd;
            break;
        case 2:
            _upText.text = ConfigManager.Instance.Conf.Meta.ZLabelEnd;
            _downText.text = ConfigManager.Instance.Conf.Meta.ZLabelStart;
            _leftText.text = ConfigManager.Instance.Conf.Meta.XLabelStart;
            _rightText.text = ConfigManager.Instance.Conf.Meta.XLabelEnd;
            break;
        }
        // Gradually Fade In Labels
        elapsedTime = 0.0f;
        while (elapsedTime < halfFadeTime)
        {
            float alpha = Mathf.Lerp(0.0f, _origLabelAlpha, elapsedTime/halfFadeTime);
            _upText.color = new Color(_upText.color.r, _upText.color.g, _upText.color.b, alpha);
            _downText.color = new Color(_downText.color.r, _downText.color.g, _downText.color.b, alpha);
            _leftText.color = new Color(_leftText.color.r, _leftText.color.g, _leftText.color.b, alpha);
            _rightText.color = new Color(_rightText.color.r, _rightText.color.g, _rightText.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public void UpdateLabels(int newIndex)
    {
        StartCoroutine(LabelChange(newIndex));
    }
    public void FadeOutLabels()
    {
        StartCoroutine(LabelFade(0.0f));
    }
    public void FadeInLabels()
    {
        StartCoroutine(LabelFade(_origLabelAlpha));
    }
    public void FadeOutAxis()
    {
        StartCoroutine(AxisFade(0.0f));
    }
    public void FadeInAxis()
    {
        StartCoroutine(AxisFade(_origAxisAlpha));
    }
    // Update is called once per frame
    void Awake()
    {
        Instance = this;
        // Assign Text variables
        _upText = UpLabel.GetComponent<TMP_Text>();
        _downText = DownLabel.GetComponent<TMP_Text>();
        _leftText = LeftLabel.GetComponent<TMP_Text>();
        _rightText = RightLabel.GetComponent<TMP_Text>();
        // Store original alpha of labels
        _origLabelAlpha = _upText.color.a;
        // Store all Sprite Renderers
        _axisSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        // Store original alpha of axes
        _origAxisAlpha = _axisSpriteRenderers[0].color.a;
    }
}
