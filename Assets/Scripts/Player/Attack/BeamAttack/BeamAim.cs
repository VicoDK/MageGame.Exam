using UnityEngine;

public class BeamAim : MonoBehaviour
{
    public GameObject bullet;
    Vector2 fireDir;
    public Transform FirePoint;
    Transform firePoint;


    // Update is called once per frame
    void Update()
    {
        transform.position = firePoint.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        fireDir = (mousePosition - FirePoint.position).normalized;

        // Rotate bullet towards mouse position
        float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }


    void Start()
    {
        firePoint = GameObject.Find("FirePoint").transform;

    }


}
