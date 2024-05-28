using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weponScript : MonoBehaviour
{
    public float range = 100;
    public float damage = 1;
    public float timeBetweenShots = 1;
    public float shootTimer = 0;
    public GameObject bullet;
    public Transform barrel;
    private List<Collider> colliders;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        colliders = new List<Collider>(GetComponentsInChildren<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
    }
    public void Shoot()
    {
        if(shootTimer <= 0)
        {
            GameObject B =  Instantiate(bullet, barrel.position, barrel.rotation);
            B.transform.LookAt(GetRaycastTarget());
            shootTimer = timeBetweenShots;
        }
    }
    public Vector3 GetRaycastTarget()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray,out hitInfo, 100))
        {
            return hitInfo.point;
        }
        return cam.transform.position + cam.transform.forward * 100;
    }
    public void PickUp(Transform dock)
    {
        transform.position = dock.position;
        transform.rotation = dock.rotation;
        transform.parent = dock.parent;
        foreach ( Collider col in colliders)
        {
            col.enabled = false;
        }   
    }
    public void Drop(Vector3 dropPos)
    {
        transform.position = dropPos;
        transform.parent = null;
        foreach ( Collider col in colliders)
        {
            col.enabled = true;
        }
    }
}
