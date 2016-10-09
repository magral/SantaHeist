using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<Sleigh_Controller>() != null)
        {
            Debug.Log("JINGLE BELLS! YOU MADE IT TO YOUR DESTINATION");
            SceneManager.LoadScene("OverworldMap");
        }
    }
}
