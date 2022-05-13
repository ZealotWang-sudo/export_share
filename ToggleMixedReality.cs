// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using TMPro;
namespace Microsoft.MixedReality.Toolkit.UI
{

    public class ToggleMixedReality : MonoBehaviour
    {
        /// <summary>
        /// Toggles hand mesh visualization
        /// </summary>
        public TextMeshPro mode;
        public void OnToggleMixedReality()
        {
            MixedRealityInputSystemProfile inputSystemProfile = CoreServices.InputSystem?.InputSystemProfile;
            if (inputSystemProfile == null)
            {
                return;
            }

            MixedRealityHandTrackingProfile handTrackingProfile = inputSystemProfile.HandTrackingProfile;

            if (handTrackingProfile != null)
            {
                handTrackingProfile.EnableHandMeshVisualization = !handTrackingProfile.EnableHandMeshVisualization;
            }
            Debug.Log(handTrackingProfile.EnableHandMeshVisualization);
            if (handTrackingProfile.EnableHandMeshVisualization)
            {
                mode.text = "Mode :VR";
            }
            else
            {
                mode.text = "Mode :MR";
            }

        }


    }
}
