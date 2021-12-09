using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Utility : MonoBehaviour {

    public enum Direction {
        FORWARD,
        BACKWARD, 
        LEFT,
        RIGHT,
        FORWARD_LEFT,
        FORWARD_RIGHT,
        BACKWARD_LEFT,
        BACKWARD_RIGHT
    }

    public static string test() {
        return "This is a test string!";
    }


    // visual representation of board indices
    // 8, 9, 10, 11, 12, 13, 14, 15
    // 0, 1, 2,  3,  4,  5,  6,  7

    // visual representation of directional movement
    //  7  8  9
    // -1  0  1
    // -9 -8 -7

    // Its not a bug, Its a feature called a wrap around board...
    public static Vector3 moveToTile(Direction dir, int currentIndex) {
        switch (dir) {
            case Direction.FORWARD:
                return convertIndexToTile(currentIndex + 8);
            case Direction.RIGHT:
                return convertIndexToTile(currentIndex + 1);
            case Direction.BACKWARD:
                return convertIndexToTile(currentIndex - 8);
            case Direction.LEFT:
                return convertIndexToTile(currentIndex - 1);
            case Direction.FORWARD_LEFT:
                return convertIndexToTile(currentIndex + 7);
            case Direction.FORWARD_RIGHT:
                return convertIndexToTile(currentIndex + 9);
            case Direction.BACKWARD_LEFT:
                return convertIndexToTile(currentIndex - 9);
            case Direction.BACKWARD_RIGHT:
                return convertIndexToTile(currentIndex - 1);
            default:
                return convertIndexToTile(currentIndex);
        }
    }

    // source: the index where the piece currently is before moving
    // destination: the index where the piece is going to move, if valid
    public static Vector3 moveToTile(int source, int destination) {
        // Check if index is a valid move
        return new Vector3(0,0,0);
    }

    public static int convertTileToCoordinates(int index) {
        return 0;
    }

    public static Vector3 convertIndexToTile(int index) {
        float x = (index % 8 * 12.7f) + 5.5f;
        float z = (float)((System.Math.Floor(index/8.0) * 12.7f) + 5.5f);
        return new Vector3(x, 1f, z);
    }

}