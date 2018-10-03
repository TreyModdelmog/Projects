/************************************************************************ 
* Proj2.java
* Trey Moddelmog / Lab Section B - Thursday 6:00PM - Atef Khan
* This program takes in your education, age, current year, and wanted retirement age
* and calulates salary accumulated over years worked and compares it to higher and
* lower education levels.
*************************************************************************/
import java.util.*;
import java.text.DecimalFormat;

public class Proj2 {
	public static void main(String[] args) {

	// Constants and variables
	final int NONE_SALARY = 52 * 493;
	final int HIGH_SCHOOL_SALARY = 52 * 678; 	
	final int BACHELOR_SALARY = 52 * 1137;
	final int MASTER_SALARY = 52 * 1341;
	final int DOCTOR_SALARY = 52 * 1623 ;

	int input, year, age, retireAge, workingYears, retireYear, 
		couldMakeNone, couldMakeHS, couldMakeBach, couldMakeMast, couldMakeDoctor, 
		moreThanNone, moreThanHS, moreThanBach, moreThanMast;

	int salary = 0,
		totalEarn = 0;

	String degree = "";
	
	// Scanner and decimal format
	Scanner scan = new Scanner(System.in);
	DecimalFormat df = new DecimalFormat ("$#,###,##0");

	System.out.println(); // Blank line

	System.out.println("\t1 = No Degree\n\t2 = High School Degree\n\t3 = Bachelor's Degree\n\t4 = Master's Degree\n\t5 = Doctorate Degree");

	System.out.println(); // Blank line

	// Loop for degree number input
	do {
	System.out.print("Enter the number corresponds to your degree: ");
	input = Integer.parseInt(scan.nextLine());

	if ((input < 1) || (input > 6)) {
		System.out.println(); // Blank line
		System.out.println("You entered and invaild menu choice.\nPlease re-run the programd enter n a vaild choice.");
		System.out.println(); // Blank line
	}

	} while ((input < 1) || (input > 6));

	System.out.println(); // Blank line

	// Input for year, age, and retirement age
	System.out.print("Enter the current year: ");
	year = Integer.parseInt(scan.nextLine());
	
	System.out.print("Enter your current age: ");
	age = Integer.parseInt(scan.nextLine());
	
	System.out.print("Enter planned age of retirement: ");
	retireAge = Integer.parseInt(scan.nextLine());

	System.out.println(); // Blank line

	//
	retireYear = year + (retireAge - age);
	workingYears = retireAge - age;

	switch (input){

		case 1: degree = "Your Education";
				salary = NONE_SALARY;
				break;

		case 2:	degree = "High School Degree";
				salary = HIGH_SCHOOL_SALARY;
				break;

		case 3:	degree = "Bachelor's Degree";
				salary = BACHELOR_SALARY;
				break;

		case 4:	degree = "Master's Degree";
				salary = MASTER_SALARY;
				break;

		case 5:	degree = "Doctor's Degree";
				salary = DOCTOR_SALARY;
				break;

	} // End Switch

	totalEarn = workingYears * salary;
	
	moreThanNone = totalEarn - (NONE_SALARY * workingYears);
	moreThanHS = totalEarn - (HIGH_SCHOOL_SALARY * workingYears);
	moreThanBach = totalEarn - (BACHELOR_SALARY * workingYears);
	moreThanMast = totalEarn - (DOCTOR_SALARY * workingYears);

	couldMakeHS = (HIGH_SCHOOL_SALARY * workingYears) - totalEarn;
	couldMakeBach = (BACHELOR_SALARY * workingYears) - totalEarn;
	couldMakeMast = (MASTER_SALARY * workingYears) - totalEarn;
	couldMakeDoctor = (DOCTOR_SALARY * workingYears) - totalEarn;

	System.out.println("Based on current statistics and your education:");
	System.out.println("Your annual salary will be " + df.format(salary));
	System.out.println("Retiring at age " + retireAge + " in " + retireYear + " you will make a total of " + df.format(totalEarn));

	if (input == 1) {
		System.out.println("With a High school degree, you can earn " + df.format(couldMakeHS) + " than if you just had no degree.");
		System.out.println("With a Bachelor's degree, you can earn " + df.format(couldMakeBach) + " than if you just had no degree.");
		System.out.println("With a Master's degree, you can earn " + df.format(couldMakeMast) + " than if you just had no degree.");
		System.out.println("With a Doctor's degree, you can earn " + df.format(couldMakeDoctor) + " than if you just had no degree.");
	}

	if (input == 2) {
		System.out.println("That is " + df.format(moreThanNone) + " more than if you only had no degree.");
		System.out.println("With a Bachelor's degree, you can earn " + df.format(couldMakeBach) + " than if you just had a High school degree.");
		System.out.println("With a Master's degree, you can earn " + df.format(couldMakeMast) + " than if you just had a High school degree.");
		System.out.println("With a Doctor's degree, you can earn " + df.format(couldMakeDoctor) + " than if you just had a High school degree.");
	}

	if (input == 3) {
		System.out.println("That is " + df.format(moreThanHS) + " more than if you only had a High school degree.");
		System.out.println("That is " + df.format(moreThanNone) + " more than if you only had no degree.");
		System.out.println("With a Master's degree, you can earn " + df.format(couldMakeMast) + " than if you just had a Bachelor's degree.");
		System.out.println("With a Doctor's degree, you can earn " + df.format(couldMakeDoctor) + " than if you just had a Bachelor's degree.");
	}

	if (input == 4) {
		System.out.println("That is " + df.format(moreThanBach) + " more than if you only had a Bachelor's degree.");
		System.out.println("That is " + df.format(moreThanHS) + " more than if you only had a High school degree.");
		System.out.println("That is " + df.format(moreThanNone) + " more than if you only had no degree.");
		System.out.println("With a Doctor's degree, you can earn " + df.format(couldMakeDoctor) + " than if you just had a Master's degree.");
	}

	if (input == 5) {
		System.out.println("That is " + df.format(moreThanMast) + " more than if you only had a Master's degree.");
		System.out.println("That is " + df.format(moreThanBach) + " more than if you only had a Bachelor's degree.");
		System.out.println("That is " + df.format(moreThanHS) + " more than if you only had a High school degree.");
		System.out.println("That is " + df.format(moreThanNone) + " more than if you only had no degree.");

	}

	System.out.println(); // Blank line

	} // End of main
} // End of Class