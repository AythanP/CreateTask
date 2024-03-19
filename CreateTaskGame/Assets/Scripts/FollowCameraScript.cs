/*Name: Aythan Pao
 * Date: 9-27-23
 * Desc: Camera that follows the target game object and shakes the screen
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{
    [Tooltip("Set this to the object to follow in the inspector")]
    public GameObject Target;
    [Tooltip("Value between 0 and 1 for how snappy the camera is (1 is no lerp)")]
    [Range(0, 1f)]
    public float SmoothVal = 0.5f;

    // screen shake variables
    public float shakeDuration = 0.0f;
    private float shakeDurationStart = 0.0f;
    private float shakeMag = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartShake(float duration, float magnitude)
    {
        if(duration > shakeDuration)
        {
            shakeDurationStart = duration;
            shakeDuration = duration;
        }
        if(magnitude > shakeMag)
        {
            shakeMag = magnitude;
        }
    }

    // FixedUpdate is called once per physics frame (every 0.2 seconds, rather than every possible moment)
    void FixedUpdate()
    {
        // if the "Target" field has an object selected in the inspector, the camera will follow the object along 
        // x and y values, but the z value won't be touched, and the camera won't be jittering. 
        if(Target != null)
        {
            Vector3 targetPos = Target.transform.position;
            targetPos.z = transform.position.z;
            // handle screenshake
            if(shakeDuration > 0.0f)
            {
                shakeDuration -= Time.fixedDeltaTime;
                Vector3 randShake = Random.insideUnitCircle * Mathf.Lerp(shakeMag, 0, 1 - (shakeDuration/shakeDurationStart));
                targetPos += randShake;
            } else
            {
                shakeMag = 0;
            }

            // lerp the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPos, SmoothVal);
        }
    }
}
