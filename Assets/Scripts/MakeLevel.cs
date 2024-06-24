using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MakeLevel : MonoBehaviour
{
    private string[] levelNames = new string[7] {"2TaskCM", "1TaskCM" , "3TaskCM" , "5TaskCM" ,"CTask","ETask", "FTask"};
    public List<List<GameObject>> dragItems = new() { };
    public List<List<GameObject>> itemSlots = new() { };
    public List<List<GameObject>> items = new() { };
    public GridLayoutGroup leftGrid;
    public GridLayoutGroup rightGrid;
    public HorizontalLayoutGroup horLayGroup;
    private Slider slider;
    public int rightsum;
    private int index = 0;
    private int index2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/2nisDrag"), Resources.Load<GameObject>("Prefabs/1nisDrag") });
        itemSlots.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/bisli") });
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/5nis1nisDrag"), Resources.Load<GameObject>("Prefabs/5nis2nis1nisDrag"), Resources.Load<GameObject>("Prefabs/10nisDrag") });
        itemSlots.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/5nisSlot") });
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/1nisDrag"), Resources.Load<GameObject>("Prefabs/10nisDrag") });
        itemSlots.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/1nisText"), Resources.Load<GameObject>("Prefabs/10nisText") });
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/2nis1nisSlot") });
        itemSlots.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/2nisDrag") });
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/5nis1nisDrag"), Resources.Load<GameObject>("Prefabs/5nis2nis1nisDrag"), Resources.Load<GameObject>("Prefabs/10nisDrag") });
        itemSlots.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/bisli") });
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/task2") });
        itemSlots.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/bisli") });
        dragItems.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/1nisDrag"), Resources.Load<GameObject>("Prefabs/2nisDrag"), Resources.Load<GameObject>("Prefabs/5nisDrag") });
        items.Add(new List<GameObject>() { Resources.Load<GameObject>("Prefabs/10nisImage"), Resources.Load<GameObject>("Prefabs/bisliImage") });
        slider = GameObject.Find("progressBar").GetComponent<Slider>();
        if (string.Equals(levelNames[index % levelNames.Length], "FTask") == true)
        {
            GameObject.Find("Task2").GetComponent<Canvas>().sortingOrder = 2;
            GameObject.Find("Task1").GetComponent<Canvas>().sortingOrder = 1;
        }
        else
        {
            GameObject.Find("Task2").GetComponent<Canvas>().sortingOrder = 1;
            GameObject.Find("Task1").GetComponent<Canvas>().sortingOrder = 2;
        }
        MakeNewLevel(levelNames[index%levelNames.Length]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeNewLevel(string levelName)
    {
        if (string.Equals(levelName, "2TaskCM") == true)
        {
            for (int i = 0; i < dragItems[0].Count; i++)
                Instantiate(dragItems[0][i], leftGrid.transform);
            for (int i = 0; i < itemSlots[0].Count; i++)
                Instantiate(itemSlots[0][i], rightGrid.transform);
            slider.maxValue = 5;
            rightsum = 0;
        }
        else if (string.Equals(levelName, "1TaskCM") == true)
        {
            for (int i = 0; i < dragItems[1].Count; i++)
                Instantiate(dragItems[1][i], leftGrid.transform);
            for (int i = 0; i < itemSlots[0].Count; i++)
                Instantiate(itemSlots[1][i], rightGrid.transform);
            slider.maxValue = 2;
            rightsum = 5;
        }
        else if (string.Equals(levelName, "3TaskCM") == true)
        {
            for (int i = 0; i < dragItems[2].Count; i++)
                Instantiate(dragItems[2][i], leftGrid.transform);
            for (int i = 0; i < itemSlots[2].Count; i++)
                Instantiate(itemSlots[2][i], rightGrid.transform);
            slider.maxValue = 2;
            rightsum = 0;
        }
        else if (string.Equals(levelName, "5TaskCM") == true)
        {
            for (int i = 0; i < dragItems[3].Count; i++)
                Instantiate(dragItems[3][i], leftGrid.transform);
            for (int i = 0; i < itemSlots[3].Count; i++)
                Instantiate(itemSlots[3][i], rightGrid.transform);
            slider.maxValue = 1;
            rightsum = 0;
        }
        else if (string.Equals(levelName, "CTask") == true)
        {
            for (int i = 0; i < dragItems[4].Count; i++)
                Instantiate(dragItems[4][i], leftGrid.transform);
            for (int i = 0; i < itemSlots[4].Count; i++)
                Instantiate(itemSlots[4][i], rightGrid.transform);
            slider.maxValue = 2;
            rightsum = 0;
        }
        else if (string.Equals(levelName, "ETask") == true)
        {
            for (int i = 0; i < dragItems[5].Count; i++)
                Instantiate(dragItems[5][i], leftGrid.transform);
            for (int i = 0; i < itemSlots[5].Count; i++)
                Instantiate(itemSlots[5][i], rightGrid.transform);
            slider.maxValue = 1;
            rightsum = 0;
        }
        else if (string.Equals(levelName, "FTask") == true)
        {
            for (int i = 0; i < dragItems[index % levelNames.Length].Count; i++)
                Instantiate(dragItems[index%levelNames.Length][i], horLayGroup.transform);
            Instantiate(items[index2 % levelNames.Length][0], GameObject.Find("price").transform);
            Instantiate(items[index2 % levelNames.Length][1], GameObject.Find("product").transform);
            slider.maxValue = 6;
        }
        
    }

    public string GetLevelName()
    {
        return levelNames[index%levelNames.Length];
    }

    public void MoveToNextLevel()
    {
        foreach(Transform itemD in leftGrid.transform)
        {
            Destroy(itemD.gameObject);
        }
        foreach (Transform itemS in rightGrid.transform)
        {
            Destroy(itemS.gameObject);
        }
        slider.value = 0;
        GameObject.Find("VictMessage").GetComponent<TextMeshProUGUI>().enabled = false;
        if(string.Equals(levelNames[index+1 % levelNames.Length], "FTask") == true)
        {
            GameObject.Find("Task2").GetComponent<Canvas>().sortingOrder = 2;
            GameObject.Find("Task1").GetComponent<Canvas>().sortingOrder = 1;
        }
        else
        {
            GameObject.Find("Task2").GetComponent<Canvas>().sortingOrder = 1;
            GameObject.Find("Task1").GetComponent<Canvas>().sortingOrder = 2;
        }
        index++;
        MakeNewLevel(levelNames[index % levelNames.Length]);
    }
}
