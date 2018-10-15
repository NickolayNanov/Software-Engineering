import java.util.Scanner;

public class Cinema {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String type = scanner.nextLine();
        int rows = Integer.parseInt(scanner.nextLine());
        int collons = Integer.parseInt(scanner.nextLine());

        int hallSeats = rows * collons;

        double Premiere = 12.00;
        double Normal = 7.50;
        double Discount = 5.00;

        if(type.equals("Premiere")){
            System.out.printf("%.2f leva", hallSeats * Premiere);
        }else if(type.equals("Normal")){
            System.out.printf("%.2f leva", hallSeats * Normal);
        }else if(type.equals("Discount")){
            System.out.printf("%.2f leva", hallSeats * Discount);
        }
    }
}
