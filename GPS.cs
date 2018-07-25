using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {

	public static GPS Instance{ set; get; }

	public float lattitude;
	public float longitude;

	// Use this for initialization
	private void Start () {
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService ());
	}
	private IEnumerator StartLocationService()
	{
		if (!Input.location.isEnabledByUser) //if (!Input.location.isEnabledByUser) si el usuario no a habilitado su ubicacion
		{
			Debug.Log ("elusuario no ha habilitado el gps");
			yield break;
		}
		Input.location.Start ();
		int maxWait = 20;
		while(Input.location.status==LocationServiceStatus.Initializing&&maxWait>0){
			yield return new WaitForSeconds (1);
			maxWait--;
		
		}
		if(maxWait<=0)
		{
			Debug.Log ("Time out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("no se pudo determinar la ubicacion");

		}
		lattitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		yield break;

		}



	// Update is called once per frame
	void Update () {
		
	}
}
