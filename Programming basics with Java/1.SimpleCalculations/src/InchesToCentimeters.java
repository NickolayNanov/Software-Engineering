import java.util.Scanner;
public class InchesToCentimeters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Double inches = Double.parseDouble(scanner.nextLine());
        Double centemeters = inches * 2.54;

        System.out.println(centemeters);
    }
}
