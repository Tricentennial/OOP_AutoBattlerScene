using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

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
    // Therefore being able to use the index to tell where a piece is on the boardLayer.


    
    // 8, 9, 10, 11, 12, 13, 14, 15
    // 0, 1, 2,  3,  4,  5,  6,  7
    private GameObject[] boardTiles = new GameObject[64];

    private RaycastHit hitInfo;

    private Camera cam;
    private RaycastHit[] results = new RaycastHit[5];
    public LayerMask pieceLayer;
    public LayerMask boardLayer;

    public LayerMask tileHover;
    public LayerMask tileNoHover;

    public GameObject draggedObject;

    public bool editing = true;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;

        Debug.Log(Utility.test());
        GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);
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
                    
                    for (int i = 0; i < n; i++) {
                        draggedObject.transform.position = results[i].point;
                    }
                }
            } else if (!Input.GetButton("Fire1")) {
                draggedObject = null;
            }
        }
         if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray1 = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray1, out info, 100, boardLayer))
        {
            //get the indexes of the tile
            Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

            // if you are hovering a tileafter not hovering a tile
            if (currentHover == -Vector2Int.one)
            {
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = tileHover;
            }
            // if we were hovering a tile, and moved to a new one

            if (currentHover != -Vector2Int.one)
            {
                tiles[currentHover.x, currentHover.y].layer = boardLayer;
                currentHover = hitPosition;
                tiles[hitPosition.x, hitPosition.y].layer = tileHover;
            }
        }
        else
        {
            if (currentHover != -Vector2Int.one)
            {
                tiles[currentHover.x, currentHover.y].layer = boardLayer;
                //currentHover = -Vector2Int.one;
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


    // ANNAS CODE

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
    // private void Awake()
    // {
    //     GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);
    // }
    // private void Update()
    // {
    //     if (!currentCamera)
    //     {
    //         currentCamera = Camera.main;
    //         return;
    //     }

    //     RaycastHit info;
    //     Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
    //     if (Physics.Raycast(ray, out info, 100, board))
    //     {
    //         //get the indexes of the tile
    //         Vector2Int hitPosition = LookupTileIndex(info.transform.GameObject);

    //         // if you are hovering a tileafter not hovering a tile
    //         if (currentHover == -Vector2Int.one)
    //         {
    //             currentHover = hitPosition;
    //             tiles[hitPosition.x, hitPosition.y].layer = tileHover;
    //         }
    //         // if we were hovering a tile, and moved to a new one

    //         if (currentHover != -Vector2Int.one)
    //         {
    //             tiles[currentHover.x, currentHover.y].layer = board;
    //             currentHover = hitPosition;
    //             tiles[hitPosition.x, hitPosition.y].layer = tileHover;
    //         }
    //     }
    //     else
    //     {
    //         if (currentHover != -Vector2Int.one)
    //         {
    //             tiles[currentHover.x, currentHover.y].layer = board;
    //             currentHover = -Vector2Int.one;
    //         }
    //     }
    // }

    // Generate the board
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
    {
        yOffset += transform.position.y;
        bounds = new Vector3((tileCountX / 2) * tileSize, 0, (tileCountX / 2) * tileSize) + boardCenter;

        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSingleTile(tileSize, x, y);
    }
    private GameObject GenerateSingleTile(float tileSize, int x, int y)
    {
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
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        for (int x = 0; x < TILE_COUNT_X; x++) {
            for (int y = 0; y < TILE_COUNT_Y; y++) {
                if (tiles[x, y] == hitInfo) {
                    return new Vector2Int(x, y);
                }
            }
        }
        return -Vector2Int.one; //invalid
    }

}
