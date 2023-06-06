using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Model.Services;

public class ChineseAstrologicalSign : StringEnum<ChineseAstrologicalSign>
{
    public ChineseAstrologicalSign(string value) : base(value)
    {

    }

    public static implicit operator ChineseAstrologicalSign(string value)
    {
        return new ChineseAstrologicalSign(value);
    }

    public static ChineseAstrologicalSign Monkey = new ChineseAstrologicalSign(nameof(Monkey));
    public static ChineseAstrologicalSign Rooster = new ChineseAstrologicalSign(nameof(Rooster));
    public static ChineseAstrologicalSign Dog = new ChineseAstrologicalSign(nameof(Dog));
    public static ChineseAstrologicalSign Pig = new ChineseAstrologicalSign(nameof(Pig));
    public static ChineseAstrologicalSign Rat = new ChineseAstrologicalSign(nameof(Rat));
    public static ChineseAstrologicalSign Ox = new ChineseAstrologicalSign(nameof(Ox));
    public static ChineseAstrologicalSign Tiger = new ChineseAstrologicalSign(nameof(Tiger));
    public static ChineseAstrologicalSign Rabbit = new ChineseAstrologicalSign(nameof(Rabbit));
    public static ChineseAstrologicalSign Dragon = new ChineseAstrologicalSign(nameof(Dragon));
    public static ChineseAstrologicalSign Snake = new ChineseAstrologicalSign(nameof(Snake));
    public static ChineseAstrologicalSign Horse = new ChineseAstrologicalSign(nameof(Horse));
    public static ChineseAstrologicalSign Goat = new ChineseAstrologicalSign(nameof(Goat));

    public static List<ChineseAstrologicalSign> AllSigns = new List<ChineseAstrologicalSign>
    {
        Monkey,
        Rooster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Goat
    };
}