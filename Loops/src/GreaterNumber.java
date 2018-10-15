import java.util.Scanner;

public class GreaterNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numbersToRead = Integer.parseInt(scanner.nextLine());
        int max = Integer.MIN_VALUE;

        for (int i = 0; i < numbersToRead ; i++) {
            int number = Integer.parseInt(scanner.nextLine());

            if(number > max){
                max = number;
            }
        }
        System.out.println(max);
    }
}
