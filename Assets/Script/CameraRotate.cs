using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerOrientation {
    FRONT = 0,
    LEFT = 1,
    BACK = 2,
    RIGHT = 3
}

public class CameraRotate : MonoBehaviour {

    // Use this for initialization
    private TowerOrientation orientation;
    public TowerOrientation Orientation {
        get {
            return orientation;
        }
    } 
    
	void Start () {
        orientation = 0;
	}

    public Transform player;
    private bool isRotating = false;
    public int speed = 10;
    private float angleRotated;
    private float previousAngleRotate;
    private int direction = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating) {
            direction = 1;
            isRotating = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isRotating)
        {
            direction = -1;
            isRotating = true;
        }
        if (isRotating) {
            angleRotated += direction * 90 * Time.deltaTime * speed;
            if (Math.Abs(angleRotated) < 90)
            {
                this.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), direction * 90 * Time.deltaTime * speed);
            }
            else
            {
                this.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), direction * 90 - previousAngleRotate);
            }
            if (Math.Abs(angleRotated) >= 90) {
                isRotating = false;
                orientation = (TowerOrientation)((int)(orientation + direction) % 4);
                direction = 0;
                angleRotated = 0;
            }
            previousAngleRotate = angleRotated;
        }
	}
}
