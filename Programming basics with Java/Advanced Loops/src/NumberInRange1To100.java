import java.util.Scanner;

public class NumberInRange1To100 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        while (n < 1 || n > 100){
            System.out.println("Invalid number!");
            n = Integer.parseInt(scanner.nextLine());
        }
        System.out.print("The number is: " + n);
    }
}
