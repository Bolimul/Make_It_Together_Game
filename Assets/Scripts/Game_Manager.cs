using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Slider slider;
    private MakeLevel makeLevel;
    private ItemSlot itemSlot = null;

    private void Start()
    {
        makeLevel = GameObject.Find("ExerciseCanva").GetComponent<MakeLevel>();
        message.GetComponent<TextMeshProUGUI>().enabled = false;
        slider.value = 0;
    }
    public void CheckCondition()
    {
        if (slider.value == slider.maxValue)
        {
            message.enabled = true;
        }
    }

    public void GameManagerCheck(PointerEventData eventData, ItemSlot iSlot)
    {
        if(iSlot != null)
            itemSlot = iSlot;
        if (GameObject.Find("ExerciseCanva") != null && GameObject.Find("ExerciseCanva").activeInHierarchy == true)
        {
            if(makeLevel.GetLevelName() == "1TaskCM")
            {
                if (eventData.pointerEnter.GetComponent<Drag>().value == makeLevel.rightsum)
                {
                    if (eventData.pointerEnter.GetComponent<Drag>().GetSwitcher() == false)
                    {
                        eventData.pointerEnter.GetComponent<Image>().color = Color.green;
                        slider.value += 1;
                        eventData.pointerEnter.GetComponent<Drag>().SetSwitcher(true);
                    }
                    else
                    {
                        eventData.pointerEnter.GetComponent<Image>().color = Color.white;
                        slider.value -= 1;
                        eventData.pointerEnter.GetComponent<Drag>().SetSwitcher(false);
                    }
                    Debug.Log("Coin is collected");
                }
            }
            else if (makeLevel.GetLevelName() == "2TaskCM")
            {
                if (eventData.pointerDrag != null && itemSlot.gameObject.CompareTag("itemSlot") && eventData.pointerDrag.CompareTag("itemDrag"))
                {
                    Debug.Log("Coin is collected");
                    slider.value += eventData.pointerDrag.GetComponent<Drag>().value;
                }
                if (eventData.pointerDrag != null)
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("LeftGrid").transform, true);
            }
            else if (makeLevel.GetLevelName() == "3TaskCM" || makeLevel.GetLevelName() == "5TaskCM" || makeLevel.GetLevelName() == "CTask")
            {
                if (eventData.pointerDrag != null && itemSlot.value == eventData.pointerDrag.GetComponent<Drag>().value)
                {
                    Debug.Log("Coin is collected");
                    Destroy(eventData.pointerDrag);
                    slider.value += 1;
                }
                if (eventData.pointerDrag != null)
                    eventData.pointerDrag.transform.SetParent(GameObject.Find("LeftGrid").transform, true);
            }
            else if (makeLevel.GetLevelName() == "FTask")
            {
                if (eventData.pointerDrag != null && itemSlot != null)
                {
                    Debug.Log(eventData.pointerDrag.ToString());
                    Instantiate(eventData.pointerDrag, GameObject.Find("GridForCoins").transform);
                    slider.value += eventData.pointerDrag.GetComponent<Drag>().value;
                }
            }
        }
/*        else if (GameObject.Find("Ftask") != null && GameObject.Find("Ftask").activeInHierarchy == true)
        {
            if(eventData.pointerDrag != null && itemSlot != null)
            {
                Debug.Log(eventData.pointerDrag.ToString());
                Instantiate(eventData.pointerDrag, GameObject.Find("GridForCoins").transform);
                slider.value += eventData.pointerDrag.GetComponent<Drag>().value;
                eventData.pointerDrag.transform.SetParent(GameObject.Find("Ftask").transform, true);
            }
        }*/
            CheckCondition();
    }

    public void AddPoint()
    {
        slider.value += 1;
        CheckCondition();
    }

    
}
