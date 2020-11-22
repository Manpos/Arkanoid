using UnityEngine;
using UnityEngine.Events;

namespace Physics
{
    public class PhysicsManager : MonoBehaviour
    {
        public static UnityEvent OnPhysics;
    
        void Awake()
        {
            OnPhysics = new UnityEvent();
        }

        // Update is called once per frame
        public void UpdatePhysics()
        {
            OnPhysics.Invoke();
        }
    }
}
