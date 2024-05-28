using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Transform gunDock;
    public Camera playerCam;
    public float maxPickUpDisstence = 5;
    public WeaponHandler handler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Ray pickUpRay = new Ray();
            pickUpRay.origin = playerCam.transform.position;
            pickUpRay.direction = playerCam.transform.forward;
            RaycastHit hitInfo;
            bool ifPickUp = Physics.Raycast(pickUpRay, out hitInfo, maxPickUpDisstence);
            if (ifPickUp) {
                weponScript wepon = hitInfo.collider.GetComponent<weponScript>();
                Debug.Log(hitInfo.transform);
                if (wepon!= null) {
                    Vector3 oldPosition = wepon.transform.position;
                    Quaternion oldRotation = wepon.transform.rotation;
                    handler.currentWeapon.transform.rotation = oldRotation;
                    handler.currentWeapon.Drop(oldPosition);
                    handler.currentWeapon = wepon;
                    handler.currentWeapon.PickUp(gunDock);
                    wepon.cam = playerCam;
                  
                }
            }
        }
        if (handler.currentWeapon.CompareTag("New Weapon"))
        {
            Debug.Log("New weapon");
        }
    }
}
