using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanFly : MonoBehaviour
{
    public float moveSpeed = 5f;  // ความเร็วในการเคลื่อนที่

    private Vector2 movement;

    void Update()
    {
        // รับอินพุตจากคีย์บอร์ด (WASD หรือปุ่มลูกศร)
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // เคลื่อนที่แบบไม่มีแรงโน้มถ่วง
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
