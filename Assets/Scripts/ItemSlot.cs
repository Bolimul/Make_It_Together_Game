using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Slider slider;
    public int value;
    


    public void OnDrop(PointerEventData eventData)
    {
        GameObject.Find("GameManager").GetComponent<Game_Manager>().GameManagerCheck(eventData, this);
    }



}
