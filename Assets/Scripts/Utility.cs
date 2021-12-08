using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Utility : MonoBehaviour {

    public enum Direction {
        FORWARD,
        BACKWARD, 
        LEFT,
        RIGHT
    }

    string test() {
        return "This is a test string!";
    }

    Vector3 moveToTile(Direction dir, int currentIndex) {
        switch (dir) {
            case Direction.FORWARD:
                return convertIndexToTile(currentIndex + 8);
            case Direction.RIGHT:
                return convertIndexToTile(currentIndex + 1);
            case Direction.BACKWARD:
                return convertIndexToTile(currentIndex - 8);
            case Direction.LEFT:
                return convertIndexToTile(currentIndex - 1);
        }
    }

    // source: the index where the piece currently is before moving
    // destination: the index where the piece is going to move, if valid
    Vector3 moveToTile(int source, int destination) {
        // Check if index is a valid move

    }

    int convertTileToCoordinates(int index) {

    }

    Vector3 convertIndexToTile(int index) {
        float x = (index % 8 * 12.7f) + 5.5f;
        float z = (float)((System.Math.Floor(index/8.0) * 12.7f) + 5.5f);
        return new Vector3(x, 1f, z);
    }

}