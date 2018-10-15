import java.math.MathContext;
import java.util.Scanner;

public class LeftRighSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numbersToRead = Integer.parseInt(scanner.nextLine());
        int sum1 = 0;
        int sum2 = 0;

        for (int i = 0; i < numbersToRead; i++) {
            int num = Integer.parseInt(scanner.nextLine());
            sum1 += num;
        }

        for (int i = 0; i < numbersToRead ; i++) {
            int num = Integer.parseInt(scanner.nextLine());
            sum2 += num;
        }
        if(sum1 == sum2){
            System.out.println("Yes, sum = " + sum1);
        }else {
            System.out.println("no diff = " + Math.abs(sum1 - sum2));
        }
    }
}
