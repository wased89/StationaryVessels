using UnityEngine;

namespace StationaryVessels
{
    public class StationaryModule : PartModule
    {
        [Persistent]
        private static bool isFrozen;
        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "isFrozen: false")]
        public void ToggleFreeze()
        {
            isFrozen = !isFrozen;
            Events["ToggleFreeze"].guiName = isFrozen ? "isFrozen: true": "isFrozen: false";
            Debug.Log("IsFrozen: "+ isFrozen);
        }

        [KSPAction("Toggle Freeze")]
        public void ToggleFreezeAction(KSPActionParam param)
        {
            ToggleFreeze();
        }
        public void FixedUpdate()
        {
            Debug.Log("FixedUpdate");
            if(isFrozen && !vessel.isEVA)
            {
                foreach (Part p in vessel.parts)
                {
                    if (p.GetComponent<Rigidbody>() == null) { continue; }
                    p.GetComponent<Rigidbody>().isKinematic = true;
                    Debug.Log("Freezing part");
                }
            }
        }
    }
}
