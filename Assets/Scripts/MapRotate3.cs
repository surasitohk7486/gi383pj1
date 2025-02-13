using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotate3 : MonoBehaviour
{
    public Transform targetObject;  // วัตถุเป้าหมายที่จะหมุน
    private bool rotateToTarget = false;
    [SerializeField] private Quaternion targetRotation;
    private Vector3 targetPosition;

    [SerializeField] AudioSource sound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (targetObject != null)
            {
                // ตั้งค่าเป้าหมายการหมุนและตำแหน่ง Y
                targetRotation = Quaternion.Euler(-180f, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z);
                targetPosition = new Vector3(targetObject.position.x, 0f, targetObject.position.z);

                rotateToTarget = true;
                Debug.Log("Start rotating target object to 180 X and moving to Y = 17.5");
                sound.Play();

                Destroy(collision.gameObject);
            }

        }
    }

    void Update()
    {
        if (rotateToTarget && targetObject != null)
        {
            // หมุนอย่างนุ่มนวล
            targetObject.rotation = Quaternion.RotateTowards(targetObject.rotation, targetRotation, 90f * Time.deltaTime);

            // เคลื่อนตำแหน่งแกน Y ไปยัง 17.5 อย่างนุ่มนวล
            targetObject.position = Vector3.Lerp(targetObject.position, targetPosition, Time.deltaTime * 2f);

            // ตรวจสอบว่าเป้าหมายการหมุนและตำแหน่งใกล้เคียงเป้าหมายแล้ว
            if (Quaternion.Angle(targetObject.rotation, targetRotation) < 0.1f &&
                Mathf.Abs(targetObject.position.y - 0f) < 0.01f)
            {
                targetObject.rotation = targetRotation;
                targetObject.position = targetPosition;
                rotateToTarget = false;
                Debug.Log("Target rotation and position complete");
                Destroy(gameObject);
            }
        }
    }
}
