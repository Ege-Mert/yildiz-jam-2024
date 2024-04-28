using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
   public AudioMixer audioMixer;
   public void StartButton(){
      SceneManager.LoadScene(1);
   }
   public void BackToTheMenu(){
      SceneManager.LoadScene(0);
   }
   
   public void SetVolume(float volume){
      audioMixer.SetFloat("volume", volume);
   }
      
   
   
   public void QuitButton(){
      Application.Quit();
   }
}
