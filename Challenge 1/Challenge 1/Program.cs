using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {
    class Program {
        static void Main(string[] args) {
    
            //creating a list which stores the possible dice numbers and an empty list to store which values are rolled
            var die = new List<int> { 1, 2, 3, 4, 5, 6};
            var dicerolls = new List<int>();
            var random = new Random();

            int set = 0;
            while(set >= 0){
                //being polite to my user and asking them how many dice they'd like to roll and storing their answer
                Console.WriteLine("How many dice would you like to roll?");
                Console.Write("Number of dice: ");
                int nodice;
                if (int.TryParse(Console.ReadLine(), out nodice)) { 
            
                
                    //rolling the number of dice the user specifies
                    int count = 0;
                    Console.WriteLine("Here are your rolls...");
                    while (count < nodice) {
                        int index = random.Next(die.Count);
                        Console.WriteLine(die[index]);
                        dicerolls.Add(die[index]);
                        count++;
                    }                
                                        
                    //Letting the user choose if they would like to roll more dice or not
                    Console.WriteLine("Would you like to roll again?");
                    Console.WriteLine("Yes or No");
                    
                    int cont = 0;
                    while (cont >= 0) {
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes") { 
                            Console.WriteLine("Here we go...");
                            break;
                        }
                        else if (answer == "no") { 
                            Console.WriteLine("Fine");
                            goto END;
                        }
                        else {
                            Console.WriteLine("Please say 'yes' or 'no'");
                            cont++;
                        }
                    }
                                                            
                }
                else { 
                    Console.WriteLine("Please select a number of dice");    
                }
                set++;
            }
            END:
            Console.WriteLine();
            //How many times they rolled
            Console.WriteLine("You rolled " + dicerolls.Count + " times!");
            Console.WriteLine("How many dice would you like to examine?");

            //User gets to choose how many dice they wish to examine
            int examine = 0;
            while (examine >= 0) {
                Console.Write("Number of dice: ");
                int examinedice;
                if (int.TryParse(Console.ReadLine(), out examinedice)) { 
                    if (examinedice > dicerolls.Count) { 
                        Console.WriteLine("Please choose a valid number");
                    }
                    else {
                        dicerolls.RemoveRange(examinedice, dicerolls.Count - examinedice);
                        break;    
                    }
                }
                else { 
                    Console.WriteLine("Please choose a valid number");   
                }
            }
            
            //Listing the dice rolls
            Console.WriteLine("These are your rolls:");
            dicerolls.ForEach(Console.WriteLine);
            //total of dice rolls
            int total = dicerolls.Sum();
            Console.WriteLine("The total of your rolls is: " + total);
            //average of dice rolls
            float avg = total/(float)dicerolls.Count;
            Console.WriteLine("The average of your rolls is: " + avg);
            
            
            Console.WriteLine("Please click to exit");
            Console.ReadKey(true);

            //References:
            //1. https://stackoverflow.com/questions/40035544/how-to-check-input-is-a-valid-integer
            //2. https://github.com/dotnet/csharplang/issues/869
            //3. https://stackoverflow.com/questions/6373006/how-to-clear-list-till-some-item-c-sharp
        }
    }
}
