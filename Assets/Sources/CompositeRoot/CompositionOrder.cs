using System.Collections.Generic;
using UnityEngine;

namespace CompositeRoot
{
    public class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _order;

        private void OnEnable()
        {
            foreach (CompositeRoot compositeRoot in _order)
            {
                compositeRoot.Compose();
                compositeRoot.enabled = true;
            }
        }
    }
}