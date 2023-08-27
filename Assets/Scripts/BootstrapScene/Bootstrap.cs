using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Image _loadingBar;
    [SerializeField] private float _simulatedLoadingTime = 2f;

    private AsyncOperation _loadingOperation;

    private void Start()
    {
        _loadingBar.fillAmount = 0;

        _loadingOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        _loadingOperation.allowSceneActivation = false;
    }

    private void Update()
    {
        _startDelay -= Time.deltaTime;
        if (_startDelay > 0) return;

        // Simulated
        if (_loadingBar.fillAmount < 0.7)
        {
            var progress = Time.deltaTime / _simulatedLoadingTime;
            _loadingBar.fillAmount += progress;
            return;
        }

        if (_loadingOperation.progress < 0.7) return;

        _loadingBar.fillAmount = _loadingOperation.progress;

        _endDelay -= Time.deltaTime;
        if (_endDelay > 0) return;
        _loadingOperation.allowSceneActivation = true;
    }

    private float _startDelay = 1f;
    private float _endDelay = 0.5f;
}
