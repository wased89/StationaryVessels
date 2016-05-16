using System.Collections.Generic;
using UnityEngine;

namespace StationaryVessels
{
    [KSPAddon(KSPAddon.Startup.Flight,false)]
    public class StationaryVesselModule : VesselModule
    {
        private Vessel vessel;
        private List<StationaryModule> modules;
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
            RebuildModulesList();
        }

        public void FreezeVessel()
        {
            foreach (Part p in vessel.parts)
            {
                if(p.Modules.Contains("StationaryModule")) { p.GetComponent<StationaryModule>().setFreeze(true); }
                if (p.GetComponent<Rigidbody>() == null) { continue; }
                p.GetComponent<Rigidbody>().isKinematic = true;

            }
        }
        public void UnFreezeVessel()
        {
            foreach (Part p in vessel.parts)
            {
                if (p.Modules.Contains("StationaryModule")) { p.GetComponent<StationaryModule>().setFreeze(false); }
                if (p.GetComponent<Rigidbody>() == null) { continue; }
                p.GetComponent<Rigidbody>().isKinematic = false;
            }
            vessel.GoOnRails();
            vessel.GoOffRails();
        }
        private void RebuildModulesList()
        {
            if (modules == null) { modules = new List<StationaryModule>(); }
            List<Part> parts = vessel.parts.FindAll(p => p.Modules.Contains("StationaryModule"));

            foreach (Part p in parts)
            {
                modules.Add(p.Modules.GetModule<StationaryModule>());
            }
        }
        public void toggleFreeze(bool freeze)
        {
            if(freeze)
            {
                UnFreezeVessel();
            }
            else
            {
                FreezeVessel();
            }
        }
    }
}
