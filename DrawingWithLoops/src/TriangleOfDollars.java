import java.util.Scanner;

public class TriangleOfDollars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 1; row <= n; row++) {
            for (int col = 1; col < row + 1 ; col++) {
                System.out.print("$ ");
            }
            System.out.println("");
        }
    }
}
