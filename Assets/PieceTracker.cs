using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side {
    white = 1,
    black = 2
}

public class PieceTracker : MonoBehaviour
{
    
    Side[,,] pieces = new Side[4,4,4];
    int[,] heightAtLoc = new int[4,4] { {0,0,0,0}, {0,0,0,0}, {0,0,0,0}, {0,0,0,0} };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int AddPiece(int x, int z, Side s)
    {
        int pegHeight = heightAtLoc[x,z];
        pieces[x,pegHeight,z] = s;

        heightAtLoc[x,z] += 1;
        return heightAtLoc[x,z] - 1;
    }

    private string PrintPieces(Side[,,] p) {
        string writtenBoard = "";
        for (int y = 0; y < 4; y++) {
            for (int x = 0; x < 4; x++) {
                for (int z = 0; z < 4; z++) {
                    writtenBoard += pieces[x,y,z] + "    ";
                }
                writtenBoard += "\r\n";
            }
            writtenBoard += "\r\n";
        }

        return writtenBoard;
    }
}
