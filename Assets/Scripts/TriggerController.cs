using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
