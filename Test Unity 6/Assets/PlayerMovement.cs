using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{   
    public float forwardForce = 500f;
    public float laterlForce = 15f;
    public float targetSpeeed = 100f;
    public float maxLaterlPos = 3f;
    private Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() 
    {
        ForwardMovement();
        LateralMoveMent();
    }
    void ForwardMovement()
    {
        float curruntSpeed  = rb.linearVelocity.z;

        if(curruntSpeed < forwardForce)
        {
            rb.AddForce(Vector3.forward * forwardForce * Time.fixedDeltaTime,ForceMode.Force);
        }
        else if (curruntSpeed > laterlForce)
        {
            Vector3 clampedVelocity = rb.linearVelocity;

            clampedVelocity.z = targetSpeeed;
            
            rb.linearVelocity = clampedVelocity;
        }
    }
    void LateralMoveMent()
    {
        float direction = Input.GetAxis("Horizontal");

        Vector3 lateralVelocity = rb.linearVelocity;
        lateralVelocity.x = direction * laterlForce;
        rb.linearVelocity = lateralVelocity;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x,-maxLaterlPos, maxLaterlPos);
        transform.position = clampedPosition;
    }
}
