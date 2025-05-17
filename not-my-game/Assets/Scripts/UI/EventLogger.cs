using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogger : MonoBehaviour
{
    // UI-�������, ���� ����� ���������� ��� (��������� ����� ���������)
    public Text logText;

    // ������ ��� ���������� ���-���������
    private List<string> logs = new List<string>();

    /// <summary>
    /// ��������� ����� ��������� � ��� � ��������� ����������� �� ������.
    /// </summary>
    /// <param name="message">��������� ��� ������</param>
    public void LogEvent(string message)
    {
        logs.Add(message);
        UpdateLogUI();
    }

    /// <summary>
    /// ��������� ���������� UI-������, ��������� ��� ���������.
    /// </summary>
    private void UpdateLogUI()
    {
        if (logText != null)
        {
            logText.text = string.Join("\n", logs);
        }
    }

    /// <summary>
    /// ����������, ����� ���������� ������� "����".
    /// ��������� � ��� ��������� �� ��������� ������ � ��������� ��������� ���������.
    /// </summary>
    public void DisplayStunStatus()
    {
        LogEvent("���� �����������! ����� �������!");
        // ��������� �������� ��� ���������� ��������� ��������� (��������, �������� ����� �� 2 �������)
        StartCoroutine(TemporaryHighlight("���� �����������!", 2.0f));
    }

    /// <summary>
    /// ��������� �������� ��� ��������� ���������.
    /// �������� ������� ���������� UI-������ �� ��������� ��������� �� �������� �����, ����� ���� ���������� ������� ���.
    /// </summary>
    /// <param name="message">���������, ������� ����� �������� ����������</param>
    /// <param name="duration">����������������� ��������� � ��������</param>
    private IEnumerator TemporaryHighlight(string message, float duration)
    {
        if (logText != null)
        {
            // ��������� �������� ���
            string previousLogs = logText.text;
            // ���������� ���������� ���������
            logText.text = message;
            // ���� �������� �����
            yield return new WaitForSeconds(duration);
            // ���������� ���������� ����������
            logText.text = previousLogs;
        }
    }

    /// <summary>
    /// ����� ��� ������� ����� (�� �������).
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
