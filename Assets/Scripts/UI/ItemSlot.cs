using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    public ItemData item;
    public UIInventory inventory;
    
    public Button Btn;
    public Image Icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;
    
    public int idx;
    public bool equipped;
    public int quantity;
    // Start is called before the first frame update
    void Awake()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set()
    {
        Icon.gameObject.SetActive(true);
        Icon.sprite = item.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if (outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        item = null;
        Icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    public void OnClickBtn()
    {
        inventory.SelectItem(idx);
    }
}
