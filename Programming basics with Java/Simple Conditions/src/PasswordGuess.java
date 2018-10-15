import java.util.Scanner;

public class PasswordGuess {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String password = "s3cr3t!P@ssw0rd".toLowerCase();
        String input = scanner.nextLine().toLowerCase();

        if(input.equals(password)){
            System.out.println("Welcome");
        } else {
            System.out.println("Wrong password!");
        }
    }
}
