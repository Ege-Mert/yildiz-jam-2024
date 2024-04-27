using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    
    public Scobj[] scriptableObj;
    public List<Scobj> Randomize;
    public List<int> missionNums;  
    public int  level, Lenght;

     
    public Card card;

    //Kart sırası
    public static int cardcomingNum = 0;

    public void Start()
    {
    //görev için gerekli kartları gösterir
    MissionTaker();

    //kartlarımız random sekilde karılır ve ilk kart gösterilir kartların gösterimlerinin ilerletilmesi 
    //Card scriptindeki fonksiyondadır
    RandomizeRoundStarter();



    }
    public void MissionTaker()
    {
          switch(level)
          {
            case 1: Lenght = 2;break;

            case 2: Lenght = 2;break;

            case 3: Lenght = 3;break;

            case 4: Lenght = 3;break;

          }
           
      
        for (int j =0; j < Lenght; j++)
        {
          Scobj Rand = scriptableObj[Random.Range(0,scriptableObj.Length)];
 
            while (missionNums.Contains(Rand.CardNo))
            {
                Rand = scriptableObj[Random.Range(0,scriptableObj.Length)];
            }
            missionNums.Add(Rand.CardNo);
          
         
        }
           
   
    
    }

    // guncel kartin bilgilerini aktif edecek scripte taşı
    public void IndexGoesToCard()
    {
     switch(cardcomingNum)
     {
        case 0: card.Kart(Randomize[0]); break;

        case 1: card.Kart(Randomize[1]); break;
        
        case 2: card.Kart(Randomize[2]); break;

        case 3: card.Kart(Randomize[3]); break;
    
        case 4: card.Kart(Randomize[4]); break;

        case 5: card.Kart(Randomize[5]); break;

     }


    }
   
   
   //Kartları rastgelekar Randomize yap
    public void RandomizeRoundStarter()
    {
       for (int i = 0; i <scriptableObj.Length; i++)
        {
             Scobj Rand = scriptableObj[Random.Range(0,scriptableObj.Length)];
 
            for (int j = 0; j < i; j++)
            {
                while ( Randomize.Contains(Rand))
                {
                    Rand = scriptableObj[Random.Range(0,scriptableObj.Length)];
                }
            }
 
            Randomize.Add(Rand);
            
    }
     IndexGoesToCard();
    }
    

}
