using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_script : MonoBehaviour
{
    float coordinate_z_PointLight;
    void Start()
    {
        CheckPointLightAndChangeTorch();
        StartCoroutine("ChangePointTorch");
    }
    
    IEnumerator ChangePointTorch()
    {
        yield return new WaitForSeconds(10);
        CheckPointLightAndChangeTorch();
        StartCoroutine("ChangePointTorch");

    }

    void CheckPointLightAndChangeTorch()
    {
        coordinate_z_PointLight = Mathf.Abs(GameObject.Find("Point Light").transform.position.z);
        if(coordinate_z_PointLight <= 25 && coordinate_z_PointLight > 20)
        {
            gameObject.GetComponent<Light>().range = 10;
        }
        else if(coordinate_z_PointLight <= 20 && coordinate_z_PointLight > 15)
        {
            gameObject.GetComponent<Light>().range = 5;
        }
        else if(coordinate_z_PointLight <= 15)
        {
            gameObject.GetComponent<Light>().range = 3;
        }
        else if(coordinate_z_PointLight > 25 && coordinate_z_PointLight < 35)
        {
            gameObject.GetComponent<Light>().range = 12;
        }
        else if(coordinate_z_PointLight >= 35)
        {
            gameObject.GetComponent<Light>().range = 17;
        }
    }
}
