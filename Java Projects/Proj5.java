/*
Trey Moddlemog - Proj5
Lab section B - Atef Khan
game of life
*/

import java.util.*;
import java.io.*;
import java.lang.*;

public class Proj5 {

	public static void main(String[] args) throws IOException {
		
		if (args.length < 0)  {
			System.out.println("Enter a valid file name.");
		}
		else {
			int[][] cells = readBoard(args[0]);

			String board = boardDisplay(cells);
			System.out.println(board);

			int[][] newArray = update(cells);
			
			while (true) {

				try {
			          Thread.sleep(500);
			     }
			     catch (InterruptedException e) {}

				board = boardDisplay(newArray);
				System.out.println(board);

				newArray = update(newArray);

			}
		}
		
	} // end main

		
	/*
	readBoard

	String

	returns int[][]

	This method should read the specified input file, 
	read it into an int[][] array, and return that array.
	*/
	public static int[][] readBoard(String filename) throws IOException {
		
		Scanner inFile = new Scanner(new File(filename));

		int rows = Integer.parseInt(inFile.nextLine());
		int columns = Integer.parseInt(inFile.nextLine());

		int[][] array = new int [rows+2][columns+2];

		int k = 1;
		while (inFile.hasNext()) {
			String line = inFile.nextLine();
			String[] pieces = line.split("");

			for (int i = 1; i < columns-1; i++) {
				array[k][i] = Integer.parseInt(pieces[i]); 
			}
			k++;
		}

		return (array);

	} // end readBoard


	/*
	boardDisplay

	int[][]

	returns String

	This method should return the String representing the 
	cells array (so that it would print as a grid if printed).
	*/
	public static String boardDisplay(int[][] cells) {

		StringBuilder board = new StringBuilder();

		for (int i = 0; i < cells.length; i++) {
			for (int j = 0; j < cells[i].length; j++) {
				if (cells[i][j] == 1) {
					board.append("*");
				}
				else {
					board.append(".");
				}
			}

			board.append("\n");
		}

		return (board.toString());

	} // end boardDisplay


	/*
	neighbors

	int[][], int, int

	returns int

	This method should return the number of live neighbors 
	that position (row,col) has in the cells array.
	*/ 
	public static int neighbors(int[][] cells, int row, int col) {

		int count = 0;
		
		// top row
		if (cells[row-1][col-1] == 1) {
			count++;
		}
		if (cells[row-1][col] == 1) {
			count++;
		}
		if (cells[row-1][col+1] == 1) {
			count++;
		}

		// middle row
		if (cells[row][col-1] == 1) {
			count++;
		}
		if (cells[row][col+1] == 1) {
			count++;					
		}

		// bottom row
		if (cells[row+1][col-1] == 1) {
			count++;
		}
		if (cells[row+1][col] == 1) {
			count++;
		}
		if (cells[row+1][col+1] == 1) {
			count++;	
		}

		return (count);

	} // end neighbors


	/*
	Update

	int[][]

	returns int[][]

	This method should return the next generation of the cells array.
	*/
	public static int[][] update(int[][] cells) {

		int count = 0;

		int[][] newArray = new int[cells.length][cells[0].length];

		for (int i = 1; i < cells.length-1; i++) {
			for (int j = 1; j < cells[i].length-1; j++) {

				count = neighbors(cells, i, j);

				if (cells[i][j] == 1) {

					if (count == 3 || count == 2) {
						newArray[i][j] = 1;
					}
					else {
						newArray[i][j] = 0;
					}

				}

				else {
					if (count == 3) {
						newArray[i][j] = 1;
					}
					else {
						newArray[i][j] = 0;
					}
				}

			}
		}

		return (newArray);

	} // end update

} // end Class