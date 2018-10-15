import java.util.Scanner;

public class Factorial {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());

        int fact = 1;

        while (num > 0){
            fact = fact * num;
            num--;
        }
        System.out.println(fact);
    }
}
