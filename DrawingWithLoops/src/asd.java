import java.util.Scanner;

public class asd {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 1; row <= n; row++) {
            System.out.print("$");
            for (int col = 0; col < row - 1; col++) {
                System.out.print(" $");
            }
            System.out.println("");
        }

    }
}
