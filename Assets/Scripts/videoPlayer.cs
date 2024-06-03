using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.Video;
 
public class videoPlayer : MonoBehaviour {
public VideoPlayer vid;
public VideoClip[] videoclips;
private int videoClipIndex;
GameObject video;
GameObject videoplayer;
GameObject uiexploracion;
GameObject primertexto;
GameObject uicombate;
GameObject textofinal;

 
void Start()
     {
     textofinal.SetActive(false);
     vid.clip = videoclips[0];
     primertexto = GameObject.Find("PrimerTextoInfo");
     textofinal = GameObject.Find("TextoFinal");
     uiexploracion = GameObject.Find("UI exploracion");
     uicombate = GameObject.Find("UI combate");
     video = GameObject.Find ("VIDEO");
     video.SetActive(false);
     videoplayer = GameObject.Find ("VideoPlayer");
     videoplayer.SetActive(false);
     }


public void Empezarelvideo()
{
     video.SetActive(true);
     videoplayer.SetActive(true);
     uiexploracion.SetActive(false);
     vid.loopPointReached += FinIntro;
}

public void FinIntro(UnityEngine.Video.VideoPlayer vp)
{
     print  ("Video Is Over");
     video.SetActive(false);
     uiexploracion.SetActive(true);
     primertexto.GetComponent<DialogueTrigger>().TriggerDialogue();
}

 
public void FinalMalo()
{
      vid.clip = videoclips[1];
      video.SetActive(true);
     videoplayer.SetActive(true);
     uicombate.SetActive(false);
     textofinal.SetActive(false);
     //vid.loopPointReached += FinFinalMalo;
}
public void FinFinalMalo(UnityEngine.Video.VideoPlayer vp2)
{
     Debug.Log("Se acabo mal");
}

public void FinalBueno()
{
      vid.clip = videoclips[2];
      video.SetActive(true);
     videoplayer.SetActive(true);
     uicombate.SetActive(false);
     textofinal.SetActive(false);
     //vid.loopPointReached += FinFinalBueno;
}
public void FinFinalBueno(UnityEngine.Video.VideoPlayer vp3)
{
     Debug.Log("Se acabo bien");
}


 
}