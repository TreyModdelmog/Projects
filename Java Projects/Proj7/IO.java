/**
 * IO handles all input and output for the
 * four-square encryption algorithm
 *
 * Trey Moddelmog - Section B
 */

import java.util.*;

public class IO {
	private Scanner s;

	/**
	 * IO sets up a new Scanner to System.in
	 */
	public IO() {
		s = new Scanner(System.in);
	}

	/**
	 * firstKey returns the first key from the user
	 *
	 * @return The first key from the user
	 */
	public String firstKey() {
		//COMPLETE THIS TO GET THE FIRST KEY

		System.out.print("Enter the first key: ");

		//UPDATE THIS LINE WHEN DONE
		return removeSpace(s.nextLine().toUpperCase());

	} // end firstKey

	/**
	 * secondKey returns the second key from the user
	 *
	 * @return The second key from the user
	 */
	public String secondKey() {
		//COMPLETE THIS TO GET THE SECOND KEY

		System.out.print("Enter the second key: ");

		//UPDATE THIS LINE WHEN DONE
		return removeSpace(s.nextLine().toUpperCase());

	} // end secondKey

	/**
	 * gets and returns whether the user wants to encrypt or decrypt
	 *
	 * @return 'e' for encryption, and 'd' for decryption
	 */
	public char encryptOrDecrypt() {
		//COMPLETE THIS TO GET THE ENCRYPT OR DECRYPT OPTION

		System.out.print("Enter (e)ncrypt or (d)ecrypt: ");

		//UPDATE THIS LINE WHEN DONE
		return s.nextLine().charAt(0);

	} // end encryptOrDecrypt

	/**
	 * message returns the message from the user
	 *
	 * @param encrypt True if encrypting, false if decrypting
	 *
	 * @return The message from the user
	 */
	public String message(boolean encrypt) {
		//COMPLETE THIS TO GET THE MESSAGE
		if (encrypt == true) 
			System.out.print("Enter the message to encrypt: ");
		else 
			System.out.print("Enter the message to decrypt: ");

		//UPDATE THIS LINE WHEN DONE
		return removeSpace(s.nextLine().toUpperCase());

	} // end message

	/**
	 * printResults prints the encrypted and decrypted messages
	 *
	 * @param msg The resulting message
	 * @param encrypt True if encrypting, false if decrypting
	 */
	public void printResults(String msg, boolean encrypt) {
		//COMPLETE THIS TO PRINT THE RESULTS

		if (encrypt == true) {
			System.out.println("encrypted message: " + msg);
		}
		else {
			System.out.println("decrypted message: " + msg);
		}
		
	} // end printResults

	/**
	 * printError prints an error message
	 *
	 * @param err The error message to print
	 */
	public void printError(String err) {
		//COMPLETE THIS TO PRINT THE ERROR MESSAGE
		System.out.println(err);
		System.exit(0);

	} // end printError

	/**
	 * containsSpace returns whether the given string
	 * contains a space
	 *
	 * @param str The string to search
	 *
	 * @return true if there is a space in str else false
	 */
	private String removeSpace(String str) {

		String temp = "";

		for (int i = 0; i < str.length(); i++) {

			if (str.charAt(i) != ' ') {
				temp += str.charAt(i);
			}
		}

		return temp;

	} // end removeSpace

} // end class