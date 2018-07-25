using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour {
	private bool camAvailable;
	private WebCamTexture backCam;
	private Texture defaultBackground;


	public RawImage background; 
	public AspectRatioFitter fit;

	private void Start()
	{
		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;
		if (devices.Length == 0) 
		{
			Debug.Log ("no hay camaras detectadas");
			camAvailable = false;
			return;
		}

		for (int i = 0; i < devices.Length; i++)
		{
			if (devices [i].isFrontFacing) //if (!devices [i].isFrontFacing) para camara trasera ||if (devices [i].isFrontFacing) para camara frontal
			{
				backCam = new WebCamTexture (devices [i].name, Screen.width, Screen.height);
			}	
		
		}
		if(backCam==null)
		{
			Debug.Log ("no se encontro camara");
			return;
		}
		backCam.Play ();
		background.texture = backCam;

		camAvailable = true;
	}

	private void Update ()
	{
		if (!camAvailable)
			return;
		float ratio = (float)backCam.width / (float)backCam.height;
		fit.aspectRatio = ratio;

		float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
		background.rectTransform.localScale = new Vector3 (1f, scaleY, 1f);

		int orient = -backCam.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3 (0, 0, orient);  
	}

}
