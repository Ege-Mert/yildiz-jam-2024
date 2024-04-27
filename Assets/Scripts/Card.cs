using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text cardName,cardText,Hobi,cardJob;
    public Image cardImage;
    public CardManager cardManager;
    public int CardNo;
    public bool ButtonOpen;

    //güncel şuanda seçim yaptığımız kartın bilgilerini aktif et 
    public void Kart(Scobj Giving)
    {
        cardJob.text = Giving.cardJob;

        cardName.text = Giving.cardName;

        cardText.text = Giving.cardInfo;

        Hobi.text = Giving.cardHobi;

        cardImage.sprite = Giving.CharacterFoto;
         
        CardNo = Giving.CardNo;
    }


    //karti yaşat
    public void Life()
    {
         if(ButtonOpen)
        {
             ButtonOpen=false;
         // son kart ise basıldığında ekran kararır görevi yapabildik mi bakılır
        }
    }
     //karti öldür
    public void Death()
    {
        if(ButtonOpen)
        {
            ButtonOpen=false;
            // öldürülen kart scriptableobj dizisinden  çıkarılır dizideki boşluk giderilir
            // öldürülen kartın görev olup olmadığı bakılır görevse int GörevSayac artar deilse yanılgı sayac artar
            // son kart ise basıldığında ekran kararır görevi yapabildik mi bakılır değilse nextCard CAGİRİLİR
            if(CardManager.cardcomingNum < cardManager.Randomize.Count-1)
            {
                StartCoroutine(nextCardAnimation());
                cardManager.DeleteCard(CardNo);
            } 
            else
            {
                //sonuncu kartın şartları girilir
            }
        }
        
      
    }
    IEnumerator nextCardAnimation()
    {
        CardManager.cardcomingNum += 1;
        yield return new WaitForSeconds(1f);
        ButtonOpen=true;
        nextCard();
    }

    // kartı öldür ya da öldürme dediğimizde BirSonrakiKartıSeçme
    public void  nextCard()
    {
      

        cardManager.IndexGoesToCard();
    }
}
