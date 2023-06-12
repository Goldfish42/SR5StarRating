using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using VRTK.UnityEventHelper;

namespace SR5StarRating.UI
{
    public class RankComponent
    {
        private GameObject starGO;
        private VRTK_InteractableObject_UnityEvents starEvents;
        private UnityAction<object, VRTK.InteractableObjectEventArgs> onStarUse;

    }
}
