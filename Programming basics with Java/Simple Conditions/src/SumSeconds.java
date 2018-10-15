import java.util.Scanner;

public class SumSeconds {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());
        int c = Integer.parseInt(scanner.nextLine());

        int min = 0;
        int sec = 0;

        int result = a + b + c;

        if (result < 60) {
            sec = result - 60;
            sec = result % 60;
        } else if (result < 120) {
            min++;
            sec = result % 60;
        } else {
            min += 2;
            sec = result % 60;
        }
        if (sec < 10) {
            System.out.printf("%d:0%d", min, sec);
        } else {
            System.out.printf("%d:%d", min, sec);
        }
    }
}
