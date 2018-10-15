import java.util.Scanner;

public class AreaOFFigures {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String figure = scanner.nextLine();

        if(figure.equals("square")){
            double a = Double.parseDouble(scanner.nextLine());
            System.out.printf("%.3f", a * a);
        }else if(figure.equals("rectangle")){
            double sideA = Double.parseDouble(scanner.nextLine());
            double sideB = Double.parseDouble(scanner.nextLine());
            System.out.printf("%.3f", sideA * sideB);
        }else if(figure.equals("circle")){
            double r = Double.parseDouble(scanner.nextLine());
            System.out.printf("%.3f", Math.PI * r * r);
        }else if(figure.equals("triangle")){
            double Side = Double.parseDouble(scanner.nextLine());
            double H = Double.parseDouble(scanner.nextLine());
            System.out.printf("%.3f", Side * H / 2);
        }
    }
}
