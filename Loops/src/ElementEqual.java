import java.util.Scanner;

public class ElementEqual {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numbersToRead = Integer.parseInt(scanner.nextLine());

        int max = Integer.MIN_VALUE;
        int sum = 0;

        for (int i = 0; i < numbersToRead; i++) {
            int num = Integer.parseInt(scanner.nextLine());
            sum += num;
            if (num > max){
                max = num;
            }
        }

        if(sum - max == max){
            System.out.printf("Yes Sum = %d", max);
        }else {
            int result = Math.abs(2 * max - sum);
            System.out.printf("No Diff = %d", result);
        }


    }
}
