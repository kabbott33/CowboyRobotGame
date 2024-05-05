using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float explosionForce;           //When exactly at runtime are these explosionForce and explosionRadius variables being set?   A: These variables are being set during the "ThrowGrenade" method in the grenade thrower script, immediately after the left mouse button has been pressed and a grenade has been instantiated.
    private float explosionRadius;          //Extra Credit: Why would we want to set these variables in this way at runtime? Hint: There may be multiple answers.   A: This way, the values from the grenade can be adjusted within the grenade thrower script without having to be adjusted in the grenade prefab itself, which is especially useful if these variables change during gameplay and the grenades have to act accordingly. 

    public void Initialize(float eF, float radius)
    {
        explosionForce = eF;
        explosionRadius = radius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] objectsHit = Physics.OverlapSphere(this.transform.position, explosionRadius);    //What does this Physics.OverlapSphere function do, and what do the passed variables represent in the function?   A: Physics.OverlapSphere creates a spherical collider centered on this.transform.position with the radius explosionRadius that returns every collider overlapping the spherical collider in an array.
        //What does the [] mean above in Collider[]?  Hint: Array (What does it being an array mean?)   A: The brackets mean that every collider hit by the Physics.OverlapSphere function are stored in a single variable, called an array. This lets the script efficiently access each of the hit colliders later on.

        for (int i = 0; i < objectsHit.Length; i++)     //How many times does this for loop go through?   A: The loop happens for every collider hit by the Physics,OverlapSphere function. If three objects with colliders are hit, it will run three times (or, more accurately, it will run once FOR each of the three objects).
        {
            if (objectsHit[i].CompareTag("Destructible"))
            {
                Destroy(objectsHit[i].gameObject);      //What object is being destroyed here?   A: Any objects overlapping with the sphereical collider that are tagged as "Destructible" are destroyed.
            }
            else
            {
                if (objectsHit[i].attachedRigidbody != null)    //Why would we need to check if this attachedRigidbody is null before the next line?   A: Without this line we would get a null reference exception error on any elements hit that didn't have a rigidbody (like the ground, for instance). This way we only try to add force to objects that have a rigid body and are therefore not null.
                {
                    objectsHit[i].attachedRigidbody.AddExplosionForce(explosionForce, this.transform.position, explosionRadius);    //Which component does the "AddExplosionForce()" function run from? A: This runs from the Rigidbody component of whatever is being pushed by the explosion.
                    //Extra Credit: There's an issue with the logic in this AddExplosionForce. It works, but doesn't work right... What is the issue, and how do you fix it?  Hint: The grenade is the thing exploding, right?   A: Currently the explosion position is the transform of the rigid body being hit, Instead it should be that of the grenade (this.transform.position).
                }
            }
        }

        Destroy(this.gameObject);   //If you comment this out, what happens? Hint: Just comment it out and check it out lol   A: Commenting this line out stops the grenade from ever being destroyed, causing it to bounce around forever and explode every time it hits the ground.
    }
}
