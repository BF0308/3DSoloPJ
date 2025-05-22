using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public IEnumerator JumpBuff(float time,float value)
    {
        CharacterManager.Instance.Player.controller.jumpPower += value;
        yield return new WaitForSecondsRealtime(time);
        CharacterManager.Instance.Player.controller.jumpPower -= value;
    }
    public IEnumerator SpeedBuff(float time,float value)
    {
        CharacterManager.Instance.Player.controller.moveSpeed += value;
        yield return new WaitForSecondsRealtime(time);
        CharacterManager.Instance.Player.controller.moveSpeed -= value;
    }
}
