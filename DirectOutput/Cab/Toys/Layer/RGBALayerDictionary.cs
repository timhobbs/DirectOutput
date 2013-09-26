﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectOutput.Cab.Color;

namespace DirectOutput.Cab.Toys.Layer
{
    public class RGBALayerDictionary : SortedDictionary<int, RGBALayer>
    {
        public new RGBALayer this[int key]
        {
            get
            {
                try
                {
                    return base[key];
                }
                catch
                {
                    RGBALayer L = new RGBALayer();
                    Add(key, L);
                    return L;
                }
            }
            set
            {
                base[key] = value;
            }
        }


       


        public RGBColor GetResultingColor()
        {
            if (Count > 0)
            {
                float Red = 0;
                float Green = 0;
                float Blue = 0;
                foreach (KeyValuePair<int, RGBALayer> KV in this)
                {
                    int Alpha = KV.Value.Alpha;
                    if (Alpha != 0)
                    {
                        int NegAlpha = 255 - Alpha;
                        Red = AlphaMappingTable.AlphaMapping[NegAlpha, (int)Red] + AlphaMappingTable.AlphaMapping[Alpha, KV.Value.Red];
                        Green = AlphaMappingTable.AlphaMapping[NegAlpha, (int)Green] + AlphaMappingTable.AlphaMapping[Alpha, KV.Value.Green];
                        Blue = AlphaMappingTable.AlphaMapping[NegAlpha, (int)Blue] + AlphaMappingTable.AlphaMapping[Alpha, KV.Value.Blue];
                    }
                }

                return new RGBColor((int)Red, (int)Green, (int)Blue);
            }
            else
            {
                return new RGBColor(0, 0, 0);
            }
        }
    }
}