using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public enum Direction {
        FORWARD,
        BACKWARD, 
        LEFT,
        RIGHT
    }

    public GameObject whitePawn;
    public GameObject whiteRook;
    public GameObject whiteKnight;
    public GameObject whiteBishop;
    public GameObject whiteQueen;
    public GameObject whiteKing;

    public GameObject blackPawn;
    public GameObject blackRook;
    public GameObject blackKnight;
    public GameObject blackBishop;
    public GameObject blackQueen;
    public GameObject blackKing;

    // This object is for keeping track of which tile a piece is on.
    // Therefore being able to use the index to tell where a piece is on the board.


    
    // 8, 9, 10, 11, 12, 13, 14, 15
    // 0, 1, 2,  3,  4,  5,  6,  7
    private GameObject[] boardTiles = new GameObject[64];

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

        Debug.Log(Utility.test());

        initPieces();
    }

    // Casts 2 rays to intersect pieces and the board.
    void Update() {
        if (editing) {
            if (Input.GetButton("Fire1")) {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo, 512f, pieceLayer)) {
                    if (!draggedObject) {
                        draggedObject = hitInfo.transform.gameObject;
                    }
                }
                if (draggedObject) {
                    int n = Physics.RaycastNonAlloc(ray, results, 512f, boardLayer);
                    print(n);
                    for (int i = 0; i < n; i++) {
                        draggedObject.transform.position = results[i].point;
                    }
                }
            } else if (!Input.GetButton("Fire1")) {
                draggedObject = null;
            }
        }
    }

    // Vector3 moveToTile(Direction dir, int currentIndex) {
    //     switch (dir) {
    //         case Direction.FORWARD:
    //             return convertIndexToTile(currentIndex + 8);
    //         case Direction.RIGHT:
    //             return convertIndexToTile(currentIndex + 1);
    //         case Direction.BACKWARD:
    //             return convertIndexToTile(currentIndex - 8);
    //         case Direction.LEFT:
    //             return convertIndexToTile(currentIndex - 1);
    //     }
    // }

    // source: the index where the piece currently is before moving
    // destination: the index where the piece is going to move, if valid
    Vector3 moveToTile(int source, int destination) {
        // Check if index is a valid move
        return new Vector3(0f,0f,0f);
    }

    int convertTileToCoordinates(int index) {
        return 0;
    }

    Vector3 convertIndexToTile(int index) {
        float x = (index % 8 * 12.7f) + 5.5f;
        float z = (float)((System.Math.Floor(index/8.0) * 12.7f) + 5.5f);
        return new Vector3(x, 1f, z);
    }

    void initPieces() {
        boardTiles[0] = Instantiate(whiteRook, convertIndexToTile(0), whiteRook.transform.rotation);
        boardTiles[1] = Instantiate(whiteKnight, convertIndexToTile(1), whiteRook.transform.rotation);
        boardTiles[2] = Instantiate(whiteBishop, convertIndexToTile(2), whiteRook.transform.rotation);
        boardTiles[3] = Instantiate(whiteQueen, convertIndexToTile(3), whiteRook.transform.rotation);
        boardTiles[4] = Instantiate(whiteKing, convertIndexToTile(4), whiteRook.transform.rotation);
        boardTiles[5] = Instantiate(whiteBishop, convertIndexToTile(5), whiteRook.transform.rotation);
        boardTiles[6] = Instantiate(whiteKnight, convertIndexToTile(6), whiteRook.transform.rotation);
        boardTiles[7] = Instantiate(whiteRook, convertIndexToTile(7), whiteRook.transform.rotation);
        boardTiles[8] =  Instantiate(whitePawn, convertIndexToTile(8), whiteRook.transform.rotation);
        boardTiles[9] =  Instantiate(whitePawn, convertIndexToTile(9), whiteRook.transform.rotation);
        boardTiles[10] = Instantiate(whitePawn, convertIndexToTile(10), whiteRook.transform.rotation);
        boardTiles[11] = Instantiate(whitePawn, convertIndexToTile(11), whiteRook.transform.rotation);
        boardTiles[12] = Instantiate(whitePawn, convertIndexToTile(12), whiteRook.transform.rotation);
        boardTiles[13] = Instantiate(whitePawn, convertIndexToTile(13), whiteRook.transform.rotation);
        boardTiles[14] = Instantiate(whitePawn, convertIndexToTile(14), whiteRook.transform.rotation);
        boardTiles[15] = Instantiate(whitePawn, convertIndexToTile(15), whiteRook.transform.rotation);
        
        boardTiles[63] = Instantiate(blackRook, convertIndexToTile(63),   blackKnight.transform.rotation);
        boardTiles[62] = Instantiate(blackKnight, convertIndexToTile(62), blackKnight.transform.rotation);
        boardTiles[61] = Instantiate(blackBishop, convertIndexToTile(61), blackKnight.transform.rotation);
        boardTiles[60] = Instantiate(blackKing, convertIndexToTile(60),  blackKnight.transform.rotation);
        boardTiles[59] = Instantiate(blackQueen, convertIndexToTile(59),   blackKnight.transform.rotation);
        boardTiles[58] = Instantiate(blackBishop, convertIndexToTile(58), blackKnight.transform.rotation);
        boardTiles[57] = Instantiate(blackKnight, convertIndexToTile(57), blackKnight.transform.rotation);
        boardTiles[56] = Instantiate(blackRook, convertIndexToTile(56),   blackKnight.transform.rotation);
        boardTiles[55] = Instantiate(blackPawn, convertIndexToTile(55),   blackKnight.transform.rotation);
        boardTiles[54] = Instantiate(blackPawn, convertIndexToTile(54),   blackKnight.transform.rotation);
        boardTiles[53] = Instantiate(blackPawn, convertIndexToTile(53),   blackKnight.transform.rotation);
        boardTiles[52] = Instantiate(blackPawn, convertIndexToTile(52),   blackKnight.transform.rotation);
        boardTiles[51] = Instantiate(blackPawn, convertIndexToTile(51),   blackKnight.transform.rotation);
        boardTiles[50] = Instantiate(blackPawn, convertIndexToTile(50),   blackKnight.transform.rotation);
        boardTiles[49] = Instantiate(blackPawn, convertIndexToTile(49),   blackKnight.transform.rotation);
        boardTiles[48] = Instantiate(blackPawn, convertIndexToTile(48),   blackKnight.transform.rotation);
    }

}
