using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneryManager : MonoBehaviour
{
    public static SceneryManager Instance;

    private Animator _animator;
    private float _transitionDelay = 2.0f;

    private IEnumerator DelayLoadLevel(string level)
    {
        _animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(_transitionDelay);
        SceneManager.LoadScene(level);
    }
    public void LoadLevel(string level)
    {
        StartCoroutine(DelayLoadLevel(level));
    }
    void Awake()
    {
        Instance = this;
        GameObject transitionImage = GameObject.Find("TransitionImage");
        if (transitionImage == null)
        {
            Debug.LogError("Unable to find transitionImage");
        }
        else
        {
            _animator = transitionImage.GetComponent<Animator>();
            if (_animator == null)
                Debug.LogError("Unable to get _animator");
        }
    }
}