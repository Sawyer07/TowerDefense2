using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretLockOn : MonoBehaviour
{
    //public Transform target;
    public float turnSpeed = 10f;
    public bool useProximityDetection = true;
    public float detectionRange = 5f;

    Transform target;
    public LayerMask mask;

    void Update()
    {
        if(target == null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange, mask);
            float ShortestDistance = detectionRange + 1f;
            for (int i = 0; i < colliders.Length; i++)
            {
                float distance = Vector2.Distance(transform.position, colliders[i].transform.position);
                if (distance < ShortestDistance)
                {
                    ShortestDistance = distance;
                    target = colliders[i].transform;
                }
            }
        }
        else
        {
            Vector3 from = transform.up;
            Vector3 to = (target.transform.position - transform.position).normalized;
            Vector3 newRotation = Vector3.RotateTowards(from, to, turnSpeed * Time.deltaTime, 0f);
            transform.up = newRotation;
            if (Vector2.Distance(target.position, transform.position) > detectionRange)
            {
                target = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
      
            Gizmos.DrawWireSphere(transform.position, detectionRange);
    }





}