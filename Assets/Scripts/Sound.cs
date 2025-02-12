using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource bg;

    private void Start()
    {
        bg.Play();
    }
}
