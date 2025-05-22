using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType//외부에서 사용할 타입정의
{
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType//외부에서 사용할 사용아이템 타입정의
{
    Health,
    Stamina,
    Buff
}

public enum BuffType
{
    Speed,
    Jump
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}
[Serializable]
public class ItemDataBuff
{
    public BuffType type;
    public float time;
}
//에셋화 시킬때 쓸 파일이름 사용할때 쓸 매뉴이름
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject //기본적인 틀 만들기(데이터 컨테이너,정의 덩어리)
{
    [Header("Info")]
    public string displayName;

    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;
    
    [Header("Staking")]
    public bool canStaking;
    public int maxStackAmount;
    
    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
    public ItemDataBuff[] buffs;
    
}
