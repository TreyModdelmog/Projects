/*
Proj8
Trey Moddelmog - Section B
*/

import java.util.*;

public class CourseApp {

	static Scanner s = new Scanner(System.in);
	static ArrayList <Course> courseList = new ArrayList <Course> ();

	public static void main(String[] args) {

		String option;

		// add courses to courseList and print results
		do {

			Course course = createCourse();
			courseList.add(course);

			System.out.print("\nDo you want to enter another course? (Y/N): ");
			option = s.nextLine();

		} while(!option.equalsIgnoreCase("n"));

		printResults(courseList);


		// Use HashMap to index courseList
		HashMap <String, Integer> map = new HashMap <String, Integer> ();

		for (int i = 0; i < courseList.size(); i++) {
			map.put(courseList.get(i).getNumber(), i);
		}

		// take key and get index of object in courseList to remove
		boolean flag = true;
		do {
			
			System.out.print("\nEnter COURSE NUMBER to delete course from list: ");
			String key = checkEmptyString("COURSE NUMBER", s.nextLine());
			int value = (Integer) map.get(key);

			if (map.containsKey(key)) {

				System.out.println("\nCourse removed.");
				courseList.remove(value);
				flag = false;

			}
			else {

				System.out.println("ERROR: Enter valid COURSE NUMBER.");
				flag = true;
			}

		} while(flag == true);


		// add one more course to courseList and print results
		int k = 1;
		do {
			
			Course course = createCourse();
			courseList.add(course);
			k--;

		} while(k > 0);

		printResults(courseList);

	} // end main


	public static Course createCourse() {

		String number, name, firstName, lastName, userName, title, author;
		double price = 0;

		System.out.print("\nEnter course NUMBER: ");
		number = checkEmptyString("NUMBER", s.nextLine());

		System.out.print("Enter course NAME: ");
		name = checkEmptyString("NAME", s.nextLine());

		System.out.print("\nEnter Instructor's FIRST NAME: ");
		firstName = checkEmptyString("Instructor's FIRST NAME", s.nextLine());

		System.out.print("Enter Instructor's LAST NAME: ");
		lastName = checkEmptyString("Instructor's LAST NAME", s.nextLine());

		System.out.print("Enter Instructor's USERNAME: ");
		userName = checkEmptyString("Instructor's USERNAME", s.nextLine());

		System.out.print("\nEnter TITLE of textbook: ");
		title = checkEmptyString("TITLE of textbook", s.nextLine());

		System.out.print("Enter AUTHOR of textbook: ");
		author = checkEmptyString("AUTHOR of textbook", s.nextLine());

		// create instructor
		Instructor instructor = new Instructor(firstName, lastName, userName);

		try {

			System.out.print("Enter PRICE of textbook: ");
			price = Double.parseDouble(s.nextLine());

		}
		catch (NumberFormatException nf) {

			System.out.println("\nERROR: cannot enter a string or empty string in for price.\n");

			price = 0;
			do {

				System.out.print("Enter a vaild number for price of textbook: ");
				price = Double.parseDouble(s.nextLine());

			} while(price <= 0); 

		}

		// create textbook
		TextBook textbook = new TextBook(title, author, price);

		// create course
		Course course = new Course(number, name, instructor, textbook);
		return course;
	
	} // end createCourse


	public static String checkEmptyString(String varible, String str) {

		try {

			if (str.equals("")) {
				throw new Exception();
			}
			
			return str;

		}

		catch(Exception e) {

			System.out.println("\nERROR: cannot have an empty string.");

			System.out.print("\nEnter vaild string for " + varible + ": ");
			str = s.nextLine();
			return checkEmptyString(varible, str);

		}

	} // end checkEmptyString


	public static void printResults(ArrayList <Course> list) {

		System.out.print("\nHit ENTER to go through list.");

		Iterator <Course> it = list.iterator();
		
		while (it.hasNext()) {
			
			s.nextLine();
			System.out.println(it.next());

		}

	} // end printResults


} // end class