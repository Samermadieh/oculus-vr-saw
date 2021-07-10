// Sliceable script
// Made By: Samer Madieh
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliceable : MonoBehaviour
{
    public GameObject saw;
    private GameObject wood;
    Vector3 woodPos;
    Vector3 woodScale;
    Material woodMat;

    private void Start()
    {
        // Set the wood object to the object that the script is attached to.
        wood = this.gameObject;
        woodPos = wood.transform.position;
        woodScale = wood.transform.localScale;
        woodMat = wood.GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the saw collides with the wood. If yes, create two pieces of wood, each half of the original piece.
        if(collision.gameObject == saw)
        {
            Destroy(wood);
            GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube1.transform.localScale = new Vector3(woodScale.x / 2, woodScale.y, woodScale.z);
            cube2.transform.localScale = new Vector3(woodScale.x / 2, woodScale.y, woodScale.z);
            cube1.transform.position = new Vector3(woodPos.x + (woodScale.x / 4), woodPos.y, woodPos.z);
            cube2.transform.position = new Vector3(woodPos.x - (woodScale.x / 4), woodPos.y, woodPos.z);
            woodMat.mainTextureScale = new Vector2(woodMat.mainTextureScale.x / 2, woodMat.mainTextureScale.y);
            cube1.GetComponent<Renderer>().material = woodMat;
            cube2.GetComponent<Renderer>().material = woodMat;
            cube1.AddComponent<Rigidbody>();
            cube2.AddComponent<Rigidbody>();
        }
    }

}
