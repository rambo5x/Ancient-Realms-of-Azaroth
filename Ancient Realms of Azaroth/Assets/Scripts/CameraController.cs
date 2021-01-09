using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Tilemap theMap;
    private Vector3 bottomLeftLimit; //left bottom corner of map
    private Vector3 topRightLimit; //right top corner of map

    private float halfHeight;
    private float halfWidth;

    public int musicToPlay;
    private bool musicStarted;

	// Use this for initialization
	void Start () {
        // target = PlayerController.instance.transform; //whichever scene the player is in
        target = FindObjectOfType<PlayerController>().transform;//find player in scene

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect; //divide by 9 units height to display 16 units wide for camera view

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f); //bottom left up is positive
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f); //top right down is negative

        PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
	}
	
	// Update is called once per frame
	void LateUpdate () { //called after update to fix camera lag
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);//zoom camera around player

        //keep the camera inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

        if (!musicStarted)
        {
            musicStarted = true;
            AudioManager.instance.PlayBGM(musicToPlay);
        }

    }
}
