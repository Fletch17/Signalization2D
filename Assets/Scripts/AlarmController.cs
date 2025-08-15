using System.Collections;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _deltaVolume = 0.05f;
    [SerializeField] private float _volumeTime = 1f;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private Coroutine _currentCoroutine;
       
    public void StartAlarm()
    {
        ChangeVolume(_maxVolume);
    }

    public void StopAlarm()
    {
        ChangeVolume(_minVolume);
    }

    private void ChangeVolume(float volume)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(VolumeSmoothChange(volume));
    }    

    private IEnumerator VolumeSmoothChange(float volume)
    {
        var waitSeconds = new WaitForSeconds(_volumeTime);

        while (enabled && _audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _deltaVolume);  
            yield return waitSeconds;
        }
    }
}
