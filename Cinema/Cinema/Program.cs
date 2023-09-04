using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 
Un cinema multisala vuole gestire la vendita dei biglietti per l'accesso alle proprie sale in modo automatico e veloce. 

Le nuove direttire antiCoVid, hanno obbligato il gestore del multisala ad attrezzarsi di un sistema informatico che gli consenta di vendere un biglietto, contestualmente memorizzando il nominativo dell'ospite che accede alla struttura.

La struttura multisala, è composta da 3 sale identificate dal nome 'SALA NORD', 'SALA EST' e 'SALA SUD'.

L'addetto al botteghino dovrà reperire e archiviare, obbligatoriamente, il nome ed il cognome dell'utente, selezionare la sala alla quale accede, ed indicare il tipo di biglietto. Quest'ultimo può essere ridotto oppure intero.

Sulla stessa schermata, in tempo reale, il sistema deve aggiornare, dopo ogni prenotazione, il numero di biglietti venduti per ogni sala, indicando anche il numero dei biglietti venduti di tipo Ridotto.

Ogni sala ha una capienza massima di 120 posti.
 
 */
namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string select = "";

            //QUESTE SONO LE DIVERSE LISTE CHE CONTERRANNO IL NOME E IL COGNOME DI OGNI SPETTATORE
            List<string> listingN = new List<string>();
            List<string> listingE = new List<string>();
            List<string> listingS = new List<string>();

            //CONTEGGIO INIZIALE DEL NUMERO DI SPETTATORI IN OGNI SALA
            int totalGuestsN = 0;
            int totalGuestsE = 0;
            int totalGuestsS = 0;

            //QUESTO LOOP PER FARE SELEZIONARE LE DIVERSE SALE
            while (!exit)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("HELLO! We have three movies today:        ");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(" - In sala North: Interstellar             ");
                Console.WriteLine(" - In sala East: 2001: Space Odyssey       ");
                Console.WriteLine(" - In sala South: Tenet                    ");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(" - Type '1' for Interstellar               ");
                Console.WriteLine(" - Type '2' for 2001: Space Odyssey        ");
                Console.WriteLine(" - Type '3' for Tenet                      ");
                Console.WriteLine("===========================================");

                bool validSelection = false;

                while (!validSelection)
                {
                    select = Console.ReadLine();

                    switch (select)
                    {
                        case "1":
                            Console.WriteLine("Sala North: Interstellar");
                            validSelection = true;
                            break;

                        case "2":
                            Console.WriteLine("Sala East: 2001: Space Odyssey");
                            validSelection = true;
                            break;

                        case "3":
                            Console.WriteLine("Sala South: Tenet");
                            validSelection = true;
                            break;

                        default:
                            Console.WriteLine("Not a valid selection");
                            continue;
                    }
                }

                //CONTROLLARE SE IL NUMERO DEGLI SPETTATORI E' MAGGIORE-UGUALE DI 120 SICCOME QUESTO SAREBBE IL NUMERO MASSIMO DI PERSONE/SALA
                bool roomFull = false;

                if (select == "1" && totalGuestsN >= 120)
                {
                    roomFull = true;
                }
                else if (select == "2" && totalGuestsE >= 120)
                {
                    roomFull = true;
                }
                else if (select == "3" && totalGuestsS >= 120)
                {
                    roomFull = true;
                }

                //QUESTO SCRIVE UN MESSAGGIO INDICANDO CHE LA SALA SCELTA E' PIENA E NE DEVE SCEGIERE UN'ALTRA
                if (roomFull)
                {
                    Console.WriteLine("|==================================ATTENTION==============================|");
                    Console.WriteLine("|                                                                         |");
                    Console.WriteLine( "Sala " + select + " is full unfortunately...please select a different sala");
                    Console.WriteLine("|                                                                         |");
                    Console.WriteLine("|==================================ATTENTION==============================|");
                }   
                else
                {
                    //QUESTO PRENDERE IL NOME E COGOME DALL'USER 
                    Console.WriteLine("Please insert spectator's name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please insert spectator's surname: ");
                    string surname = Console.ReadLine();

                    //AGGIUNGE L'USER ALLA LISTA GIUSTA
                    if (select == "1")
                    {
                        listingN.Add(name + " " + surname);
                        totalGuestsN++;
                    }
                    else if (select == "2")
                    {
                        listingE.Add(name + " " + surname);
                        totalGuestsE++;
                    }
                    else if (select == "3")
                    {
                        listingS.Add(name + " " + surname);
                        totalGuestsS++;
                    }
                    //CONERMA LA SALA SELEZIONATA, IL NOME DELL'USER E IL COGNOME DELL'USER
                    Console.WriteLine("The sala selection is: " + select + "; Nome: " + name + "; Cognome: " + surname);

                    //SE L'USER IMMETTE yes PUO' IMMETERE UN NUOVO SPETTATORE, ALTRIMENTI ESCE DAL LOOP
                    Console.WriteLine("Do you want to make another selection? (yes/no)");
                    string choice = Console.ReadLine().ToLower();

                    if (choice != "yes")
                    {
                        exit = true;
                        break;
                    }
                }
            }

            //USCITO DAL LOOP, STAMPA LA LISTA DEGLI SPETTATORI PER OGNI SALA

            Console.WriteLine("======================GUEST LISTING======================");
            Console.WriteLine("                                                         ");
            Console.WriteLine("------------------------SALA NORD------------------------");
            // OSPITI SALA NORD
            Console.WriteLine("Guests in Sala North:");
            foreach (string guest in listingN)
            {
                Console.WriteLine(guest);
            }
            //OSPITI SALA EST
            Console.WriteLine("                                                         ");
            Console.WriteLine("------------------------SALA EST-------------------------");
            
            Console.WriteLine("Guests in Sala East:");
            foreach (string guest in listingE)
            {
                Console.WriteLine(guest);
            }
            //OSPITI SALA SUD
            Console.WriteLine("                                                         ");
            Console.WriteLine("------------------------SALA SUD-------------------------");
            
            Console.WriteLine("Guests in Sala South:");
            foreach (string guest in listingS)
            {
                Console.WriteLine(guest);
            }

            Console.WriteLine("                                                         ");
            Console.WriteLine("======================GUEST LISTING======================");

            Console.ReadKey();
        }
    }
}
