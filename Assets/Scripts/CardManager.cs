using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    
    public List<Scobj> scriptableObj;
    public List<Scobj> Randomize;
    public List<int> missionNums;  
    public int  level, Lenght,DeletedInt;

     
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
    public void DeleteCard(int numOfCard)
    {
        for(int i=0;i<scriptableObj.Count;i++)
        {
             if(numOfCard==scriptableObj[i].CardNo)
             {
                scriptableObj.RemoveAt(i);
               
             }
        }
        
       
       
    }
    public void MissionTaker()
    {
          switch(level)
          {
            case 1: Lenght = Random.Range(1,4);break;

            case 2: Lenght = Random.Range(1,4);break;

            case 3: Lenght = Random.Range(1,4);break;

            case 4: Lenght = Random.Range(1,4);break;

          }
           
      
        for (int j =0; j < Lenght; j++)
        {
          Scobj Rand = scriptableObj[Random.Range(0,scriptableObj.Count)];
 
            while (missionNums.Contains(Rand.CardNo))
            {
                Rand = scriptableObj[Random.Range(0,scriptableObj.Count)];
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

        case 6: card.Kart(Randomize[6]); break;

        case 7: card.Kart(Randomize[7]); break;

        case 8: card.Kart(Randomize[8]); break;
        
        case 9: card.Kart(Randomize[9]); break;

        case 10: card.Kart(Randomize[10]); break;
    
        case 11: card.Kart(Randomize[11]); break;

        case 12: card.Kart(Randomize[12]); break;

        case 13: card.Kart(Randomize[13]); break;

        case 14: card.Kart(Randomize[14]); break;

        case 15: card.Kart(Randomize[15]); break;
        
        case 16: card.Kart(Randomize[16]); break;

        case 17: card.Kart(Randomize[17]); break;
    
        case 18: card.Kart(Randomize[18]); break;

        case 19: card.Kart(Randomize[19]); break;

     }


    }
   
   public void NewSahne()
   {
    RandomizeRoundStarter();

   }
   //Kartları rastgelekar Randomize yap
    public void RandomizeRoundStarter()
    {
        cardcomingNum = 0;

        Randomize.Clear();

       for (int i = 0; i <scriptableObj.Count; i++)
        {
             Scobj Rand = scriptableObj[Random.Range(0,scriptableObj.Count)];
 
            for (int j = 0; j < i; j++)
            {
                while ( Randomize.Contains(Rand))
                {
                    Rand = scriptableObj[Random.Range(0,scriptableObj.Count)];
                }
            }
 
            Randomize.Add(Rand);
            
    }
     MissionTaker();
     IndexGoesToCard();
    }
    

}
