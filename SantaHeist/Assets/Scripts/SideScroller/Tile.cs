using UnityEngine;
using System.Collections;

    [RequireComponent(typeof(SpriteRenderer))]

    public class Tile : MonoBehaviour
    {

    [SerializeField]
    private int offsetX = 2;                 
           
    public bool rightTile = false;
    public bool leftTile = false;

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

        void Awake()
        {
            cam = Camera.main;
            myTransform = transform;
        }

        // Use this for initialization
        void Start()
        {
            SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
            spriteWidth = sRenderer.sprite.bounds.size.x;

        }

        // Update is called once per frame
        void Update()
        {
           
            if (leftTile == false || rightTile == false)
            {
               
                float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

                
                float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
                float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;


                if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && rightTile == false)
                {
                    newTile(1);
                    rightTile = true;
                }
                else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && leftTile == false)
                {
                    newTile(-1);
                    leftTile = true;
                }
            }
        }

        
        void newTile(int rightOrLeft)
        {
            
            Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
            
            Transform newObject = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;
            newObject.name = "Tile";
          
            newObject.parent = myTransform.parent;
            if (rightOrLeft > 0)
            {
                newObject.GetComponent<Tile>().leftTile = true;
            }
            else
            {
                newObject.GetComponent<Tile>().rightTile = true;
            }
        }

}