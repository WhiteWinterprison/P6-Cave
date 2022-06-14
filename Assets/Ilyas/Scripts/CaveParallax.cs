using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveParallax : MonoBehaviour
{
    [SerializeField]
    private Transform headRotation;
    [SerializeField]
    private float parallaxStrength;

    private void Update()
    {
        transform.localPosition = headRotation.forward * parallaxStrength;
    }
}
