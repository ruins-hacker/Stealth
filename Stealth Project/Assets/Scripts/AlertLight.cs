using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLight : MonoBehaviour
{
    public Light light;
    public bool alertOn = false;
    public static AlertLight shared;

    private float startIntensity = 0;
    private float endIntensity = 1;
    private float targetIntensity;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        shared = this;
        targetIntensity = endIntensity;
        alertOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(alertOn)
        {
            light.intensity =  Mathf.Lerp(light.intensity, targetIntensity, Time.deltaTime * speed);
            if (Mathf.Abs(targetIntensity - light.intensity) < 0.01f )
            {
                if(targetIntensity == startIntensity)
                {
                    targetIntensity = endIntensity;
                } else
                {
                    targetIntensity = startIntensity;
                }
                
            }
        } else
        {
            light.intensity = Mathf.Lerp(light.intensity, startIntensity, Time.deltaTime * speed);
        }
    }
}
