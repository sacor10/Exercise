using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Model.Services;

public class WesternAstrologicalSign : StringEnum<WesternAstrologicalSign>
{
    public WesternAstrologicalSign(string value) : base(value)
    {

    }

    public static implicit operator WesternAstrologicalSign(string value)
    {
        return new WesternAstrologicalSign(value);
    }

    public static WesternAstrologicalSign Capricorn = new WesternAstrologicalSign(nameof(Capricorn));
    public static WesternAstrologicalSign Aquarius = new WesternAstrologicalSign(nameof(Aquarius));
    public static WesternAstrologicalSign Pisces = new WesternAstrologicalSign(nameof(Pisces));
    public static WesternAstrologicalSign Aries = new WesternAstrologicalSign(nameof(Aries));
    public static WesternAstrologicalSign Taurus = new WesternAstrologicalSign(nameof(Taurus));
    public static WesternAstrologicalSign Gemini = new WesternAstrologicalSign(nameof(Gemini));
    public static WesternAstrologicalSign Cancer = new WesternAstrologicalSign(nameof(Cancer));
    public static WesternAstrologicalSign Leo = new WesternAstrologicalSign(nameof(Leo));
    public static WesternAstrologicalSign Virgo = new WesternAstrologicalSign(nameof(Virgo));
    public static WesternAstrologicalSign Libra = new WesternAstrologicalSign(nameof(Libra));
    public static WesternAstrologicalSign Scorpio = new WesternAstrologicalSign(nameof(Scorpio));
    public static WesternAstrologicalSign Sagittarius = new WesternAstrologicalSign(nameof(Sagittarius));

    public static List<WesternAstrologicalSign> AllSigns = new List<WesternAstrologicalSign>
    {
        Capricorn,
        Aquarius,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius
    };
}