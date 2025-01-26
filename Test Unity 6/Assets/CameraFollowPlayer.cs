using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform transformTarget;

    void Update()
    {

        transform.Translate(new Vector3(transformTarget.position.x,transformTarget.position.y));
    }
}
