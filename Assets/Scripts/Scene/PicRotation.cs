using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicRotation : MonoBehaviour
{
    [SerializeField] private GameObject pic;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าชนกับ Player หรือไม่
        {
            pic.transform.rotation = Quaternion.Euler(0, 0, 180); // หมุน Z 180 องศา
        }
    }
}
