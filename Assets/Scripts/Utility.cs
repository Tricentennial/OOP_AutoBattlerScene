using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is authored by Hunter Bowers.
class Utility : MonoBehaviour {

    // This contains an easy way to reference direction for the
    // movement function
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

    // This is a function to test using a separate class for
    // utility functions
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
    // This function is meant to be able to move a piece in a given
    // direction without having to do too many things by hand
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


    // UNUSED FUNCTION
    // source: the index where the piece currently is before moving
    // destination: the index where the piece is going to move, if valid
    public static Vector3 moveToTile(int source, int destination) {
        // Check if index is a valid move
        return new Vector3(0,0,0);
    }
    
    // UNUSED FUNCTION
    public static int convertTileToCoordinates(int index) {
        return 0;
    }

    // This function is used to be able to convert a given index into coordinate values
    // for pieces in the game.
    public static Vector3 convertIndexToTile(int index) {
        // This just takes the index, mods the value by 8 and applies some offsets
        // that I spent a while tweaking
        float x = (index % 8 * 12.7f) + 5.5f;

        // This variable was not so easy to figure out.
        // Taking the modulus and applying some offsets would not work the same here
        // it would essentially make the pieces move in a diagonal line
        // What it does is convert the index to the horizontal row on the board
        // using the property that the index divided by 8 gives the approximate row
        // then flooring the value and applying the offsets gives us our Z position
        float z = (float)((System.Math.Floor(index/8.0) * 12.7f) + 5.5f);
        
        // And of course return the new vector
        return new Vector3(x, 1f, z);
    }

}