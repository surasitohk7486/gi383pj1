using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject live;
    [SerializeField] private Button myButton; // ใช้ SerializeField ให้แสดงใน Inspector
    [SerializeField] private Button myButton2;

    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnClickLive);
        }

        if (myButton2 != null)
        {
            myButton.onClick.AddListener(OnClickLeave);
        }

    }
    void OnClickLive()
    {
        live.SetActive(true);
    }

    void OnClickLeave()
    {
        
    }
}
