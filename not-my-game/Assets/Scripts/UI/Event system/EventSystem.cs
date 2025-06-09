using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class EventSystem : MonoBehaviour
{
    public int Index = 1;
    public TextMeshProUGUI log;
    public TextMeshProUGUI EventCast;
    public CanvasGroup cg;

    private List<string> logtext = new List<string>
    {
        "����� ��������", "����������� ���� �����", "������� �����"
    };

    private Color logColor;
    private Coroutine textAnimationCoroutine;
    private bool isTextAnimating = false;
    private Queue<string> messageQueue = new Queue<string>();

    public static EventSystem Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        log.text = "";
        logColor = log.color;
        // ��������� ������ ��������� � ���������
        Gamelog(1);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote) || Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleConsole();
        }
    }

    private void ToggleConsole()
    {
        if (cg.alpha != 1)
        {
            cg.alpha = 1.0f;
            cg.interactable = true;
        }
        else
        {
            cg.alpha = 0f;
            cg.interactable = false;
        }
    }

    public void Gamelog(int massageIndex)
    {
        if (massageIndex >= 0 && massageIndex < logtext.Count)
        {
            string messageToAdd = logtext[massageIndex];
            AddMessageWithAnimation(messageToAdd);
        }
    }

    public void AddMessageWithAnimation(string message)
    {
        messageQueue.Enqueue(message);

        // ���� �������� �� ��������, ��������� ��������� �������
        if (!isTextAnimating)
        {
            StartCoroutine(ProcessMessageQueue());
        }
    }

    private IEnumerator ProcessMessageQueue()
    {
        isTextAnimating = true;

        while (messageQueue.Count > 0)
        {
            string currentMessage = messageQueue.Dequeue();

            // ��������� ������� ������, ���� � ���� ��� ���� �����
            if (!string.IsNullOrEmpty(log.text))
            {
                log.text = "";
            }

            yield return StartCoroutine(TextAnimation(currentMessage));
        }

        isTextAnimating = false;
    }

    private IEnumerator TextAnimation(string textToShow)
    {
        string currentText = "";

        foreach (char character in textToShow)
        {
            currentText += character;
            log.text = log.text.Substring(0, log.text.LastIndexOf('\n') + 1) + currentText;

            // ��������� �� ����� ���������� ��� �����
            if (character == '.' || character == ',' || character == '!' || character == '?')
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    public void garbage()
    {
        // ������������� ��� �������� ��� �������
        if (textAnimationCoroutine != null)
        {
            {
                StopCoroutine(textAnimationCoroutine);
            }
            messageQueue.Clear();
            isTextAnimating = false;

            log.text = "������� ��������";
            Debug.Log(logtext);
        }
    }
    public void further()
    {
        Index++;
        Gamelog(Index);
    }
}