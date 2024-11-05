using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionGame : MonoBehaviour
{
    GameObject UI;
    TMP_Text txt;
    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        txt = UI.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P)) Increment();
    }

    void Increment()
    {
        Count++;
        txt.text = "Flowers Picked: " + Count;
    }
}
