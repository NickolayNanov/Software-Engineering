import java.util.Scanner;

public class TrapeziodArea {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Double a = Double.parseDouble(scanner.nextLine());
        Double b = Double.parseDouble(scanner.nextLine());
        Double h = Double.parseDouble(scanner.nextLine());


        System.out.println((a + b) * h / 2);
    }
}
