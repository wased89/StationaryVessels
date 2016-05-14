using UnityEngine;

namespace StationaryVessels
{
    public class StationaryModule : PartModule
    {
        private StationaryVesselModule SVM;
        [KSPEvent(guiActive = true, guiActiveEditor = true, guiName = "isFrozen: false")]
        public void ToggleFreeze()
        {
            vessel.GetComponent<StationaryVesselModule>().toggleFrozen();
            Events["ToggleFreeze"].guiName = SVM.getFrozen() ? "isFrozen: true": "isFrozen: false";
        }

        [KSPAction("Toggle Freeze")]
        public void ToggleFreezeAction(KSPActionParam param)
        {
            ToggleFreeze();
            if(!SVM.getFrozen())
            {
                SVM.UnFreezeVessel();
            }
        }

        public void Start()
        {
            SVM = vessel.GetComponent<StationaryVesselModule>();
            Events["ToggleFreeze"].guiName = SVM.getFrozen() ? "isFrozen: true" : "isFrozen: false";
        }
        public void FixedUpdate()
        {
            if (!vessel.isEVA && SVM.getFrozen())
            {
                vessel.GetComponent<StationaryVesselModule>().FreezeVessel();
            }
        }

        
    }
}
