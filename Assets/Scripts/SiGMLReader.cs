using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System; 
using UnityEngine;

public class SiGMLReader : MonoBehaviour
{
    public string fullFilePath;
    public string gloss = "";
    public GameObject hand, r_index_1, r_index_2, r_index_3,
        r_mid_1, r_mid_2, r_mid_3,
        r_pinky_1, r_pinky_2, r_pinky_3,
        r_ring_1, r_ring_2, r_ring_3,
        r_thumb_1, r_thumb_2, r_thumb_3;
    public List<GameObject> firstJoint, secondJoint, thirdJoint, 
        index_finger, middle_finger, ring_finger, pinky_finger; 
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("CC_Base_R_Hand");

        r_index_1 = GameObject.Find("CC_Base_R_Index1");
        r_index_2 = GameObject.Find("CC_Base_R_Index2");
        r_index_3 = GameObject.Find("CC_Base_R_Index3");

        r_mid_1 = GameObject.Find("CC_Base_R_Mid1");
        r_mid_2 = GameObject.Find("CC_Base_R_Mid2");
        r_mid_3 = GameObject.Find("CC_Base_R_Mid3");

        r_ring_1 = GameObject.Find("CC_Base_R_Ring1");
        r_ring_2 = GameObject.Find("CC_Base_R_Ring2");
        r_ring_3 = GameObject.Find("CC_Base_R_Ring3");

        r_pinky_1 = GameObject.Find("CC_Base_R_Pinky1");
        r_pinky_2 = GameObject.Find("CC_Base_R_Pinky2");
        r_pinky_3 = GameObject.Find("CC_Base_R_Pinky3");

        r_thumb_1 = GameObject.Find("CC_Base_R_Thumb1");
        r_thumb_2 = GameObject.Find("CC_Base_R_Thumb2");
        r_thumb_3 = GameObject.Find("CC_Base_R_Thumb3");

        firstJoint = new List<GameObject> { r_index_1, r_mid_1, r_ring_1, r_pinky_1 }; 
        secondJoint = new List<GameObject> { r_index_2, r_mid_2, r_ring_2, r_pinky_2 };
        thirdJoint = new List<GameObject> { r_index_3, r_mid_3, r_ring_3, r_pinky_3 };

        index_finger = new List<GameObject> { r_index_1, r_index_2, r_index_3 };
        middle_finger = new List<GameObject> { r_mid_1, r_mid_2, r_mid_3 };
        ring_finger = new List<GameObject> { r_ring_1, r_ring_2, r_ring_3 };
        pinky_finger = new List<GameObject> { r_pinky_1, r_pinky_2, r_pinky_3 }; 


        using (TextReader rdr = new StreamReader(fullFilePath))
        {
            string line;
            while ((line = rdr.ReadLine()) != null)
            {
                //Debug.Log(line);
                /*if (line == "<sigml>")
                {
                }
                else
                {
                    var result = line.Split(new[] { '\r', ' ', '\n' });
                    if (result[0] == "hns_sign")
                    {
                        String[] separator = { "gloss=\"", "\">" };
                        String[] gloss_list = result[1].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        gloss = gloss_list[1];
                    }*/
                    if (line.Contains("<hamfinger2345/>"))
                    {
                        Debug.Log("hamfinger2345");
                        HamFinger2345();
                    }
                    if (line.Contains("<hamthumbacross/>"))
                    {
                        HamThumbAcross(); 
                    }
                    if (line.Contains("<hamdoublehooked/>"))
                    {
                        HamDoubleHooked(); 
                    }
                    if (line.Contains("<hamflathand/>"))
                    {
                        HamFlatHand();
                    }
                    if (line.Contains("<hamfist/>"))
                    {
                        HamFist(); 
                    }
                //}

            }
        }

    }
    void HamFist()
    {
        hand.transform.localEulerAngles = new Vector3(6.5453558f, 42.2618027f, 20.2450981f);

        r_mid_1.transform.localEulerAngles = new Vector3(326.713562f, 349.161133f, 296.593781f);
        r_mid_2.transform.localEulerAngles = new Vector3(10.4145117f, 27.8110352f, 251.522964f);
        r_mid_3.transform.localEulerAngles = new Vector3(10.2577782f, 359.371124f, 314.808075f);

        r_index_1.transform.localEulerAngles = new Vector3(341.260345f, 353.591705f, 304.143982f);
        r_index_2.transform.localEulerAngles = new Vector3(357.735504f, 16.973547f, 243.460938f);
        r_index_3.transform.localEulerAngles = new Vector3(12.7431002f, 9.7474556f, 303.365356f);

        r_pinky_1.transform.localEulerAngles = new Vector3(355.58252f, 358.176605f, 275.375641f);
        r_pinky_2.transform.localEulerAngles = new Vector3(341.412018f, 1.44459534f, 283.063202f);
        r_pinky_3.transform.localEulerAngles = new Vector3(346.593842f, 2.28613067f, 277.546417f);

        r_ring_1.transform.localEulerAngles = new Vector3(328.289398f, 350.164398f, 292.71701f);
        r_ring_2.transform.localEulerAngles = new Vector3(351.779602f, 30.1202679f, 244.872375f);
        r_ring_3.transform.localEulerAngles = new Vector3(354.967102f, 5.62406063f, 323.406342f);

        r_thumb_1.transform.localEulerAngles = new Vector3(40.6625748f, 14.1808491f, 3.50698328f);
        r_thumb_2.transform.localEulerAngles = new Vector3(326.230591f, 11.1770878f, 4.3101306f);
        r_thumb_3.transform.localEulerAngles = new Vector3(350.610168f, 329.296021f, 343.379364f); 


    }
    void HamFlatHand()
    {
        hand.transform.localEulerAngles = new Vector3(0, 45, 2.9050045f);

        foreach (List<GameObject> finger in new List<List<GameObject>> { index_finger, middle_finger, ring_finger, pinky_finger })
        {
            foreach (GameObject joint in finger)
            {
                joint.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }

        r_thumb_1.transform.localEulerAngles = new Vector3(39.3486404f, 0.0348656513f, 0.247943848f);
        r_thumb_2.transform.localEulerAngles = new Vector3(327.625183f, 357.907501f, 12.1656246f);
        r_thumb_3.transform.localEulerAngles = new Vector3(352.386749f, 0.155667439f, 2.63004708f); 
    }
    void HamFinger2345()
    {
        hand.transform.localEulerAngles = new Vector3(0, 45f, 0);

        foreach (List<GameObject> finger in new List<List<GameObject>> { index_finger, middle_finger, ring_finger, pinky_finger })
        {
            foreach (GameObject joint in finger)
            {
                joint.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
    void HamThumbAcross()
    {
        r_thumb_1.transform.localEulerAngles = new Vector3(35, 24, 0);
        r_thumb_2.transform.localEulerAngles = new Vector3(-55, 6, -4);
        r_thumb_3.transform.localEulerAngles = new Vector3(-24, -30, -12);
    }
    void HamDoubleHooked()
    {
        foreach (GameObject item in secondJoint)
        {
            item.transform.localEulerAngles = new Vector3(-5, 35,-95);
        }
        foreach (GameObject item in thirdJoint)
        {
            item.transform.localEulerAngles = new Vector3(-10, 20, -65); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
