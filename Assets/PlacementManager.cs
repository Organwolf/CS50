// WEIRD CUTS

using UnityEngine;
using UnityEngine.XR.ARFoundation;
// Can't create objects while over UI 
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
        // Consider putting this in its own function
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Add a faded black background
                // Add a white boarder to the chosen object

                Vector3 pos = arCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1f));
                placedObject = Instantiate(objectPrefab);
                arSessionOrigin.MakeContentAppearAt(placedObject.transform, pos, Quaternion.identity);
            }

            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // In Weird Cuts TouchPhase.Moved is used to rotate and scale the object
                // Left and Right swipes = Rotation
                // Up and Down swipes = Increase/Decrease scale
                Vector3 pos = arCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1f));
                arSessionOrigin.MakeContentAppearAt(placedObject.transform, pos, Quaternion.identity);
            }

            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // If a black background was added turn it off here
                // If a white boundary was added to the object turn it off here
            }
        }
    }

    public void UndoButton()
    {
        // Remove all objects in the scene
    }

    public void InformationButton()
    {
        // Give cool information here
    }

    // EXTRA - low priority
    public void RecordButtonPressed()
    {
        // Do cool things here
    }

    // EXTRA - low priority
    public void ScissorsButton()
    {
        // Show a the latest used cut
        // Black out the background to like 90% alpha
        // Choose from cuts with left and right arrows

        // Listen for a touch
        // TouchPhase.Began -> take image withing "cut"
        //                  -> trigger vibration
        //                  -> show a small flash
        //                  -> show the cut in top panel
    }
}

