using UnityEngine;

namespace Combat.Guns
{
    public sealed class GunView : MonoBehaviour, IGunView
    {

        public void OnDirectionChanged(Vector3 direction)
        {

            //#TODO magic code here

            Vector3 lookingDir = direction - transform.position;

            float angle = Mathf.Atan2(lookingDir.z, lookingDir.x) * Mathf.Rad2Deg + 180;
            

            Quaternion rotation = Quaternion.Euler(-90, -angle, 0f);
            
            transform.rotation = rotation;
        }
    }
}
