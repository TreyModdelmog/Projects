/*
Trey Moddelmog - Proj6
Lab Section B - Atef Khan
*/

import java.util.*;

public class StudentApp {

	public static void main(String[] args) {
		
		Scanner in = new Scanner(System.in);

		Student[] students = new Student[50];

		// get total points for Labs and Projects
		System.out.print("Enter total points possible for LABS: ");
		double labPoints = Double.parseDouble(in.nextLine());

		System.out.print("Enter total points possible for PROJECTS: ");
		double projectPoints = Double.parseDouble(in.nextLine());

		boolean check = true;
		int pos = 0;
		while (check) {

			System.out.println(); // blank line

			// get student's name and WID
			System.out.print("Enter the student's name (firstname lastname): ");
			String name = in.nextLine(); // name
			System.out.print("Enter the student's WID: ");
			String wID = in.nextLine(); // WID

			// create new student object with name and WID
			students[pos] = new Student(name, wID);

			System.out.println(); // blank line

			// get points for student
			System.out.print("Enter the student's total for all LABS: ");
			double labs = Double.parseDouble(in.nextLine()); // labs
			
			System.out.print("Enter the student's total for all PROJECTS: ");
			double projects = Double.parseDouble(in.nextLine()); // projects
			
			System.out.print("Enter the student's total for CODELAB: ");
			double codelab = Double.parseDouble(in.nextLine()); // codelab
			
			System.out.print("Enter the student's total for the 3 CLASS EXAMS: ");
			double exams = Double.parseDouble(in.nextLine()); // exams
			
			System.out.print("Enter the student's total for the FINAL EXAM: ");
			double finalExam = Double.parseDouble(in.nextLine()); // final
			
			// set totals
			students[pos].setTotals(labPoints, projectPoints);

			// set points
			students[pos].setPoints(labs, projects, codelab, exams, finalExam);

			System.out.println(); // blank line

			System.out.println((pos+1) + " Student(s) entered so far.\nUp to 50 students can be entered.");
			System.out.print("Would you like to enter another student? ('Y' or 'N'): ");
			String response = in.nextLine();
			response.toLowerCase();

			if (response.equals("y"))
				pos++;
			else
				check = false;

		} // end loop for entering students

		pos = 0;
		while (students[pos] != null) {
			
			System.out.println(); // blank line

			System.out.println(students[pos]);

			System.out.println("\tPress enter to display next student...");
			String enter = in.nextLine();

			if (enter.equals("")) {
				pos++;
			}
		
		} // end loop for printing through students array

		System.out.println("All students displayed...");

		System.out.println(); // blank line
		

	} // end main

} // end Class