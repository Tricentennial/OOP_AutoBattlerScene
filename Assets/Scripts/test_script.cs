using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_script : MonoBehaviour {

    private void OnMouseDown() {
        Debug.Log("The thing was clicked");
    }

    private void OnMouseDrag() {
        //this.transform.position = new Vector3(Input.mousePosition.x, 13.13101f, Input.mousePosition.z);
    }

    // Start is called before the first frame update
    void Start() {

    }

    private void Awake() {
        Debug.Log(this.transform.position);
    }

    // Update is called once per frame
    void Update() {

    }
}
