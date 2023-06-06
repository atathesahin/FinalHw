using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public static CameraScript Instance // singlton     
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<CameraScript> ( );
                if ( instance == null )
                {
                    var instanceContainer = new GameObject ( "CameraMovement" );
                    instance = instanceContainer.AddComponent<CameraScript> ( );
                }
            }
            return instance;
        }
    }

    private static CameraScript instance;


    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }


    public float offsetY = 45f;
    public float offsetZ = -40f;

    Vector3 cameraPosition;

    // Update is called once per frame
    void LateUpdate()
    {
            //cameraPosition.x = _player.transform.position.x;
      
            cameraPosition.y = _player.transform.position.y + offsetY;
            cameraPosition.z = _player.transform.position.z + offsetZ;

            transform.position = cameraPosition;



        
    }

    public void CarmeraNextRoom ( )
    {
        //Fade in/out
        
        cameraPosition.x = _player.transform.position.x;
    }

   
}
