using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _deltaVolume = 0.05f;
    [SerializeField] private float _volumeTime = 1f;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private IEnumerator _currentCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeVolume(_maxVolume);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeVolume(_minVolume);
    }

    private void ChangeVolume(float volume)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = VolumeSmoothChange(volume);

        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator VolumeSmoothChange(float volume)
    {
        var waitSeconds = new WaitForSeconds(_volumeTime);

        while (enabled)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _deltaVolume);

            if (_audioSource.volume == volume)
            {
                StopCoroutine(_currentCoroutine);
            }

            yield return waitSeconds;
        }
    }
}
