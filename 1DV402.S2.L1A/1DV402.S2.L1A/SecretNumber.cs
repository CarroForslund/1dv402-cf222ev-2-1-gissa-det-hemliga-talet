using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        //MaxNumberOfGuesses ska vara en konstant med värdet 7, vilket definierar antal tillåtna gissningar.
        public const int MaxNumberOfGuesses = 7;

        //Deklarera fält
        private int _count; 
        private int _number; 

        //Konstruktorn kontrollerar att SecretNumber-objekten är korrekt initierade
        //Det vill säga att fälten har lämpligt tilldelade värden
        public SecretNumber()
        {
            Initialize();
        }

        //_number ska tilldelas ett slumpat heltal i det slutna intervallet mellan 1 och 100, vilket blir det hemliga talet.
        //_count ska tilldelas värdet 0 och räknar sedan antalet gjorda gissningar efter det hemliga talet slumpades fram
        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);

            _count = 0;
        }

        //MakeGuess anropas för att göra en gissning av det hemliga talet.
        //Skriv ut lämpliga meddelanden beroende på vad gissningarna blir. Rätt, eller fel och om det är för högt eller lågt nummer.
        //Om gissat nummer inte är 1-100 ska ArgumentOutOfRangeException kastas
        //Efter 7 gissningar ska ApplicationException kastas
        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            _count++;

            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count);
                return true;
            }
            
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar", number, MaxNumberOfGuesses - _count);
            }
            else
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar", number, MaxNumberOfGuesses - _count);
            }

            //När gissningarna är slut ska det hemliga talet visas
            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
            }
            
            return false;
        }
    }
}
