using UnityEngine;
using System.Collections;

public class TheAmazingGameLoop : MonoBehaviour {

	public GameObject gameWinO;
	public Transform Dick;
	//public GameObject isGrassHighEnough;
	public Transform[] Grass;
	int lenOfGrass = 20;
	int goodLenOfGrass = 10;
	int currHighGrass = 0;
	bool dickWin = false;
	bool grassWin = false;
	bool gameWin = false;

	void Start () {
		//if(isGrassHighEnough.activeInHierarchy)
		//{
		//	isGrassHighEnough.SetActive(false);
		//}
		if(Grass != null)
		{
			lenOfGrass = Grass.Length;
			goodLenOfGrass = lenOfGrass / 2;
		}
	}
	
	void Update () {

		currHighGrass = 0;
		for(int i = 0; i < lenOfGrass; i++)
		{
			if(Grass[i].localScale.y > 1.5f)
			{
				currHighGrass++;
			}
		}
		if(currHighGrass > goodLenOfGrass)
		{
			grassWin = true;
		}
		
		if(gameWin)
		{
			//
			//Debug.Log("Win");
			if(!gameWinO.activeInHierarchy)
			{
				gameWinO.SetActive(true);
			}
		}

		if(dickWin && grassWin)
		{
			gameWin = true;
		}

		if(Dick.localScale.y >= 0.8f)
		{
			if(!dickWin)
			{
				dickWin = true;
			}
			
		}
		else
		{
			dickWin = false;
		}

	}
}
