using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    [SerializeField] Texture2D moveCursor = null;
    [SerializeField] Texture2D fightCursor = null;
    [SerializeField] Texture2D nopeCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(64, 64);

    Texture2D pickedCursor = null;
    CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () {
        cameraRaycaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (cameraRaycaster.layerHit)
        {
            case Layer.Walkable:
                pickedCursor = moveCursor;
                break;
            case Layer.RaycastEndStop:
                pickedCursor = nopeCursor;
                break;
            case Layer.Enemy:
                pickedCursor = fightCursor;
                break;
            default:
                Debug.LogError("I dun goofed... unknown layer hit");
                return;
        }
        Cursor.SetCursor(pickedCursor, cursorHotspot, CursorMode.Auto);
     //   print (cameraRaycaster.layerHit);
	}
}
