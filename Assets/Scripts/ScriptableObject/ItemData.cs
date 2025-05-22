using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType//�ܺο��� ����� Ÿ������
{
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType//�ܺο��� ����� �������� Ÿ������
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
//����ȭ ��ų�� �� �����̸� ����Ҷ� �� �Ŵ��̸�
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject //�⺻���� Ʋ �����(������ �����̳�,���� ���)
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
