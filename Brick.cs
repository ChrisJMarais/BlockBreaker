using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] HitSprite;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Brick");
		
		if (isBreakable){
			breakableCount++;
			Debug.Log(breakableCount);
		}
		timesHit = 0;	
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.2f);

		if (isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		this.timesHit++;
		int maxHits = HitSprite.Length + 1;
		
		if (this.timesHit >= maxHits){			
			breakableCount--;
			PuffSmoke ();
			Destroy(gameObject);
			levelManager.BrickDestroyed();
			/*if (GameObject.FindGameObjectsWithTag("Brick").Length == 1){
				levelManager.LoadNextLevel();
			}*/
		} else {
			LoadSprites();
		}	
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		
		if (HitSprite[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = HitSprite[spriteIndex];
		} else {
			Debug.LogError("Sprite at index " + spriteIndex + " is missing");
		}
	}
	
}
