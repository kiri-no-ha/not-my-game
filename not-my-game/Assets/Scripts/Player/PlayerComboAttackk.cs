using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttackk : MonoBehaviour
{
    [Header("Настройки атаки")]
    public KeyCode attackKey = KeyCode.E; // Кнопка атаки (ЛКМ)
    public float comboTimeWindow = 0.5f; // Время между ударами для комбо
    public float attackDamage = 1f; // Урон за удар

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
        // Если игрок нажал кнопку атаки
        if (Input.GetKeyDown(attackKey))
        {
            // Если атака уже идет, увеличиваем комбо
            if (Time.time - lastAttackTime < comboTimeWindow && !isAttacking)
            {
                currentComboStep++;
                if (currentComboStep > 3) currentComboStep = 1; // Цикл из 3 ударов
            }
            else // Если время вышло, начинаем новое комбо
            {
                currentComboStep = 1;
            }

            // Запускаем анимацию атаки
            animator.SetInteger("Combo_Attack", currentComboStep);
            lastAttackTime = Time.time;
            isAttacking = true;
        }

        // Сброс комбо, если игрок не успел нажать
        if (Time.time - lastAttackTime > comboTimeWindow && currentComboStep > 0)
        {
            ResetCombo();
        }
    }

    // Вызывается в конце анимации (через Animation Event)
    public void EndAttack()
    {
        isAttacking = false;
    }

    // Сброс комбо
    private void ResetCombo()
    {
        currentComboStep = 0;
        animator.SetInteger("Combo_Attack", currentComboStep);
    }

    // Нанесение урона (вызывается в середине анимации через Animation Event)
    public void DealDamage()
    {
        // Проверяем, есть ли враг перед игроком
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            transform.position,
            1f, // Радиус атаки
            LayerMask.GetMask("Enemy") // Слой врагов
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
    }
