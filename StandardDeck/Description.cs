﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardCardDeck
{
    class Description : Attribute
    {
        public string Text;

        public Description(string text)
        {
            Text = text;
        }

    }

}
