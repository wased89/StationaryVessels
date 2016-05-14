using UnityEngine;

namespace StationaryVessels
{
    public class StationaryVesselModule : VesselModule
    {
        private Vessel vessel;
        [Persistent]
        public static bool isFrozen;

        public bool getFrozen()
        {
            return isFrozen;
        }
        public void Start()
        {
            Debug.Log("StationaryStart");
            vessel = GetComponent<Vessel>();
            if(!vessel.isEVA)
            foreach(Part p in vessel.parts)
            {
                if(p.Modules.Contains("ModuleCommand") && !p.Modules.Contains("StationaryModule"))
                {
                    p.AddModule("StationaryModule");
                }
            }
        }

        public void FreezeVessel()
        {
            foreach (Part p in vessel.parts)
            {
                if (p.GetComponent<Rigidbody>() == null) { continue; }
                p.GetComponent<Rigidbody>().isKinematic = true;

            }
        }
        public void UnFreezeVessel()
        {
            foreach (Part p in vessel.parts)
            {
                if (p.GetComponent<Rigidbody>() == null) { continue; }
                p.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        public void toggleFrozen()
        {
            isFrozen = !isFrozen;
        }
    }
}
