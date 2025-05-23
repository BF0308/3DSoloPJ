using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UIConditions uiCondition;
    public BuffUI buffui;
    Condition health//UI����ǿ� �ִ� health�� ��������
    {
        get { return uiCondition.health; }
    }

    Condition stamina////UI����ǿ� �ִ� stamina�� ��������
    {
        get { return uiCondition.stamina; }
    }

    Condition jumpBuff
    {
        get { return buffui.JumpBuff; }
    }

    Condition speedBuff
    {
        get { return buffui.SpeedBuff; }
    }

    //public event Action onTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);
        health.Add(health.passiveValue * Time.deltaTime);
        if (health.curValue < 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void StaminaHeal(float amount)
    {
        stamina.Add(amount);
    }

    public void Die()
    {
        Debug.Log("�÷��̾ �׾���.");
    }

    public void StaminaConsume(float amount)
    {
        stamina.Subtract(amount);
    }
}