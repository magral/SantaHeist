using UnityEngine;
using System.Collections;

public class CharFollow : MonoBehaviour {

    private GameObject Sleigh;

	// Use this for initialization
	void Awake () {

        Sleigh = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update ()
    {
	
        if (Sleigh == null)
        {
            Sleigh = GameObject.FindGameObjectWithTag("Player");
        }

        this.transform.position = new Vector3(Sleigh.transform.position.x, transform.position.y, transform.position.z);

	}
}
