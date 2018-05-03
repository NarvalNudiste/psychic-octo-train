using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private bool active = true;
    public bool Active {
        get {
            return active;
        }

        set {
            active = value;
        }
    }
    //Anim booleans
    private bool moving;
    public bool Moving {
        get {
            return moving;
        }
    }
    //vars
    public float speed;
    public float jumpForce;
    private bool isJump;


    void Start () {
        this.speed = 5.0f;
	}
    void Movement() {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
            moving = false;
        }
        Rigidbody rigb = this.GetComponent<Rigidbody>();
        CameraRotate camRot = FindObjectOfType<CameraRotate>();
        if (Input.GetKey(KeyCode.A) && Active || Input.GetAxis("Horizontal") < -0.1f && Active) {
            this.moving = true;
            if (camRot.Orientation == TowerOrientation.FRONT) rigb.MovePosition(transform.position + new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.LEFT) rigb.MovePosition(transform.position + new Vector3(0, 0, speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.RIGHT) rigb.MovePosition(transform.position + new Vector3(0, 0, -speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.BACK) rigb.MovePosition(transform.position + new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0.1f && Active) {
            this.moving = true;
            if (camRot.Orientation == TowerOrientation.FRONT) rigb.MovePosition(transform.position + new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.LEFT) rigb.MovePosition(transform.position + new Vector3(0, 0, -speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.RIGHT) rigb.MovePosition(transform.position + new Vector3(0, 0, speed) * Time.deltaTime);
            else if (camRot.Orientation == TowerOrientation.BACK) rigb.MovePosition(transform.position + new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) {
            if (!isJump) {
                isJump = true;
                rigb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
        if (rigb.velocity == Vector3.zero) {
            isJump = false;
        }
    }
	// Update is called once per frame
	void Update () {
        if (Active) {
            Movement();
        }
    }
}
