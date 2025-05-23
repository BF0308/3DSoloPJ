using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UIConditions uiCondition;
    public BuffUI buffui;
    Condition health//UI컨디션에 있는 health를 리턴해줌
    {
        get { return uiCondition.health; }
    }

    Condition stamina////UI컨디션에 있는 stamina를 리턴해줌
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
        Debug.Log("플레이어가 죽었다.");
    }

    public void StaminaConsume(float amount)
    {
        stamina.Subtract(amount);
    }
}