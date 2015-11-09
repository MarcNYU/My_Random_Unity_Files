using UnityEngine;
using System.Collections;

public class text : MonoBehaviour {
	
	public string current = "title";
	public string prior = "";
//	public Camera mycamera;
	[Header("Audio stuff")]
	public AudioSource bgm;
	public AudioClip bgm_background;
	
	public AudioSource sfx;
	public AudioClip sfx_Build;
	public AudioClip sfx_Jolt;
	public AudioClip sfx_siren;
	public AudioClip sfx_static;

	public string w;
	public string a;
	public string s;
	public string d;

	//private bool haskey = false;
	private bool hasKey = false;
	private bool hasGun = false;
	private bool hasMoney = false;
	private bool hasFought = false;
	private bool unlocked = false;
	private bool isHurt = false;
	private bool alarm = false;
	private bool found = false;
	private int hurt = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (start);
		//string textB = "";
		string dialog = "";
		w = "";
		a = "";
		s = "";
		d = "";
		int randomizer;
		bgm.clip = bgm_background;
		if(!bgm.isPlaying)
		{
			bgm.Play ();
		}
		switch (current) 
		{
		case "title":
			hasKey = false;
			hasGun = false;
			hasMoney = false;
			hasFought = false;
			unlocked = false;
			alarm = false;
			isHurt = false;
			found = false;
			hurt = 5;
			dialog = "Lost_7\n\nBy: SoundVoid (Marcus Williams)\n\n\t\t\tPress the Anykey\n\n\n\n\nAudio: https://freesound.org\nMusic by Notch";
			if (Input.anyKeyDown)
			{
				current = "ally";
			}
			break;
		case "ally":
			dialog = "You wake up in an alley way.\nThere's a sharp pain in your side,\nyou're freezing and the world is spinning.\npress (w) to continue";
			w = "lost";
			a = current;
			s = current;
			d = current;
			break;
		case "lost":
			dialog = "You look around but you don't see much.\nThere's a few dumpsters to your left\nand a broken beer bottle to your right\n(w) Leave alley\n(a) Check dumpsters\n";
			w = "corner";
			a = "dumpster";
			s = current;
			d = current;
			break;
		case "dumpster":
			if (prior != "trash") 
			{
				dialog = "As you open the lid a waft of old diapers\nand rum fills the air. It's pretty gross inside\nthere. You also see some syringes and\nrusted nails poking out.\n(w) Risk sereaching through the trash\n(s) To go back\n";
				w = "trash";
			}
			else 
			{
				dialog = "As you open the lid a waft of old diapers\nand rum fills the air. It's pretty gross inside\nthere. You also see some syringes and\nrusted nails poking out.\n(s) To go back\n";
			}
			a = current;
			s = "lost";
			d = current;
			isHurt = false;
			break;
		case "trash":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (randomizer > 6)
			{
				current = "lucky";
				break;
			}
			else 
			{
				current = "unlucky";
				break;
			}
			break;
		case "unlucky":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Jolt);
				isHurt = true;
			}
			dialog = "You reach in but you cut yourself\non a rusted nail. I hope it was worth it.\nYou found a key. (s) To go back\n";
			hasKey = true;
			hurt += 5;
			prior = "trash";
			w = current;
			a = current;
			s = "lost";
			d = current;
			break;
		case "lucky":
			dialog = "That was risky but it paid off in the end.\nYou found a key. (s) To go back\n";
			hasKey = true;
			prior = "trash";
			w = current;
			a = current;
			s = "lost";
			d = current;
			break;
		case "shot door":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (randomizer == 10)
			{
				current = "not shot";
				break;
			}
			else 
			{
				current = "shot";
				break;
			}
			break;
		case "shot":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Jolt);
				isHurt = true;
			}
			dialog = "Why would you do that, do you know\n how dangerous that was?!\n Well you just shot yourself.\n(s) To go back\n";
			hasGun = false;
			w = current;
			a = current;
			s = "store";
			d = current;
			hurt += 15;
			break;
		case "not shot":
			dialog = "Wow that actually worked?\nUh... Ok the door is unlocked.\n(w) Open door\n";
			w = "alarm";
			a = current;
			s = current;
			d = current;
			break;
		case "corner":
			prior = "corner";
			dialog = "The sun is almost up, but it's way to dark\nto see the street. The street light above\nyou seems busted, although you do see\na pawnshop across the street.\n(w) Go to pawn-shop\n(a or d) To explore\n(s) To go back\n";
			w = "store";
			a = "street";
			s = "lost";
			d = a;
			break;
		case "store":
			dialog = "The shop is closed but you can see the street\n a little better from here.\n(w) Examin the shop\n(a or d) To explore\n(s) To go back\n";
			if (prior == "unlocked") 
			{
				w = "shop";
			}
			else 
			{
				w = "door";
			}
			a = "street";
			s = "corner";
			d = a;
			prior = "store";
			break;
		case "street":
			if (prior == "corner") {
				dialog = "You can't really see anything\n(a) Risk the darkness\n(d) Risk the darkness\n(s) To go back\n";
			} else if (prior == "store") {
				dialog = "You see a police station a few blocks to your 'right'\n and some guys hanging around a beat-up car to your 'left'.\n(a) Approach them\n(d) Head towards the station\n(s) To go back\n";
			}
			w = current;
			a = "crowd";
			s = "corner";
			d = "station";
			isHurt = false;
			break;
		case "door":
			if (unlocked != true) 
			{
				dialog = "The door is locked and the lock looks\ncompletely rusted. The henges also apear to be\nbusted and the window is craked.\n(a) Check Pockets\n(d) Atempt to break in\n(s) To go back\n";
				w = current;
				a = "inventD";
				s = "store";
				d = "break-in";
			}
			else {
				dialog = "(w) Enter\n";
				w = "unlocked";
				a = current;
				s = current;
				d = current;
			}
			break;
		case "inventD":
			if (hasKey == true || hasGun == true) 
			{
				if (hasKey == true && hasGun == true)
				{
					dialog = "(a) Use Key\n(d) Use Gun\n";
					w = current;
					a = "unlocked";
					s = current;
					d = "shot door";
				}
				else if (hasKey == true)
				{
					dialog = "(a) Use Key\n";
					w = current;
					a = "unlocked";
					s = current;
					d = current;
				}
				else if (hasGun == true)
				{
					dialog = "(d) Use Gun\n";
					w = current;
					a = current;
					s = current;
					d = "shot door";
				}
			}
			else
			{
				dialog = "(s) To go back\n";
				w = current;
				a = current;
				s = "door";
				d = current;
			}
			break;
		case "unlocked":
			unlocked = true;
			dialog = "A warm draft brushes by you as you\nopen the door. The inside of the shop is\npitch black making it impossble to see.\n(w) Enter shop\n(s) To go back\n";
			w = "shop";
			a = current;
			s = "store";
			d = current;
			break;
		case "break-in":
			dialog = "You try to break-in and feel the door\ngetting looser. One more nudge\nshould do it.\n(w) To break the door\n(s) To give up\n";
			w = "alarm";
			a = current;
			s = "store";
			d = current;
			break;
		case "alarm":
			if (!alarm) 
			{
				sfx.volume = .2f;
				sfx.PlayOneShot(sfx_siren);
				alarm = true;
			}
			dialog = "You trigger the alarm a red light blares\nabove you and sirens echo out.\n(s) Runaway\n";
			w = current;
			a = current;
			s = "darkness";
			d = current;
			isHurt = false;
			break;
		case "shop":
			dialog = "You can't seem to find a light switch\nand you begin to hear rats scurrying\nacross the floor\n(w) Risk the darkness\n(s) Leave";
			w = "dark";
			a = current;
			s = "store";
			d = current;
			break;
		case "dark":
			dialog = "You fumble around in the darkness\nuntill you find a door to the back room.\nWhich, surprisingly is unlocked.\n(w) Enter\n(s) Leave";
			w = "back room";
			a = current;
			s = "store";
			d = current;
			break;
		case "back room":
			if (prior != "exit")
			{
				dialog = "As you enter the room you notice a candle\nflikckering on a desk. Next to the candle\nis a dimly lit news article and a pay phone.\n(a) Read it\n(s) Use phone\n(d) Search the desk";
				w = current;
				a = "read";
				d = "search";
				s = "phone";
			}
			else
			{
				dialog = "The candle on the desk flikckers wildly.\nNext to the candle is a dimly lit news article.\n(a) Read it\n(d) Use secret passage";
				w = current;
				a = "read";
				d = "secret";
				s = current;
			}
			break;
		case "search":
			if (prior != "new")
			{
				dialog = "The draws are jamed shut and\nwhen you attempted to use the key\nit broke inside the lock.\n(s) Back out";
				w = current;
				a = current;
				d = current;
				s = "back room";
				hasKey = false;
			}
			else
			{
				dialog = "You see a switch\n(w) Use it";
				w = "exit";
				a = current;
				d = current;
				s = current;
			}
			break;
		case "exit":
			dialog = "A latch drops down on the floor\nrevealing a hidden cavern.\n(w) Go in\n(s) Back out";
			w = "secret";
			a = current;
			d = current;
			s = "back room";
			prior = "exit";
			break;
		case "secret":
			if (!found) 
			{
				sfx.volume = .2f;
				sfx.PlayOneShot(sfx_static);
				found = true;
			}
			dialog = "You gather all the supplies you can find\nand enter the chamber. You hear a faint\nradio signal playing in the distance...\n‘Be on the lookout for a tall, atheltic built,\ndark haired woman. Local mercenaries\nproclaim the fugitive Sara Withers as the\napparent cause of Little Rock nuclear fallout\n7 years ago.'\n'Status: Still at large'\n'Threat Level: Kill on sight'\n'Secret' ending. Press Any Key to Continue";
			if (Input.anyKeyDown)
			{
				current = "End";
			}
			break;
		case "phone":
			if (hasMoney == true)
			{
				current = "new";
			}
			else
			{
				dialog = "It doesn't work.\n(s) Back out";
				w = current;
				a = current;
				d = current;
				s = "back room";
			}
			break;
		case "new":
			dialog = "You insert a couple of coins but\ninstead of hearing a dial tone\nthe desk draw pops open\n(s) Back out";
			w = current;
			a = current;
			d = current;
			s = "back room";
			hasMoney = false;
			prior = "new";
			break;
		case "read":
			dialog = "You read the article and realize it's about you...\n‘Sara Withers missing. Last seen driving a silver\nsedan off Route 40, 7 years ago. Local officers\nclaim said sedan, crashed across the street\nform 'Luckies Pawnshop' then said person,\nas described by local eye witnesses, climbed\n out of said vehicle in a panicked state.\nMs. Withers apparently then disappeared\ninto the back ally never to be seen again.\nSurprisingly only a few minutes later\n did Little Rock suffer from a nuclear flash.\nWhipping out 87.6 percent of the city's\npopulation. Origin of explosion unknown...'\n'Truth' ending\tPress Any Key to Continue";
			if (Input.anyKeyDown)
			{
				current = "End";
			}
			break;
		case "station":
			prior = "station";
			dialog = "Your a few blocks away from the\npolice station now. You also notice\na bum on the street.\n(w) Go to station\n(d) Head towards the bum\n(s) To go back to pawn shop\n";
			w = "outside station";
			a = current;
			d = "bum";
			s = "store";
			break;
		case "bum":
			if (hasFought != true) 
			{
				dialog = "You crossed paths with a hobo on the street.\nHe's covered in newspapers fast asleep.\nYou happen to spy a cash box next to him.\n(a) Steal the box\n(d) Leave him alone\n(s) To go back\n";
				w = current;
				a = "steal";
				d = "station";
				s = prior;
			}
			else
			{
				dialog = "You see the bum on the floor.\n(s) To go back";
				w = current;
				a = current;
				s = "station";
				d = current;
			}
			isHurt = false;
			break;
		case "outside station":
			if (hasGun != true) 
			{
				dialog = "You go to the police station but\nit seems abandon.You find a gun\non the steps though it looks empty.\n(a) Take it\n(d) Leave\n";
				w = current;
				a = "weapon";
				s = current;
				d = "station";
			}
			else
			{
				dialog = "You go to the police station but\nit seems abandon.\n(d) Leave\n";
				w = current;
				a = current;
				s = current;
				d = "station";
			}
			isHurt = false;
			break;
		case "weapon":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Build);
				isHurt = true;
			}
			dialog = "You examined the gun and discover it\nonly has one bullet left. You holster\nthe gun to your back.\n(s) Continue";
			hasGun = true;
			w = current;
			a = current;
			s = "outside station";
			d = current;
			break;
		case "steal":
			dialog = "You tried to steal from the bum but\nyou were caught! The hobo jumps up\nand grabs you by the neck!\n(a) Talk him down\n(s) Challenge him\n(d) Fight\n";
			w = current;
			a = "talk down";
			s = "challenge";
			d = "fight";
			break;
		case "challenge":
			dialog = "You challenge the bum to a game\nof rock paper scissors.\n(a) Rock\n(s) Paper\n(d) Scissors";
			w = current;
			a = "rock";
			s = "paper";
			d = "scissors";
			break;
		case "rock":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (randomizer > 5)
			{
				current = "GG";
			}
			else
			{
				current = "best";
			}
			break;
		case "paper":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (randomizer > 5)
			{
				current = "GG";
			}
			else
			{
				current = "best";
			}
			break;
		case "scissors":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (randomizer > 5)
			{
				current = "GG";
			}
			else
			{
				current = "best";
			}
			break;
		case "GG":
			dialog = "You lost the game and your chance\nat getting the money.\n(s) Leave\n";
			hasFought = true;
			w = current;
			a = current;
			s = "bum";
			d = current;
			break;
		case "best":
			dialog = "You won! The hobo reluctantly hands\nover the box and is now depressed.\n(s) Leave\n";
			hasFought = true;
			hasMoney = true;
			w = current;
			a = current;
			s = "bum";
			d = current;
			break;
		case "talk down":
			dialog = "You convince the bum to back off\nbut you gave up your chance at\ngetting the money.\n(s) Leave\n";
			hasFought = true;
			w = current;
			a = current;
			s = "bum";
			d = current;
			break;
		case "fight":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (hasGun == true)
			{
				dialog = "(a) Use Gun\n(d) Don't use Gun\n";
				w = current;
				a = "kill";
				s = current;
				d = "fight2";
			}
			else
			{
				if (hurt > 30)
				{
					if (!isHurt) 
					{
						sfx.volume = .3f;
						sfx.PlayOneShot(sfx_Jolt);
						isHurt = true;
					}
					dialog = "You were too badly injured\nand lost the fight.\n'Bad' ending.\n(s) Continue\n";
					w = current;
					a = current;
					s = "title";
					d = current;
				}
				if (hurt > 10 && hurt <= 30)
				{
					if (randomizer >= 5)
					{
						current = "won";
					}
					else 
					{
						current = "beaten";
					}
			
				}
				if (hurt < 10)
				{
					if (randomizer >= 2 )
					{
						current = "won";
					}
					else 
					{
						current = "unfortunate";
					}
					
				}
			}
			break;
		case "fight2":
			randomizer = Random.Range(0,10);
			Debug.Log (randomizer);
			if (hurt > 30)
			{
				if (!isHurt) 
				{
					sfx.volume = .3f;
					sfx.PlayOneShot(sfx_Jolt);
					isHurt = true;
				}
				dialog = "You were too badly injured\nand lost the fight.\n'Bad' ending.\n(s) Continue\n";
				w = current;
				a = current;
				s = "title";
				d = current;

			}
			if (hurt > 10 && hurt <= 30)
			{
				if (randomizer >= 5)
				{
					current = "won";
				}
				else 
				{
					current = "beaten";
				}
				
			}
			if (hurt < 10)
			{
				if (randomizer >= 2 )
				{
					current = "won";
				}
				else 
				{
					current = "unfortunate";
				}
				
			}	
			break;
		case "kill":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Jolt);
				isHurt = true;
			}
			dialog = "You killed him... But for what?\n(s) Continue";
			hasFought = true;
			hasGun = false;
			w = current;
			a = current;
			s = "bum";
			d = current;
			break;
		case "won":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Jolt);
				isHurt = true;
			}
			dialog = "You barely made it out. You knocked\nhim unconcious and stole the cash box.\n(s) Continue\n";
			w = current;
			a = current;
			s = "bum";
			d = current;
			hasFought = true;
			hurt += 20;
			hasMoney = true;
			break;
		case "beaten":
			dialog = "You were badly injured\nand lost the fight.\n'Bad' ending.\n(s) Continue\n";
			w = current;
			a = current;
			s = "title";
			d = current;
			hasGun = false;
			hasKey = false;
			hurt = 5;
			break;
		case "unfortunate":
			dialog = "You were hit by a cheap shot\nand lost the fight.\n'Unfortunate' ending.\n(s) Continue\n";
			w = current;
			a = current;
			s = "title";
			d = current;
			hasGun = false;
			hasKey = false;
			hurt = 5;
			break;
		case "crowd":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Jolt);
				isHurt = true;
			}
			dialog = "You aproached a group of figures but\nyou realize that they are only shadows.\nBut casted from where? You start to\npanic a little, confused by what your seeing.\n(w) Examine the scene\n(s) Get out of here\n";
			w = "car";
			a = current;
			s = "street";
			d = current;
			break;
		case "car":
			dialog = "You look at a silver sedan and notice\nthat the metal is warped and rusted.\nAlso the tires were striped and the\nmirrors removed. But by who?\nThe ground is sinking a little bit too.\n(s) To go back";
			w = current;
			a = current;
			s = "crowd";
			d = current;
			break;
		case "darkness":
			if (!isHurt) 
			{
				sfx.volume = .3f;
				sfx.PlayOneShot(sfx_Build);
				isHurt = true;
			}
			dialog = "You break out into a sprint only to be\ntagged by a bullet. You drop to the floor\nbleeding out. A squad of soilders converge\non your location and capture you. You never\nlearned the truth.\n'Dark' ending. Press Any Key to Continue";
			if (Input.anyKeyDown)
			{
				current = "title";
			}
			break;
		case "End":
			dialog = "The End... So far.";
			if (Input.anyKeyDown)
			{
				current = "title";
			}
			break;
		default:
			break;
		}

		if (w != "" || a != "" || s != "" || d != "") 
		{
			if(Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W))
			{
				current = w;
			}
			else if(Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A))
			{
				current = a;
			}
			else if(Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S))
			{
				current = s;
			}
			else if(Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D))
			{
				current = d;
			}
		}
		GetComponent<TextMesh> ().text = dialog;
// 		(Input.anykeydwon)
//		if(start == "cell")
//		{
//			GetComponent<TextMesh> ().text = "You are lost.\n" + "Go forward";
//
//			if(Input.GetKeyDown (KeyCode.W)){
//				start = "door";
//			} 
//
//		}
//		else if(start == "door")
//		{
//			GetComponent<TextMesh> ().text = "Nice you found a door.\n" + "Good luck!";
//			if(Input.GetKeyDown (KeyCode.S))
//			{
//				start = "cell";
//			}
//		}
	}
}
