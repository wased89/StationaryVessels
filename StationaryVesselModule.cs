using UnityEngine;

namespace StationaryVessels
{
    public class StationaryVesselModule : VesselModule
    {
        private Vessel vessel;

        public StationaryVesselModule()
        {
            Debug.Log("ctor called");
        }
        public void Start()
        {
            Debug.Log("StationaryStart");
            vessel = GetComponent<Vessel>();
            if(!vessel.isEVA)
            foreach(Part p in vessel.parts)
            {
                if(p.Modules.Contains("ModuleCommand"))
                {
                    Debug.Log("Adding module");
                    p.AddModule("StationaryModule");
                }
            }
        }
    }
}
