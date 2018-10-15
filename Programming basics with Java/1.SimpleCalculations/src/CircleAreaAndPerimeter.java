import java.util.Scanner;

public class CircleAreaAndPerimeter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Double r = Double.parseDouble(scanner.nextLine());
        double Area = Math.PI * r * r;
        double Perimeter = 2 * Math.PI * r;

        System.out.println(Area);
        System.out.println(Perimeter);

    }
}
