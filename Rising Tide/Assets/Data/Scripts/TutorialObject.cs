using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class TutorialObject : MonoBehaviour {

	public bool debugStatements = true;
	private int minimumDist = 20;
	private int maximumDist = 120;
	public GameObject tutorialText;
	private Text tutText;
	public GameObject player;
	private GameObject egg;
	public GameObject tutorialBox;
	public GameObject tutOrigin;
	RectTransform rt;
	private Mesh squidMesh;
	private Mesh tempMesh;
	private Mesh eggMesh;
	private bool dialogStarted = false;
	private bool inLOS = false;
	private bool inRangeToHear = false;
	private bool inRangeToInt = false;
	private bool inLOS_inRange = false;
	public string[] narrText = new string[20];
	public bool[] narrTextTrigger = new bool[20];
	private int posInDialogue;
	private bool firstDialogueTrigger = false;
	private bool secondDialogueTrigger = false;
	private bool canPressE = false;
	public bool isEgg = true;
	private int dist;
	private int distToInteract;
	private int clampedDist;


	void Start(){
		narrTextTrigger [0] = true;
		fillNarrativeString ();
		player = GameObject.FindGameObjectWithTag("Player");
		egg = GameObject.FindGameObjectWithTag ("krakenEgg");
		tutorialText.SetActive (false);
		tutorialBox.SetActive (false);
		tutText = tutorialText.GetComponent<Text> ();
		rt = tutorialText.GetComponent<RectTransform> ();

	}


	void Update ()
	{
		
		if (isEgg) {
			if (!dialogStarted) {
				dialogStarted = true;
				StartCoroutine (waitForFirstDialogueTrigger (4f));
				//StartCoroutine (waitForDialogueTrigger (4f));
			}

		}
		if (inLOS && inRangeToHear) {
			inLOS_inRange = true;
		} else {
			inLOS_inRange = false;
		}
		if (inLOS_inRange && firstDialogueTrigger) {
			Debug.Log ("trigger one");
			tutorialText.SetActive (true);
			tutorialBox.SetActive (true);
			tutText.text = narrText [posInDialogue];
			rt.sizeDelta = Vector2.Lerp (rt.sizeDelta, new Vector2 (550, 35), Time.deltaTime / 2f);
			if (Input.GetKeyDown ("e") && secondDialogueTrigger && narrTextTrigger [posInDialogue + 1] && isEgg && canPressE) {
				isEgg = false;
				egg.SetActive (false);
				rt.sizeDelta = new Vector2(100, 23);
				posInDialogue++;
			}
			if(Input.GetKeyDown("e") && secondDialogueTrigger && inRangeToInt && narrTextTrigger[posInDialogue+1] && !isEgg && canPressE){
				posInDialogue++;
				//Debug.Log (posInDialogue);
				rt.sizeDelta = new Vector2(100, 23);
			}
		} else {
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);

		}
		distanceNotify ();
		Debug.Log (posInDialogue);


	}

	void distanceNotify(){
		dist = (int)Vector3.Distance (player.transform.position, tutOrigin.transform.position);
		clampedDist = Mathf.Clamp(dist, minimumDist, maximumDist);
	
		if (dist <= 120) {
			inRangeToHear = true;
			//Debug.Log ("In Range");
			if (dist <= 20) {
				inRangeToInt = true;
				//Debug.Log ("Close enough to interact");
				GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToHL ();
				//GetComponent<NPCHighlighting>().changeMatToHL ();

			} else {
				inRangeToInt = false;
				GameObject.FindWithTag("BorkNPCLocation").GetComponent<NPCHighlighting>().changeMatToNml();
			}

		} else {
			inRangeToHear = false;
			//Debug.Log ("Not In Range");

		}


	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			inLOS = true;
			//Debug.Log ("In LOS");
		}

	}
	void OnTriggerStay(Collider other){
		if(other.gameObject == player)
		{
			inLOS = true;
			//Debug.Log ("In LOS");


		}

	}
	void OnTriggerExit(Collider other){
		if(other.gameObject == player)
		{
			inLOS = false;
			tutorialText.SetActive (false);
			tutorialBox.SetActive (false);
			//Debug.Log ("Not In LOS");

		}
	}
	IEnumerator waitForFirstDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		firstDialogueTrigger = true;
		rt.sizeDelta = new Vector2(100, 23);
		posInDialogue = 0;
		triggerNarrText ();
		StartCoroutine (waitForDialogueTrigger (10f));
	}

	IEnumerator waitForDialogueTrigger (float x){
		yield return new WaitForSeconds (x);
		rt.sizeDelta = new Vector2(100, 23);
		secondDialogueTrigger = true;
		posInDialogue++;
		triggerNarrText ();
		StartCoroutine (waitForInteraction (6f));
	}

	IEnumerator waitForInteraction (float x){
		yield return new WaitForSeconds (x);
		canPressE = true;
	}



	void fillNarrativeString(){
		narrText [0] = "Hey, my lil' Krakenling, it would be very helpful if you were to hatch sometime soon.";
		narrText [1] = "Look... we don't have all day, we have important work to attend to and this container is cramped and stuffy. Shake a tentacle and break out of that prison of yours.";
		narrText [2] = "Oh thank goodness you are relatively intelligent. Now come yonder and help me out of here. Try picking up one of those boxes [Hold LMB] and tossing it at the glass [While holding LMB, RMB].";
		narrText [3] = "Lovely, you are smart! Now come closer and break me out of here. Try picking up one of those boxes [Hold LMB] and tossing it at the glass [While holding LMB, RMB].";
	}
	void triggerNarrText(){
		narrTextTrigger [posInDialogue+1] = true;

	}

	//Do break glass scenario, if break glass increment the dialogue update the dialogue text to the next one, and print it
	// out again.




}
