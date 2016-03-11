using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace Klingon
{
    class Program
    {
        

        static void Main(string[] args)
        {
            KlingonGame game = new KlingonGame();

            Console.WriteLine("Welcome to 'Klingon' by David A. Wheeler.");
            Console.WriteLine("(an exercise in retrocomputing; original game circa 1976)");
            Console.WriteLine("You command the U.S.S. Enterprise && must defeat a Klingon Warbird.");
            
            Console.Write("Do you want instructions? ");
            string line = Console.ReadLine();
            if (line.Length > 0 && (line[0] == 'Y' || line[0] == 'y')) game.show_instructions();

            Console.WriteLine("When you want a list of choices, type 0 and press return.");

            while (true)
            {
                game.play_a_game();
                Console.WriteLine(); Console.WriteLine();
                game.compute_new_rank();
                game.display_rank();
                Console.Write("Do you wish to play again? ");
                line = Console.ReadLine();
                if (line.Length > 0 && (line[0] == 'N' || line[0] == 'n')) break;
            }
        }
    }

    class KlingonGame
    {
        public int enterprise = 0;
        public int klingon = 1;
        public int[] damage = new int[2]; // damage[0] = enterprise, [1] = klingon; larger is worse
        public double distance = 0.0;
        public int rank = 0;
        public System.Random random = new System.Random(
            DateTime.Now.Hour * 3600 +
            DateTime.Now.Minute * 60 +
            DateTime.Now.Second +
            DateTime.Now.Millisecond * 127);

        private SpeechSynthesizer speak = new SpeechSynthesizer();

        public void init_game()
        {
            damage[0] = 0;
            damage[1] = 0;
            distance = 100 * random.NextDouble() + 100;
        }

        public void show_instructions()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("1 = Phaser           Range =   0 to 200");
            Console.WriteLine("2 = Photon Torpedo   Range = 150 to 300");
            Console.WriteLine("3 = Move Closer");
            Console.WriteLine("4 = Move Away");
            Console.WriteLine("5 = Self-Destruct");
            Console.WriteLine("6 = Surrender");
            Console.WriteLine("7 = Evasive Action");
        }

        public int get_command()
        {
            int command;
            bool parseSuccess;
            while (true)
            {
                Console.Write("Your Command? >>>  ");
                parseSuccess = int.TryParse(Console.ReadLine(), out command);
                if (!parseSuccess)
                {
                    Console.WriteLine("That was not a valid number.  Enter 0 for help.");
                }
                else
                {
                    if (command == 0) show_instructions();
                    else if (command <= 7 && command >= 1) return command;
                    else Console.WriteLine("No such command; choose 0 for help.");
                }
            }
        }

        public int opponent(int p) { return 1 - p; }

        public string name(int p)
        {
            if (p == 0) return "U.S.S. Enterprise";
            else return "Klingon";
        }

        public bool dead(int damage)
        {
            if (damage >= 12) return true;
            else return false;
        }

        public void show_destruction(int victim)
        {
            if (victim == 0)
            {
                Console.WriteLine("U.S.S. Enterprise destroyed!");
                speak.Speak("U S S Enterprise destroyed");
            }
            else
            {
                Console.WriteLine("K L I N G O N   D E S T R O Y E D");
                speak.Speak("Klingon destroyed");
            }
        }

        public void cause_damage(int victim, int shotvalue)
        {
            int d = damage[victim] + shotvalue;
            if (d > 12)
            {
                show_destruction(victim);
                damage[victim] = d;
                return;
            }
            if (d >= 7 && damage[victim] < 7)
            {
                Console.WriteLine("{0}: Shields down.", victim);
            }
            if (d >= 11 && damage[victim] < 11)
            {
                Console.WriteLine("{0}: Warp engines have suffered major damage.", victim);
            }
            damage[victim] = d;
            switch (d)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("{0}: Shields holding, no damage.", victim);
                    break;
                case 4:
                case 5:
                    Console.WriteLine("{0}: Shields weakening.", victim);
                    break;
                case 6:
                    Console.WriteLine("{0}: Shields weakening... minor damage amidships.", victim);
                    break;
                case 7:
                    //pass   # print "Shields down."
                    break;
                case 8:
                    Console.WriteLine("{0}: Minor damage to hull.", victim);
                    break;
                case 9:
                    Console.WriteLine("{0}: Major damage to hull.", victim);
                    break;
                case 10:
                    Console.WriteLine("{0}: Dilithium crystals overheating.", victim);
                    break;
                case 11:
                    //pass # print "Warp engines have suffered major damage."
                    break;
                case 12:
                    Console.WriteLine("{0}: Photon torpedo tube destroyed!", victim);
                    break;
            }
        }

        public bool game_over()
        {
            if (dead(damage[0]) || dead(damage[1])) return true;
            if (distance > 300 || distance <= 0)  return true;
            return false;
        }

        public void phaser(int victim)
        {
            int shotvalue;
            if (distance > 200)
            {
                Console.WriteLine("{0}: Sorry, too far away for phasers.", victim);
                return;
            }
            if (random.NextDouble() > 0.7 - distance / 1000)
            {
                Console.WriteLine("{0}: Miss.", victim);
                return;
            }
            if (random.NextDouble() < 0.05)
            {
                Console.WriteLine("{0}: Lucky shot!", victim);
                shotvalue = 3;
            }
            else
            {
                Console.WriteLine("{0}: Phaser hits, damage done to {1} :", victim, name(victim));
                shotvalue = 1;
            }
            cause_damage(victim, shotvalue);
        }

        public void photon(int victim)
        {
            int shotvalue;
            if (distance < 150)
            {
                Console.WriteLine("{0}: Sorry, too close for photon torpedos.", victim);
                return;
            }
            if (random.NextDouble() > (0.7 - distance / 600))
            {
                Console.WriteLine("{0}: Miss.", victim);
                return;
            }
            if (random.NextDouble() < 0.05)
            {
                Console.WriteLine("{0}: Lucky shot!", victim);
                shotvalue = 4;
            }
            else
            {
                Console.WriteLine("{0}: Photon Torpedo hits, damage done to {1} :", victim, name(victim));
                shotvalue = 2;
            }
            cause_damage(victim, shotvalue);
        }

        public void move(int mover, int direction)
        {
            if (damage[mover] >= 11)
            {
                distance = distance + direction * (10 + 25 * random.NextDouble());
            }
            else
            {
                distance = distance + direction * (50 + 15 * random.NextDouble());
            }
            if (distance > 300)
            {
                Console.WriteLine("Out of range.");
            }
            if (distance < 0)
            {
                if (random.NextDouble() < 0.3)
                {
                    Console.WriteLine("The ships have run past each other.");
                    distance = Math.Abs(distance) + 10;
                }
                else
                {
                    Console.WriteLine("The ships have crashed into each other!");
                    damage[0] = damage[1] = 100;
                }
            }
        }

        public void self_destruct(int player)
        {
            Console.WriteLine("Auto-destruct sequence   A C T I V A T E D");
            speak.SpeakAsync("Auto-destruct sequence  activated");
            for (int x = 5; x >= 0; x--)
            {
                Console.WriteLine(x);
                System.Threading.Thread.Sleep(1000);
            }
            cause_damage(player, 100);
            //# Make the range extremely variable, and create a small but nonzero
            //# chance to hit faraway opponents
            double range = random.NextDouble() * 90 + 10;
            if (random.NextDouble() < 0.02) range = range * 5;
            Console.WriteLine("Radius of anti-matter explosion = {0}", range);
            if (distance <= range) cause_damage(opponent(player), 100);
            else Console.WriteLine(name(opponent(player)) + " unharmed.");
        }

        public void surrender(int player)
        {
            //# In Star Trek, Klingons don't take prisoners, but consistency is
            //# less important than gameplay...
            Console.WriteLine("I accept your surrender.");
            damage[player] = 100;
        }

        public void klingon_turn()
        {
            int command;
            if (damage[klingon] > 10 && damage[enterprise] < 8)
            {
                //# The situation is desparate!
                if (distance <= 80) command=5;
                else if (distance < 175) command=3;
                else command=4;
            }
            else
            {
                if (random.NextDouble() < 0.35)
                {
                    //# Make a random choice.
                    command=0;
                    while (command==0)
                    {
                        command=(int)(random.NextDouble()*4 + 1);
                        if (command==1 && distance>200) command=2;
                        else if (command==2 && distance<150) command=1;
                        if (command==2 && damage[klingon]>11) command=0;
                    }
                }
                else //# Normal case, make a "reasonable decision"
                {
                    if (distance<80) command=4;
                    else if (distance<175) command=1;
                    else if (distance<210) command=2;
                    else command=3;
                }
            }
            //# Execute command selected.
            switch(command)
            {
                case 1:
                    Console.WriteLine("Klingon fires phasers.");
                    phaser(0);
                    break;
                case 2:
                    Console.WriteLine("Klingon fires photon torpedos.");
                    photon(0);
                    break;
                case 3:
                    Console.WriteLine("Klingon moves closer.");
                    move(klingon, -1);
                    break;
                case 4:
                    Console.WriteLine("Klingon moves away.");
                    move(klingon, 1);
                    break;
                case 5:
                    Console.WriteLine("Klingon initiates self-destruct!");
                    self_destruct(1);
                    break;
                default:
                    Console.WriteLine("Klingon executes {0}",command);
                    break;
            }
        }

        public void compute_new_rank()
        {
            //# Did we win (1), lose (-1), or draw (0)?
            int win = 0;
            if (dead(damage[klingon])) win = win + 1;
            if (dead(damage[enterprise])) win = win - 1;
            rank = rank + win;
        }

        public string rank_name(int rank)
        {
            if (rank <= -3) return "Son of a Romulan worm";
            else if (rank == -2) return "Latrine-cleaner";
            else if (rank == -1) return "Ensign";
            else if (rank ==  0) return "Lieutenant";
            else if (rank ==  1) return "Lieutenant Commander";
            else if (rank ==  2) return "Commander";
            else if (rank ==  3) return "Captain";
            else if (rank ==  4) return "Commodore";
            else if (rank ==  5) return "Admiral";
            else if (rank ==  6) return "Rear Admiral";
            else if (rank ==  7) return "Full Admiral";
            else return (rank-3) + "-star Full Admiral";
        }

        public void display_rank()
        {
            Console.WriteLine("Your current rank is {0}.", rank_name(rank));
        }

        public void play_a_game()
        {
            //# Play a game
            init_game();
            Console.WriteLine();
            int command;
            if (rank < 5)
            {
                Console.WriteLine("Klingon coming in!");
            }
            else
            {
                Console.WriteLine("Klingon Flagship coming in!");
                damage[klingon] = -4;
            }
            Console.WriteLine();
            while (true)
            {
                distance = distance + (random.NextDouble() - 0.5) * 10;
                if (distance < 1) distance = 1 + (random.NextDouble() * 2);
                Console.WriteLine("Distance to Klingon = {0}", distance);
                Console.WriteLine();
                command = get_command();
                switch (command)
                {
                    case 1: phaser(1); break;
                    case 2: photon(1); break;
                    case 3: move(0, -1); break;
                    case 4: move(0, 1); break;
                    case 5: self_destruct(0); break;
                    case 6: surrender(0); break;
                }
                if (game_over()) break;
                klingon_turn();
                if (game_over()) break;
            }
        }
    }
}
