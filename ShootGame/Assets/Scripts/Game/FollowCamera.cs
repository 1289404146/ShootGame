using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : YLBaseMono
{
    private Transform camaraTransform;
    public void SetTarget(Transform transform)
    {
        this.camaraTransform = transform;
    }
    private void LateUpdate()
    {
        if(camaraTransform!=null)
        {
            transform.position = camaraTransform.position + new Vector3(0, 3.5f, -4);
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
    }

}
