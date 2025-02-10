using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowPlatforms : MonoBehaviour
{
    private bool isOnPlatform = false; // เช็คว่า Player ยืนอยู่บนแพลตฟอร์มหรือไม่
    private Transform platformTransform; // อ้างอิงถึงแพลตฟอร์ม
    private Vector3 platformLastPosition; // ตำแหน่งสุดท้ายของแพลตฟอร์ม

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // เมื่อ Player เหยียบแพลตฟอร์ม
            isOnPlatform = true;
            platformTransform = collision.transform;
            platformLastPosition = platformTransform.position;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // เมื่อ Player ออกจากแพลตฟอร์ม
            isOnPlatform = false;
            platformTransform = null;
        }
    }

    void Update()
    {
        if (isOnPlatform && platformTransform != null)
        {
            // คำนวณการเคลื่อนที่ของแพลตฟอร์ม
            Vector3 platformMovement = platformTransform.position - platformLastPosition;

            // ให้ Player เคลื่อนที่ตามแพลตฟอร์ม
            transform.position += platformMovement;

            // อัปเดตตำแหน่งสุดท้ายของแพลตฟอร์ม
            platformLastPosition = platformTransform.position;
        }
    }
}
