What's new (v1.00 -> V1.10)

    Moves the project to Visual Studio 2010 using .Net Framework V4
    Uses System.Threading.Tasks to simplify the multi-threading implementation
    Improves the Board Evaluation interface
    Correct exception when ChessControl was resized
    Somes clean-up of the code

What's new (0.943 -> v1.00)

  Game:
    Permits pawn promotion to non-queen pieces
    
  Move Display:
    Moves can now be seen using PGN format or Start/End position format
    Start/End position format use 'x' when a piece is eated
    Book move shown between parentheses are now preserved after being saved

  Search engine:
    New searching mode: iterative depth-first search with a fix number of play
    Correct problem with iterative search so it now perform better than before
    Correct problem with point evaluation of draw in alpha-beta and min-max
    Declare a draw when the minimum pieces requirement for checkmate is not met
    Improve point evaluation by using the number of attacked pieces and the number of attacked positions
    
  Interface:
    Add timer for white/black player
    Use vector graphic to draw the pieces of the board to improve quality when board is resized.
    Add a toolbar
    Improves the status bar
    Permits to undo the first move when in player vs player mode
    Add option to select the color of the pieces and board
    Improves messages related to the end of the game
 
  Loading / Saving
    Board can now also be saved in PGN format
    Saved format has changed a lot... so, it's not compatible with the old format
    Correct bug which was discarding the move list when loading a PGN file with FEN included.

  
  