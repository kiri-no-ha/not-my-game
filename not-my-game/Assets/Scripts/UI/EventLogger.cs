using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogger : MonoBehaviour
{
    // UI-элемент, куда будет выводиться лог (назначьте через инспектор)
    public Text logText;

    // Хранит все записанные лог-сообщения
    private List<string> logs = new List<string>();

    /// <summary>
    /// Добавляет новое сообщение в лог и обновляет отображение на экране.
    /// </summary>
    /// <param name="message">Сообщение для записи</param>
    public void LogEvent(string message)
    {
        logs.Add(message);
        UpdateLogUI();
    }

    /// <summary>
    /// Обновляет содержимое UI-текста, объединяя все сообщения.
    /// </summary>
    private void UpdateLogUI()
    {
        if (logText != null)
        {
            logText.text = string.Join("\n", logs);
        }
    }

    /// <summary>
    /// Вызывается, когда происходит событие "Стан".
    /// Добавляет в лог сообщение об оглушении игрока и запускает временное выделение.
    /// </summary>
    public void DisplayStunStatus()
    {
        LogEvent("Стан активирован! Игрок оглушен!");
        // Запускаем корутину для временного выделения сообщения (например, заменить текст на 2 секунды)
        StartCoroutine(TemporaryHighlight("Стан активирован!", 2.0f));
    }

    /// <summary>
    /// Временная корутина для выделения сообщения.
    /// Заменяет текущее содержимое UI-текста на указанное сообщение на заданное время, после чего возвращает прежний лог.
    /// </summary>
    /// <param name="message">Сообщение, которое нужно временно отобразить</param>
    /// <param name="duration">Продолжительность выделения в секундах</param>
    private IEnumerator TemporaryHighlight(string message, float duration)
    {
        if (logText != null)
        {
            // Сохраняем нынешний лог
            string previousLogs = logText.text;
            // Отображаем выделенное сообщение
            logText.text = message;
            // Ждем заданное время
            yield return new WaitForSeconds(duration);
            // Возвращаем предыдущее содержимое
            logText.text = previousLogs;
        }
    }

    /// <summary>
    /// Метод для очистки логов (по желанию).
    /// </summary>
    public void ClearLogs()
    {
        logs.Clear();
        if (logText != null)
        {
            logText.text = "";
        }
    }
}
