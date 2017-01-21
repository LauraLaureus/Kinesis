using UnityEngine;
using System.Collections;

public class Locker : MonoBehaviour {

    public bool isLocked = false;

    private void OnEnable()
    {
        CatchController.lockThem += lockMyself;
        CatchController.releaseThem += releaseMyself;
    }

    private void OnDisable()
    {
        CatchController.lockThem -= lockMyself;
        CatchController.releaseThem -= releaseMyself;
    }

    void lockMyself(GameObject sender) {
        if(sender != this.gameObject)
            isLocked = true;
    }

    void releaseMyself() {
        isLocked = false;
    }
}
