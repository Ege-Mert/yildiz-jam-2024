using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour
{
    public TMP_Text[] godSpeech;
    public TMP_Text Gsodtext;
    public List<Scobj> scriptableObj;
    public List<Scobj> Randomize;
    public List<int> missionNums;  
    public int  level, Lenght, DeletedInt, CompleteInt, Wrong;
    public Image GodScene;
     public bool NextRound;
    public Card card;

    //Kart sırası
    public static int cardcomingNum = 0;
    public void CardControl(int cardNo)
    {
        bool isthere=false;
        for(int i=0;i<missionNums.Count;i++)
        {
            if(cardNo==missionNums[i])
            {
                CompleteInt+=1;
                isthere=true;
            }
           
        }
        if(!isthere)
        {
            Wrong+=1;
        }
    }

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
        if(scriptableObj.Count>1)
        {
              for(int i=0;i<scriptableObj.Count;i++)
            {   
             if(numOfCard == scriptableObj[i].CardNo)
             {
                scriptableObj.RemoveAt(i);
               
             }
            
       
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
      
        
       
       
    }
    public void MissionTaker()
    {
          godSpeech[0].text = "";
          godSpeech[1].text = "";
          godSpeech[2].text = "";
          missionNums.Clear();
          switch(level)
          {
            case 1: Lenght = Random.Range(1,3);  ; break;

            case 2:/*bir önceki görevin şartları olursa level 2 yi başlatsın yoksa  restart*/ Lenght = Random.Range(1,3); CompleteInt = Lenght;break;

            case 3: Lenght = Random.Range(1,3); ; break;
            case 4: Lenght = Random.Range(1,3); ; break;

            case 5: SceneManager.LoadScene(0); cardcomingNum=0; break;

          }
           

        for (int j =0; j < Lenght; j++)
        {
          Scobj Rand = scriptableObj[Random.Range(0,scriptableObj.Count)];
 
            while (missionNums.Contains(Rand.CardNo))
            {
                Rand = scriptableObj[Random.Range(0,scriptableObj.Count)];
                 
            }
            missionNums.Add(Rand.CardNo);
            godSpeech[j].text = Rand.Mininfo;
          
         
        }
        // not gelir
        
           
   
    
    }

    // guncel kartin bilgilerini aktif edecek scripte taşı
    public void IndexGoesToCard()
    {
        
        
        

        if(cardcomingNum < Randomize.Count)
        {
         card.Kart(Randomize[cardcomingNum]);    
        }
        else
        {
            // günlük görev çıktıları

            NewSahne();
        }
    }

   
   // new sahne koşul bağlaması yapılıcak
   public void NewSahne()
   {


    //görev yanlış olursa
   
    //görev doğru olursa
    if(CompleteInt==Lenght && Wrong<3)
    {
        //aferim
       StartCoroutine(GodWillCome());
    }
     else
    {
        StartCoroutine(GodWillBlameYou());
    }
    

   }
   IEnumerator GodWillCome()
   {
    GodScene.transform.DOScale(1,0.25f);
    GodScene.transform.DORotate(new Vector3(0,0,360*4),0.5f,RotateMode.FastBeyond360);
    card.Guncelle();
     yield return new WaitForSeconds(1f);
    Gsodtext.text="Aferim Öldürülmesi gerekenleri öldürmüşsün";
    yield return new WaitForSeconds(2f);

    
    
    GodScene.transform.DOScale(0,0.25f);
    GodScene.transform.DORotate(new Vector3(0,0,-360*4),0.5f,RotateMode.FastBeyond360);
    yield return new WaitForSeconds(0.5f);
     RandomizeRoundStarter();
   }
   IEnumerator GodWillBlameYou()
   {
    GodScene.transform.DOScale(1,0.5f);
    GodScene.transform.DORotate(new Vector3(0,0,360*4),0.5f,RotateMode.FastBeyond360);
    cardcomingNum = 0;
    card.Guncelle();
    yield return new WaitForSeconds(1f);

    Gsodtext.text = "Bu ne rezaletdir böyle mi dedim ben !!";
    yield return new WaitForSeconds(1f);
    GodScene.transform.DOScale(0,0.5f);
    GodScene.transform.DORotate(new Vector3(0,0,360*4),0.1f,RotateMode.FastBeyond360);
    
    yield return new WaitForSeconds(0.2f);

      SceneManager.LoadScene(0);
   }
   //Kartları rastgelekar Randomize yap
    public void RandomizeRoundStarter()
    {
        cardcomingNum = 0;
        CompleteInt=0;
        Wrong=0;

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
     card.Guncelle();
    }
    

}
