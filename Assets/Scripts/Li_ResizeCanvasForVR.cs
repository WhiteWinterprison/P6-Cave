//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
//Lisa Fröhlich Gabra, Expanded Realities, Semester 6th//
//Group 1: HEL                                         //
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//


//Script: Providing a function to change the canvas if the player setup is for VR


//What it do:
// - provides a function that changes the render mode, sets the event camera and repositions/resizes the canvas


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Li_ResizeCanvasForVR : MonoBehaviour
{
    #region Variables

    [Header("Scale and Position of new Canvas")]
    [SerializeField]
    private float scale = 0.0015f;
    [SerializeField]
    private float xPos = 0.0f;
    [SerializeField]
    private float yPos = 1.1f;
    [SerializeField]
    private float zPos = 4.5f;

    #endregion

    public void ResizeCanvas(Canvas canvas, GameObject player)
    {
        //set the canvas to world space
        canvas.renderMode = RenderMode.WorldSpace;

        //set the event camera
        canvas.worldCamera = player.GetComponentInChildren<Camera>();

        //--------------------------------//
        //resize and reposition the canvas//
        //--------------------------------//

        canvas.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
        canvas.GetComponent<RectTransform>().position = new Vector3(xPos, yPos, zPos);
    }
}
