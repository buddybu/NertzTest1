using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CardDeck
{

    public class Card
    {
        public Suits CardSuit { get; set; }
        public Values CardValue { get; set; }
        public string Name
        {
            get
            {
                return GetDescription(CardValue) + GetDescription(CardSuit);
            }
        }

        public Card(Suits cardSuit, Values cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool DoesCardMatch(Card cardToCheck, Suits suit)
        {
            if (cardToCheck.CardSuit == suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DoesCardMatch(Card cardToCheck, Values value)
        {
            if (cardToCheck.CardValue == value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Plural(Values value)
        {
            if (value == Values.Six)
                return "Sixes";
            else
                return value.ToString() + "s";
        }

        static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description),
                                                                false);
                if (attrs != null && attrs.Length > 0)
                    return ((Description)attrs[0]).Text;

            }
            return en.ToString();
        }


    }
}
