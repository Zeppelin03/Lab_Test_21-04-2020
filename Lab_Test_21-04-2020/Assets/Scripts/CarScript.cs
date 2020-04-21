using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float MaxVelocity = 5;
    public float Mass = 20;
    public float MaxForce = 20;
    private Vector3 velocity;
    public TrafficLightScript trafficLightScript;

    [SerializeField]
    private Transform target;
    public List<GameObject> lightGreen;

    void Start()
    {
        velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        ChooseLight();
        MoveToLight();
    }

    void ChooseLight()
    {
        foreach (GameObject item in trafficLightScript.gameObject.GetComponent<TrafficLightScript>().trafficlights)
        {
            var LightRef = item.gameObject.GetComponent<TrafficLightColour>();

            if (LightRef.state == TrafficLightColour.State.green)
            {

                if (lightGreen.Count < 10)
                {
                    lightGreen.Add(item);
                }

                target = lightGreen[0].transform;

                if (Vector3.Distance(item.transform.position, this.transform.position) < 1)
                {
                    lightGreen.Remove(item);
                }
            }
            else if (LightRef.state == TrafficLightColour.State.yellow || LightRef.state == TrafficLightColour.State.red)
            {
                lightGreen.Remove(item);
            }

        }
    }

    void MoveToLight()
    {
        var desiredVelocity = target.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);
    }
}
