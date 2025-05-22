using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIInventory : MonoBehaviour
{
    public ItemSlot[] itemSlots;

    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Transform dropPosition;

    [Header("Select Item")] public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useBtn;
    public GameObject equipBtn;
    public GameObject unEquipBtn;
    public GameObject dropBtn;

    public Effect effect;

    private PlayerController controller;
    private PlayerCondition condition;

    ItemData selectedItem;
    private int selectedIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        effect = CharacterManager.Instance.Player.effect;
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;
        dropPosition = CharacterManager.Instance.Player.dropPosition;

        controller.inventory += Toggle; //델리게이트 구독
        CharacterManager.Instance.Player.addItem += AddItem;

        inventoryWindow.SetActive(false);
        itemSlots = new ItemSlot[slotPanel.childCount];

        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            itemSlots[i].idx = i;
            itemSlots[i].inventory = this;
        }

        ClearSelectedItemWindow();
    }

    void ClearSelectedItemWindow()
    {
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useBtn.SetActive(false);
        equipBtn.SetActive(false);
        unEquipBtn.SetActive(false);
        dropBtn.SetActive(false);
    }

    public void Toggle() //델리게이트에서 호출되는 메서드(구독되는 메서드)
    {
        if (IsOpen())
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }

    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    void AddItem()
    {
        ItemData data = CharacterManager.Instance.Player.itemData;


        if (data.canStaking)
        {
            ItemSlot slot = GetItemStack(data);
            if (slot != null)
            {
                slot.quantity++;
                UIUpdate();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot(); //비어있는 슬롯
        if (emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            UIUpdate();
            return;
        }

        ThrowItem(data);
        CharacterManager.Instance.Player.itemData = null;
    }

    void UIUpdate()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item != null) //슬롯i번째가 null이 아니면
            {
                itemSlots[i].Set(); //생성
            }
            else
            {
                itemSlots[i].Clear(); //지우기
            }
        }

        CharacterManager.Instance.Player.itemData = null;
    }

    ItemSlot GetItemStack(ItemData data)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            //슬롯에있는 아이템이 data와 일치하고, 현재스텍이 최대스택보다 작을때
            if (itemSlots[i].item == data && itemSlots[i].quantity < data.maxStackAmount)
            {
                return itemSlots[i]; //현재슬롯을 반환해준다.
            }
        }

        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                return itemSlots[i];
            }
        }

        return null;
    }

    void ThrowItem(ItemData data)
    {
        Instantiate(data.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360));
    }

    public void SelectItem(int idx)
    {
        if (itemSlots[idx].item == null) return;

        selectedItem = itemSlots[idx].item;
        selectedIdx = idx;

        selectedItemName.text = selectedItem.displayName;
        selectedItemDescription.text = selectedItem.description;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        for (int i = 0; i < selectedItem.consumables.Length; i++)
        {
            selectedItemStatName.text += selectedItem.consumables[i].type.ToString() + "\n";
            selectedItemStatValue.text += selectedItem.consumables[i].value.ToString() + "\n";
        }

        useBtn.SetActive(selectedItem.type == ItemType.Consumable);
        equipBtn.SetActive(selectedItem.type == ItemType.Equipable && !itemSlots[idx].equipped);
        unEquipBtn.SetActive(selectedItem.type == ItemType.Equipable && itemSlots[idx].equipped);
        dropBtn.SetActive(true);
    }

    public void OnUseBtn()
    {
        if (selectedItem.type == ItemType.Consumable)
        {
            for (int i = 0; i < selectedItem.consumables.Length; i++)
            {
                if (i >= 0 && i < selectedItem.consumables.Length)
                {
                    switch (selectedItem.consumables[i].type)
                    {
                        case ConsumableType.Health:
                            condition.Heal(selectedItem.consumables[i].value);
                            break;
                        case ConsumableType.Stamina:
                            condition.StaminaHeal(selectedItem.consumables[i].value);
                            break;
                    }
                }

                if (i >= 0 && i < selectedItem.buffs.Length)
                {
                    Debug.Log(selectedItem.buffs[i].type.ToString());
                    CharacterManager.Instance.Player.controller.Buff(selectedItem.buffs[i].time,
                        selectedItem.buffs[i].value, selectedItem.buffs[i].type);
                }
            }

            RemoveSelectedItem();
        }
    }

    public void OnDropBtn()
    {
        ThrowItem(selectedItem);
        RemoveSelectedItem();
    }

    void RemoveSelectedItem()
    {
        itemSlots[selectedIdx].quantity--;
        if (itemSlots[selectedIdx].quantity <= 0)
        {
            selectedItem = null;
            itemSlots[selectedIdx].item = null;
            selectedIdx = -1;
            ClearSelectedItemWindow();
        }

        UIUpdate();
    }
}