﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirectOutput.Cab.Toys.Layer
{
    public class AnalogLayerDictionary : SortedDictionary<int, AnalogAlphaLayer>
    {

        public new AnalogAlphaLayer this[int key]
        {
            get
            {
                try
                {
                    return base[key];
                }
                catch
                {
                    AnalogAlphaLayer L = new AnalogAlphaLayer();
                    Add(key, L);
                    return L;
                }
            }
            set
            {
                base[key] = value;
            }
        }


       


        public int GetResultingValue()
        {
            if (Count > 0)
            {
                float Value = 0;

                foreach (KeyValuePair<int, AnalogAlphaLayer> KV in this)
                {
                    int Alpha = KV.Value.Alpha ;
                    if (Alpha != 0)
                    {
                        Value = AlphaMappingTable.AlphaMapping[255 - Alpha, (int)Value] + AlphaMappingTable.AlphaMapping[Alpha, KV.Value.Value];
                    }
                }

                return (int)Value;
            }
            else
            {
                return 0;
            }
        }



    }

}