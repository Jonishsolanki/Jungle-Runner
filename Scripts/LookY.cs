using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousey = Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + mousey, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
