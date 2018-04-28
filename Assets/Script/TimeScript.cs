using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour {
    public Transform player_prefab;
    public Transform spawnPoint;
    private Transform currentPepito;
    private LimitedList<Vector3> pos_ary;

    int list_capacity = 100;
    
    void Start() {
        pos_ary = new LimitedList<Vector3>(list_capacity);
        for (int i = 0; i < pos_ary.L.Capacity; i++) {
            pos_ary.L.Add(new Vector3(0.0f, 0.0f, 0.0f));
        }
        if (spawnPoint != null) {
            currentPepito = Instantiate<Transform>(player_prefab, spawnPoint.position, Quaternion.identity);
        }
        else {
            currentPepito = Instantiate<Transform>(player_prefab, this.transform.position, Quaternion.identity);
        }
       currentPepito.GetComponent<Movement_Temp>().Active = true;
    }
	void FixedUpdate () {
        pos_ary.Add(currentPepito.position);
        if (Input.GetKeyDown(KeyCode.Q)) {
            //todo reset le tableau
            currentPepito.GetComponent<Movement_Temp>().Active = false;
            currentPepito = Instantiate<Transform>(player_prefab, pos_ary.L[list_capacity-1], Quaternion.identity);
            currentPepito.GetComponent<Movement_Temp>().Active = true;
        }
	}
}
