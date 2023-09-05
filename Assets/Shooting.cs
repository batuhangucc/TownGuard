using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public PlayerControl playerControl;

    public float angleMax, angleMin;
    public  bool bulletActive = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& Mathf.Abs(playerControl.HorizontalMove) != 0)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 angle = transform.eulerAngles;
        angle.z = 180f - GetAngle();
        transform.eulerAngles = angle;
        GameObject bullet=Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb=bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right*bulletForce,ForceMode2D.Impulse);
        bool bulletActive = true;
    }

    float GetAngle()
    {
        Vector3 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 v1 = new Vector3(transform.position.x, transform.position.y, 0) - new Vector3(m.x, m.y, 0);
        v1 = v1.normalized;
        Vector3 v2 = Vector3.right;
        if (playerControl.movement == MovementType.Left)
        {
            v2 = Vector3.left;
        }
        float angle = Vector3.Angle(v1, v2);

        if (angle < angleMin) angle = angleMin;
        else if (angle > angleMax) angle = angleMax;

        if(m.y < transform.position.y) angle = 180;


        return angle;
    }
}
