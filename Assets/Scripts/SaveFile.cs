using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveFile : MonoBehaviour {
	//make variable call saveScore of SaveFile that only have one
	public static SaveFile saveScore;

	//	public float random = 10;

	void Awake(){
		Debug.Log (Application.persistentDataPath);
		//instantiating saveScore
		saveScore = this;
	}

	public void Save(){

		if(!(File.Exists(Application.persistentDataPath + "/player.dat"))){
			Debug.Log(" should not be running");
			//conversion between binary and language
			BinaryFormatter bf = new BinaryFormatter();
			//create a file
			FileStream file = File.Create(Application.persistentDataPath + "/player.dat");
			//instantiate a Score variable
			Score score = new Score();
			//score = current score from CurrentScore script
			score.score = CurrentScore.currentScore;
			//continue converting between binary and language
			bf.Serialize(file, score);
			file.Close();
		}
		else{

			BinaryFormatter bf = new BinaryFormatter();

			FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);

			Score score = new Score();

			score = (Score) bf.Deserialize(file);

			file.Close();
			//if previous score is less than current score
			if(score.score < CurrentScore.currentScore){
				//create a file
				FileStream file2 = File.Create(Application.persistentDataPath + "/player.dat");
				//score = timer from timer/point
				score.score = CurrentScore.currentScore;
				//
				bf.Serialize(file2, score);
				file2.Close();

			}
		}
	}

	public void load(){

		if(File.Exists(Application.persistentDataPath + "/player.dat")){
			BinaryFormatter bf = new BinaryFormatter();

			FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
			//show where file is stored at on your computer
			Debug.Log(Application.persistentDataPath + "/player.dat");

			Score score = new Score();

			score = (Score) bf.Deserialize(file);

			file.Close();

			HighScore.highscore.setHighScore(score.score);
		}
	}


}
//must tag public class Score serialze 
[Serializable]
public class Score{

	public int score;	
}
