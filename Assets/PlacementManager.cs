using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private Camera arCamera;

    private ARSessionOrigin arSessionOrigin;
    private GameObject placedObject;
	private Touch touch;

	private void Awake()
    {
        arSessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void Update()
    {
        // For debugging
        //var cameraStuff = arCamera.transform.position;
        //Debug.Log("camera transform pos: " + cameraStuff);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
			Debug.Log("Touch began");
            if(placedObject == null)
            {
                touch = Input.GetTouch(0);
                Vector3 pos = arCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1f));
                placedObject = Instantiate(objectPrefab);
                var pos1 = new Vector3(transform.position.x, transform.position.y, 1);
                arSessionOrigin.MakeContentAppearAt(placedObject.transform, pos1, Quaternion.identity);
            }
        }

        else if(placedObject != null)
        {
            placedObject.transform.position = arCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1f));
            // rotation has to be set towards the camera
        }

        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
			Debug.Log("Touch ended");
        }
    }

    public void RecordButtonPressed()
    {
        // Do cool things here
    }
}

