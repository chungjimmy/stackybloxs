using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour {

    public static int combo = 0;

    public static Combo _combo;

    void Awake() {
        _combo = this;
    }

    public static void resetCombo() {
        combo = 0;
    }
}
