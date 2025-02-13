using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.BoolParameter;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject live;
    [SerializeField] private Button myButton; // ใช้ SerializeField ให้แสดงใน Inspector
    [SerializeField] private Button myButton2;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject dialogueText;
    [SerializeField] private GameObject lives;
    [SerializeField] private GameObject leave;
    [SerializeField] private GameObject leaveBox;

    public float displayTime = 5f;

    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnClickLive);
        }

        if (myButton2 != null)
        {
            myButton2.onClick.AddListener(OnClickLeave);
        }

    }
    void OnClickLive()
    {
        live.SetActive(true);
        lives.SetActive(false);
        leave.SetActive(false);
    }

    void OnClickLeave()
    {
        dialogueBox.SetActive(true);
        dialogueText.SetActive(true);
        leaveBox.SetActive(true);
        StartCoroutine(HideDialogueAfterTime());
    }

    IEnumerator HideDialogueAfterTime()
    {
        lives.SetActive(false);
        leave.SetActive(false);
        yield return new WaitForSeconds(displayTime);
        dialogueText.SetActive(false);
        dialogueBox.SetActive(false); // ปิดบทพูด
    }
}
