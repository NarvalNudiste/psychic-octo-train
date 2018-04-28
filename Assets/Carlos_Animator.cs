using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carlos_Animator : MonoBehaviour {
    private Animator animator;
    private Player playerScr;
	void Start () {
        playerScr = this.GetComponentInParent<Player>();
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
         animator.SetBool("ismoving", playerScr.Moving);
	}
}
