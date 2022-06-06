using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using LootLocker.Requests;

public class ScoreSystem : MonoBehaviour

{

 [Header("Sistem")]
 private WhiteLabelManager ID;
 public string leaderboardID = "2458";
 int memberID;
 public TMP_Text ScoreText;
 Coroutine test;
 public int ScoreNumber = 0; 
 public GameObject Karakter;


 [Header("Sesler")]
public AudioSource TrueAudio;
public AudioSource FalseAudio;


 [Header("Sorular")]
public GameObject Soru1;
public GameObject Soru2;
public GameObject Soru3;



  [Header("Cevaplar")]
public GameObject Cevap1;
public GameObject Cevap2;
public GameObject Cevap3;



  
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TrueAnswer()
    {
        ScoreNumber += 10;
        
        TrueAudio.Play();
        Karakter.GetComponent<Animator>().Play("yes");
        ScoreText.text = ScoreNumber.ToString();
        
    
      
        test = StartCoroutine (CoroutineTest ());
       
    }

  public void FalseAnswer()
    {
                
        FalseAudio.Play();
        Karakter.GetComponent<Animator>().Play("no");


        test = StartCoroutine (CoroutineTest ());
       
    }

   IEnumerator CoroutineTest()
{
    
        yield return new WaitForSeconds( 1f );  // 1 saniye bekle
    


    if(Soru1.activeSelf)
    {
        Soru1.SetActive(false);
        Cevap1.SetActive(false);

        Soru2.SetActive(true);
        Cevap2.SetActive(true);
    }

   else if(Soru2.activeSelf)
    {
        Soru2.SetActive(false);
        Cevap2.SetActive(false);

        Soru3.SetActive(true);
        Cevap3.SetActive(true);
    }
       
}




public void ScoreSend()
{
  
     LootLockerSDKManager.SubmitScore( "memberID" , ScoreNumber, leaderboardID , (response) =>
      
        {
           if(response.success)
          {
               Debug.Log("Skor Gönderildi");
         }
          else
          {
             Debug.Log("Skor Gönderilemedi");
         }
       }
       );
    
}


 void IDControl()
     {
         ID.playerId = memberID.ToString();

          Debug.Log(ID.playerId);
     }
    




}
