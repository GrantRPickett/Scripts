using System.Collections.Generic;
using UnityEngine;
using DataBank;
public class RHs {
    private static RHs instance = null;
    public static RHs SharedInstance { get {
            if (instance == null) instance = new RHs();
            return instance;}}
    public static List<string> l (string a, string b, string c){
        return new List<string>{a,b,c};
    }
    public static List<string> l (string a, string b, string c, string d){
        return new List<string>{a,b,c,d};
    }
    public readonly List<List<string>> rs = new List<List<string>>{
        l("Dorne","Sunspear","Parched deserts, temperate to arid hills, and mountains","9"),
        l("The Crownlands","King`s Landing","Plains, valleys, forests","9"),
        l("The Iron Islands","Pyke","Cold stormy islands, rocky soil","8"),
        l("The North","Riverrun","Chilled plains, forests and mountains","9"),
        l("The Reach","Highgarden","Rivers, forests, fertile plains","12"),
        l("The Riverlands","Riverrun","Broad and fertile river basins.","7"),
        l("The Stormlands","Storm`s End","Stormy forests interrupted by low mountains and marches","9"),
        l("The Vale of Arryn","The Eyrie","All mountains punctuated by fertile valleys","9"),
        l("The Westerlands","Casterly Rock","Low mountains and hills.","10"),
    };    //todo back tick ` fix
    public readonly List<List<string>> hs = new List<List<string>>{
         //"Dorne":[
        l("Martell","great","a red sun pierced by a gold spear, on an orange field"),
        l("Blackmont","noble","a flying grey and white vulture, grasping a baby in its talons, on a black field"),
        l("Dayne","noble","a sword and a falling star on a lavender background"),
        l("Jordayne","noble","chequy light and dark green, a gold quill"),
        l("Manwoody","noble","a crowned skull on black"),
        l("Qorgyle","noble","three black scorpions on red"),
        l("Uller","noble","a rayonne yellow over crimson"),
        l("Allyrion","noble","gyronny red and black, a gold hand"),
        l("Yronwood","noble","a black portcullis grill over sand"),
        //"The Crownlands
        l("Baratheon of King`s Landing","royal","the crowned stag of Baratheon black on gold and the lion of Lannister golden on red combatant"),
        l("Blount","noble","green, A red bend sinister red between two black porcupines on green"),
        l("Brune","noble","silver, a bear`s paw erased within a double tressure orange"),
        l("Gaunt","noble","three black lances upright on pink, between black flaunches"),
        l("Rosby","noble","three red chevronels on ermine"),
        l("Rykker","noble","two black warhammers crossed on a white saltire on blue"),
        l("Slynt","noble","black, a bloody spear, tipped red"),
        l("Stokeworth","noble","green, a lamb couchant silver holding a goblet"),
        l("Thorne","noble","a silver flail on red within a black border"),
        //"The Iron Islands":[
        l("Greyjoy","great","a golden kraken on a black field"),
        l("Blacktyde","noble","vairy green and black"),
        l("Botley","noble","a shoal of silver fish on pale green"),
        l("Goodbrother","noble","a gilded black horn on red"),
        l("Harlaw","noble","silver scythe on black"),
        l("Kenning of Kayce","noble","quarterly orange and black, four suns in splendour counterchanged"),
        l("Merlyn","noble","silver, twining waterspouts green"),
        l("Sparr","noble","an oak saltire on blue"),
        //"The North":[
        l("Stark","great","a running grey direwolf, on an ice-white field"),
        l("Cerwyn","noble","silver, a battle-axe paleways black"),
        l("Dustin","noble","two longaxes crossed, a black crown between their heads on a field of yellow"),
        l("Hornwood","noble","a brown bull moose on an orange field."),
        l("Karstark","noble","a white sunburst on black"),
        l("Manderly","noble","a white merman with green hair, over a blue-green field"),
        l("Mormont","noble","a wood green, a bear black"),
        l("Ryswell","noble","bronze, a horse`s head black orbed and maned red within a bordure engrailed black"),
        l("Umber","noble","four gold chains linked by a central ring on dark red"),
         //"The Reach":[
        l("Tyrell","great","a golden rose on green"),
        l("Ashford:","noble","orange, a sun in splendour beneath a chevron ingreened silver"),
        l("Beesbury","noble","three beehives, gold and black,"),
        l("Bulwer","noble","red, a bull`s skull silver"),
        l("Cuy","noble","six yellow flowers on blue"),
        l("Florent","noble","ermine, a fox`s head cabossed within an annulet of flowers, all proper"),
        l("Fossoway","noble","a red apple on gold"),
        l("Hightower","noble","grey, a tower silver with a beacon on fire red"),
        l("Leygood","noble","orange, three thunderbolts in black"),
        l("Oakheart","noble","three oak leaves on gold"),
        l("Redwyne","noble","blue, a grape cluster proper"),
        l("Tarly","noble","a huntsman in redon a green field"),
        //"The Riverlands":[
        l("Tully","great","a silver trout on a red and blue background"),
        l("Frey","noble","the two stone grey towers and bridge of the Twins, on a dark grey field, surmounting an escutcheon of blue water."),
        l("Blackwood","noble","a flock of black ravens surmounting a dead white weirwood tree"),
        l("Bracken","noble","a red stallion on a gold field, over a brown escutcheon"),
        l("Mallister","noble","a silver eagle on a blue field"),
        l("Mooton","noble","a red salmon on a white field"),
        l("Smallwood","noble","six acorns orange, three, two and one"),
        //"The Stormlands":[
        l("Baratheon","great","a crowned black stag on gold"),
        l("Errol","noble","A haystack"),
        l("Estermont","noble","a green seaturtle in green"),
        l("Grandison","noble","a sleeping black great cat"),
        l("Musgood","noble","quarterly: A golden pavillion on blue, a green laurel crown on white"),
        l("Peasebury","noble","silver, a pea pod open within a bordure of peas green"),
        l("Tarth","noble","red, a sun in splendour gold quartered with blue, an increscent silver"),
        l("Trant","noble","the silhouette of a hanged man in the night"),
        l("Wylde","noble","a blue maelstrom"),
        //"The Vale of Arryn":[
        l("Arryn","great","a white falcon and crescent moon on a blue field."),
        l("Corbray","noble","silver, a raven black holding a heart"),
        l("Egen","noble","silver, on a chief blue an increscent of the first between a sun in splendour gold and a star of the first"),
        l("Lynderly","noble","eleven green snakes on a black field"),
        l("Hunter","noble","orange, five arrows in fret with heads to chief silver"),
        l("Moore","noble","silver, three spearheads bronze within a bordure embattled of the same"),
        l("Royce","noble","orange pelletty, and runes black"),
        l("Tollett","noble","pily, grey and black"),
        l("Waynwood","noble","a black broken wheel on green"),
        //"The Westerlands":[
        l("Lannister","great","a golden lion rampant on a crimson field."),
        l("Crakehall","noble","a black and white brindled boar on brown"),
        l("Lannister of Lannisport","noble","a golden lion rampant on a white field."),
        l("Lefford","noble","a golden coin on sky blue, a sun right in the sky"),
        l("Marbrand","noble","a burning tree, orange with smoke"),
        l("Payne","noble","purple and white chequy with gold coins in the checks."),
        l("Sarsfield","noble","a green arrow on a white bend on green"),
        l("Serrett","noble","silver, a peacock in his pride proper"),
        l("Westerling","noble","six white shells on a sand-colored field"),
        l("Yarwyck","noble","silver, two halberds saltireways orange hafted black between four diamonds of the second"),
    };
}