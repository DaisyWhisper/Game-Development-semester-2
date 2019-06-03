using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GemSpawn : MonoBehaviour
{
    int gems = 0;
    [SerializeField]
    private GameObject box;
    public GameObject collectedGem;
    GameObject collectedGemClone;
    public TextMeshProUGUI GemText;
    public Transform GemPos;
    public bool holdingGem;


    private void Start()
    {
        UpdateText("Gems:"+ gems +"/5");                               // Set UI text to "Gems 0/5" on start
    }


    private void OnTriggerEnter(Collider other)                           
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag=="Collectable" && !holdingGem)        // if the item collided with is tagged 'Collectable' and currently not holding a gem 
        {
            other.gameObject.transform.SetParent(GemPos);              // get reference for the gem(other.gameobject) and assign it as a child of GemPos so it inherits the position of GemPos
            other.gameObject.transform.localPosition = Vector3.zero;   // sets position as the same as GemPos in local space
			holdingGem = true;                                         // changes holdingGem from false to true
        }
    }


    void BoxRange()
    {

        if (Vector3.Distance(transform.position, box.transform.position) < 5)           
        {
            if (holdingGem)
            {
                gems++;
                UpdateText("Gems: " + gems + "/5");
                collectedGemClone = Instantiate(collectedGem, box.transform.position + new Vector3(-2, 3, -1f * gems), Quaternion.identity) as GameObject;
                collectedGemClone.tag = "Untagged";
                {
                    if (gems == 5)
                    {
                        UpdateText("You Win!");
						Invoke ("goToEnd", 10f);
                    }
                }
                holdingGem = false;
                Destroy(GemPos.GetChild(0).gameObject);
            }
        }
    }


    void Update()
    {
        BoxRange();
    }


    void UpdateText(string input)
    {
        GemText.text = input;
    }

	void goToEnd(){
		SceneManager.LoadScene (3);
	}
}
