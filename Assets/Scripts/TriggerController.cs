using UnityEngine;

[RequireComponent(typeof(AlarmController))]
public class TriggerController : MonoBehaviour
{
    [SerializeField] private AlarmController _alarmController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarmController.StartAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarmController.StopAlarm();
    }
}
