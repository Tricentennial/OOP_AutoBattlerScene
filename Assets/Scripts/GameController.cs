using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unless otherwise specfied, this code was authored by Hunter Bowers.

public class GameController : MonoBehaviour {

    // Begin piece prefab variables
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
    // End piece prefab variables 

    // A way of keeping track of piece positions using a array where each
    // index is a place on the board with functions to perform the proper
    // movements so you don't have to mess with the indices too much
    private GameObject[] boardTiles = new GameObject[64];

    // Information from a raycast collision
    private RaycastHit hitInfo;

    // The main game camera
    private Camera cam;

    // A list of results returned from a raycast collision
    private RaycastHit[] results = new RaycastHit[5];
    public LayerMask pieceLayer;
    public LayerMask boardLayer;

    // Temporary layers for Anna's code
    public LayerMask tileHover;
    public LayerMask tileNoHover;


    // Called draggedObject to represent the current object you are dragging
    // around with your mouse.
    public GameObject draggedObject;

    // I called this editing with the intention of there being a section where
    // You are able to edit the position of your pieces and this would be the
    // flag that would allow you to move your pieces or not.
    public bool editing = true;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;

        Debug.Log(Utility.test());
        
        // This function call is for Anna's code
        GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);

        // This function call is my code
        initPieces();
    }

    // Casts 2 rays to intersect pieces and the board.
    void Update() {
        if (editing) {
            // Checks to see if you are holding down the left mouse button
            if (Input.GetButton("Fire1")) {

                // This casts a ray from the camera to where the mouse is on the screen
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                // This checks to see if the ray collides with any object in the specified layer
                // in this case the piece layer.
                if (Physics.Raycast(ray, out hitInfo, 512f, pieceLayer)) {
                    // Checks if 'draggedObject' to null
                    if (!draggedObject) {
                        // This sets 'draggedObject' to the first object that the ray collides with
                        // on the pieceLayer
                        draggedObject = hitInfo.transform.gameObject;
                    }
                }
                
                // If we have an object we are dragging around, then move to where the mouse is
                if (draggedObject) {
                    int n = Physics.RaycastNonAlloc(ray, results, 512f, boardLayer);

                    for (int i = 0; i < n; i++) {
                        draggedObject.transform.position = results[i].point;
                    }
                }
            } else if (!Input.GetButton("Fire1")) {
                // Stops dragging objects around.
                draggedObject = null;
            }
        }

        // This is Anna's code, I don't know what it does exactly
        if (!currentCamera) {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray1 = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray1, out info, 100, boardLayer)) {
            //get the indexes of the tile
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            // if you are hovering a tileafter not hovering a tile
            if (currentHover == -Vector2Int.one) {
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = tileHover;
            }
            // if we were hovering a tile, and moved to a new one

            if (currentHover != -Vector2Int.one) {
                tiles[currentHover.x, currentHover.y].layer = boardLayer;
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = tileHover;
            }
        } else {
            if (currentHover != -Vector2Int.one) {
                tiles[currentHover.x, currentHover.y].layer = boardLayer;
                //currentHover = -Vector2Int.one;
            }
        }
        // This is the end of Anna's code
    }

    // This ugly function is just a messy way of instantiating all
    // of our piece prefabs on our board.
    void initPieces() {
        boardTiles[0] = Instantiate(whiteRook, Utility.convertIndexToTile(0), whiteRook.transform.rotation);
        boardTiles[1] = Instantiate(whiteKnight, Utility.convertIndexToTile(1), whiteRook.transform.rotation);
        boardTiles[2] = Instantiate(whiteBishop, Utility.convertIndexToTile(2), whiteRook.transform.rotation);
        boardTiles[3] = Instantiate(whiteQueen, Utility.convertIndexToTile(3), whiteRook.transform.rotation);
        boardTiles[4] = Instantiate(whiteKing, Utility.convertIndexToTile(4), whiteRook.transform.rotation);
        boardTiles[5] = Instantiate(whiteBishop, Utility.convertIndexToTile(5), whiteRook.transform.rotation);
        boardTiles[6] = Instantiate(whiteKnight, Utility.convertIndexToTile(6), whiteRook.transform.rotation);
        boardTiles[7] = Instantiate(whiteRook, Utility.convertIndexToTile(7), whiteRook.transform.rotation);
        boardTiles[8] = Instantiate(whitePawn, Utility.convertIndexToTile(8), whiteRook.transform.rotation);
        boardTiles[9] = Instantiate(whitePawn, Utility.convertIndexToTile(9), whiteRook.transform.rotation);
        boardTiles[10] = Instantiate(whitePawn, Utility.convertIndexToTile(10), whiteRook.transform.rotation);
        boardTiles[11] = Instantiate(whitePawn, Utility.convertIndexToTile(11), whiteRook.transform.rotation);
        boardTiles[12] = Instantiate(whitePawn, Utility.convertIndexToTile(12), whiteRook.transform.rotation);
        boardTiles[13] = Instantiate(whitePawn, Utility.convertIndexToTile(13), whiteRook.transform.rotation);
        boardTiles[14] = Instantiate(whitePawn, Utility.convertIndexToTile(14), whiteRook.transform.rotation);
        boardTiles[15] = Instantiate(whitePawn, Utility.convertIndexToTile(15), whiteRook.transform.rotation);

        boardTiles[63] = Instantiate(blackRook, Utility.convertIndexToTile(63), blackKnight.transform.rotation);
        boardTiles[62] = Instantiate(blackKnight, Utility.convertIndexToTile(62), blackKnight.transform.rotation);
        boardTiles[61] = Instantiate(blackBishop, Utility.convertIndexToTile(61), blackKnight.transform.rotation);
        boardTiles[60] = Instantiate(blackKing, Utility.convertIndexToTile(60), blackKnight.transform.rotation);
        boardTiles[59] = Instantiate(blackQueen, Utility.convertIndexToTile(59), blackKnight.transform.rotation);
        boardTiles[58] = Instantiate(blackBishop, Utility.convertIndexToTile(58), blackKnight.transform.rotation);
        boardTiles[57] = Instantiate(blackKnight, Utility.convertIndexToTile(57), blackKnight.transform.rotation);
        boardTiles[56] = Instantiate(blackRook, Utility.convertIndexToTile(56), blackKnight.transform.rotation);
        boardTiles[55] = Instantiate(blackPawn, Utility.convertIndexToTile(55), blackKnight.transform.rotation);
        boardTiles[54] = Instantiate(blackPawn, Utility.convertIndexToTile(54), blackKnight.transform.rotation);
        boardTiles[53] = Instantiate(blackPawn, Utility.convertIndexToTile(53), blackKnight.transform.rotation);
        boardTiles[52] = Instantiate(blackPawn, Utility.convertIndexToTile(52), blackKnight.transform.rotation);
        boardTiles[51] = Instantiate(blackPawn, Utility.convertIndexToTile(51), blackKnight.transform.rotation);
        boardTiles[50] = Instantiate(blackPawn, Utility.convertIndexToTile(50), blackKnight.transform.rotation);
        boardTiles[49] = Instantiate(blackPawn, Utility.convertIndexToTile(49), blackKnight.transform.rotation);
        boardTiles[48] = Instantiate(blackPawn, Utility.convertIndexToTile(48), blackKnight.transform.rotation);
    }


    // This is more of Anna's code

    [Header("Art")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float tileSize = 1.0f;
    [SerializeField] private float yOffset = 0.2f;
    [SerializeField] private Vector3 boardCenter = Vector3.zero;

    private const int TILE_COUNT_X = 8;
    private const int TILE_COUNT_Y = 8;
    private GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;
    private Vector3 bounds;

    // Generate the board
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY) {
        yOffset += transform.position.y;
        bounds = new Vector3((tileCountX / 2) * tileSize, 0, (tileCountX / 2) * tileSize) + boardCenter;

        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSingleTile(tileSize, x, y);
    }
    private GameObject GenerateSingleTile(float tileSize, int x, int y) {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;


        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, 0, y * tileSize) - bounds;
        vertices[1] = new Vector3(x * tileSize, 0, (y + 1) * tileSize) - bounds;
        vertices[2] = new Vector3((x + 1) * tileSize, 0, y * tileSize) - bounds;
        vertices[3] = new Vector3((x + 1) * tileSize, 0, (y + 1) * tileSize) - bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.RecalculateNormals();


        tileObject.AddComponent<BoxCollider>();
        tileObject.layer = boardLayer;

        return tileObject;
    }

    //Operations
    private Vector2Int LookupTileIndex(GameObject hitInfo) {
        for (int x = 0; x < TILE_COUNT_X; x++) {
            for (int y = 0; y < TILE_COUNT_Y; y++) {
                if (tiles[x, y] == hitInfo) {
                    return new Vector2Int(x, y);
                }
            }
        }
        return -Vector2Int.one; //invalid
    }
    
    // End of more of Anna's code
}

