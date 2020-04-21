using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightScript : MonoBehaviour
{
    public List<GameObject> trafficlights;
    public float radius = 10;
    public int lightsAmount = 10;

    void Start()
    {
        TrafficLightsSpawn();
    }

    void TrafficLightsSpawn()
    {
        trafficlights.Clear();
        float thetaInc = (Mathf.PI * 2) / lightsAmount;
        for (int i = 0; i < lightsAmount; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            Cylinder.transform.position = pos;
            Cylinder.name = "Trafficlight " + (i + 1);
            trafficlights.Add(Cylinder);
            Cylinder.gameObject.AddComponent<TrafficLightColour>();
            Cylinder.transform.parent = this.transform;
        }
    }

    public void OnDrawGizmos()
    {
        float thetaInc = (Mathf.PI * 2) / lightsAmount;
        for (int i = 0; i < lightsAmount; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);

            Gizmos.DrawWireSphere(pos, 2);
        }
    }
}
