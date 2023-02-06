using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public Transform cam;
    float turnSmoothVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction=new Vector3(horizontal,0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle=Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg+cam.eulerAngles.y;//get angle for rotation.
            float angle=Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation=Quaternion.Euler(0,angle,0);//rotate the object   
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDir.normalized*speed*Time.deltaTime);
        }
    }
}
