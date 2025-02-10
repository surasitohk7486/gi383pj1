using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowPlatforms : MonoBehaviour
{
    private bool isOnPlatform = false;
    private Transform platformTransform;
    private Vector3 lastPlatformPosition;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnPlatform = true;
            platformTransform = collision.transform;
            lastPlatformPosition = platformTransform.position;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnPlatform = false;
            platformTransform = null;
        }
    }

    void Update()
    {
        if (isOnPlatform && platformTransform != null)
        {
            // คำนวณการเคลื่อนที่ของแพลตฟอร์ม
            Vector3 platformMovement = platformTransform.position - lastPlatformPosition;

            // ให้ Player ติดตามแพลตฟอร์ม
            transform.position += platformMovement;

            // อัปเดตตำแหน่งล่าสุดของแพลตฟอร์ม
            lastPlatformPosition = platformTransform.position;
        }
    }
}
