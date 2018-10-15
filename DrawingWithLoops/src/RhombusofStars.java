import java.util.Scanner;

public class RhombusofStars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 1; row <= n ; row++) {
            for (int col = 1; col <= n - row ; col++) {
                System.out.print(" ");
            }
            System.out.print("*");
            for (int col = 1; col <= row -1 ; col++) {
                System.out.print(" *");
            }
            System.out.println("");
        }

        for (int row = n-1; row > 0 ; row--) {
            for (int col = 1; col <= n - row ; col++) {
                System.out.print(" ");
            }
            System.out.print("*");
            for (int col = row-2; col >= 0 ; col--) {
                System.out.print(" *");
            }
            System.out.println("");
        }



    }
}
