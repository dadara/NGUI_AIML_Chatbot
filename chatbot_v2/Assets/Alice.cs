using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIMLbot;

//namespace Chatbot
public class Alice : MonoBehaviour {

	GameObject inputLabel;
	GameObject janecb;
	UILabel uilab;
	UILabel jane;
	GameObject editBtn;
	UIButtonSound uisound;
	int cursor;
	int cursorMax;
	bool editBtnPressed;

	private Bot myBot;
	private User myUser;
	// Use this for initialization
	void Start () {
		inputLabel = GameObject.Find("InputLabel");
		uilab = inputLabel.GetComponent<UILabel>();
		janecb = GameObject.Find("JaneChatbox");
		jane = janecb.GetComponent<UILabel>();

		editBtn = GameObject.Find ("EditButton");
		uisound = editBtn.GetComponent<UIButtonSound>();
		editBtnPressed = uisound.btnClicked;

		myBot = new Bot();
		myUser = new User("consoleUser", myBot);

		int cnt = 0;
		string path = myBot.loadSettings(cnt);
		Debug.Log("Alice.cs path: "+path);

		myBot.loadSettings();
		myBot.isAcceptingUserInput = false;
		myBot.loadAIMLFromFiles();
		myBot.isAcceptingUserInput = true;

		cursor = 0;
		cursorMax = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if(editBtnPressed!=uisound.btnClicked){
			editBtnPressed = uisound.btnClicked;
			Debug.Log("editBtnPressed: "+editBtnPressed);
		}

		if(uilab.text!=null){
			if(editBtnPressed==false){
				if(Input.GetKeyDown(KeyCode.Return)){

					Debug.Log("keycode is RETURN: ");
					string answerBot = getOutput(uilab.text);

//					if(uilab.text.Length > 1){
//						Debug.Log("I typed: " + uilab.text);
//					}

					uilab.text = "";
					jane.text = "B: "+answerBot;


				} 

				cursorMax = uilab.text.Length-1;
				cursor = cursorMax;

			}else{

				if(Input.GetKeyDown (KeyCode.RightArrow)){
					if(cursor!=cursorMax){
						cursor = cursor + 1;
					}
					Debug.Log("cursor: "+cursor);

				}else if(Input.GetKeyDown (KeyCode.LeftArrow)){
					if(cursor>0){
						cursor = cursor - 1;
					}
					Debug.Log("cursor: "+cursor);
				}


				string replacement = getKeyInput();
				if(!replacement.Equals("no") && uilab.text.Length>0){
					Debug.Log ("replacement: "+replacement);

					string input = uilab.text;

					Debug.Log("input: "+input);

					char[] charinput = input.ToCharArray();
					char[] partChar1 = new char[cursor+1];
					char[] partChar1Del = new char[cursor];
					char[] partChar2 = new char[cursorMax-cursor];


					for(int i=0; i<=cursor; i++){
						Debug.Log ("index: "+i+" cursormax-cursor: "+(cursorMax-cursor)+" cursor: "+cursor);
						partChar1[i]=charinput[i];
						if(i<cursor){
							partChar1Del[i]=charinput[i];
						}
					}
					for(int i=cursor+1; i<=cursorMax;i++){
						Debug.Log ("index: "+i+" cursormax-cursor: "+(cursorMax-cursor)+" cursor: "+cursor);
						partChar2[i-(cursor+1)]=charinput[i];
					}

					string partString1;
					string partString2 = new string(partChar2);

					if(replacement.Equals("")){
						partString1  = new string(partChar1Del);
						input = partString1 + partString2;
					}else{
						partString1  = new string(partChar1);
						input = partString1 + replacement +partString2;
					}
//					input = new string(charinput);
//					Debug.Log("charinput: "+input);
//					Debug.Log("charArrayLength: "+charinput.Length);
//					char testRep = replacement.ToCharArray()[0];
//					charinput[cursor] = replacement.ToCharArray()[0];
//					
					uilab.text = input;

					if(replacement.Equals("")){
						cursorMax = cursorMax-1;
					}else{
						cursorMax = cursorMax+1;
					}
					cursor=cursorMax;

				}
			}


		}
	}

	/// <summary>
	/// This method takes an input string, then finds a response using the the AIMLbot library and returns it
	/// </summary>
	/// <param name="input">Input Text</param>
	/// <returns>Response</returns>
	public string getOutput(string input)
	{
		Request r = new Request(input, myUser, myBot);
		Result res = myBot.Chat(r);
		return(res.Output);
	}

	private string getKeyInput(){
					if(Input.GetKeyDown(KeyCode.A)){
						return "a";
					}else if(Input.GetKeyDown(KeyCode.B)){
						return "b";
					}else if(Input.GetKeyDown(KeyCode.C)){
						return "c";
					}else if(Input.GetKeyDown(KeyCode.D)){
						return "d";
					}else if(Input.GetKeyDown(KeyCode.E)){
						return "e";
					}else if(Input.GetKeyDown(KeyCode.F)){
						return "f";
					}else if(Input.GetKeyDown(KeyCode.G)){
						return "g";
					}else if(Input.GetKeyDown(KeyCode.H)){
						return "h";
					}else if(Input.GetKeyDown(KeyCode.I)){
						return "i";
					}else if(Input.GetKeyDown(KeyCode.J)){
						return "j";
					}else if(Input.GetKeyDown(KeyCode.K)){
						return "k";
					}else if(Input.GetKeyDown(KeyCode.L)){
						return "l";
					}else if(Input.GetKeyDown(KeyCode.M)){
						return "m";
					}else if(Input.GetKeyDown(KeyCode.N)){
						return "n";
					}else if(Input.GetKeyDown(KeyCode.O)){
						return "o";
					}else if(Input.GetKeyDown(KeyCode.P)){
						return "p";
					}else if(Input.GetKeyDown(KeyCode.Q)){
						return "q";
					}else if(Input.GetKeyDown(KeyCode.R)){
						return "r";
					}else if(Input.GetKeyDown(KeyCode.S)){
						return "s";
					}else if(Input.GetKeyDown(KeyCode.T)){
						return "t";
					}else if(Input.GetKeyDown(KeyCode.U)){
						return "u";
					}else if(Input.GetKeyDown(KeyCode.V)){
						return "v";
					}else if(Input.GetKeyDown(KeyCode.W)){
						return "w";
					}else if(Input.GetKeyDown(KeyCode.X)){
						return "x";
					}else if(Input.GetKeyDown(KeyCode.Y)){
						return "y";
					}else if(Input.GetKeyDown(KeyCode.Z)){
						return "z";
					}else if(Input.GetKeyDown(KeyCode.Space)){
						return " ";
					}else if(Input.GetKeyDown(KeyCode.Semicolon)){
						return ";";
					}else if(Input.GetKeyDown(KeyCode.Comma)){
						return ",";
					}else if(Input.GetKeyDown(KeyCode.Question)){
						return "?";
					}else if(Input.GetKeyDown(KeyCode.Exclaim)){
						return "!";
					}else if(Input.GetKeyDown(KeyCode.Period)){
						return ".";
					}else if(Input.GetKeyDown(KeyCode.Delete)){
						return "";
					}else if(Input.GetKeyDown(KeyCode.Backspace)){
						return "";
					}
					
					return "no";
	}


}