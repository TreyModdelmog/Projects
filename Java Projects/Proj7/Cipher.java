/**
 * Cipher handles the encryption and decryption of
 * messages according to the four-square cipher algorithm.
 *
 * Trey Moddelmog - Section B
 */

public class Cipher {
	private Square plain1;
	private Square plain2;
	private Square cipher1;
	private Square cipher2;

	/**
	 * Cipher creates the four squares based on
	 * two keys for the four-square cipher algorithm.
	 *
	 * @param key1 The first key (no Q's)
	 * @param key2 The second key (no Q's)
	 */
	public Cipher(String key1, String key2) {
		//COMPLETE THIS CONSTRUCTOR
		//CREATE plain1, plain2, cipher1, and cipher2

		plain1 = new Square();
		plain2 = new Square();

		cipher1 = new Square(key1);
		cipher2 = new Square(key2);

	} // end 2 arg constructor

	/**
	 * encrypt returns the encrypted message using the
	 * four-square cipher algorithm
	 *
	 * @param message The message to encrypt
	 *
	 * @return The encrypted message
	 */
	public String encrypt(String message) {
		//COMPLETE THIS METHOD

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < message.length(); i += 2) {

			int[] pos1 = plain1.getPos(message.charAt(i));
			int[] pos2 = plain2.getPos(message.charAt(i+1));

			if (pos1[0] != -1 && pos2[1] != -1) {

				sb.append(cipher1.getChar(pos1[0], pos2[1]));
			}

			if (pos2[0] != -1 && pos1[1] != -1) {

				sb.append(cipher2.getChar(pos2[0], pos1[1]));

			}

		}

		//RETURN THE ENCRYPTED message
		return sb.toString();

	} // end encrypt

	/**
	 * decrypt returns the decrypted message using the
	 * four-square cipher algorithm
 	 *
	 * @param message The message to decrypt
	 *
	 * @return The decrypted message
	 */
	public String decrypt(String message) {
		//COMPLETE THIS METHOD

		StringBuilder sb = new StringBuilder();

		for (int i = 0; i < message.length(); i += 2) {

			int[] pos1 = cipher1.getPos(message.charAt(i));
			int[] pos2 = cipher2.getPos(message.charAt(i+1));

			if (pos1[0] != -1 && pos2[1] != -1) {

				sb.append(plain1.getChar(pos1[0], pos2[1]));

			}

			if (pos2[0] != -1 && pos1[1] != -1) {

				sb.append(plain2.getChar(pos2[0], pos1[1]));

			}

		}		

		//RETURN THE DECRYPTED message
		return sb.toString();

	} // end decrypt
} // end class