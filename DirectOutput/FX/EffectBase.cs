﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectOutput.General.Generic;
using DirectOutput.Table;

namespace DirectOutput.FX
{

    /// <summary>
    /// Abstract base class for IEffect objects.
    /// This class does inherit IEffect.
    /// </summary>
    public abstract class EffectBase : NamedItemBase,IEffect
    {


        /// <summary>
        /// Triggers the effect for the given TableElementData
        /// \warning Remember that the TableElementData parameter will contain null if a effect is called as a static effect. Make sure your implementation of this method does not fail when called with null.
        /// </summary>
        /// <param name="TableElementData">TableElementData for the TableElement which has triggered the effect.</param>
        public abstract void Trigger(TableElementData TableElementData);


        /// <summary>
        /// Init does all necessary initialization work after the effect object has been instanciated
        /// </summary>
        /// <param name="Table">Table object containing the effect.</param>
        public abstract void Init(Table.Table Table);


        /// <summary>
        /// Finish does all necessary cleanupwork before the object is discarded
        /// </summary>
        public virtual void Finish() {}


    }
}
