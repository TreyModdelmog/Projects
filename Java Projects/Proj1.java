/************************************************************************ 
* Proj1.java
* Trey Moddelmog / Lab Section B - Thursday 6:00PM - Atef Khan
*
* This program takes in grade scores and calculates the overall percentage.
* And takes in a number of people for a party, the finds how many pizzas are 
* needed and how many slices will be left Over.
*************************************************************************/

import java.util.Scanner;
import java.text.DecimalFormat;

public class Proj1 
{ public static void main(String[] args) 
	{
		System.out.println(""); // Blank line

		// Constants & Variables
		final double MAXPOINTS = 290;
		double proj1score, proj2score, proj3score, midtermScore, finalExamScore, overallGrade;

		Scanner scan = new Scanner (System.in);

		// Score inputs
		System.out.print("Enter in Project score #1 (0-30): ");
		proj1score = Double.parseDouble(scan.nextLine());

		System.out.print("Enter in Project score #2 (0-30): ");
		proj2score = Double.parseDouble(scan.nextLine());

		System.out.print("Enter in Project score #3 (0-30): ");
		proj3score = Double.parseDouble(scan.nextLine());

		System.out.println(""); // Blank line

		// Exam inputs
		System.out.print("Enter the midterm exam score (0-100): ");
		midtermScore = Double.parseDouble(scan.nextLine());

		System.out.print("Enter the final exam score (0-100): ");
		finalExamScore = Double.parseDouble(scan.nextLine());

		// Calculating overall grade
		overallGrade = (proj1score + proj2score + proj3score + midtermScore + finalExamScore) / MAXPOINTS;

		// Format and print
		DecimalFormat df = new DecimalFormat ("#00.00%");
		System.out.println("Overall grade percentage: " + df.format(overallGrade));

		System.out.println(""); // Blank line

		//------------------------------------------------------------------------------------------------

		// Constants & Variables
		final int MAXSLICES = 20;
		final int SLICES_PER_PERSON = 2;
		int numberPeople, numberSlices, slicesLeftOver, numberPizza;

		// Number of people input
		System.out.print("What is the number of people expected at the pizza party? ");
		numberPeople = Integer.parseInt(scan.nextLine());

		// Calculate number of pizzas and slices left over
		numberSlices = SLICES_PER_PERSON * numberPeople;
		numberPizza = (numberSlices - 1) / MAXSLICES;
		numberPizza++;
		slicesLeftOver = (numberPizza * MAXSLICES) - (numberPeople * SLICES_PER_PERSON);

		System.out.println(""); // Blank line

		// Print
		System.out.println("For " + numberPeople + " people, that would be " + (numberPizza)+ " pizza(s) with each having " + SLICES_PER_PERSON + " slices each.");
		System.out.println("There would be " + slicesLeftOver + " slice(s) leftover.");

		System.out.println(""); // Blank line


	} // End main
} // End Class