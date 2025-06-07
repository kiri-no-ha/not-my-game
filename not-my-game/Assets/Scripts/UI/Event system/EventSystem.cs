using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class EventSystem : MonoBehaviour
{
    //public EventSystem eventSystem; ���� �������� � ������� � ������ ���� ��������� � ������� � ���������� ��
    public TextMeshProUGUI log;
    public TextMeshProUGUI EventCast;

    private List<string> logtext = new List<string>
    {
    "����� ��������","����������� ���� �����", "������� �����"
    };

    private Color logColor;
    private Coroutine coroutine;

    public static EventSystem Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }
    void Start()
    {

        log.text += logtext[0];
        logColor = log.color;

    }
    public void Gamelog(int massageIndex)
    {
        if (massageIndex >= 0 && massageIndex < logtext.Count)
        {
            string massageToAdd = logtext[massageIndex];
            if (!string.IsNullOrEmpty(log.text))
            {
                log.text += "\n" + massageToAdd;
            }
            else { log.text = massageToAdd; }
        }
    }
}
