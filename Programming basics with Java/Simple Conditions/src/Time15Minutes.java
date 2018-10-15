import java.util.Scanner;

public class Time15Minutes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hour = Integer.parseInt(scanner.nextLine());
        int mins = Integer.parseInt(scanner.nextLine());

        int minsAfter15 = mins + 15;

        if(minsAfter15 > 59){
            hour += 1;
        }

    }
}
