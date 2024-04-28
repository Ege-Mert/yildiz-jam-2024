using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   public AudioMixer audioMixer;
   public GameObject Cre;
   bool credits;
   public void StartButton(){
      SceneManager.LoadScene(1);
   }
   public void BackToTheMenu(){
      SceneManager.LoadScene(0);
   }
   
   public void SetVolume(float volume){
      audioMixer.SetFloat("volume", volume);
   }
      
   public void setActive()
   {
    credits=!credits;
    if(credits)
    {
        Cre.SetActive(true);
    }
    else
    {
        Cre.SetActive(false);
    }
   }
   
   public void QuitButton(){
      Application.Quit();
   }
}
