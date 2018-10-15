import com.sun.org.apache.xpath.internal.SourceTree;

import java.util.Scanner;

public class Rectangular2D {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double x1 = Double.parseDouble(scanner.nextLine());
        double y1 = Double.parseDouble(scanner.nextLine());
        double x2 = Double.parseDouble(scanner.nextLine());
        double y2 = Double.parseDouble(scanner.nextLine());

        double a = Double.max(x1, x2) - Double.min(x1, x2);
        double b = Double.max(y1, y2) - Double.min(y1, y2);

        double area = a * b;
        double perimeter = (a + b) * 2;


        System.out.println("Area = " + area);
        System.out.println("Perimeter = " + perimeter );

    }








}
