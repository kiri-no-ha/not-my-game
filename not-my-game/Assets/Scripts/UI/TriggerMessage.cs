using UnityEngine;
using TMPro; // �������� � TextMeshPro

public class LocationTextChanger : MonoBehaviour
{
    [Header("��������� ���������� ����")]
    public TextMeshProUGUI textObject;              // ������ �� ������ � �������
    public string defaultText = "����� �� ���������"; // ����� �� ���������, ���� �������� ��� ���� ��������

    [System.Serializable]
    public class RegionSlot
    {
        [Tooltip("�������� ������� ��� �������� (�� ������ �� ������)")]
        public string name;

        [Tooltip("������ ������, ������������ ���� ���� �������")]
        public Transform corner1;

        [Tooltip("������ ������, ������������ ��������������� ���� �������")]
        public Transform corner2;

        [Tooltip("�����, ������� ������������, ����� �������� ��������� � ���� �������")]
        public string regionText;

        // ����������� ����������� ���������� (�� ������ ���)
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

        // ����������� ������������ ���������� (�� ������ ���)
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

    [Header("��������� �������� (8 ������)")]
    public RegionSlot[] regionSlots = new RegionSlot[8];

    /// <summary>
    /// � FixedUpdate ���������� �������� ��������� ���������.
    /// ���� �������� ��������� ������ �������, ������������ ��������������� �����.
    /// ���� �� ���� ������� �� �������� � ��������� ����� �� ���������.
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        bool foundRegion = false;

        // ���������� ��� �������� �������
        foreach (RegionSlot region in regionSlots)
        {
            // ���� � ������� �� ��������� ������ �������, ���������� �
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
                break; // ���� ������ ������ � ������ �� ���������
            }
        }

        // ���� �� ���� ������ �� ������, ������� ����� �� ���������
        if (!foundRegion)
        {
            UpdateText(defaultText);
        }
    }

    /// <summary>
    /// ��������� ����� �� ������, ���� �� ���������� �� ������.
    /// </summary>
    /// <param name="newText">����� ����� ��� �����������.</param>
    private void UpdateText(string newText)
    {
        if (textObject != null && textObject.text != newText)
        {
            textObject.text = newText;
            Debug.Log("������� �����: " + newText);
        }
    }
}
