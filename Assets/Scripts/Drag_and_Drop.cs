using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour {

    private int layerMask = (int)(1 << 8);
    private RaycastHit hitInfo;

    private Camera cam;
    private RaycastHit[] results = new RaycastHit[5];
    public LayerMask validLayers;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        print("why the fuck isnt this working?");
    }

    private void OnMouseDown() {
        
    }

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        bool button = Input.GetButton("Fire1");
        print(button);
        if (button) {
            int n = Physics.RaycastNonAlloc(ray, results, 512f, validLayers);
            for (int i = 0; i < n; i++) {
                transform.position = results[i].point;
                print(results[i].point);
            }
        }
    }
}
