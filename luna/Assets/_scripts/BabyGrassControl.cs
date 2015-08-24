using UnityEngine;
using System.Collections;

public class BabyGrassControl : MonoBehaviour {

	float maxHeight = 1;
	int spriteIndex = 0; // 0-3
	bool isThisGrassGrowing = false;
	float growTime = 1;

	public Sprite[] grassSprite;
	//public GameObject[] grassGO;
	SpriteRenderer spriteRenderer;
	GrassObject[] grass;
	int lenOfGrass = 0;
	float randomMaxHeight = 1;
	int randomSpriteIndex = 0;
	bool isGrassGrowing = false;
	float currGrassScale = 0;
	float growTimeFactor = 10;
	int growFlag = 0;
	float newGrowTime = 0;
	float oldGrowTime = 0;
	float randomGrowTime = 1;
	float growRate = 0.5f;

	BoxCollider boxCollider;

	void Start () {
		newGrowTime = Time.time;
		oldGrowTime = newGrowTime;

		// initialize each grass' parameters
		//isGrassGrowing = true; 

		//if(grassGO != null)
		//{
		//	lenOfGrass = grassGO.Length;
		//}

		//grass = new GrassObject[lenOfGrass];

		//for(int i = 0; i < lenOfGrass; i++)
		{
			//GrassObject babyGrass = new GrassObject();
			//grass[i] = babyGrass;

			randomMaxHeight = Random.Range(1f, 2f);
			//grass[i].SetMaxHeight(randomMaxHeight);

			randomSpriteIndex = Random.Range(0, 4);
			//grass[i].SetSpriteIndex(randomSpriteIndex);

			isThisGrassGrowing = false;
			//grass[i].SetIsThisGrassGrowing(true);
		

			randomGrowTime = Random.Range(0.1f, 2f);
			//grass[i].SetGrowTime( randomGrowTime );
			//Debug.Log("" + randomGrowTime);

			spriteRenderer = GetComponent("SpriteRenderer") as SpriteRenderer;
			spriteRenderer.sprite = grassSprite[ randomSpriteIndex ];
		}

		boxCollider = GetComponent("BoxCollider") as BoxCollider;
	}
	
	void Update () {
	
		newGrowTime = Time.time;
		//Debug.Log("" + (newGrowTime - oldGrowTime));
		
		// TODO: get an int flag to determine whether to set isGrassGrowing to false 
		//for(int i = 0; i < lenOfGrass; i++)
		//{
		//	if(grass[i].GetIsThisGrassGrowing())
		//	{
		//		break;
		//	}
		//	isGrassGrowing = false;
		//}

		if(isGrassGrowing)
		{
			//for(int i = 0; i < lenOfGrass; i++)
			//{
				//if(isThisGrassGrowing)
		//		{
					//if(currGrassScale < randomMaxHeight)
					//{
						//if(newGrowTime - oldGrowTime >= growTime)
						{
							//growTimeFactor = grass[i].GetMaxHeight() / growTimeFactor * Time.deltaTime;
							
							//grassGO[i].gameObject.transform.localScale += new Vector3(0, growTimeFactor, 0);
							growRate = 0.5f;
							transform.localScale += 
								new Vector3(0, 10 * growRate * randomMaxHeight /** Time.deltaTime */, 0);
							//currGrassScale = transform.localScale.y;

							isGrassGrowing = false;
						}
						//else
						//{
							///continue;
						//}
					//}
					//else
					//{
					//	isThisGrassGrowing = false;
					//}
		//		} 
			//}

		} // end isGrassGrowing
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "rain")
		{
			//isThisGrassGrowing = true;
			transform.localScale += new Vector3(0, growRate, 0);
			boxCollider.size += new Vector3(0, growRate, 0);
		}
		else if(coll.gameObject.tag == "sun")
		{
			transform.localScale -= new Vector3(0, growRate, 0);
			boxCollider.size -= new Vector3(0, growRate, 0);
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.gameObject.tag == "sun")
		{
			transform.localScale -= new Vector3(0, growRate, 0);
			boxCollider.size -= new Vector3(0, growRate, 0);
		}
	}
}
