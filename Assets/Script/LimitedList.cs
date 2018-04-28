using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedList<T> {
    private List<T> l;
    int size;
    public LimitedList(int s) {
        this.size = s;
        L = new List<T>(s);
    }

    public List<T> L {
        get {
            return l;
        }

        set {
            l = value;
        }
    }

    public void Add(T o) {

        for (int i = size - 1 ; i > 0; i--) {
            L[i] = L[i-1];
        }
        L[0] = o;
        Debug.Log("LAST POSITION : " + L[L.Capacity - 1]);
    }
}
