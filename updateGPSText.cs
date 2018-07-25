using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateGPSText : MonoBehaviour {

	public Text cordenadas;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		cordenadas.text = "Lat:" + GPS.Instance.lattitude.ToString () + "   Lon:" + GPS.Instance.longitude.ToString ();
	}
}
