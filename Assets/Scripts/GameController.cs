using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int layerMask = (int)(1 << 8);
    private RaycastHit hitInfo;

    private Camera cam;
    private RaycastHit[] results = new RaycastHit[5];
    public LayerMask pieceLayer;
    public LayerMask boardLayer;

    public GameObject draggedObject;

    public bool editing = true;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (editing) {
            print("fuck");
            if (Input.GetButton("Fire1")) {
                print("mouse down");
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, 512f, pieceLayer)) {
                    if (!draggedObject) {
                        draggedObject = hitInfo.transform.gameObject;
                    }
                    
                }
                if (draggedObject) {
                    int n = Physics.RaycastNonAlloc(ray, results, 512f, boardLayer);

                    for (int i = 0; i < n; i++) {
                        draggedObject.transform.position = results[i].point;
                    }
                }
            } else if (!Input.GetButton("Fire1")) {
                draggedObject = null;
            }
        }
    }

    public void dragAndDrop(GameObject piece) {
        
    }

}
