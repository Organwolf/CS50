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
    private Vector3 oTransformPos;

	private void Awake()
    {
        oTransformPos = transform.position;
        arCameraManager = GetComponent<ARCameraManager>();
        arSessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
			Debug.Log("Touch began");
            if(placedObject == null)
            {
                touch = Input.GetTouch(0);

                placedObject = Instantiate(objectPrefab);
                var positionToPlaceAt = new Vector3(oTransformPos.x, oTransformPos.y, oTransformPos.z + 1f);
                arSessionOrigin.MakeContentAppearAt(placedObject.transform, positionToPlaceAt, Quaternion.identity);
            }
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

