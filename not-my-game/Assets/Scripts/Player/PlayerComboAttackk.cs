using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttackk : MonoBehaviour
{
    [Header("��������� �����")]
    public KeyCode attackKey = KeyCode.E; // ������ ����� (���)
    public float comboTimeWindow = 0.5f; // ����� ����� ������� ��� �����
    public float attackDamage = 1f; // ���� �� ����

    private Animator animator;
    private int currentComboStep = 0;
    private float lastAttackTime = 0f;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ���� ����� ����� ������ �����
        if (Input.GetKeyDown(attackKey))
        {
            // ���� ����� ��� ����, ����������� �����
            if (Time.time - lastAttackTime < comboTimeWindow && !isAttacking)
            {
                currentComboStep++;
                if (currentComboStep > 3) currentComboStep = 1; // ���� �� 3 ������
            }
            else // ���� ����� �����, �������� ����� �����
            {
                currentComboStep = 1;
            }

            // ��������� �������� �����
            animator.SetInteger("Combo_Attack", currentComboStep);
            lastAttackTime = Time.time;
            isAttacking = true;
        }

        // ����� �����, ���� ����� �� ����� ������
        if (Time.time - lastAttackTime > comboTimeWindow && currentComboStep > 0)
        {
            ResetCombo();
        }
    }

    // ���������� � ����� �������� (����� Animation Event)
    public void EndAttack()
    {
        isAttacking = false;
    }

    // ����� �����
    private void ResetCombo()
    {
        currentComboStep = 0;
        animator.SetInteger("Combo_Attack", currentComboStep);
    }

    // ��������� ����� (���������� � �������� �������� ����� Animation Event)
    public void DealDamage()
    {
        // ���������, ���� �� ���� ����� �������
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            transform.position,
            1f, // ������ �����
            LayerMask.GetMask("Enemy") // ���� ������
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
    }
