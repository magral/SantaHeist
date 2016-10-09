using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sleigh_Controller : MonoBehaviour
{
    //Accessing rigidbody
    private Rigidbody2D rb;


    //Physics Variables
    [SerializeField]
    private float accelerationForce;
    [SerializeField]
    private float thrustersForce;
    [SerializeField]
    private float deccelerationForce;
    
    private float maxSpeed = 10;

    private Rect cameraRect;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = rb.velocity.x;

        CameraPostion();
        CharactClamp();

        //Movement controller
        bool fly = Input.GetButton("Fly");
        bool accelerating = Input.GetButton("Accelerate");
        bool deccelerating = Input.GetButton("Deccelerate");

        if (fly)
        {
            rb.AddForce(transform.up * thrustersForce);
            print ("Moving up");
        }

        if (accelerating && currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.right * accelerationForce);
            print("Moving right");
        }

        if (deccelerating && currentSpeed > 0.1)
        {
            rb.AddForce(transform.right * -deccelerationForce);
                print("Moving left");
        }

        if (transform.position.y < cameraRect.yMin)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }

    void CameraPostion()
    {
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
    }

    void CharactClamp()
    {
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y, cameraRect.yMin * 2, cameraRect.yMax));
    }

    
}
