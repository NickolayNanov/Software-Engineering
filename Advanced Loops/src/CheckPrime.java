import java.util.Scanner;

public class CheckPrime {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());

        boolean isPrime = true;

        if(num < 2){
            System.out.println("Not Prime");
            return;
        }

        for (int i = 2; i <= Math.sqrt(num); i++) {
            if(num % i == 0){
                isPrime = false;
                System.out.println("Not Prime");
                break;
            }
        }

        if(isPrime){
            System.out.println("Prime");
        }


    }
}
