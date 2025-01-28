using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pz2Gravity : MonoBehaviour
{
    public Animator Pz1;  // Reference to the Animator of the object being hit
    public Animator Pz21;
    public Animator Pz22;
    public Animator Pz3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // เช็คว่าโดน GameObject ที่เราต้องการหรือไม่ (คุณสามารถเปลี่ยนชื่อหรือชนิดของวัตถุได้ตามที่ต้องการ)
        if (collision.gameObject.CompareTag("Pz2"))
        {
            // เรียกใช้ Bool ใน Animator ของ Object
            if (Pz1 != null)
            {
                Pz1.SetBool("hit", true);  // ตั้งค่า Bool "PzSc" เป็น true เพื่อเริ่มเล่นแอนิเมชัน
                Pz21.SetBool("hit", true);
                Pz22.SetBool("hit", true);
                Pz3.SetBool("hit", true);
            }

            // ทำลายกระสุน
            Destroy(gameObject);
        }
    }
}
