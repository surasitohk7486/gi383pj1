using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pz3 : MonoBehaviour
{
    public Animator[] objectAnimator;  // Reference to the Animator of the object being hit

    void OnCollisionEnter2D(Collision2D collision)
    {
        // เช็คว่าโดน GameObject ที่เราต้องการหรือไม่ (คุณสามารถเปลี่ยนชื่อหรือชนิดของวัตถุได้ตามที่ต้องการ)
        if (collision.gameObject.CompareTag("Bullet"))
        {
            for (int i = 0; i < objectAnimator.Length; i++) 
            {
                if (objectAnimator != null)
                {
                    objectAnimator[i].SetBool("Pz3Sc", true);  // ตั้งค่า Bool "PzSc" เป็น true เพื่อเริ่มเล่นแอนิเมชัน
                }
            }

            Destroy(collision.gameObject);
            // ทำลายกระสุน
            Destroy(gameObject);
        }
    }
}
