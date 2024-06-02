using UnityEngine;

public class Combate : MonoBehaviour
{
    public int VidaArturo;

    GameObject Yerik;

    yerik yerikScript;
    void Start()
    {
        VidaArturo = 100;
        Yerik = GameObject.Find("Yerik_3D");
        yerikScript = Yerik.GetComponent<yerik>();

    }

    // Update is called once per frame
    void Update()
    {
        VidaArturo = yerikScript.VidaArturo;

        //Debug.Log("vida de artura " + VidaArturo);

        if (VidaArturo < 0 )
        {
            //Debug.Log("Arturo ha muerto");
        }
    }
}
