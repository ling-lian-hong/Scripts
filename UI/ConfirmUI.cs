using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmUI : MonoBehaviour {
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void ClickConfirm() {
        if (ani == null)
            return;
        ani.SetBool("Click", true);
    }

    public void IsStayOn(bool _IsStay) {
        if (ani == null)
            return;
        ani.SetBool("Stay", _IsStay);
    }
}
