using UnityEngine;
using TMPro; // Работаем с TextMeshPro

public class LocationTextChanger : MonoBehaviour
{
    [Header("Настройка текстового поля")]
    public TextMeshProUGUI textObject;              // Ссылка на объект с текстом
    public string defaultText = "Текст по умолчанию"; // Текст по умолчанию, если персонаж вне всех областей

    [System.Serializable]
    public class RegionSlot
    {
        [Tooltip("Название области для удобства (не влияет на логику)")]
        public string name;

        [Tooltip("Пустой объект, определяющий один угол области")]
        public Transform corner1;

        [Tooltip("Пустой объект, определяющий противоположный угол области")]
        public Transform corner2;

        [Tooltip("Текст, который отображается, когда персонаж находится в этой области")]
        public string regionText;

        // Вычисленные минимальные координаты (по каждой оси)
        public Vector3 MinCoordinates
        {
            get
            {
                if (corner1 == null || corner2 == null)
                    return Vector3.zero;
                return new Vector3(
                    Mathf.Min(corner1.position.x, corner2.position.x),
                    Mathf.Min(corner1.position.y, corner2.position.y),
                    Mathf.Min(corner1.position.z, corner2.position.z)
                );
            }
        }

        // Вычисленные максимальные координаты (по каждой оси)
        public Vector3 MaxCoordinates
        {
            get
            {
                if (corner1 == null || corner2 == null)
                    return Vector3.zero;
                return new Vector3(
                    Mathf.Max(corner1.position.x, corner2.position.x),
                    Mathf.Max(corner1.position.y, corner2.position.y),
                    Mathf.Max(corner1.position.z, corner2.position.z)
                );
            }
        }
    }

    [Header("Настройка областей (8 слотов)")]
    public RegionSlot[] regionSlots = new RegionSlot[8];

    /// <summary>
    /// В FixedUpdate происходит проверка координат персонажа.
    /// Если персонаж находится внутри области, определяется соответствующий текст.
    /// Если ни одна область не подходит — выводится текст по умолчанию.
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        bool foundRegion = false;

        // Перебираем все заданные области
        foreach (RegionSlot region in regionSlots)
        {
            // Если у области не назначены пустые объекты, пропускаем её
            if (region.corner1 == null || region.corner2 == null)
                continue;

            Vector3 min = region.MinCoordinates;
            Vector3 max = region.MaxCoordinates;

            if (pos.x >= min.x && pos.x <= max.x &&
                pos.y >= min.y && pos.y <= max.y &&
                pos.z >= min.z && pos.z <= max.z)
            {
                UpdateText(region.regionText);
                foundRegion = true;
                break; // Если найден регион — дальше не проверяем
            }
        }

        // Если ни один регион не найден, выводим текст по умолчанию
        if (!foundRegion)
        {
            UpdateText(defaultText);
        }
    }

    /// <summary>
    /// Обновляет текст на экране, если он отличается от нового.
    /// </summary>
    /// <param name="newText">Новый текст для отображения.</param>
    private void UpdateText(string newText)
    {
        if (textObject != null && textObject.text != newText)
        {
            textObject.text = newText;
            Debug.Log("Обновлён текст: " + newText);
        }
    }
}
