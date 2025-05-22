using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    
    public Effect effect;
    public ItemData itemData;
    public Action addItem;
    public SpawnPoint spawnPoint;

    public Transform dropPosition;
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        effect = GetComponent<Effect>();
    }
}