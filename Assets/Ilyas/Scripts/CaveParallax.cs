using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveParallax : MonoBehaviour
{
    [SerializeField]
    private Transform headRotation;
    [SerializeField]
    private float parallaxStrength;

    private float rotationOffset;


    private void Start()
    {
        rotationOffset = headRotation.rotation.eulerAngles.y;
    }

    private void Update()
    {
        transform.localPosition = Quaternion.AngleAxis(-rotationOffset,Vector3.up) * headRotation.forward * parallaxStrength;
        Debug.Log(rotationOffset);
    }
}
