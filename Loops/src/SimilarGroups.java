import java.text.DecimalFormat;
import java.util.Scanner;

public class SimilarGroups {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numbersToRead = Integer.parseInt(scanner.nextLine());
       double oddSum = 0;
       double evenSum = 0;
       double evenMin = Double.MAX_VALUE;
       double evenMax = (double)Integer.MIN_VALUE;
       double oddMin = Double.MAX_VALUE;
       double oddMax = (double)Integer.MIN_VALUE;

        for (int i = 1; i <= numbersToRead; i++) {
            double number = Double.parseDouble(scanner.nextLine());

            if(i % 2 == 0){
                evenSum += number;
                if(number > evenMax){
                    evenMax = number;
                }
                if(number < evenMin){
                    evenMin = number;
                }
            }else {
                oddSum += number;
                if(number > oddMax){
                    oddMax = number;
                }
                if(number < oddMin){
                    oddMin = number;
                }
            }
        }

        DecimalFormat df = new DecimalFormat("#.#############");
        System.out.printf("OddSum = %s%n", df.format(oddSum));
        System.out.printf("OddMin = %s%n", df.format(oddMin));
        System.out.printf("OddMax = %s%n", df.format(oddMax));
        System.out.printf("EvenSum = %s%n", df.format(evenSum));
        System.out.printf("EvenMin = %s%n", df.format(evenMin));
        System.out.printf("EvenMax = %s%n", df.format(evenMax));

    }
}
