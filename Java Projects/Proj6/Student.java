/*
Trey Moddelmog - Proj6
Lab Section B - Atef Khan
*/

public class Student {

// properties
	private String name;
	private String wID;
	private double labs;
	private double projects;
	private double codelab;
	private double exams;
	private	double finalExam;
	private double overall;

	private final double CODELAB_TOTAL = 225;
	private final double EXAMS_TOTAL = 150;
	private final double FINAL_TOTAL = 100;
	private double labsTotal;
	private double projectsTotal;

	private final double LAB_WGHT = 0.10;
	private final double PROJ_WGHT = 0.15;
	private final double CODELAB_WGHT = 0.10;
	private final double EXAM_WGHT = 0.45;
	private final double FINAL_WGHT = 0.20;

// constructors
	public Student() {

		this.name = "no name";
		this.wID = "no WID";
		this.labs = 0;
		this.projects = 0;
		this.codelab = 0;
		this.exams = 0;
		this.finalExam = 0;		

	}

	public Student(String name, String wID) {
		this.name = name;
		this.wID = wID;
	}

// methods
	
	/*
	setTotal

	double lab, double projects

	returns nothing

	takes in total points for labs and projects then
	sets them to LAB_TOTAL and PROJECTS_TOTAL.
	*/
	public void setTotals(double labs, double projects) {
		labsTotal = labs;
		projectsTotal = projects;
	}
	
	/*
	setPoints

	double lab, double projects, double codelab, double exams, double finalExam

	returns nothing

	takes in points for all of a students assignments then
	sets them to the variables.
	*/
	public void setPoints(double labs, double projects, double codelab, double exams, double finalExam) {
		this.labs = labs;
		this.projects = projects;
		this.codelab = codelab;
		this.exams = exams;
		this.finalExam = finalExam;
	}

	/*
	calcOverall

	no arguements

	returns nothing

	calculates the overall grade for a student
	*/
	private void calcOverall() {
		
		double total = CODELAB_TOTAL + EXAMS_TOTAL + FINAL_TOTAL + labsTotal + projectsTotal;

		// adjusted points possible

		double labPtsEarned = (labs / labsTotal) * (total * LAB_WGHT);
		double projPtsEarned = (projects / projectsTotal) * (total * PROJ_WGHT);
		double codeLabPtsEarned = (codelab / CODELAB_TOTAL) * (total * CODELAB_WGHT);
		double examsPtsEarned = (exams / EXAMS_TOTAL) * (total * EXAM_WGHT);
		double finalPtsEarned = (finalExam / FINAL_TOTAL) * (total * FINAL_WGHT);

		// adjusted total
		double adjTotal = labPtsEarned + projPtsEarned + codeLabPtsEarned + examsPtsEarned + finalPtsEarned;

		// overall grade
		overall = (adjTotal / total) * 100;
		overall = Math.round(overall*10.0)/10.0;

	}

	/*
	toString

	no arguements

	returns String

	builds string of student name grade % and letter grade
	*/
	public String toString() {

		if (!name.equals("no name")) {
			String[] parts = name.split(" ");
			name = parts[1] + ", " + parts[0];
		}

		String letterGrade;

		calcOverall();

		if (overall >= 89.5)
			letterGrade = "A";
		else if (overall >= 79.5)
			letterGrade = "B";
		else if (overall >= 68.5)
			letterGrade = "C";
		else if (overall > 58.5)
			letterGrade = "D";
		else
			letterGrade = "F";

		return ("Student Name: " + name + "\nWID: " + wID + "\nOverall %: " + overall + ("%") + "\nFinal Grade: " + letterGrade);

	}
}