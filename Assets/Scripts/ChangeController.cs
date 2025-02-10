using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeController : MonoBehaviour
{
    [SerializeField] private GameObject player; // Drag the player object here in the inspector
    [SerializeField] private MonoBehaviour oldController; // Drag the current player controller script here
    [SerializeField] private MonoBehaviour newController; // Drag the new controller script here
    [SerializeField] private GameObject change2rd;
    

    private void Start()
    {
        if (oldController != null)
            oldController.enabled = true;

        if (newController != null)
            newController.enabled = false;

        change2rd.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (oldController != null)
            {
                oldController.enabled = false;
            }

            if (newController != null)
            {
                newController.enabled = true;
            }

            Debug.Log("Player controller switched!");

            
            change2rd.SetActive(true);
        }
    }
}
