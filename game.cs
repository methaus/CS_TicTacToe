using System;

namespace CS_TicTacToe {
    class TicTacToe {
        static char[,] gameScreen = {
            {'.','0','.','1','.','2'},
            {'0',' ','|',' ','|',' '},
            {'.','-','+','-','+','-'},
            {'1',' ','|',' ','|',' '},
            {'.','-','+','-','+','-'},
            {'2',' ','|',' ','|',' '}
        };
        static int[,,] winConditions = { // Position 1 = [0], 3 = [1], 5 = [2]
            {{1,1},{1,3},{1,5}},
            {{3,1},{3,3},{3,5}},
            {{5,1},{5,3},{5,5}},
            {{1,1},{3,1},{5,1}},
            {{1,3},{3,3},{5,3}},
            {{1,5},{3,5},{5,5}},
            {{1,1},{3,3},{3,5}},
            {{5,1},{3,3},{1,5}}
        };
        static char[,] gameItself = gameScreen;
        static int turn = 0;
        static bool gameRunning = true;
        public TicTacToe() {
            char player; // "x" or "o"
            int i, j; // line, columm

            while (gameRunning == true) {
                begin:
                Console.Clear();
                
                // ShowGame()
                for (int line = 0; line < gameItself.GetLength(0); line++){
                    for (int columm = 0; columm < gameItself.GetLength(1); columm++) {
                        Console.Write(gameItself[line,columm]+"  ");
                    }
                    Console.Write("\n");
                }

                // PlayerMove()      
                if (turn % 2 == 0) {
                    player = 'x';
                } else {
                    player = 'o';
                }       
                Console.WriteLine("\n\"{0}\" Turn.", player);

                // MoveValidation()
                try {
                    Console.Write("Line: ");
                    i = Int32.Parse(Console.ReadLine());
                    Console.Write("Columm: ");
                    j = Int32.Parse(Console.ReadLine());
                    if ((i == 0 || i == 1 || i == 2) && (j == 0 || j == 1 || j == 2)) {
                        i = IndexConvertion(i);
                        j = IndexConvertion(j);
                        if (gameItself[i,j] == 'x' || gameItself[i,j] == 'o') {
                            Console.WriteLine("Invalid Play");
                        } else {
                            if (player == 'x') {
                                gameItself[i,j] = 'x';
                            }
                            if (player == 'o') {
                                gameItself[i,j] = 'o';
                            }
                            turn++;
                        }
                    } else {
                        throw new Exception();
                    }
                }
                catch (System.FormatException) {
                    Console.WriteLine("Invalid Value Entered.");
                    Console.ReadLine();
                    goto begin;
                }
                catch {
                    Console.WriteLine("Invalid Indexes.");
                    Console.ReadLine();
                    goto begin;
                }

                // CheckWin()
                if (turn > 4) {
                    int contador = 0;
                    int[] tester = new int[6];
                    foreach (int row in winConditions) {
                        tester[contador++] = row;
                        if (contador == 6) {
                            contador = 0;
                            if (gameItself[tester[0],tester[1]] == player && gameItself[tester[2],tester[3]] == player && gameItself[tester[4],tester[5]] == player) {
                                Console.WriteLine("\n\"{0}\" won.", player);
                                PlayAgain();
                                goto begin;
                            }
                        }
                    }
                }
                if (turn > 8) {
                    Console.WriteLine("\nScrath");
                    PlayAgain();
                }
            }
        }
        private int IndexConvertion(int index) {
            return (index == 0 ? index + 1 : (index == 1 ? index + 2 : (index == 2 ? index + 3 : -1)));
        }
        private void PlayAgain() {
            Console.WriteLine("\nAgain? Yes/No: ");
            string again = Console.ReadLine();
            if (again.Equals("no", StringComparison.OrdinalIgnoreCase)) {
                gameRunning = false;
            } else {
                gameItself = gameScreen;
                turn = 0;
            }
        }
    }
    class game {
        static void Main() {
            TicTacToe Game = new TicTacToe();
        }
    }
}

/* ABSTRACT

namespace CS_TicTacToe {

    class TicTacToe {

        static char[] gameScreen;
        static int[,,] winConditions;
        static int turn;

        TicTacToe() {
            variables;

            Loop:
            ShowGame();
            PlayerMove() {
                MoveValidation == false ? goto Loop; 
            };
            CheckWin() {
                Test winConditions;
                PlayAgain again == true ? reset variables && goto Loop : End;
            };

        }
    }
}
*/