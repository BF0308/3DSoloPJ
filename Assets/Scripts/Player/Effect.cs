using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private float jumpBuffDuration=0f;
    private bool isJumpingBuffActive=false;
    private float speedBuffDuration=0f;
    private bool isSpeedBuffActive=false;

    public IEnumerator JumpBuff(float time, float value)
    {
        if (isJumpingBuffActive) yield break;

        isJumpingBuffActive = true;
        jumpBuffDuration = time;
        CharacterManager.Instance.Player.condition.buffui.JumpBuff.maxValue = time;
        CharacterManager.Instance.Player.controller.jumpPower += value;

        while (jumpBuffDuration >= 0)
        {
            jumpBuffDuration -= Time.deltaTime;
            CharacterManager.Instance.Player.condition.buffui.JumpBuff.curValue = jumpBuffDuration;
            yield return null;
        }

        jumpBuffDuration = 0;
        Debug.Log(jumpBuffDuration+"점프버프 끝");
        CharacterManager.Instance.Player.controller.jumpPower -= value;
        isJumpingBuffActive = false;
    }

    public IEnumerator SpeedBuff(float time, float value)
    {
        if (isSpeedBuffActive) yield break;

        isSpeedBuffActive = true;
        speedBuffDuration = time;
        CharacterManager.Instance.Player.condition.buffui.SpeedBuff.maxValue = time;
        CharacterManager.Instance.Player.controller.moveSpeed += value;

        while (speedBuffDuration >= 0)
        {
            speedBuffDuration -= Time.unscaledDeltaTime;
            
            CharacterManager.Instance.Player.condition.buffui.SpeedBuff.curValue = speedBuffDuration;
            yield return null;
        }

        speedBuffDuration = 0;
        Debug.Log(speedBuffDuration+"스피드버프 끝");
        CharacterManager.Instance.Player.controller.moveSpeed -= value;
        isSpeedBuffActive = false;
    }
}