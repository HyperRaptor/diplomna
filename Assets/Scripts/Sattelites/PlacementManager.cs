using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    //Script for placing satellites
    public static PlacementManager Instance;
    private GameObject objectToPlace;
    private bool waitingForPlacement;
    private void Awake()
    {
        Instance = this;
    }
    public void BeginPlacement(GameObject prefab)
    {
        if (waitingForPlacement) return;

        objectToPlace = prefab;
        waitingForPlacement = true;
    }
    private void Update()
    {
        if (!waitingForPlacement || objectToPlace == null)
            return;
        Vector3 spawnPosition = Vector3.zero;
        bool validInput = false;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ignore touches over UI
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                return;

            if (touch.phase == TouchPhase.Began)
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(touch.position);
                spawnPosition.z = 0f;
                validInput = true;
            }
        }
#if UNITY_EDITOR
        if (!validInput)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.z = 0f;

                validInput = true;
            }
        }
#endif
        if (validInput)
        {
            UnitManager.Instance.Sattelites.Add(Instantiate(objectToPlace, spawnPosition, Quaternion.identity));
            waitingForPlacement = false;
            objectToPlace = null;
        }
    }
}
