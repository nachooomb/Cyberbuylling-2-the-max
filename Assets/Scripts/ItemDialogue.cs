using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemDialogue : MonoBehaviour
{

    public GameObject Arturo;

    private NavMeshAgent ArturoNavMesh;

    public Animator ArturoAnim;

    private ClickAndMove clickAndMove;

    private DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        ArturoNavMesh = Arturo.GetComponent<NavMeshAgent>();
        ArturoAnim = Arturo.GetComponent<Animator>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //clickAndMove.GoDestination(transform.position);
        // if(ArturoNavMesh.remainingDistance>=0.5){
        //     ArturoAnim.SetBool("walkb", true);
        // }else{
        //     ArturoAnim.SetBool("walkb", false);
        //     //StartCoroutine(timeCorrutina());
        //    dialogueTrigger.TriggerDialogue();

        // }
    }

   /* IEnumerator timeCorrutina()
    { 
        yield return new WaitForSeconds(2.0f);
        dialogueTrigger.TriggerDialogue();
    }
*/

}
