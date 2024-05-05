using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab;

    public Transform grenadeSpawnLocation;      //Why might we want to have a grenade spawn location that isn't on "this.transform.position"?   A: We want it written this way so we can have flexibility about where we add this script.
                                                //If the grenade was spawned at 'this.transform.position' it would be spawned in the center of the player character's capsule collider.
                                                //Without a discrete transform that is a child of the player's camera, we would have to put this grenade thrower script on the grenade spawn point itself.

    [SerializeField] private float grenadeExplosionRadius = 5f;
    [SerializeField] private float grenadeExplosionForce = 15f;     //What does this [SerializeField] tag do to the variable that comes after it?   A: The serialized field tag makes private variables accessible in the unity  inspector without having to make them public.

    [SerializeField] private float grenadeThrowPower = 25f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))     //Which button is this?   A: This is the left mouse button.
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()     //When does this function get called?   A: Thus function gets called in Update only if the left mouse button is pressed.
    {
        GameObject go = Instantiate(grenadePrefab, grenadeSpawnLocation.position, this.transform.rotation);      //Please explain what this line does and what assigning it to "GameObject go" lets us do.   A: This line instantiates a grenade prefab  at a specified position and rotation, Assigning it to a local veriable (go) lets us reference and affect it after it has been created.

        go.GetComponent<Grenade>().Initialize(grenadeExplosionForce, grenadeExplosionRadius);

        go.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * grenadeThrowPower);     //What is the point of calling AddForce on the rigidbody of the spawned object?   A: AddingForce causes the instantiated grenade to be thrown forward instead of just falling to the ground at the feet of the player character.
        //Why might we want to add force in the direction of the camera's forward instead of the player's forward?   A: Adding force in the direction of the player's forward would only ever throw the grenade horizontally because the player character's X and Z rotations are locked. Adding force to the camera's forward lets the grenade be thrown up if the player is looking up and down if they're looking down.
    }
}
