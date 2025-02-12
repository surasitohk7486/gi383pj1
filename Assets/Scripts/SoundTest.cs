using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null)
        {
            Debug.Log("Playing Sound..."); // เช็คว่าโค้ดทำงาน
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource ไม่ได้ถูกตั้งค่า!");
        }
    }
}
