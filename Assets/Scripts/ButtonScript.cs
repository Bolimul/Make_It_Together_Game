using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ButtonScript : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GameObject.Find("GameManager").GetComponent<Game_Manager>().AddPoint);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
