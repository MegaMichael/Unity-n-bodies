using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private List<GameObject> obj = new List<GameObject>();
    private List<Vector3> radius_v = new List<Vector3>();
    private List<float> m = new List<float>();
    private Vector3 impulse = new Vector3(0,1,0);
    private Vector3 r = new Vector3();
    private float d = new float();


    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            obj.Add(transform.GetChild(i).gameObject);

            m.Add(obj[i].GetComponent<Rigidbody>().mass);
            radius_v.Add(obj[i].transform.position);
            obj[i].GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.childCount; j++)
            {
                if (j != i)
                {
                    r = radius_v[i] - radius_v[j];
                    d = r.magnitude;
                    r.Normalize();
                    obj[j].GetComponent<Rigidbody>().AddForce(r * 6.68f * m[i] * m[j] / (d * d),ForceMode.Force);
                }
            }
        }
    }
}
