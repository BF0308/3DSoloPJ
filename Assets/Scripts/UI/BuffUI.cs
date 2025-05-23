using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
   public Condition JumpBuff;
   public Condition SpeedBuff;

   private void Start()
   {
      CharacterManager.Instance.Player.condition.buffui = this;
   }
}
