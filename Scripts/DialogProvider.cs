using System.Collections.Generic;
using System.Linq;

namespace BreakingTheBarrier.Scripts
{
    public class DialogProvider
    {
        private readonly List<string> Dialogs = new()
        {
            "A rose by any other name would smell as sweet.",
            "All that glitters is not gold.",
            "All the world’s a stage, and all the men and women merely players.",
            "Ask not what your country can do for you; ask what you can do for your country.",
            "Ask, and it shall be given you; seek, and you shall find.",
            "Eighty percent of success is showing up.",
            "Elementary, my dear Watson.",
            "For those to whom much is given, much is required.",
            "Frankly, my dear, I don't give a damn.",
            "Genius is one percent inspiration and ninety-nine percent perspiration.",
            "Go ahead, make my day.",
            "He travels the fastest who travels alone.",
            "Hell has no fury like a woman scorned.",
            "Hell is other people.",
            "Here's looking at you, kid.",
            "Houston, we have a problem.",
            "I have a dream that my four little children will one day live in a nation where they will not be judged by the color of their skin but by the content of their character.",
            "I have always depended on the kindness of strangers.",
            "I love the smell of napalm in the morning.",
            "I think therefore I am.",
            "If at first you don’t succeed, try, try again.",
            "If you are going through hell, keep going.",
            "If you build it, they will come.",
            "If you want something done right, do it yourself.",
            "If you want something said, ask a man; if you want something done, ask a woman.",
            "I'll be back.",
            "I'm gonna make him an offer he can't refuse.",
            "I've got a feeling we're not in Kansas anymore.",
            "Keep your friends close, but your enemies closer.",
            "Knowledge is power.",
            "Life is like a box of chocolates. You never know what you’re gonna get.",
            "Life is like riding a bicycle. To keep your balance, you must keep moving.",
            "May the Force be with you.",
            "No one can make you feel inferior without your consent.",
            "Not all those who wander are lost.",
            "Nothing is certain except for death and taxes.",
            "Parting is such sweet sorrow",
            "Power corrupts; absolute power corrupts absolutely.",
            "Speak softly and carry a big stick",
            "That’s one small step for a man, a giant leap for mankind.",
            "The love of money is the root of all evil.",
            "The only thing we have to fear is fear itself.",
            "The truth will set you free.",
            "There's no place like home.",
            "Three can keep a secret, if two of them are dead.",
            "Tis better to have loved and lost than never to have loved at all.",
            "To be or not to be, that is the question.",
            "To err is human; to forgive, divine.",
            "To thine own self, be true.",
            "Two roads diverged in a wood, and I, I took the one less travelled by, and that has made all the difference.",
            "United we stand, divided we fall.",
            "What doesn't kill us makes us stronger.",
            "What we've got here is failure to communicate. Some men you just can't reach.",
            "Whatever you are, be a good one.",
            "You can fool all of the people some of the time, and some of the people all of the time, but you can't fool all of the people all of the time.",
            "You must be the change you wish to see in the world.",
            "You talkin' to me?"
        };

        public string GetDialogAt(int index)
        {
            return Dialogs.ElementAtOrDefault(index);
        }
    }
}
