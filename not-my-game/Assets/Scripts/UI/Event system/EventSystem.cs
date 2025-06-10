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
        "",
        "игрок появился",
        "Привет. Это Mekura Games.Мы — небольшая команда, работаем без бюджета, на энтузиазме. Эта игра — наш личный эксперимент, наш путь в геймдев.",
        "Мы не ставим себе цель удивить графикой или масштабами.Главное — передать идею, атмосферу и сделать что-то, что останется в памяти. Хоть на немного.",
        "У нас пока всё в процессе. Некоторые вещи будут меняться, что-то ещё недоделано, где-то могут быть баги.Но за каждым элементом — смысл. Мы не делаем «просто потому что»",
        "Ты — не тестировщик. Ты — часть этого пути.Если тебе откликнется то, что мы делаем, значит, всё не зря.Мы читаем фидбек, замечаем, что работает, а что нет.",
        "Мы не знаем, что будет дальше: выстрелит ли проект, или останется в тени.Но мы делаем это честно, без накруток и без копирования чужих идей.",
        "Спасибо, что ты здесь.Если тебе нравится то, что ты видишь — оставайся.Нам будет проще идти дальше, если кто-то это действительно ценит.",
        "Привет. Добро пожаловать в то, что другие назвали бы «сырой прототип», а мы — началом новой эры.Мы — Mekura Games. Маленькая студия с большими зубами.Мы не просим доверия. Мы его заслужим.",
        "У нас нет инвесторов, нет красивых офисов и корпоративного мерча.Зато есть движок, идеи, бессонные ночи и странная вера, что мы можем сделать что-то большее, чем просто игру.И мы уже начали.",
        "Эта игра — как черновик сна, который не отпускает.В ней будут сбои, странности, грани между жанрами. Но всё это — с намерением.Мы не делаем развлекалово. Мы создаём переживание.",
        "Ты — не просто игрок. Ты — свидетель зарождения мира.Каждое твоё действие здесь фиксируется. Анализируется. Вдохновляет.Мы смотрим. И мы слушаем.",
        "Мы не знаем, к чему приведёт этот путь.Но если всё пойдёт по плану — это будет что-то дикое, глубокое и страшно живое.Что-то, что можно будет назвать искусством, а не просто продуктом.",
        "В будущем — новые главы, механики, персонажи, баги, патчи, шрамы на коде.Возможно, и ты станешь частью команды. Почему бы и нет?Инди — это не жанр. Это вызов.",
        "Так что... Спасибо, что пришёл.Спасибо, что читаешь это. Что дышишь с этим проектом в одном ритме.У нас только один шанс — и он начинается сейча",

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
        // Запускаем первое сообщение с анимацией
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

        // Если анимация не запущена, запускаем обработку очереди
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

            // Добавляем перенос строки, если в логе уже есть текст
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

            // Проверяем на знаки препинания для паузы
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
        // Останавливаем все анимации при очистке
        if (textAnimationCoroutine != null)
        {
            {
                StopCoroutine(textAnimationCoroutine);
            }
            messageQueue.Clear();
            isTextAnimating = false;

            log.text = "консоль отчищена";
            Debug.Log(logtext);
        }
    }
    public void further()
    {
        Index++;
        Gamelog(Index);
    }
}