using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;
public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text cardName, cardText, cardJob, NumText;
    public Image cardImage, Hand;
    public int alo;
    public AudioSource Sound;
    public AudioClip[] Sfx;
     public AudioClip[] SfxNingen;
    public CardManager cardManager;
    public int CardNo;
    public bool ButtonOpen;

    //güncel şuanda seçim yaptığımız kartın bilgilerini aktif et 
    public void Start()
    {
        cardImage.DOFade(1,0.1f);
    }
    public void Kart(Scobj Giving)
    {
        // kart gerekli konuma gelir ve dönerek bunu yapar
        Sound.PlayOneShot(Sfx[0]);

        StartCoroutine(Speech());
        
        this.transform.DOLocalMoveX(0,0.3f);
        this.transform.DORotate(new Vector3(0,0,360),0.3f,RotateMode.FastBeyond360);
        this.transform.DOScale(1,0.3f);

        cardJob.text = Giving.cardJob;

        cardName.text = Giving.cardName;

        cardText.text = Giving.cardInfo;

        cardImage.sprite = Giving.CharacterFoto;
         
        CardNo = Giving.CardNo;
    }
    public IEnumerator Speech()
    {
        yield return new WaitForSeconds(0.5f);
        Sound.PlayOneShot(SfxNingen[Random.Range(0, SfxNingen.Length)]);
    }
    //karti yaşat
    public void Idle()
    {
          Hand.transform.DOLocalMove(new Vector2(800,-145), 0.2f);
            Hand.transform.DOScale(1f,0.2f);
    }

    public void lofe()
    {
          Hand.transform.DOLocalMove(new Vector2(-260,-200), 0.2f);
            Hand.transform.DOScale(new Vector2(-0.7f,0.7f),0.2f);
    }
     public void dead()
    {
           Hand.transform.DOLocalMove(new Vector2(260,-200), 0.2f);
            Hand.transform.DOScale(0.7f,0.2f);
    }

    public void Life()
    {
         if(ButtonOpen)
        {
            
           
             Sound.PlayOneShot(Sfx[1]);
             StartCoroutine(nextCardAnimation());
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
                 Sound.PlayOneShot(Sfx[1]);
                cardManager.DeleteCard(CardNo);
                cardManager.CardControl(CardNo);
                StartCoroutine(nextCardAnimation());
                
          
        }
        
      
    }
    IEnumerator nextCardAnimation()
    {
       
        // kart savrulur gider ya da çözünür
         
        this.transform.DOLocalMoveX(1500,0.5f);
        this.transform.DORotate(new Vector3(0,0,360),0.5f,RotateMode.FastBeyond360);
        this.transform.DOScale(0,0.5f);
        CardManager.cardcomingNum += 1; 
        yield return new WaitForSeconds(0.5f);

        ButtonOpen=true;
        nextCard();
         
        
    }
    public void Guncelle()
    {
           alo=CardManager.cardcomingNum;
         NumText.text=(alo+1)+"/"+(cardManager.Randomize.Count);
    }
    // kartı öldür ya da öldürme dediğimizde BirSonrakiKartıSeçme
    public void  nextCard()

    {
        cardManager.IndexGoesToCard();
         
        alo = CardManager.cardcomingNum;
        NumText.text=(alo+1)+"/"+(cardManager.Randomize.Count);

    }
}
