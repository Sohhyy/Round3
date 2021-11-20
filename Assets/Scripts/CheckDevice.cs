using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CheckDevice : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Device1;
    public GameObject Device2;
    void Start()
    {
        uint index1 = 0;
        uint index2 = 0;
        var error = ETrackedPropertyError.TrackedProp_Success;
        for (uint i = 0; i < 16; i++)
        {
            var result = new System.Text.StringBuilder((int)64);
            OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);
            if (result.ToString().Contains("tracker"))
            {
                index1 = i;
                if (index1 != 0&&index1!=i)
                {
                    index2 = i;
                }
                //break;
            }
        }
        Device1.GetComponent<SteamVR_TrackedObject>().index = (SteamVR_TrackedObject.EIndex)index1;
        Device2.GetComponent<SteamVR_TrackedObject>().index = (SteamVR_TrackedObject.EIndex)index2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
