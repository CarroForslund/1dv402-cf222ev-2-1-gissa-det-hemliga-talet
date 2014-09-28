using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        //Deklarera fält
        //MaxNumberOfGuesses ska vara en konstant med värdet 7, vilket definierar antal tillåtna gissningar.
        private int _count; 
        private int _number; 
        public const int MaxNumberOfGuesses = 7; 

        //_number ska tilldelas ett slumpat heltal i det slutna intervallet mellan 1 och 100, vilket blir det hemliga talet.
        //_count ska tilldelas värdet 0 och räknar sedan antalet gjorda gissningar efter det hemliga talet slumpades fram
        public void Initialize()
        {
            Random rnd = new Random(); //http://eforum.idg.se/topic/325610-slumpa-ett-tal-mellan-1-och-10-i-c/
            _number = rnd.Next(1, 101);

            _count = 0;
        }

        //MakeGuess anropas för att göra en gissning av det hemliga talet.
        //Skriv ut lämpliga meddelanden beroende på vad gissningarna blir. Rätt, eller fel och om det är för högt eller lågt nummer.
        //Om gissat nummer inte är 1-100 ska ArgumentOutOfRangeException kastas
        //Efter 7 gissningar ska ApplicationException kastas
        public bool MakeGuess(int number)
        {
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }    

            while (_count < 7)
            {
                _count++;
                if (number == _number)
                {
                    Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count);
                    return true;
                }
                else if (number < _number)
                {
                    Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar", number, 7 - _count);
                    TellSecretNumber();
                    return false;
                }
                else
                {
                    Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar", number,  7 - _count);
                    TellSecretNumber();
                    return false;
                }
            }
            throw new ApplicationException();
        }
        
        //Konstruktorn kontrollerar att SecretNumber-objekten är korrekt initierade
        //Det vill säga att fälten har lämpligt tilldelade värden
        public SecretNumber()
        {
            Initialize();
        }

        //När gissningarna är slut ska det hemliga talet visas. Skre
        public void TellSecretNumber()
        {
            if (_count == 7)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
            }
        }
    }
}
