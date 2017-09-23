using UnityEngine;
using System.Collections;

public class EggCollider : MonoBehaviour {

    PlayerScript myPlayerScript;

    //Automatically run when a scene starts
    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<PlayerScript>();
    }

    //Triggered by Unity's Physics
	void OnTriggerEnter(Collider theCollision)
    {
        //Check what object is being hit
        
		GameObject collisionGO = theCollision.gameObject;

		switch(collisionGO.tag)
		{
			case "basicEgg":
				myPlayerScript.theScore++;
				break; 
			case "goldEgg":
				myPlayerScript.theScore += 5; 
				break;
			case "rock":
				myPlayerScript.theScore -= 5;
				break;
			default:
				break;
		}

		Destroy(collisionGO);

    }
}
