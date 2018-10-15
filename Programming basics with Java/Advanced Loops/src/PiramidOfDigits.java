import java.util.Scanner;

public class PiramidOfDigits {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int cuurentNumber = 1;

        int sum = 1;
        for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= row; col++) {
                if(col > 1) System.out.print(" ");
                System.out.print(cuurentNumber);
                cuurentNumber++;
                if(cuurentNumber > n) {break;}
            }
            System.out.println();
            if(cuurentNumber > n){
                break;
            }
        }

    }
}
