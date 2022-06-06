using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;
public class GetNickName : MonoBehaviour
{
    

   private WhiteLabelManager ID;

   public TMP_Text nick;

    string leaderboardID = "2458";
    int memberID;

    private GameObject kullanıcıID;
     private TMP_Text Score;

     private TMP_Text PlayerID;
    
    void Start()
    {

        // ID.playerId = memberID.ToString();
        // //ID = kullanıcıID.GetComponent<WhiteLabelManager> ();
      

      
        LootLockerSDKManager.GetPlayerName((response) =>
        {
            if (response.success)
            {
                nick.text = response.name;
            }

            else
            {
                     Debug.Log("İsim Bulunamadı");
            }
        });




          LootLockerSDKManager.GetMemberRank(leaderboardID, memberID, (response) =>
 {
     if (response.statusCode == 200) {

             Score.text = response.score.ToString();

         Debug.Log("Skor Alındı");   
     } else {
         Debug.Log("failed: " + response.Error);
     }
 });
    
    }


    // Update is called once per frame
    void Update()
    {
        
    }


  void test()
     {
         ID.playerId = memberID.ToString();

          Debug.Log(ID.playerId);
     }
    
}
