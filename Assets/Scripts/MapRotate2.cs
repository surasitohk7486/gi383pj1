using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotate2 : MonoBehaviour
{
    public Transform targetObject;
    private bool canRotate = false;
    [SerializeField] private Quaternion targetRotation;
    private Vector3 targetPosition;
    private bool rotateToTarget = false;

    

    int count = 0;

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject artifact;
    [SerializeField] private GameObject dialogue3;
    [SerializeField] private GameObject dialogue4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && count == 0)
        {
            Debug.Log("Touch");
            canRotate = true; // อนุญาตให้ตรวจสอบการคลิกเมาส์
        }
    }

    void Update()
    {
        if (canRotate && Input.GetMouseButtonDown(1) && count == 0)
        {
            artifact.SetActive(true);
            dialogue3.SetActive(true);
            dialogue4.SetActive(true);
            Destroy(wall);
            Destroy(gameObject);
            


            /*targetRotation = Quaternion.Euler(-180f, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z);
            targetPosition = new Vector3(targetObject.position.x, 25f, targetObject.position.z);
            rotateToTarget = true;
            Debug.Log("Start rotating target object");
            count++;*/
        }

        if (rotateToTarget && targetObject != null)
        {
            /*targetObject.rotation = Quaternion.RotateTowards(targetObject.rotation, targetRotation, 90f * Time.deltaTime);
            targetObject.position = Vector3.Lerp(targetObject.position, targetPosition, Time.deltaTime * 2f);

            if (Quaternion.Angle(targetObject.rotation, targetRotation) < 0.1f &&
                Mathf.Abs(targetObject.position.y - 25f) < 0.01f)
            {
                targetObject.rotation = targetRotation;
                targetObject.position = targetPosition;
                rotateToTarget = false;
                Debug.Log("Target rotation and position complete");
                Destroy(gameObject);
                Destroy(wall);
            }*/
        }
    }
}
