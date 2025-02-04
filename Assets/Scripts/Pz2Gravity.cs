using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pz2Gravity : MonoBehaviour
{
    public Animator Pz1;
    public Animator Pz21;
    public Animator Pz22;
    public Animator Pz3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pz2"))
        {
            Debug.Log("Trigger collision with Pz2");

            if (Pz1 != null)
            {
                Pz1.SetBool("Hit", true);
                Pz21.SetBool("hit", true);
                Pz22.SetBool("hit", true);
                Pz3.SetBool("hit", true);

                Debug.Log("Animations triggered");
            }

            Destroy(gameObject);
        }
    }
}
