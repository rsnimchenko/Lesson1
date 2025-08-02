using System.Collections;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private readonly Gradient _gradient = new();
    private Renderer _rend;
    private bool _isActive = false;
    private float _interpolate = 0.0f;
    private float _timeChangeColor = 5.0f;
    private bool _isLaunchedEnable = false;
    private Coroutine _timerCoroutine;
    private float _launchSpeed = 50.0f;
    void Start()
    {
        _rend = GetComponent<Renderer>();

        _gradient.colorKeys = new GradientColorKey[] {
            new(Color.green, 0.0f),
            new(Color.blue, 0.33f),
            new(Color.yellow, 0.66f),
            new(Color.red, 1f)
        };

        _rend.material.color = _gradient.Evaluate(_interpolate);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) _isActive = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isActive = false;
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }
        }
    }

    void Update()
    {
        ChangeColor();
        CheckAndStartLaunchTimer();
        LaunchedCube();
    }

    private void ChangeColor()
    {
        if (_isLaunchedEnable) return;

        if (_isActive) _interpolate = (_interpolate >= 1.0f) ?
            1.0f : _interpolate + Time.deltaTime / _timeChangeColor;
        else _interpolate = (_interpolate <= 0.0f) ?
            0.0f : _interpolate - Time.deltaTime / _timeChangeColor;

        _rend.material.color = _gradient.Evaluate(_interpolate);
    }

    private void LaunchedCube()
    {
        if (!_isLaunchedEnable) return;

        transform.Translate(new Vector3(Random.Range(0.0f, 0.5f), 1.0f, Random.Range(0.0f, 0.5f)) * Time.deltaTime * _launchSpeed);
    }

    private void CheckAndStartLaunchTimer()
    {
        if (!_isLaunchedEnable && _interpolate >= 1.0f && _timerCoroutine == null)
        {
            _timerCoroutine = StartCoroutine(StartTimerToLaunch());
        }
    }

    private IEnumerator StartTimerToLaunch()
    {
        yield return new WaitForSeconds(3.0f);

        _isLaunchedEnable = true;
    }
}
