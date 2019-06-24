using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{

    public Button[] TabButtons;
    public GameObject[] TabPages;
    public GameObject CurrentPage;
    public int CurrentPageIndex;
    // Start is called before the first frame update
    void Start()
    {
        SetPage(0); 
    }

    public void SetPage(int index)
    {
        CurrentPageIndex = index;
        CurrentPage = TabPages[CurrentPageIndex];
        foreach(GameObject go in TabPages)
        {
            if (go != CurrentPage)
            {
                go.SetActive(false);
            }
            else
            {
                go.SetActive(true);
            }
        }
        foreach (Button b in TabButtons)
        {
            if (Array.IndexOf(TabButtons, b) == CurrentPageIndex)
            {
                b.GetComponent<Animator>().SetBool("InTab", true);
            }
            else
            {
                b.GetComponent<Animator>().SetBool("InTab", false);
            }
        }
             
    }
}
