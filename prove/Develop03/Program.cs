using System;
using System.Collections.Generic;

namespace ScriptureProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //  list of scriptures
            List<Scripture> _scriptures = new List<Scripture>
            {
                new Scripture(new Reference("1 Nephi", 1, 1), "In the beginning, Lehi had a vision."),
                new Scripture(new Reference("1 Nephi", 2, 4, 5), "And it came to pass that he saw a pillar of fire, and he heard the voice of the Lord."),
                new Scripture(new Reference("Alma", 36, 3), "And now, O my son, I have somewhat to say concerning the restoration of which has been spoken; for behold, some have wrested the scriptures, and have gone far astray because of this thing."),
            };

            // Random pick of scripture from the list
            Random _random = new Random();
            Scripture _scripture = _scriptures[_random.Next(_scriptures.Count)];

            // Display the scripture and prompt the user
            string _userInput;
            do
            {
                Console.Clear();
                Console.WriteLine(_scripture.GetRenderedText());
                Console.WriteLine("Press enter to hide some words or type quit to end the program: ");
                _userInput = Console.ReadLine();

                if (_userInput != "quit")
                {
                    _scripture.HideWords();
                }
            } while (!_scripture.IsCompletelyHidden() && _userInput != "quit");
        }
    }

    class Reference
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public int EndVerse { get; set; }

        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
            EndVerse = verse;
        }

        public Reference(string book, int chapter, int verse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
            EndVerse = endVerse;
        }
    }

class Scripture
    {
        private Reference reference;
        private List<Word> words;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            words = new List<Word>();
            string[] _splitWords = text.Split(' ');
            foreach (string word in _splitWords)
            {
                words.Add(new Word(word));
            }
        }

        public void HideWords()
        {
            Random random = new Random();
            foreach (Word word in words)
            {
                if (!word.IsHidden())
                {
                    if (random.Next(2) == 1)
                    {
                        word.Hide();
                    }
                }
            }
        }

        public string GetRenderedText()
        {
            string renderedText = "";
            foreach (Word _word in words)
            {
                renderedText += _word.GetRenderedText() + " ";
            }
            return renderedText;
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Word
    {
        private string _text;
        private bool _hidden;

        public Word(string text)
        {
            this._text = text;
            _hidden = false;
        }

        public void Hide()
        {
            _hidden = true;
        }

        public void Show()
        {
            _hidden = false;
        }

        public bool IsHidden()
        {
            return _hidden;
        }

        public string GetRenderedText()
        {
            if (_hidden)
            {
                return "_";
            }
            else
            {
                return _text;
            }
        }
    }
}