using System;

namespace CS_TicTacToe {
    class Game {
        // ----------
        // GAME PRINT
        // ----------
        private string[,] gameItself = {
            {" ","0"," ","1"," ","2"},
            {"0"," ","|"," ","|"," "},
            {" ","-","+","-","+","-"},
            {"1"," ","|"," ","|"," "},
            {" ","-","+","-","+","-"},
            {"2"," ","|"," ","|"," "},
            {"","","","","",""},
            {"P1:","@","","P2:","@",""}
        };
        static int round = 0;
        public void ShowGame() {
            Console.Clear();
            for (int i = 0; i < gameItself.GetLength(0); i++){
                for (int j = 0; j < gameItself.GetLength(1); j++) {
                    Console.Write(gameItself[i,j]+"  ");
                }
                Console.Write("\n");
            }
        }

        // -------------
        // PLAYERS MOVES
        // -------------
        public void PlayerMove() {
            int row, columm;
            string player;
            if (round % 2 == 0) {
                player = "1";
            } else {
                player = "2";
            }
            move:
            ShowGame();
            Console.Write("\nP"+player+" row: ");
            row = Int32.Parse(Console.ReadLine());
            switch (row) {
                case 0:
                    row+=1;
                    break;
                case 1:
                    row+=2;
                    break;
                case 2:
                    row+=3;
                    break;
                default:
                    Console.Write("Invalid row!");
                    Console.ReadLine();
                    goto move;
            }
            Console.Write("P"+player+" col: ");
            columm = Int32.Parse(Console.ReadLine());
            switch (columm) {
                case 0:
                    columm+=1;
                    break;
                case 1:
                    columm+=2;
                    break;
                case 2:
                    columm+=3;
                    break;
                default:
                    Console.Write("Invalid columm!");
                    Console.ReadLine();
                    goto move;
            }
            if (gameItself[row,columm] == "x" || gameItself[row,columm] == "o") {
                Console.Write("Invalid move!");
                Console.ReadLine();
                goto move;
            } else {
                switch (player) {
                    case "1":
                        gameItself[row,columm] = "x";
                        break;
                    case "2":
                        gameItself[row,columm] = "o";
                        break;
                }
                round++;
            }
        }
    }
    class tictactoe {
        static void Main() {
            Game Game = new Game();
            while (true) {
                Game.PlayerMove();
            }
        }
    }
}