using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;

    private ARSessionOrigin arSessionOrigin;
    private ARCameraManager arCameraManager;
    private GameObject placedObject;
	private Touch touch;

	private void Awake()
    {
        arCameraManager = GetComponent<ARCameraManager>();
        arSessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
			Debug.Log("Touch began");
        }

        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
			Debug.Log("Touch ended");
            if(placedObject == null)
            {
                touch = Input.GetTouch(0);
                placedObject = Instantiate(objectPrefab, touch.position, Quaternion.identity);
                var positionToPlaceAt = arCameraManager.transform.position + Vector3.forward * 0.5f;
                arSessionOrigin.MakeContentAppearAt(placedObject.transform, positionToPlaceAt, Quaternion.identity);
            }
        }
    }

    public void RecordButtonPressed()
    {
        // Do cool things here
    }
}

