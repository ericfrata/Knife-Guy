using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public bool bounds;

    public GameObject player;

    public Vector3 minCameraPos;
    public Vector3 maxnCameraPos;



    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxnCameraPos.x),
                                              Mathf.Clamp(transform.position.y, minCameraPos.y, maxnCameraPos.y),
                                              Mathf.Clamp(transform.position.z, minCameraPos.z, maxnCameraPos.z)
                                              );

        }

    }

    public void SetMinCamPos()
    {
        minCameraPos = gameObject.transform.position;
    }
    public void SetMaxCamPos()
    {
        maxnCameraPos = gameObject.transform.position;
    }

}
