using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{
    public float Downwardspeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Downwardspeed*Time.deltaTime);  //Making the bars go in downward direction

        if(transform.position.y <= -8f)
        {
            Destroy(gameObject);
        }
    }
}
