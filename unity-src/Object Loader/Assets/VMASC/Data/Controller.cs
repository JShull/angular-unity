using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;
namespace ElevenThousand
{
  public class Controller : MonoBehaviour
  {
    
    [DllImport("__Internal")]
    private static extern void SendMessageToWeb(string msg);

    [Tooltip("Bar Chart Object to Show")]
    public GameObject BarGraphObject;
    [Tooltip("Line Graph Object to Show")]
    public GameObject LineGraphObject;
    public TextMeshProUGUI JsonDataTest;
    public void Start()
    {
      BarGraphObject.SetActive(true);
      LineGraphObject.SetActive(false);
    }
    public void ReceiveMessageFromWeb(string msg)
    {
      Debug.Log("Controller.ReceiveMessageFromWeb: " + msg);
      switch (msg)
      {
        case "Line Graph":
          LineGraphObject.SetActive(true);
          BarGraphObject.SetActive(false);
          break;
        case "Bar Chart":
          LineGraphObject.SetActive(false);
          BarGraphObject.SetActive(true);
          break;
      }
    }
    /// <summary>
    /// Called from javascript associated with loading json through the browser
    /// </summary>
    /// <param name="data"></param>
    public void ReceiveDataFromWeb(string data)
    {
      JsonDataTest.text = data;
    }
  }

}
