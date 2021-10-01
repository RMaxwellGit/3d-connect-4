using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlacementControls : MonoBehaviour
{
    public float previewHoverHeight;
    public float[] pieceHeights = new float[4];

    public PieceTracker pT;
    public GameObject previewPiece;
    public GameObject whitePiece, blackPiece;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //pretty sure the ray hits multiple colliders causing flickering, also a Null Ref. Exception??? idk check this later future rhys ty love u bye i gotta smooch sarah now

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Casts the ray and get the first game object hit
        Physics.Raycast(ray, out hit);

        

        if (hit.collider) {
            GameObject hitObj = hit.collider.gameObject;

            if (hitObj.tag == "Peg") {
                if (Input.GetMouseButtonDown(0)) {
                    //figure out what colour this should be
                    Side curSide = TurnTracker.CurTurn;
                    //find the coordinates
                    int x = GetCoordFromPosition(hitObj.transform.position.x);
                    int z = GetCoordFromPosition(hitObj.transform.position.z);
                    //add the piece to the piece tracker
                    int stackLevel = pT.AddPiece(x,z,curSide);
                    //check that the height isn't out of bound
                    if (stackLevel < 4) {
                        //instantiate a piece of the right colour, using the height from AddPiece
                        Vector3 newPiecePos = new Vector3(hitObj.transform.position.x, pieceHeights[stackLevel], hitObj.transform.position.z);

                        if (curSide == Side.white) {
                            GameObject.Instantiate(whitePiece, newPiecePos, Quaternion.identity);
                        } else {
                            GameObject.Instantiate(blackPiece, newPiecePos, Quaternion.identity);
                        }

                        TurnTracker.UpdateTurn();
                    }
                } else {
                    Vector3 hitPegPosition = hit.collider.gameObject.transform.position;
                    previewPiece.transform.position = new Vector3(hitPegPosition.x, previewHoverHeight, hitPegPosition.z);
                }
            } else {
                previewPiece.transform.position = Vector3.zero;
            }
        }
    }

    int GetCoordFromPosition(float p)
    {
        return (int)(p / 2.30f + 1.50f);
    }
}
