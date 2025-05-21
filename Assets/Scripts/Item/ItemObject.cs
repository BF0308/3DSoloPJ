using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable//인터페이스(껍데기)
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()//아이템 이름,정보 가져와서 저장하기(알맹이)
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract() //
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
