using UnityEngine;
using System.Collections;

public class Remover : MonoBehaviour {

    private Renderer spriteRenderer;
    private bool onScreen;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(spriteRenderer.isVisible)
        {
            onScreen = true;
        }

        if (onScreen && !spriteRenderer.isVisible)
        {
            Destroy(this.gameObject);
        }
	
	}
}
