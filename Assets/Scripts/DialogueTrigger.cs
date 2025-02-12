using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox; // กล่องข้อความ
    public GameObject dialogueText; // ใช้ TextMeshPro แทน UI Text
    public float displayTime = 10f; // เวลาที่จะโชว์ข้อความ
    int count = 0;

    void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // ซ่อนข้อความตอนเริ่มเกม
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && count == 0) // ตรวจสอบว่า Player เดินชนหรือไม่
        {
            if (dialogueBox != null && dialogueText != null)
            {
                dialogueText.SetActive(true);
                dialogueBox.SetActive(true); // แสดงข้อความ
                count++;
                StartCoroutine(HideDialogueAfterTime()); // ซ่อนอัตโนมัติหลัง 10 วิ
            }
        }
    }

    IEnumerator HideDialogueAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        dialogueText.SetActive(false);
        dialogueBox.SetActive(false); // ปิดบทพูด
        Destroy(gameObject);
    }
}
