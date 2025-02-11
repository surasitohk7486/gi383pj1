using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanFly : MonoBehaviour
{
    public float moveSpeed = 5f;  // ความเร็วในการเคลื่อนที่

    private Vector2 movement;

    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // รับอินพุตจากคีย์บอร์ด
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // คำนวณความเร็วปัจจุบัน
        float currentSpeed = movement.magnitude;

        // ส่งค่า Speed ให้ Animator
        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }

        // การพลิกภาพเมื่อเดินซ้ายหรือขวา
        if (movement.x != 0 && spriteRenderer != null)
        {
            spriteRenderer.flipX = movement.x < 0;
        }
    }

    void FixedUpdate()
    {
        // เคลื่อนที่แบบไม่มีแรงโน้มถ่วง
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
