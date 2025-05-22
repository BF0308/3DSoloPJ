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

        CharacterManager.Instance.Player.controller.jumpPower += value;

        while (jumpBuffDuration > 0)
        {
            jumpBuffDuration -= Time.deltaTime;
            Debug.Log(jumpBuffDuration+"������");
            yield return null;
        }
        Debug.Log(jumpBuffDuration+"�������� ��");
        CharacterManager.Instance.Player.controller.jumpPower -= value;
        isJumpingBuffActive = false;
    }

    public IEnumerator SpeedBuff(float time, float value)
    {
        if (isSpeedBuffActive) yield break;

        isSpeedBuffActive = true;
        speedBuffDuration = time;

        CharacterManager.Instance.Player.controller.moveSpeed += value;

        while (speedBuffDuration > 0)
        {
            speedBuffDuration -= Time.unscaledDeltaTime;
            
            Debug.Log(speedBuffDuration+"���ǵ���");
            yield return null;
        }
        Debug.Log(speedBuffDuration+"���ǵ���� ��");
        CharacterManager.Instance.Player.controller.moveSpeed -= value;
        isSpeedBuffActive = false;
    }
}