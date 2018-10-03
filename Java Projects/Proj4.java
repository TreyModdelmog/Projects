/*
Trey Moddelmog - Proj4
Lab section B - Atef Khan
Poker game that generates random cards and stores them in arrays, then finds the hand value by
comparing the values in the arrays with if statements
*/

import java.util.*;

public class Proj4 {
	public static void main(String[] args) {

		// Royal Flush 
		  // int[] value = {10, 12, 14, 13, 11}; 
		  // int[] suit = {1,1,1,1,1};

		// Straight Flush 
		  // int[] value = {9, 7, 8, 6, 5}; 
		  // int[] suit = {1,1,1,1,1};

		// 4 of kind 
		  // int[] value = {9, 7, 9, 9, 9}; 
		  // int[] suit = {1,2,3,4,1};

		// Full House 
		  // int[] value = {9, 7, 9, 7, 9}; 
		  // int[] suit = {1,2,3,4,1};

		// Flush 
		  // int[] value = {9, 9, 8, 6, 5}; 
		  // int[] suit = {1,1,1,1,1};

		// Straight 
		  // int[] value = {9, 7, 8, 6, 5}; 
		  // int[] suit = {1,2,4,3,1};

		// 3 of kind 
		  // int[] value = {9, 7, 9, 2, 9}; 
		  // int[] suit = {1,2,3,4,1};

		// Two Pair 
		  // int[] value = {9, 7, 9, 2, 7}; 
		  // int[] suit = {1,2,3,4,1};

		// One Pair 
		  // int[] value = {9, 7, 8, 2, 7}; 
		  // int[] suit = {1,2,3,4,1};

		// High Card (Ace) 
		  // int[] value = {9, 7, 8, 14, 11}; 
		  // int[] suit = {1,2,3,4,1};
		
		// arrays
		int [] value = new int [5];
		int [] suit = new int [5];

		// variables and objectss
		Random r = new Random();
		Scanner s = new Scanner(System.in);
		boolean check = false, input = false;
		String card = "";
		int total = 0;
		char answer = 'a';

		System.out.println("\n** Welcome to the 2017 Las Vegas Poker Festival! ** \n(Application developed by Trey Moddelmog)");

		do {
			System.out.println("\nShuffling cards...\nDealing the cards...\n");

	// Dealing Cards

			for (int i = 0; i < value.length; i++) {
				while (check == false) {
					value[i] = r.nextInt(13) + 2;
					suit[i] = r.nextInt(4) + 1;
					
					check = true;

					for (int j = 0; j < i; j++) {
						if (value[i] == value[j] && suit[i] == suit[j]) {
							check = false;
						} // end if
					} // end inner for
				} // end while
				
				check = false;

			} // end outer for

			Arrays.sort(value); // sort

	// Printing out hand
			// Spades = 1, Hearts = 2, Clubs = 3, Diamonds = 4

			System.out.println("Here are your five cards...");

			for (int i = 0; i < value.length; i++) {
					switch (value[i]) {
						case 11: card = "Jack";
							break;
						case 12: card = "Queen";
							break;
						case 13: card = "King";
							break;
						case 14: card = "Ace";
							break;
						default:
							card = Integer.toString(value[i]);
						}

					if (suit[i] == 1) {
						System.out.println("\t" + card + " of Spades");
					}
					else if (suit[i] == 2) {
						System.out.println("\t" + card + " of Hearts");
					}
					else if (suit[i] == 3) {
						System.out.println("\t" + card + " of Clubs");
					}
					else {
						System.out.println("\t" + card + " of Diamonds");
					}
			}
			System.out.println(); // blank

			// find total for royal flush
			for (int i = 0; i < value.length; i++) {
				total += value[i];
			}

	// Check to find hand

			System.out.print("You were dealt a ");

			if (suit[0] == suit[1] && suit[1] == suit[2]
				&& suit[2] == suit[3] && suit[3] == suit[4]) {
				// Royal flush
				if (total == 60) {
					System.out.print("Royal flush\n");
				}
				// Straight flush
				else if (value[0] + 1 == value[1]
						&& value[1] + 1 == value[2]
						&& value[2] + 1 == value[3]
						&& value[3] + 1 == value[4]) {
					System.out.print("Straight flush\n");
				}
				// Flush
				else {
					System.out.print("Flush\n");
				}
			}

			// Full house
			else if ((value[0] == value[1]
					&& value[2] == value[3]
					&& value[3] == value[4])
					|| (value[0] == value[1]
					&& value[1] == value[2]
					&& value[3] == value[4])) {
				System.out.print("Full house\n");
			}

			// Straight
			else if (value[0] + 1 == value[1]
					&& value[1] + 1 == value[2]
					&& value[2] + 1 == value[3]
					&& value[3] + 1 == value[4]){
				System.out.print("Straight\n");
			}

			// Four of a kind
			else if ((value[0] == value[1]
					&& value[1] == value[2]
					&& value[2] == value[3])
					|| (value[1] == value[2]
					&& value[2] == value[3]
					&& value[3] == value[4])) {
				System.out.print("Four of a kind\n");
			}

			// Three of a kind
			else if ((value[0] == value[1] && value[1] == value[2])
					||(value[1] == value[2] && value[2] == value[3])
					||(value[2] == value[3] && value[3] == value[4])) {
				System.out.print("Three of a kind\n");
			}

			// Two pair
			else if ((value[0] == value[1] && value[2] == value[3])
					|| (value[0] == value[1] && value[3] == value[4])
					|| (value[1] == value[2] && value[3] == value[4])) {
				System.out.print("Two pair\n");
			}

			// Pair
			else if ((value[0] == value[1]) || (value[1] == value[2])
					|| (value[2] == value[3]) || (value[3] == value[4])) {
				System.out.print("Pair\n");
			}

			// High card
			else {
				System.out.print("High card of a(n) " + card);
				System.out.println(); // blank
			}

			System.out.println(); // blank

			do {
				System.out.print("Play Again (Y or N)? ");
				answer = s.nextLine().charAt(0);
				Character.toLowerCase(answer);
				if (answer == 'y' || answer == 'n') {
					input = true;
				}
				else {
					System.out.println("Please enter a ‘Y’ or ‘N’ only");
					input = false;
				}
			} while (input == false);

		} while (answer == 'y' );

	} // end main	
} // end Class