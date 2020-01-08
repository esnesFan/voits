using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class KeyboardListener : MonoBehaviour
{
	// 押しているKeyのList
	public static List<KeyCode> pressingKeyList;
	
	
	// Start is called before the first frame update
	void Start ()
	{
		// Fieldの初期化
		pressingKeyList = new List<KeyCode> ();
	}

	// Update is called once per frame
	void Update ()
	{
		// 押したKey/離したKeyをListに追加/削除する
		foreach ( KeyCode key in Enum.GetValues ( typeof ( KeyCode ) ) )
		{
			if ( Input.GetKeyDown ( key ) )
			{
				AddKeyToPressingKeyList ( key );
			}
			if ( Input.GetKeyUp ( key ) )
			{
				RemoveKeyFromPressingKeyList ( key );
			}
		}
	}
	
	// pressingKeyListにKeyを追加する
	public static void AddKeyToPressingKeyList ( KeyCode key )
	{
		if ( !pressingKeyList.Contains ( key ) )
		{
			pressingKeyList.Add ( key );

			Debug.Log ( MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod ().Name + " ()  key.ToString () : " + key.ToString () );
		}
	}
	
	// pressingKeyListからKeyを削除する
	public static void RemoveKeyFromPressingKeyList ( KeyCode key )
	{
		pressingKeyList.Remove ( key );

		Debug.Log ( MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodBase.GetCurrentMethod ().Name + " ()  key.ToString () : " + key.ToString () );
	}
}
