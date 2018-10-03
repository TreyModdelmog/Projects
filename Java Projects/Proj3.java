import java.util.*;
import java.text.DecimalFormat;

public class Proj3 {
	public static void main(String[] args) {

		// variables
		double x1 = 0,
		x2 =  0,
		y1 = 0,
		y2 = 0,
		m, b;

		char letter = 'a';

		boolean check = false;

		// scanner and df		
		Scanner scan = new Scanner(System.in);
		DecimalFormat df = new DecimalFormat("0.00");

		// start of program
		do {
			
			// validate undefined slope and same point
			do {

				// x1
				do {
					System.out.print("Enter x1: ");
					x1 = Double.parseDouble(scan.nextLine());

					if (x1 < 0 || x1 > 9) {
						System.out.println("Enter an X coordinate between 0-9.");
					}
				} while (x1 < 0 || x1 > 9);

				// y1
				do {
					System.out.print("Enter y1: ");
					y1 = Double.parseDouble(scan.nextLine());
					
					if (y1 < 0 || y1 > 9) {
						System.out.println("Enter an Y coordinate between 0-9.");
					}
				} while (y1 < 0 || y1 > 9);

				// x2
				do {
					System.out.print("Enter x2: ");
					x2 = Double.parseDouble(scan.nextLine());
					
					if (x2 < 0 || x2 > 9) {
						System.out.println("Enter an X coordinate between 0-9.");
					}
				} while (x2 < 0 || x2 > 9);

				// y2
				do {
					System.out.print("Enter y2: ");
					y2 = Double.parseDouble(scan.nextLine());

					if (y2 < 0 || y2 > 9) {
						System.out.println("Enter an Y coordinate between 0-9.");
					}
				} while (y2 < 0 || y2 > 9);


				// same points
				if (x1 == x2 && y1 == y2) {
					System.out.println("Points have to be different.");
				}
				// undefined slope
				else if (x1 - x2 == 0) {
					System.out.println("Can't enter an undefined slope.");
				}
				else {
					check = true;
				}

			} while (check == false);
			

			System.out.println(); // blank line

			// find slope, y-intercept
			m = (y2 - y1) / (x2 - x1);
			b = y1 - (m * x1);

			// print y = mx + b
			System.out.println("y = " + df.format(m) + "x + " + df.format(b));

			System.out.println(); // blank line


			// Print Y axis
			for (int i = 9; i > 0; i--) {
				
				if ((y1 == i && x1 == 0) || (y2 == i && x2 == 0)) {
					System.out.print(i + "*");	
				}

				else {
					System.out.print(i + "|");
				}

				for (int j = 1; j < 10; j++) {

					if ((y1 == i && x1 == j) || (y2 == i && x2 == j)) {
						System.out.print("*");	
					}

					else {
						System.out.print(" ");
					}
				
				} // end inner for
			
			System.out.println();
			
			} // end outer for


			// Print X axis
			System.out.print("0 ");

			for (int k = 0; k <= 9; k++) {

				if ((x1 == k && y1 == 0) || (x2 == k && y2 == 0)) {
					System.out.print("*");
				} 

				else {
					System.out.print("-");
				}
			} // end for

			System.out.println();

			System.out.print(" ");

			for (int n = 0; n < 10; n++) {
				System.out.print(n);
			}

			System.out.println();

			// check loop
			System.out.print("Run program again? (y/n)");
			letter = scan.nextLine().charAt(0);
			System.out.println(); // blank line

		} while (letter != 'n');
	
	} // end main
} // end Class