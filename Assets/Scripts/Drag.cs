using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject canvas;
    public GameObject initialParent;
    public int value;
    private bool switcher = false;


    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector2 pos;
    private void Start()
    {
        
        string levelName = GameObject.Find("ExerciseCanva").GetComponent<MakeLevel>().GetLevelName();
        if (levelName != "FTask")
        {
            canvas = GameObject.Find("Task1");
            initialParent = GameObject.Find("LeftGrid");
        }
        else
        {
            canvas = GameObject.Find("Task2");
            initialParent = GameObject.Find("CoinsLayout");
        }
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        pos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        this.transform.SetParent(canvas.transform, true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(GameObject.Find("ExerciseCanva").GetComponent<MakeLevel>().GetLevelName() != "1TaskCM")
        {
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta / canvas.GetComponent<Canvas>().scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        eventData.pointerDrag.transform.SetParent(initialParent.transform, true);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        GameObject.Find("GameManager").GetComponent<Game_Manager>().GameManagerCheck(eventData, null);
    }

    public void SetSwitcher(bool sw)
    {
        this.switcher = sw;
    }

    public bool GetSwitcher()
    {
        return this.switcher;
    }


}
