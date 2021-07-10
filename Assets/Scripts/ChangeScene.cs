using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class ChangeScene : MonoBehaviour
{
	private  AudioSource changeSceneSound;
    void Start()
    {
        changeSceneSound = GetComponent<AudioSource>();
    }
	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag  ==  "Player")
		{
			changeSceneSound.Play();
			StartCoroutine(LoadYourAsyncScene("MarioLevel2"));
		}
	}

	IEnumerator  LoadYourAsyncScene(string sceneName)
	{
		yield  return  new  WaitUntil(() =>  !changeSceneSound.isPlaying);
		CentralManager.centralManagerInstance.changeScene();
	}
}

