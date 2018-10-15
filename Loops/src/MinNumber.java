import java.util.Scanner;

public class MinNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int numbersToRead = Integer.parseInt(scanner.nextLine());
        int min = Integer.MAX_VALUE;

        for (int i = 0; i < numbersToRead ; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            if(number < min){
                min = number;
            }
        }
        System.out.println(min);
    }
}
