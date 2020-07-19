using System.Collections;  
using System.Collections.Generic;  
using UnityEngine; 

public class coll: MonoBehaviour {  

    public bool joy = false;
	public bool fear = false;
	public bool anger = false;
	public bool sadness = false;
	public bool disgust = false;
	public bool bathroom = false;
	public bool sleep = false;
	public bool fatigue = false;

    public float JoyDiff;
    public float FearDiff;
    public float AngerDiff;
    public float SadnessDiff;
    public float DisgustDiff;
    public float BathroomDiff;
    public float SleepDiff;
    public float FatigueDiff;

    player_status ps;

    void OnTriggerEnter(Collider other) {  
        Debug.Log("Collision detected");
        ps = other.GetComponent<player_status>();
        if (joy)          ps.joyQueue(JoyDiff);
        if (fear)         ps.fearQueue(FearDiff);
        if (anger)        ps.angerQueue(AngerDiff);
        if (sadness)      ps.sadnessQueue(SadnessDiff);
        if (disgust)      ps.disgustQueue(DisgustDiff);
        if (bathroom)     ps.bathroomQueue(BathroomDiff);
        if (sleep)        ps.sleepQueue(SleepDiff);
        if (fatigue)      ps.fatigueQueue(FatigueDiff);
        Destroy(gameObject);
    }  
    // Use this for initialization  
    void Start() {}  
    // Update is called once per frame  
    void Update() {}  
}  