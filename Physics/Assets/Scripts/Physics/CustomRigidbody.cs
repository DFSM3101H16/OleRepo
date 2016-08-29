using UnityEngine;


public class CustomRigidbody : MonoBehaviour {

    [SerializeField]
    private RigidbodyProperties properties;
    public RigidbodyProperties Properties {
        private set { properties = value; }
        get { return properties; }
    }


    void Start() {
        /*
            A game object needs a rigidbody for collision detection to work.
            The rigidbody is never used.
        */
        if(GetComponent<Rigidbody>() == null) {
            gameObject.AddComponent<Rigidbody>();
        }
        GetComponent<Rigidbody>().isKinematic = true;
    }
}