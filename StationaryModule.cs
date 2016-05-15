using UnityEngine;

namespace StationaryVessels
{
    public class StationaryModule : PartModule
    {
        [Persistent]
        public bool isFrozen;
        private StationaryVesselModule SVM;
        [KSPEvent(guiActive = true, guiName = "isFrozen: false")]
        public void ToggleFreeze()
        {
            SVM.toggleFreeze(isFrozen);
            Events["ToggleFreeze"].guiName = isFrozen ? "isFrozen: true": "isFrozen: false";
        }

        [KSPAction("Toggle Freeze")]
        public void ToggleFreezeAction(KSPActionParam param)
        {
            ToggleFreeze();
            if(!isFrozen)
            {
                SVM.UnFreezeVessel();
            }
        }

        public void Start()
        {
            SVM = vessel.GetComponent<StationaryVesselModule>();
            Events["ToggleFreeze"].guiName = isFrozen ? "isFrozen: true" : "isFrozen: false";
        }
        public void FixedUpdate()
        {
            if (!vessel.isEVA && isFrozen)
            {
                vessel.GetComponent<StationaryVesselModule>().FreezeVessel();
            }
        }
        public void setFreeze(bool freeze)
        {
            isFrozen = freeze;
        }

    }
}
